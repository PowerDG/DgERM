<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>
 <script>
import { reqRoleGetAll, reqUserGetRow,requserWithout } from "../src/api";
export default {
  data() {
    return {
      userId: sessionStorage.getItem("userId")
    };
  },
  async created() {
  if(this.userId!=null){
    
     let res1 = await reqRoleGetAll(0, 999);
        const res2allRoles = res1.result.items;
        let res2CurUser = await reqUserGetRow(this.userId);
        const roleNames = res2CurUser.result.roleNames;
        var result = this.filterRoleNames(res2allRoles, roleNames);
        var route = this.filterroutes(this.$store.state.rout, result);
        this.$router.addRoutes(route);
     }
    
  },
  methods: {
    filterRoleNames(allRoles, roleNames) {
      var aa = [];
      for (var i = 0; i < allRoles.length; i++) {
        for (var j = 0; j < roleNames.length; j++) {
          if (allRoles[i].normalizedName == roleNames[j]) {
            for (let k = 0; k < allRoles[i].permissions.length; k++) {
              aa.push(allRoles[i].permissions[k]);
            }
          }
        }
      }
      var tt = [];
      for (let i = 0; i < aa.length; i++) {
        if (tt.indexOf(aa[i]) == -1) {
          tt.push(aa[i]);
        }
      }
      return tt;
    },
    filterroutes(state, items) {
      let children = state[0].children;
      var cot = [];
      var cont = [];
      for (var i = 0; i < children.length; i++) {
        for (var j = 0; j < items.length; j++) {
          if (children[i].name == items[j]) {
            cont.push(children[i]);
          }
        }
      }
      cont.push({
        path: "/404",
        component: resolve =>
          require(["../src/components/page/404.vue"], resolve),
        meta: { title: "404" }
      });
      cot.push(
        {
          path: "/",
          component: resolve =>
            require(["../src/components/common/Home.vue"], resolve),
          children: cont
        },
        {
          path: "*",
          redirect: "/404"
        }
      );

      return cot;
    }
  }
};
</script>
 
<style>
@import "../static/css/main.css";
@import "../static/css/color-dark.css";
@import "../src/assets/style/style.css"; /*深色主题*/
 .el-notification.right{
    right:1416px;
    top:76px !important;
  }

/* .right_inner .el-table--small td{padding:0 0;} */

/*@import "../static/css/theme-green/color-green.css";   浅绿色主题*/
</style>