<style scoped lang="less">
.truckinfo {
  display: flex;
  .truckinfo_left {
    width: 524px;
    background: #ffffff;
    padding: 10px 15px;
    border-radius: 10px;
  }
  .truckinfo_right {
    width: calc(100% - 544px);
    box-sizing: border-box;
    padding-left: 22px;
    .truckinfo_inner {
      background: #fff;
      padding: 10px;
      border-radius: 10px;
      max-height: 900px;
    }
  }
}
</style>
<style lang="less">
.truckinfo {
  .el-input__inner {
    border: 0;
    border-bottom: 1px;
    border-color: #c9c9c9;
    border-style: solid;
    border-radius: 0;
    padding: 0;
  }
  .el-input__prefix {
    left: 74px;
  }
}
</style>
<template>
  <div class="truckinfo">
    <div class="truckinfo_left">
      <el-form
        :model="ruleForm"
        label-width="120px"
        :label-position="labelPosition"
        ref="ruleForm"
        class="demo-ruleForm"
      >
        <el-form-item label="车辆信息表主键" prop="truckID" style="width:400px">
          <el-input v-model="ruleForm.truckID"></el-input>
        </el-form-item>
        <el-form-item label="车辆号码" prop="truckNum" style="width:400px">
          <el-input v-model="ruleForm.truckNum"></el-input>
        </el-form-item>
        <el-form-item label="车辆发动机号" prop="truckEngineNum" style="width:400px">
          <el-input v-model="ruleForm.truckEngineNum"></el-input>
        </el-form-item>
        <el-form-item label="车辆行驶证号" prop="truckRunNum" style="width:400px">
          <el-input v-model="ruleForm.truckRunNum"></el-input>
        </el-form-item>
        <el-form-item label="车辆保险单号" prop="truckInsuranceNum" style="width:400px">
          <el-input v-model="ruleForm.truckInsuranceNum"></el-input>
        </el-form-item>
        <!-- <el-form-item label="车辆型号" prop="tmid">
          <el-select v-model="ruleForm.tmid" style="width:280px">
            <el-option
              v-for="item in selectlist"
              :key="item.index"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item> -->
        <el-form-item label="车辆颜色" prop="truckColor" style="width:400px">
          <el-input v-model="ruleForm.truckColor"></el-input>
        </el-form-item>
        <el-form-item label="车辆照片url" prop="truckPhoto" style="width:400px">
          <el-input v-model="ruleForm.truckPhoto"></el-input>
        </el-form-item>
        <el-form-item label="车辆购买时间" prop="truckBuyData">
          <el-date-picker
            style="width:280px"
            v-model="ruleForm.truckBuyData"
            type="datetime"
            placeholder="选择日期时间"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="车辆状态" prop="truckIsVacancy">
          <el-radio-group v-model="ruleForm.truckIsVacancy">
            <el-radio :label="0">空闲</el-radio>
            <el-radio :label="1">在途</el-radio>
            <el-radio :label="2">维修</el-radio>
          </el-radio-group>
        </el-form-item>
        <label class="el-form-item__label" style="width: 80px;">上传图片</label>
        <!--elementui的上传图片的upload组件-->
        <el-upload
          class="upload-demo"
          :before-upload="beforeupload"
          drag
        
          style="margin-left:80px;"
        >
          <i class="el-icon-upload"></i>
          <div class="el-upload__text">
            将文件拖到此处，或
            <em>点击上传</em>
          </div>
          <!--<div class="el-upload__tip" slot="tip">只能上传jpg/png文件，且不超过500kb</div>-->
        </el-upload>
        <div style="width:100%;overflow: hidden;margin-left:150px;">
          <img :src="src" alt style="width:100%;">
        </div>
        <el-form-item>
          <el-button type="success" @click="onSubmit">立即创建</el-button>
          <el-button type="primary" @click="resetForm('ruleForm')">重置</el-button>
          <el-button @click="deletcustome" type="danger">删除</el-button>
        </el-form-item>
      </el-form>
    </div>
    <div class="truckinfo_right">
      <div class="truckinfo_inner">
        <el-table :data="tablelist" border stripe @row-click="opebDetails">
          <el-table-column prop="truckNum" label="车辆信息主键"></el-table-column>
          <el-table-column prop="truckEngineNum" label="车牌号"></el-table-column>
          <el-table-column prop="truckRunNum" label="车辆型号"></el-table-column>
          <el-table-column prop="truckIsVacancy" label="车辆颜色"></el-table-column>
          <el-table-column prop="truckEngineNum" label="车辆购买时间"></el-table-column>
          <el-table-column prop="truckRunNum" label="车辆隶属分公司名称"></el-table-column>
          <el-table-column prop="truckIsVacancy" label="车辆状态"></el-table-column>
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
import { reqHjCLinfo, reqCLUpdate,reqCLGetPagedTask } from "../../../api/index.js";
export default {
  data() {
    return {
      paginations: {
        total: 0,
        page_index: 1,
        page_size: 30,
        page_sizes: [10, 20, 30]
      },
      TruckID:"",
      TruckNum:'',
      TruckEngineNum:'',
      TruckRunNum:'',
      TruckInsuranceNum:"",
      TMID:'',
      TruckColor:"",
      TruckPhoto:"",
      TruckBuyData:"",
      BranchID:'',
      TruckIsVacancy:"",
      uploadForm: "",
      flag: false,
      src: "",
      selectlist: [{ value: 1, label: "奔驰" }, { value: 2, label: "法拉利" }], //下拉框列表
      formlist: {}, //当前行的表单列表
      tablelist: [], //所有表格数据
      labelPosition: "left", //label定位属性
      ruleForm: {
        truckID: "",
        truckNum: "",
        truckEngineNum: "",
        truckRunNum: "",
        truckInsuranceNum: "",
        tmid: "10086",
        truckColor: "",
        truckPhoto: "",
        truckBuyData: "",
        truckIsVacancy: "",
        truckID: "",
        branchID: 1111,
        id: 111,
        // pageIndex:"",
        // pageSize:"",
        truckPhoto: ""
        // file:""
      }
    };
  },
  methods: {
  //表格分页
      async getCltablelist() {
         let res = await reqCLGetPagedTask(
            this.TruckID,
            this.paginations.page_index,
            this.paginations.page_size,
            this.TruckNum,
            this.TruckEngineNum,
            this.TruckRunNum,
            this.TruckInsuranceNum,
            this.TMID,
            this.TruckColor,
            this.TruckPhoto,
            this.TruckBuyData,
            this.BranchID,
            this.TruckIsVacancy,
           );
            this.tablelist = res.result.items;
            this.paginations.total = res.result.totalCount;
      },
    async onSubmit() {
      if (this.flag == false) {
        let res = await reqHjCLinfo(this.ruleForm);
        if(res.success){
          this.$message('新建成功')
          this.getCltablelist()
        }
      } else {
      }
    }
  },
  created() {
    this.getCltablelist()
  }
};
</script>



