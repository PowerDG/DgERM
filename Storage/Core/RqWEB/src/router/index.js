import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

export const constantRouterMap=[
    {
        path:'/login', component: resolve => require(['../components/page/login/Login.vue'], resolve)
    },
  
    {
        path:'/',redirect:'/login'
    }
]
export default new Router({
    history: 'true',
    routes:constantRouterMap
})
// export const asyncRouterMap=[
//     {
//         path: '/',
//         component: resolve => require(['../components/common/Home.vue'], resolve),
//         children:[
//             {
//                 name: 'pages.Staff.Merchandiser',
//                 index:'customer',
//                 title:'客户管理',
//                 path: '/customer',
//                 component: resolve => require(['../components/page/customer/customer.vue'], resolve),
//                 meta: { title: '客户管理',  index:'customer', }
//             },
//             {
//                 path: '/business',
//                 component: resolve => require(['../components/page/customer/business.vue'], resolve),
//                 meta: { title: '业务管理',index:'business'}
//             },
//             {
//                 path: '/order',
//                 component: resolve => require(['../components/page/wuliuorder/order.vue'], resolve),
//                 meta: { title: '订单管理' , index:'order'}
//             },
         
//             {
//                 path: '/yunshang',
//                 component: resolve => require(['../components/page/wuliuorder/yunshang.vue'], resolve),
//                 meta: { title: '转包运商',index:'yunshang' }
//             },
//             {
//                 path: '/businesslist',
//                 component: resolve => require(['../components/page/finance/businesslist.vue'], resolve),
//                 meta: { title: '业务清单',index:'businesslist'}
//             },
//             {
//                 path: '/invoice',
//                 component: resolve => require(['../components/page/finance/invoice.vue'], resolve),
//                 meta: { title: '发票管理' ,index:'invoice'}
//             },
//             {
//                 path: '/news',
//                 component: resolve => require(['../components/page/news/news.vue'], resolve),
//                 meta: { title: '内容新闻',index:'news' }
//             },
//             {
//                 path: '/vehicle',
//                 component: resolve => require(['../components/page/cheliang/vehicle.vue'], resolve),
//                 meta: { title: '车型管理' ,index:'vehicle'}
//             },
//             {
//                 path:'/myself',component: resolve => require(['../components/page/personal/information.vue'], resolve)
//             },
//             {
//                 path: '/chelianginfo',
//                 component: resolve => require(['../components/page/cheliang/chelianginfo.vue'], resolve),
//                 meta: { title: '车辆管理',index:'chelianginfo' }
//             },
//             {
//                 path: '/personnel',
//                 component: resolve => require(['../components/page/personal/personnel.vue'], resolve),
//                 meta: { title: '人员角色',index:'personnel' }
//             },
//             {
//                 path: '/character',
//                 component: resolve => require(['../components/page/personal/character.vue'], resolve),
//                 meta: { title: '角色分配',index:'character' }
//             },
//             {
//                 path:'/system',
//                 component: resolve => require(['../components/page/personal/system.vue'], resolve),
//                 meta: { title: '系统设置',index:'system' }
                    
//             },
//             {
//                 path:'/Toaudit',
//                 component: resolve => require(['../components/page/audit/Toaudit.vue'], resolve),
//                 meta: { title: '待审核',index:'Toaudit' }

//             },
//             {
//                 path: '/404',
//                 component: resolve => require(['../components/page/404.vue'], resolve),
//                 meta: { title: '404' }
//             },
//         ]
//     },
//     {
//         path: '*',
//         redirect: '/404'
//     }
// ]
 