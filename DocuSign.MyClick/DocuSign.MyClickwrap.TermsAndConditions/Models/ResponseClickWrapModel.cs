﻿using DocuSign.MyClickwrap.TermsAndConditions.Domain;

namespace DocuSign.MyClickwrap.TermsAndConditions.Models
{
    public class ResponseClickWrapModel
    {
        public string DocuSignBaseUrl { get; set; }

        public ClickWrap ClickWrap { get; set; }

        public string AccountId { get; set; }

        public string UserId { get; set; }
    }
}