
import {SET_ITEM, SET_ROUTE } from './mutation-type'
import {reqUserLogin,reqUserGetRow, reqRoleGetAll,requserWithout,reqChangeLanguage} from '../api'
import router from '../router'
export default {
    async reqUserLogin({commit,state },ruleForm) {
        const res = await reqUserLogin(ruleForm);
        if(res.success){
            const data = res.result.AuthenticateResultModel.accessToken; //获取token
            const userId = res.result.AuthenticateResultModel.userId;    //获取userId
            const permissionsToRolesVersion = res.result.permissionsToRolesVersion //获取版本号
            const allPermissions = res.result.allPermissions //获取所有权限
             //当前用户ID
             sessionStorage.setItem('userId', userId)
    
             sessionStorage.setItem('date',new Date().getTime())
          
             sessionStorage.setItem('token', data)
             //版本号
             sessionStorage.setItem('version', permissionsToRolesVersion)
             var form={};
             form.languageName='zh-Hans';
             let reschange=await reqChangeLanguage(JSON.stringify(form))
             let res1=await requserWithout()
             if(res1.success){
                const PermissionscanAssigned=res1.result.PermissionscanAssigned;  //获取所有可分配的权限
                const RolescanAssigned=res1.result.RolescanAssigned;  //获取所有可分配的角色
                //所有分配权限
                if(PermissionscanAssigned!==null){
                    localStorage.setItem('PermissionscanAssigned',JSON.stringify(PermissionscanAssigned))
                }
                if(RolescanAssigned!==null){
                 //所有分配角色
                localStorage.setItem('RolescanAssigned',JSON.stringify(RolescanAssigned))
                }    
             }
            //所有权限
            localStorage.setItem('allPermissions', JSON.stringify(allPermissions))
            //所有角色
            let res2 = await reqRoleGetAll(0, 999)  //所有角色   角色下有对应的permissions权限
            console.log(res2)
            const res2allRoles=res2.result.items
            localStorage.setItem('res2allRoles', JSON.stringify(res2allRoles))
            let res2CurUser = await reqUserGetRow(userId) //获取当前User信息
            console.log(res2CurUser)
            const  roleNames = res2CurUser.result.roleNames //获取User下面的角色
            const  userName=  res2CurUser.result.userName; //获取用户名
            const  name =res2CurUser.result.name;  //获取姓名
            const  surname=res2CurUser.result.surname;//获取surname
            const  creationTime=res2CurUser.result.creationTime;
            const  lastLoginTime=res2CurUser.result.lastLoginTime;
            const  emailAddress= res2CurUser.result.emailAddress
           
            if(userName){
                localStorage.setItem('userName',userName)
            }
            if(name){
                localStorage.setItem('name',name)
            }
            if(surname){
                localStorage.setItem('surname',surname)
            }
            if(creationTime){
                localStorage.setItem('creationTime',creationTime)
            }
            if(lastLoginTime){
                localStorage.setItem('lastLoginTime',lastLoginTime)
            }
            if(emailAddress){
                localStorage.setItem('emailAddress',emailAddress)
            }
            var result =filterRoleNames(res2allRoles,roleNames)
       
            sessionStorage.setItem('permissionslist',JSON.stringify(result))

            //根据roleNames  在allSysRoles【匹配 Permissions的集合
            // let myPermissions
            var items=filteritems(state.items,result)
            commit(SET_ITEM,{items})
            sessionStorage.setItem('items',JSON.stringify(items))
            var route=filterroutes(state.rout,result)
            commit(SET_ROUTE,{route})
            router.addRoutes(route)
            router.replace('/order')
        }
      
        function filterRoleNames(allRoles,roleNames){
            var aa = [];
            for(var i=0;i<allRoles.length;i++){
                for(var j=0;j<roleNames.length;j++){
                    if(allRoles[i].normalizedName==roleNames[j]){
                        for(let k = 0; k < allRoles[i].permissions.length; k++ ){
                         aa.push(allRoles[i].permissions[k])
                        }
                    }
                }
            }
            var tt = [];
            for(let i = 0; i < aa.length; i++) {
                 if(tt.indexOf(aa[i]) == -1){
                     tt.push(aa[i]);
                }
            }
            return tt
        }
        function filteritems(state, items) {
            var rout = [];
            for (var i = 0; i < state.length; i++) {
                var object = {}
                for (var k = 0; k < items.length; k++) {
                    if (state[i].name == items[k]) {
                        object.icon = state[i].icon;
                        object.name = state[i].name;
                        object.index = state[i].index;
                        object.title = state[i].title;
                        object.subs = '';
                        rout.push(object);
                    }
                }
            }
            var k;
            var childe = [];
            for (var i = 0; i < state.length; i++) {
                var arr = [];
                var obj = {};
                if (i < state.length) {
                    k = 0;
                    for (k = 0; k < items.length; k++) {
                        for (var f = 0; f < state[i].subs.length; f++) {
                            var object = {};
                            if (state[i].subs[f].name == items[k]) {
                                object.name = state[i].subs[f].name;
                                object.index = state[i].subs[f].index;
                                object.title = state[i].subs[f].title;
                                object.path = state[i].subs[f].path;
                                object.component = state[i].subs[f].component;
                                object.meta = state[i].subs[f].meta;
                                arr.push(object);
                            }
                        }
                    }
                }
                obj.subs = arr;
                childe.push(obj)
            }
            for (var i = 0; i < rout.length; i++) {
                rout[i].subs = childe[i].subs;
            }
       
            return rout;
        }
        function filterroutes(state, items) {
            let children = state[0].children;
            var cot = []
            var cont = []
            for (var i = 0; i < children.length; i++) {
                for (var j = 0; j < items.length; j++) {
                    if (children[i].name == items[j]) {
                        cont.push(children[i])
                    }
                }
            }
      
            cont.push({
                path: '/404',
                component: resolve => require(['../components/page/404.vue'], resolve),
                meta: { title: '404' }

            })
            cot.push({
                path: '/',
                component: resolve => require(['../components/common/Home.vue'], resolve),
                children: cont
            }, {
                    path: '*',
                    redirect: '/404'
                })
             
            return cot
        }
        
        return res
    }


}
