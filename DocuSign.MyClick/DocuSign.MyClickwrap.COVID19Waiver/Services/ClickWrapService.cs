﻿using System;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using DocuSign.MyClickwrap.COVID19Waiver.Domain;
using DocuSign.MyClickwrap.COVID19Waiver.Exceptions;
using Newtonsoft.Json;
using RestSharp;

namespace DocuSign.MyClickwrap.COVID19Waiver.Services
{
    public class ClickWrapService : IClickWrapService
    {
        private const string _clickWrapName = "Covid19Waiver";

        private readonly IDocuSignApiProvider _docuSignApiProvider;

        public ClickWrapService(IDocuSignApiProvider docuSignApiProvider)
        {
            _docuSignApiProvider = docuSignApiProvider;
        }

        public ClickWrap GetClickWrap(string accountId)
        {
            if (accountId == null)
            {
                throw new ArgumentNullException(nameof(accountId));
            }

            var request = new RestRequest($"/accounts/{accountId}/clickwraps?name={_clickWrapName}", DataFormat.Json);

            IRestResponse response = _docuSignApiProvider.DocuSignClickApiRestClient.Get(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        throw new AuthenticationException(
                            "DocuSign Click API responded with status code Unauthorized");
                    default:
                        throw new InvalidOperationException(
                            $"DocuSign Click API responded with status code {response.StatusCode}");
                }
            }

            var clickwrapsResponse =
                JsonConvert.DeserializeObject<ClickWrapsResponse>(response.Content);

            ClickWrap clickWrap = clickwrapsResponse
                .Clickwraps
                .FirstOrDefault(x => x.ClickwrapName == _clickWrapName);

            if (clickWrap == null)
            {
                throw new ClickWrapNotFoundException(_clickWrapName);
            }

            return clickWrap;
        }
    }
}