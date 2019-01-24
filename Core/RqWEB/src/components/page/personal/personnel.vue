<style scoped lang="less">
.persimon {
  display: flex;
  .persimon_left {
    width: 520px;
    background: #ffffff;
    padding: 10px 15px;
    border-radius: 10px;
  }
  .persimon_right {
    width: calc(100% - 520px);
    box-sizing: border-box;
    padding-left: 22px;
    .right_inner {
      background: #fff;
      padding: 20px;
      border-radius: 10px;
    }
  }
}
</style>
<style lang="less">
.persimon {
  .el-input__inner {
    border: 0;
    border-bottom: 1px;
    border-color: #c9c9c9;
    border-style: solid;
    border-radius: 0;
    padding: 0;
  }
  .el-table--small td {
    padding: 0 0;
  }
  .el-button {
    margin-left: 35px;
  }
}
</style>

<template>
  <div class="persimon">
    <div class="persimon_left">
      <el-form
        :model="ruleForm"
        ref="ruleForm"
        :label-position="labelPosition"
        class="demo-ruleForm"
      >
        <el-collapse v-model="activeNames" style="width:520px">
          <el-collapse-item title="用户信息" name="1">
            <el-row>
              <el-col :span="12">
                <span>用户名</span>
                <el-input
                  @blur="handleblur"
                  v-model="ruleForm.userName"
                  style="width:115px;padding-left:38px"
                ></el-input>
              </el-col>
              <el-col :span="12">
                <span>真实姓名</span>
                <el-input v-model="ruleForm.name" style="width:155px;padding-left:12px"></el-input>
              </el-col>
            </el-row>
            <el-row style="margin-top:10px">
              <el-col :span="12">
                <span>分公司编号</span>
                 <el-select v-model="ruleForm.surname" style="width:115px;margin-left:10px" placeholder="请选择">
                    <el-option
                    v-for="item in branchidlist"
                    :key="item.value"
                    :label="item.displayName"
                    :value="item.claim_Name">
                    </el-option>
                </el-select>
                
              </el-col>
              <el-col :span="12">
                <span>邮箱</span>
                <el-input v-model="ruleForm.emailAddress" style="width:155px;padding-left:12px"></el-input>
              </el-col>
            </el-row>
            <el-row style="margin-top:10px">
              <el-col :span="12" v-show="!isUpdate">
                <span>密码</span>
                <el-input type="password" v-model="ruleForm.password" style="width:95px;padding-left:12px"></el-input>
              </el-col>
              <!-- <el-col :span="12">
                              <el-checkbox v-model="ruleForm.isActive">是否激活</el-checkbox>
              </el-col>-->
            </el-row>
          </el-collapse-item>
          <el-collapse-item title="角色管理" name="2">
            <el-row v-for="(item,index) in RolescanAssigned" :key="index">
              <el-col :span="8">
                <el-checkbox-group v-model="ruleForm.roleNames">
                  <el-checkbox :label="item.displayName"></el-checkbox>
                </el-checkbox-group>
              </el-col>
            </el-row>

            <el-row style="margin-top:25px;text-align:center">
              <el-col :span="24">
                <el-button type="success" @click="handleSubmit">提交</el-button>
                <el-button type="danger" @click="handleClear">清空</el-button>
              </el-col>
            </el-row>
          </el-collapse-item>
        </el-collapse>
      </el-form>
    </div>
    <div class="persimon_right">
      <div class="right_inner">
        <el-table :data="tablelist" border stripe ref="form" @row-click="opebDetails">
          <el-table-column prop="userName" label="用户名"></el-table-column>
          <el-table-column prop="name" label="姓名"></el-table-column>
          <el-table-column prop="surname" label="分公司编号"></el-table-column>
          <el-table-column prop="emailAddress" label="邮箱"></el-table-column>
          <el-table-column prop="isActive" label="isActive"></el-table-column>
        </el-table>
        <el-pagination
          @size-change="handleSizeChange"
          @current-change="handleCurrentChange"
          :current-page.sync="paginations.page_index"
          :page-sizes="paginations.page_sizes"
          :page-size="paginations.page_size"
          layout="total, sizes, prev, pager, next, jumper"
          :total="paginations.total"
          style="text-align:center;margin-top:15px"
        ></el-pagination>
      </div>
    </div>
  </div>
