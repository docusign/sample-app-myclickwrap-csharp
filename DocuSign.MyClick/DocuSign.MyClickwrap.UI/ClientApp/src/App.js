import React, { Suspense } from "react";
import { Route, Switch } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./features/Home/index";

import "./assets/scss/main.scss";

const App = () => {
  const routes = (
    <Switch>
      <Route path="/" component={Home} />
    </Switch>
  );
  return (
    <Suspense fallback="">
      <Layout>{routes}</Layout>
    </Suspense>
  );
};
export default App;
