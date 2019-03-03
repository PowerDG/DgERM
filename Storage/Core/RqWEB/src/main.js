import Vue from 'vue';
Vue.config.devtools = true
import App from './App';
import router from './router';
import store from './store'
import axios from 'axios';
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';    // 默认主题
// import '../static/css/theme-green/index.css';       // 浅绿色主题
import '../static/css/icon.css';
import "babel-polyfill";
import "../static/utf8-asp/ueditor.config"
import "../static/utf8-asp/ueditor.all"
import "../static/utf8-asp/lang/zh-cn/zh-cn"
import "../static/utf8-asp/ueditor.parse"
import Vuex from 'vuex'
Vue.prototype.axios=axios
Vue.use(Vuex)
Vue.use(ElementUI, { size: 'small' });

Vue.config.productionTip = false
Array.prototype.contains = function(val)
{
     for (var i = 0; i < this.length; i++)
    {
       if (this[i] == val)
      {
       return true;
      }
    }
     return false;
};



//使用钩子函数对路由进行权限跳转
router.beforeEach((to,from,next)=>{
    const isLogin=sessionStorage.getItem('token')?true:false;
    if(to.path=='/login'){
        next()
    }else{
        isLogin?next():next('/login')
    }
})

new Vue({ 
    router,
    render: h => h(App),store
}).$mount('#app');