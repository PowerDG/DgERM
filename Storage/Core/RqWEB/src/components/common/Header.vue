<template>
  <div class="header">
    <!-- 折叠按钮 -->
    <el-row>
      <el-col :span="1">
        <div class="collapse-btn" @click="collapseChage">
          <i class="icon-5"></i>
        </div>
      </el-col>
      <el-col :span="2" style="width:30px;padding-left:5px">
        <img src="../../assets/img/04.png" alt style="height:30px;margin-top:7px">
      </el-col>
      <el-col :span="20">
        <div class="txt">瑞庆货物运输代理&nbsp;&nbsp;(苏州)&nbsp;&nbsp;有限公司内部系统</div>
      </el-col>
      <!-- <el-col :span="4">
        <input type="text" placeholder="请输入搜索内容">
      </el-col> -->
      <el-col :span="2">
        <el-dropdown style="margin-top:10px;margin-right:20px" placement="bottom">
          <span class="el-dropdown-link">
            <a href="#">
              <img src="../../assets/img/消息.png" alt>
            </a>
          </span>
          <el-dropdown-menu slot="dropdown">
            <router-link to="/myinfos" replace>
              <el-badge :value="count" class="item">
                <el-dropdown-item>我的消息</el-dropdown-item>
              </el-badge>
            </router-link>
          </el-dropdown-menu>
        </el-dropdown>
        <el-dropdown style="margin-right:20px" placement="bottom">
          <span class="el-dropdown-link">
            <a href="#">
              <img src="../../assets/img/1.1.png" alt>
            </a>
          </span>
          <el-dropdown-menu slot="dropdown">
            <router-link to="/myself" replace>
              <el-dropdown-item>个人信息</el-dropdown-item>
            </router-link>
            <router-link to="/updatepassword" replace>
              <el-dropdown-item>修改密码</el-dropdown-item>
            </router-link>
          </el-dropdown-menu>
        </el-dropdown>
        <el-dropdown   placement="bottom">
          <span class="el-dropdown-link">
            <a href="#">
              <img src="../../assets/img/02.png" alt>
            </a>
          </span>
          <el-dropdown-menu  slot="dropdown">
       
              <el-dropdown-item @click.native="tuichu">退出登录</el-dropdown-item>
    
          </el-dropdown-menu>
        </el-dropdown>
      </el-col>
    </el-row>
  </div>
</template>
<script>
import { reqUsermyinfos } from "../../api/index.js";
export default {
  data() {
    return {
      fullscreen: false,
      name: "linxin",
      message: 2,
      count: ""
    };
  },
  methods: {
    // 用户名下拉菜单选择事件
    handleCommand(command) {
      if (command == "loginout") {
        localStorage.removeItem("ms_username");
        this.$router.push("/login");
      }
    },
    // 侧边栏折叠
    collapseChage() {
      this.$store.commit("increment", this.collapse);
    },
    //我的消息数量
    async getmyinfos() {
      let res = await reqUsermyinfos(sessionStorage.getItem("userId"));
      this.count = res.result;
    },
    tuichu(){
      console.log(111)
      sessionStorage.clear();
      localStorage.clear();
      this.$router.replace('/login')
    }
  },
  mounted() {
    this.getmyinfos();
  }
};
</script>
<style scoped lang="less">
.item {
  margin-top: 10px;
  margin-right: 40px;
}
.header {
  background: #0a3f89;
  height: 50px;
  min-width: 1650px;
  .collapse-btn {
    padding: 0 21px;
    cursor: pointer;
    line-height: 50px;
    color: #ffffff;
  }
  .txt {
    line-height: 50px;
    font-size: 18px;
    color: #ffffff;
    margin-left: 20px;
  }
  input {
    width: 220px;
    height: 28px;
    margin-top: 10px;
    border: 1px solid #7f9bc1;
    outline: none;
    background: transparent url("../../assets/img/05.png") no-repeat 10px 0px;
    border-radius: 40px;
    padding-left: 38px;
    color: #ffffff;
  }
}
</style>