</template>
<script>
import {
  reqBranchId,
  reqUserGetAll,
  reqUserCreate,
  reqUserGetRow,
  reqUserUpdate,
  reqUsernameexist,
  reqBranchIdPer
} from "../../../api/index.js";
import { formatDate } from "../../../fiters/common.js";
export default {
  data() {
    return {
      labelPosition: "right", //label定位
      RolescanAssigned: JSON.parse(localStorage.getItem("RolescanAssigned")),
      activeNames: ["1", "2"],
      ruleForm: {
        userName: "",
        name: "",
        surname: "",
        emailAddress: "",
        isActive: true,
        roleNames: [],
        password: "",
        fullName: "",
        creationTime: "",
        lastLoginTime: "",
        id:""
      },
      branchidlist:[],
      paginations: {
        total: 0,
        page_index: 1,
        page_size: 30,
        page_sizes: [10, 20, 30]
      },
      tablelist: [],
      isUpdate: false
    };
  },
  methods: {
    //获取表格数据
    async getUserAll() {
      let res = await reqUserGetAll(
        this.paginations.page_index,
        this.paginations.page_size
      );
      res.result.items.forEach(v => {
        v.isActive = v.isActive ? "是" : "否";
      });
      this.paginations.total = res.result.totalCount;
      this.tablelist = res.result.items;
    },
    //页码变化
    async handleCurrentChange(page) {
      let res1 = await reqUserGetAll(page, this.paginations.page_size);
      res1.result.items.forEach(v => {
        v.isActive = v.isActive ? "是" : "否";
      });
      this.tablelist = res1.result.items;
    },
    //一页数量变化
    async handleSizeChange(page) {
      this.paginations.page_size = page;
      let res2 = await reqUserGetAll(1, page);
      res2.result.items.forEach(v => {
        v.isActive = v.isActive ? "是" : "否";
      });
      this.paginations.page_index = 1;
      this.tablelist = res2.result.items;
    },
    async handleSubmit() {
      if (this.isUpdate == false) {
        for (var i = 0; i < this.RolescanAssigned.length; i++) {
          for (var j = 0; j < this.ruleForm.roleNames.length; j++) {
            if (
              this.ruleForm.roleNames[j] == this.RolescanAssigned[i].displayName
            ) {
              this.ruleForm.roleNames[j] = this.RolescanAssigned[i].normalizedName;
            }
          }
        }
        let res1 = await reqUserCreate(JSON.stringify(this.ruleForm));
        if (res1.success) {
          this.$message("添加成功....");
          this.getUserAll();
          this.ruleForm.userName = "";
          this.ruleForm.name = "";
          this.ruleForm.surname = "";
          this.ruleForm.emailAddress = "";
          this.ruleForm.password = "";
          this.ruleForm.roleNames = "";
        }
      } else {
        delete this.ruleForm.password;
        for (var i = 0; i < this.RolescanAssigned.length; i++) {
          for (var j = 0; j < this.ruleForm.roleNames.length; j++) {
            if (
              this.ruleForm.roleNames[j] == this.RolescanAssigned[i].displayName
            ) {
              this.ruleForm.roleNames[j] = this.RolescanAssigned[i].normalizedName;
            }
          }
        }
        let res2 = await reqUserUpdate(JSON.stringify(this.ruleForm));
        if (res2.success) {
          this.$message("更新成功");
          this.getUserAll();
        }
      }
    },
    async getBranchId() {
      let res = await reqBranchId();
    },
    //清空左侧
    handleClear() {
      for (var key in this.ruleForm) {
        this.ruleForm[key] = "";
      }
    },
    //行点击
    async opebDetails(row) {
      this.isUpdate = true;
      let res = await reqUserGetRow(row.id);
      console.log(res)
      this.ruleForm.userName = res.result.userName;
      this.ruleForm.name = res.result.name;
      this.ruleForm.surname = res.result.surname;
      this.ruleForm.emailAddress = res.result.emailAddress;
      this.ruleForm.isActive = res.result.isActive;
      this.ruleForm.fullName = res.result.fullName;
      this.ruleForm.id=res.result.id
      this.ruleForm.creationTime = formatDate(
        new Date(res.result.creationTime),
        "yyyy-MM-dd hh:mm"
      );
      this.ruleForm.lastLoginTime = formatDate(
        new Date(res.result.lastLoginTime),
        "yyyy-MM-dd hh:mm"
      );
      for (var i = 0; i < this.RolescanAssigned.length; i++) {
        for (var j = 0; j < res.result.roleNames.length; j++) {
          if (
            this.RolescanAssigned[i].normalizedName == res.result.roleNames[j]
          ) {
            res.result.roleNames[j] = this.RolescanAssigned[i].displayName;
          }
        }
      }
      this.ruleForm.roleNames = res.result.roleNames;
    },
    handleblur() {
      var reg = /^[a-zA-Z]+[1-9]*[a-zA-Z]*$/;
      if (!this.ruleForm.userName) {
        this.$message("用户名不能为空!");
      } else if (!reg.test(this.ruleForm.userName)) {
        this.$message("用户名字母开头!!");
      } else {
        this.axios({
          method: "POST",
            //  url:"http://"+window.location.host+"/api/services/app/User/CheckUserNameAsync?name="+this.ruleForm.userName,
          url:
            "http://localhost:21021/api/services/app/User/CheckUserNameAsync?name=" +
            this.ruleForm.userName
        }).then(res => {
          if (res.data.result == false) {
            this.$message("该用户名已存在!!!");
          } else {
            this.ruleForm.emailAddress = this.ruleForm.userName + "@EQ.com";
          }
        });
      }
    },
   async getBranchIdPer(){
    let res=await reqBranchIdPer('BranchID')
    this.branchidlist=res.result
    }
  },

  created() {
    this.getBranchId();
    this.getUserAll();
    this.getBranchIdPer()
  }
};
</script>




