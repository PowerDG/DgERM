<style scoped lang="less">
.system {
  display: flex;
  .system_left {
    width: 500px;
    background: #ffffff;
    padding: 10px 15px;
    border-radius: 10px;
    
  }
  .system_right {
    width: calc(100% - 500px);
    box-sizing: border-box;
    padding-left: 22px;
    .right_innerg {
      background: #fff;
      padding: 20px;
      border-radius: 10px;

    }
  }
}
.clearfix:after {
  display: block;
  content: "";
  clear: both;
}
</style>

<style lang="less">
.system .el-input__inner {
  border: 0;
  border-bottom: 1px;
  border-color: #c9c9c9;
  border-style: solid;
  border-radius: 0;
  padding: 0;
}
.system_left .el-checkbox__input{
    line-height:3
}
.system  .el-table--small td { padding: 0 0; }
</style>

<template>
  <div class="system">
    <div class="system_left">
            <el-row style="margin:45px 0">
        <el-col :span="10">
          <span style="font-size:16px;color:rgb(48, 49, 51)">主题</span>
          <el-input style="width:115px" v-model="ruleForm.subject"></el-input>
        </el-col>
        <el-col :span="14">
          <span  style="font-size:16px;color:rgb(48, 49, 51)">申明名</span>
          <el-input style="width:115px" v-model="ruleForm.claim_Name"></el-input>
        </el-col>
      </el-row>
      <el-row style="margin:45px 0">
        <el-col :span="10">
          <span  style="font-size:16px;color:rgb(48, 49, 51)">展示名</span>
          <el-input style="width:95px" v-model="ruleForm.displayName"></el-input>
        </el-col>
        <el-col :span="14">
          <span  style="font-size:16px;color:rgb(48, 49, 51)">解释说明</span>
          <el-input style="width:175px" v-model="ruleForm.description"></el-input>
        </el-col>
      </el-row>
      <el-row style="margin:45px 0">
        <el-col :span="10">
          <span  style="font-size:16px;color:rgb(48, 49, 51)">申明值</span>
          <el-input style="width:95px" v-model="ruleForm.claim_Value"></el-input>
        </el-col>
        <el-col :span="14">
          <span  style="font-size:16px;color:rgb(48, 49, 51)">类型 </span>
          <el-input style="width:95px" v-model="ruleForm.claim_Type"></el-input>
        </el-col>
      </el-row>
      <el-row style="margin:45px 0">
        <el-col :span="10">
          <span  style="font-size:16px;color:rgb(48, 49, 51)">所属父类</span>
          <el-input style="width:95px" v-model="ruleForm.super_Type"></el-input>
        </el-col>
        <el-col :span="14">
          <span  style="font-size:16px;color:rgb(48, 49, 51)">下辖子类</span>
          <el-input style="width:95px" v-model="ruleForm.sub_Type"></el-input>
        </el-col>
      </el-row>
      <el-row style="margin:45px 0">
        <el-col :span="10">
          <span  style="font-size:16px;color:rgb(48, 49, 51)">发行人</span>
          <el-input style="width:95px" v-model="ruleForm.issuer"></el-input>
        </el-col>
        <el-col :span="14">
          <span  style="font-size:16px;color:rgb(48, 49, 51);padding-right:15px">是是否显示</span>
          <el-checkbox v-model="ruleForm.isDisplay"></el-checkbox>
        </el-col>
      </el-row>
     
      <el-row style="margin-top:15px;margin-left:140px">
        <el-col :span="6">
          <el-button type="success" @click="handleClick()">提交</el-button>
        </el-col>
         <el-col :span="6">
          <el-button type="primary" @click="handleClear()">清空</el-button>
        </el-col>
        <el-col :span="4">
          <el-button type="danger" @click="onDelete">删除</el-button>
        </el-col>
      </el-row>
    </div>
    <div class="system_right">
      <div class="right_innerg">
        <el-table
          :data="tablelist"
          border
          stripe
          ref="form"
          style="width: 100%"
          @row-click="opebDetails"
        >
          <el-table-column prop="subject" label="主题"></el-table-column>
          <el-table-column prop="displayName" label="displayName"></el-table-column>
          <el-table-column prop="claim_Name" label="申明名"></el-table-column>
          <el-table-column prop="claim_Value" label="申明值"></el-table-column>
          <el-table-column prop="claim_Type" label="类型"></el-table-column>

          <el-table-column prop="issuer" label="发行人"></el-table-column>
          <el-table-column prop="isDisplay" label="是是否显示">
            <template slot-scope="scope">
              <el-checkbox v-model="scope.row.isDisplay"></el-checkbox>
            </template>
          </el-table-column>
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
  reqSystemGetAll,
  reqSystemCreate,
  reqSystemGetMissionById,
  reqSystemDelete,
  reqSystemUpdate
} from "../../../api/index.js";
export default {
  data() {
    return {
      labelPosition: "left",
      ruleForm: {
        subject: "",
        isDisplay: true,
        claim_Name: "",
        displayName: "",
        description: "",
        claim_Value: "",
        issuer: "",
        claim_Type: "",
        super_Type: "",
        sub_Type: "",
        id: 0
      },
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
    //获取所有信息
    async getlist() {
      let res = await reqSystemGetAll()
      this.tablelist = res.result;
    },
    async handleClick() {
      if (this.isUpdate == false) {
        let res = await reqSystemCreate(JSON.stringify(this.ruleForm));
        if (res.success) {
          this.$message("创建成功");
          this.getlist();
          this,handleClear()
        }
      } else {
        let res = await reqSystemUpdate(JSON.stringify(this.ruleForm));
        if (res.success) {
          this.$message("更新成功");
          this.getlist();
          this.handleClear()
        }
      }
    },
    async opebDetails(row) {
      this.isUpdate = true;
      let res = await reqSystemGetMissionById(row.id);
      this.ruleForm.subject = res.result.subject;
      this.ruleForm.claim_Name = res.result.claim_Name;
      this.ruleForm.displayName = res.result.displayName;
      this.ruleForm.description = res.result.description;
      this.ruleForm.claim_Value = res.result.claim_Value;
      this.ruleForm.claim_Type = res.result.claim_Type;
      this.ruleForm.super_Type = res.result.super_Type;
      this.ruleForm.sub_Type = res.result.sub_Type;
      this.ruleForm.issuer = res.result.issuer;
      this.ruleForm.isDisplay = res.result.isDisplay;
      this.ruleForm.id = res.result.id;
    },
    async onDelete() {
      let res = await reqSystemDelete(this.ruleForm.id);
      if (res.success) {
        this.$message("删除成功");
        this.getlist();
        this.handleClear()
      }
    },
    handleClear(){
      for(var key in this.ruleForm){
              this.ruleForm[key]="" 
           }    
    }
  },

  created() {
    this.getlist();
  }
};
</script>




