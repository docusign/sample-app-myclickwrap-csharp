import React from "react";
import { Covid19Waiver } from "../Covid19Waiver/index";
import { useTranslation } from "react-i18next";

export const Home = () => {
  const { t } = useTranslation("Home");
  return (
    <>
      <div className="myclick-header text-center">
        <h1 className="h1">{t("Title")}</h1>
        <p className="lead">{t("Description")}</p>
      </div>
      <Covid19Waiver />
    </>
  );
};
