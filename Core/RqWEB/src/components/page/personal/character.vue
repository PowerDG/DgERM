
<style scoped lang="less">
.character {
  display: flex;
  height: auto;
  .character_left {
    width: 520px;
    background: #ffffff;
    padding: 10px 15px;
    border-radius: 10px;
  }
  .character_right {
    width: calc(100% - 520px);
    box-sizing: border-box;
    padding-left: 22px;
    .right_inner {
      background: #fff;
      padding: 20px;
      border-radius: 10px;
      max-height: 1000px;
    }
  }
}
</style>

<style lang="less">
.character {
  .el-input__inner {
    border: 0;
    border-bottom: 1px;
    border-color: #c9c9c9;
    border-style: solid;
    border-radius: 0;
    padding: 0;
  }
}
</style> 

<template>
  <div class="character">
    <div class="character_left">
      <el-form :model="ruleForm" ref="ruleForm" class="demo-ruleForm">
        <el-row>
          <el-col :span="12">
            <span>角色名</span>
            <el-input v-model="ruleForm.name" style="width:115px;padding-left:12px" @blur="existblur"></el-input>
          </el-col>
          <el-col :span="12">
            <span>显示名</span>
            <el-input v-model="ruleForm.displayName" style="width:115px;padding-left:12px"></el-input>
          </el-col>
        </el-row>

        <el-row v-for="(item,index) in PermissionscanAssigned" :key="index" style="margin-top:10px">
          <el-col :span="8">
            <el-checkbox-group v-model="ruleForm.permissions">
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
      </el-form>
    </div>
    <div class="character_right">
      <div class="right_inner">
        <el-table :data="permisonlist" border stripe ref="form" @row-click="opebDetails">
          <el-table-column prop="name" label="name"></el-table-column>
          <el-table-column prop="displayName" label="displayName"></el-table-column>
        </el-table>
      </div>
    </div>
  </div>
</template> 

<script>
import {
  reqRoleGetAll,
  reqRoleGetRow,
  reqRoleCreate,
  reqRoleUpdate
} from "../../../api/index.js";
export default {
  data() {
    return {
      permisonlist: [],
      PermissionscanAssigned: JSON.parse(
        localStorage.getItem("PermissionscanAssigned")
      ),
      isupdate: false,
      ruleForm: {
        name: "",
        displayName: "",
        permissions: [],
        description: "string",
        isStatic: true,
        normalizedName: "",
        id:""
      }
    };
  },

   
  methods: {
    async getRoleall() {
      let res = await reqRoleGetAll(0, 999);
      this.permisonlist = res.result.items;
    },
    async opebDetails(row) {
      this.isupdate = true;
      let res = await reqRoleGetRow(row.id);
      console.log(res)
      this.ruleForm.normalizedName = res.result.normalizedName;
      this.ruleForm.id = res.result.id;
      this.ruleForm.name = res.result.name;
      this.ruleForm.displayName = res.result.displayName;
      for (var i = 0; i < this.PermissionscanAssigned.length; i++) {
        for (var j = 0; j < res.result.permissions.length; j++) {
          if (
            this.PermissionscanAssigned[i].name == res.result.permissions[j]
          ) {
            res.result.permissions[j] = this.PermissionscanAssigned[
              i
            ].displayName;
          }
        }
      }

      this.ruleForm.permissions = res.result.permissions;
    },
    async handleSubmit() {
      if (this.isupdate == false) {
        for (var i = 0; i < this.PermissionscanAssigned.length; i++) {
          for (var j = 0; j < this.ruleForm.permissions.length; j++) {
            if (
              this.PermissionscanAssigned[i].displayName ==
              this.ruleForm.permissions[j]
            ) {
              this.ruleForm.permissions[j] = this.PermissionscanAssigned[
                i
              ].name;
            }
          }
        }
        let res = await reqRoleCreate(JSON.stringify(this.ruleForm));
        if (res.success) {
          this.$message("新建成功");
          this.getRoleall();
        }
      } else {
      
        for(var i=0;i<this.PermissionscanAssigned.length;i++){
          for(var j=0;j<this.ruleForm.permissions.length;j++){
              if(this.PermissionscanAssigned[i].displayName==this.ruleForm.permissions[j]){
                this.ruleForm.permissions[j]=this.PermissionscanAssigned[i].name
              }
          }
        }
        let res = await reqRoleUpdate(JSON.stringify(this.ruleForm));
        console.log(res)
        if (res.success) {
          this.$message("更新成功");
          this.getRoleall();
        }
      }
    },
    handleClear(){
         for(var key in this.ruleForm){
              this.ruleForm[key]="" 
           }    
    },
    existblur(){
        var reg=/^[A-Za-z_\u4e00-\u9fa5]{1,}[1-9]*$/ 
          if(!this.ruleForm.name){
              this.$message('角色名不能为空哦!')
          }else if(!reg.test(this.ruleForm.name)){
                this.$message('角色名格式有误哦!!')
          }else{
            this.axios({
          method: "POST",
          //  url:"http://"+window.location.host+"/api/services/app/Role/CheckName?name=" +this.ruleForm.name,
          url:"http://localhost:21021/api/services/app/Role/CheckName?name=" +this.ruleForm.name
        }).then(res => {
           
          if (res.data.result==false) {
             this.$message("该角色已存在!!!");
          }
        }); 
          }
    }
  },

  created() {
    this.getRoleall();
  }
};
</script> 
 



