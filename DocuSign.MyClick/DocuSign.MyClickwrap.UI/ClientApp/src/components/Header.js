import React from "react";
import { Link, NavLink } from "react-router-dom";
import svg from "../assets/img/logo.svg";
import { useTranslation } from "react-i18next";

export const Header = () => {
    const { t } = useTranslation("Header");
    return (
        <nav className="navbar navbar-expand-md navbar-light">
            <Link className="navbar-brand" to="/">
                <img className="d-inline-block align-top" src={svg} alt={t("ApplicationName")} />
                <strong>{t("ApplicationName")}</strong>
            </Link>
            <div className="collapse navbar-collapse" id="navbarNav">
                <ul className="navbar-nav ml-auto">
                    <li className="nav-item">
                        <a
                            className="nav-link  nav-link-external"
                            href={t("GitHubLink.URL")}
                            target="_blank"
                            rel="noopener noreferrer"
                        >
                            {t("GitHubLink.Title")}
                            <span className="sr-only">(current)</span>
                        </a>
                    </li>
                </ul>
            </div>
        </nav>
    );
};
