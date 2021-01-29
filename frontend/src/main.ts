import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify';
import veevalidate from './plugins/vee-validate';
import i18n from './i18n'
import { humanizeDate } from './utils';


Vue.config.productionTip = false

veevalidate.apply(Vue)

Vue.filter("humanizeDate", humanizeDate)

new Vue({
    router,
    store,
    vuetify,
    i18n,
    render: h => h(App)
}).$mount('#app')
