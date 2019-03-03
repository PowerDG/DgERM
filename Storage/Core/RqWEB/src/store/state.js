/*状态对象*/
export default{
    collapse:true,//头部折叠
    token:'',
    rout:[
        {
            path: '/',
            component: resolve => require(['../components/common/Home.vue'], resolve),
            children:[
                {
                    name: 'Pages.Staff.Merchandiser',
                    index:'customer',
                    title:'客户管理',
                    path: '/customer',
                    component: resolve => require(['../components/page/customer/customer.vue'], resolve),
                    meta: { title: '客户管理',  index:'customer', }
                },
                // {
                //     name: 'Pages.Staff.Merchandiser',
                //     index:'business',
                //     title:"业务管理",
                //     path: '/business',
                //     component: resolve => require(['../components/page/customer/business.vue'], resolve),
                //     meta: { title: '业务管理',index:'business'}
                // },
                {
                    name: 'Pages.Staff.Customer_service',
                    index:'order',
                    title:"订单管理",   
                    path: '/order',
                    component: resolve => require(['../components/page/wuliuorder/order.vue'], resolve),
                    meta: { title: '订单管理' , index:'order'}
                },
              
                {
                    name: 'Pages.Staff.Others',
                    index:"yunshang",
                    title:"转包运商",
                    path: '/yunshang',
                    component: resolve => require(['../components/page/wuliuorder/yunshang.vue'], resolve),
                    meta: { title: '转包运商',index:'yunshang' }
                },
                {
                    name: 'Pages.Staff.Financial',
                    index:'businesslist',
                    title:'业务清单',
                    path: '/businesslist',
                    component: resolve => require(['../components/page/finance/businesslist.vue'], resolve),
                    meta: { title: '业务清单',index:'businesslist'}
                },
                {
                    name: 'Pages.Staff.Financial',
                    index:'businesslist2',
                    title:'业务清单2',
                    path: '/businesslist2',
                    component: resolve => require(['../components/page/finance/businesslist2.vue'], resolve),
                    meta: { title: '业务清单2',index:'businesslist2'}
                },
                
                {
                    name: 'Pages.Staff.Financial',
                    index:'invoice',
                    title:"发票管理",
                    path: '/invoice',
                    component: resolve => require(['../components/page/finance/invoice.vue'], resolve),
                    meta: { title: '发票管理' ,index:'invoice'}
                },
                {
                    
                    name:"Pages.Staff.Others",
                    index:'news',
                    title:'内容新闻',
                    path: '/news',
                    component: resolve => require(['../components/page/news/news.vue'], resolve),
                    meta: { title: '内容新闻',index:'news' }
                },
                // {
                //     name: 'Pages.Staff.Others',
                //     index:'vehicle',
                //     title:"车型管理",
                //     path: '/vehicle',
                //     component: resolve => require(['../components/page/cheliang/vehicle.vue'], resolve),
                //     meta: { title: '车型管理' ,index:'vehicle'}
                // },
    
                // {
                //     name: 'Pages.Staff.Others',
                //     index:'vehicle',
                //     title:"车型管理",
                //     path: '/chelianginfo',
                //     component: resolve => require(['../components/page/cheliang/chelianginfo.vue'], resolve),
                //     meta: { title: '车辆管理',index:'chelianginfo' }
                // },
                {
                    name: 'Pages.RQAssitant.Users',
                    index:"personnel",
                    title:"人员分配",
                    path: '/personnel',
                    component: resolve => require(['../components/page/personal/personnel.vue'], resolve),
                    meta: { title: '人员分配',index:'personnel' }
                },
                {
                    name: 'Pages.RQAssitant.Roles',
                    index:"character",
                    title:"角色分配",
                    path: '/character',
                    component: resolve => require(['../components/page/personal/character.vue'], resolve),
                    meta: { title: '角色分配',index:'character' }
                },
                {
                    name: 'Pages.RQAssitant.Roles',
                    index:"system",
                    title:"系统设置",
                    path: '/system',
                    component: resolve => require(['../components/page/personal/system.vue'], resolve),
                    meta: { title: '系统设置',index:'system' }
                },
                {
                    name: 'Pages.Inspection',
                    index:"Toaudit",
                    title:"待审核项",
                    path: '/Toaudit',
                    component: resolve => require(['../components/page/audit/Toaudit.vue'], resolve),
                    meta: { title: '待审核项',index:'Toaudit' }
                },
                {
                    name:"Pages.Staff.Owner",
                    title:'个人信息',
                    index:"myself",
                    path:'/myself',component: resolve => require(['../components/page/personal/information.vue'], resolve),
                    meta: { title: '个人信息' , index:'myself'}
                },
                {
                    name:"Pages.Staff.Owner",
                    title:'密码修改',
                    index:"updatepassword",
                    path:'/updatepassword',component: resolve => require(['../components/page/personal/updatepassword.vue'], resolve),
                    meta: { title: '修改密码' , index:'updatepassword'}
                },
                {   
                    name:"Pages.Staff.Owner",
                    title:'我的消息',
                    index:"myinfos",
                    path:"/myinfos" ,
                    component: resolve => require(['../components/page/personal/myinfos.vue'], resolve),
                    meta: { title: '我的消息' , index:'myinfos'}   
                },
                {
                    path: '/404',
                    component: resolve => require(['../components/page/404.vue'], resolve),
                    meta: { title: '404' }
                },
            ]
        },
        {
            path: '*',
            redirect: '/404'
        }
    ],
    items: [
        {
            icon: 'icon-uniE905',
            name: 'Pages.Staff.Merchandiser',
            index: 'a',
            title: '业务客户',
            subs:[
                {
                    name: 'Pages.Staff.Merchandiser',
                    index:'customer',
                    title:'客户管理',
                    path: '/customer',
                    component: resolve => require(['../components/page/customer/customer.vue'], resolve),
                    meta: { title: '客户管理',  index:'customer',show:true}
                },
                // {
                //     name: 'Pages.Staff.Merchandiser',
                //     index:'business',
                //     title:"业务管理",
                //     path: '/business',
                //     component: resolve => require(['../components/page/customer/business.vue'], resolve),
                //     meta: { title: '业务管理',index:'business',show:false}
                // }
            ]
        },
        {
            icon: 'icon--1',
            index: 'b',
            title: '物流订单',
            name:'Pages.Staff.Owner',
            subs:[
              
                {
                    name: 'Pages.Bill',
                    index:'order',
                    title:"订单管理",   
                    path: '/order',
                    component: resolve => require(['../components/page/wuliuorder/order.vue'], resolve),
                    meta: { title: '订单管理' , index:'order'}
                },
                {
                    name: 'Pages.Staff.Others',
                    index:"yunshang",
                    title:"转包运商",
                    path: '/yunshang',
                    component: resolve => require(['../components/page/wuliuorder/yunshang.vue'], resolve),
                    meta: { title: '转包运商',index:'yunshang' }
                }
            ]
        },
        {
            icon: 'icon-4',
            index: 'c',
            title: '财务管理',
            name:'Pages.Staff.Financial',
            subs:[
                {
                    name: 'Pages.Staff.Financial',
                   index:'businesslist',
                   title:'业务清单',
                   path: '/businesslist',
                    component: resolve => require(['../components/page/finance/businesslist.vue'], resolve),
                    meta: { title: '业务清单',index:'businesslist'}
                },
                // {
                //     name: 'Pages.Staff.Financial',
                //    index:'businesslist2',
                //    title:'业务清单2',
                //    path: '/businesslist2',
                //     component: resolve => require(['../components/page/finance/businesslist2.vue'], resolve),
                //     meta: { title: '业务清单2',index:'businesslist2'}
                // },
                // {
                //     name: 'Pages.Staff.Financial',
                //     index:'invoice',
                //     title:"发票管理",
                //     path: '/invoice',
                //     component: resolve => require(['../components/page/finance/invoice.vue'], resolve),
                //     meta: { title: '发票管理' ,index:'invoice'}
                // },
                
            ]
        },
        {
            icon: 'icon-1',
            index: 'news',
            title: '内容新闻',
            name:'Pages.Staff.Others',
             subs:[
                 {
                     name:"Pages.Staff.Others",
                     index:'news',
                     title:'内容新闻',
                     path: '/news',
                     component: resolve => require(['../components/page/news/news.vue'], resolve),
                     meta: { title: '内容新闻',index:'news' }
                 }
             ]
    
        },
        // {
        //     icon: 'icon-2',
        //     index: 'd',
        //     title: '司机车辆',
        //     name:'Pages.Staff.Others',
        //      subs:[
        //           {
        //             name: 'Pages.Staff.Others',
        //             index:'chelianginfo',
        //             title:"车辆管理",
        //             path: '/chelianginfo',
        //             component: resolve => require(['../components/page/cheliang/chelianginfo.vue'], resolve),
        //             meta: { title: '车辆管理',index:'chelianginfo' }
        //         },
        //         {
        //             name: 'Pages.Staff.Others',
        //             index:'vehicle',
        //             title:"车型管理",
        //             path: '/vehicle',
        //             component: resolve => require(['../components/page/cheliang/vehicle.vue'], resolve),
        //             meta: { title: '车型管理' ,index:'vehicle'}
        //         }
        //     ]
        // },
        {
            icon: 'icon-3',
            index: 'e',
            title: '人员角色',
            name:'Pages.RQAssitant',
            subs:[
                {
                    name: 'Pages.RQAssitant.Users',
                    index:"personnel",
                    title:"人员分配",
                    path: '/personnel',
                    component: resolve => require(['../components/page/personal/personnel.vue'], resolve),
                    meta: { title: '人员分配',index:'personnel' }
                },
                {
                    name: 'Pages.RQAssitant.Roles',
                    index:"character",
                    title:"角色分配",
                    path: '/character',
                    component: resolve => require(['../components/page/personal/character.vue'], resolve),
                    meta: { title: '角色分配',index:'character' }
                },
                {
                    name: 'Pages.RQAssitant.Roles',
                    index:"system",
                    title:"系统设置",
                    path: '/system',
                    component: resolve => require(['../components/page/personal/system.vue'], resolve),
                    meta: { title: '系统设置',index:'system' }
                }
            ]
        }, 
        {
            icon:'el-icon-edit',
            index:'t',
            title:'审核管理',
            name:'Pages.Inspection',
            subs:[
               {
                   name:'Pages.Inspection',
                   index:'Toaudit',
                   title:'待审核项',
                   path:'/Toaudit',
                   component: resolve => require(['../components/page/audit/Toaudit.vue'], resolve),
                   meta: { title: '待审核项',index:'Toaudit' }
               }

            ]
        }
     ]
    } 