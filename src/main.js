import 'devextreme/dist/css/dx.common.css';
import './themes/generated/theme.base.css';
import './themes/generated/theme.additional.css';
import './styles/root.css';
import Vue from "vue";

import App from "./App";
import router from "./router";
import appInfo from "./app-info";
export const eventBus = new Vue();
Vue.prototype.$bus = eventBus;

Vue.config.productionTip = false;
Vue.prototype.$appInfo = appInfo;
import './globalComponents.js';

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
