<style scoped lang="less">
.customer {
  display: flex;
  min-width: 1720px;
  .customer_left {
    width: 500px;
    background: #ffffff;
    padding: 10px 15px;
    border-radius: 10px;
  }
  .customer_right {
    width: calc(100% - 500px);
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
.cottt(@width;@pad:2px;@color:#303133) {
  width: @width;
  padding-left: @pad;
  color: @color;
}
.customer {
  .el-input__inner {
    border: 0;
    border-bottom: 1px;
    border-color: #c9c9c9;
    border-style: solid;
    border-radius: 0;
    padding: 0;
  }
  .el-form-item--mini.el-form-item {
    margin-bottom: 8px;
  }
  .el-form-item--small.el-form-item {
    margin-bottom: 15px;
  }
  .my_thirteen .el-radio {
    margin-left: 10px;
  }
  .my_time {
    .el-form-item__label {
      width: 120px;
      padding-left: 2px;
      color: #303133;
    }
    .el-input__inner {
      padding-left: 10px;
    }
    .el-input__prefix {
      left: -9px;
    }
  }
  .my_timer {
    .el-form-item__label {
      width: 120px;
      padding-left: 2px;
      color: #303133;
    }
    .el-input__inner {
      padding-left: 10px;
    }
    .el-input__prefix {
      left: -9px;
    }
  }
  

  .customer_left .el-form-item--small.el-form-item {
    margin-bottom: 18px;
  }
  .right_inner .el-table--small td {
    padding: 0 0;
  }
}
</style>
<template>
  <div class="customer">
    <div class="customer_left">
      <el-form :model="ruleForm"  :rules="rules" :label-position="labelPosition"  label-width="78px" ref="ruleForm">
        <el-row>
          <el-col :span="11" class="my_first">
            <el-form-item label="客户主键" prop="customerID" label-width="110px">
              <el-input v-model="ruleForm.customerID" @blur="handleBlur" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12" class="my_second">
            <el-form-item label="分公司编号" prop="branchID" label-width="110px">
              <el-input v-model="ruleForm.branchID" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12" class="my_third">
            <el-form-item label="客户简称" prop="companyAbbreviation"  label-width="110px">
              <el-input v-model="ruleForm.companyAbbreviation" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12" class="my_four">
            <el-form-item label="开票类型" prop="invoiceType">
              <el-radio v-model="ruleForm.invoiceType" label="1">普票</el-radio>
              <el-radio v-model="ruleForm.invoiceType" label="2">增票</el-radio>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="12" class="my_five">
            <el-form-item label="客户公司名称" prop="companyName" label-width="110px">
              <el-input v-model="ruleForm.companyName" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12" class="my_six">
            <el-form-item label="纳税识别号" prop="taxpayer_identification_number" label-width="110px">
              <el-input v-model="ruleForm.taxpayer_identification_number" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="24" class="my_serven">
            <el-form-item label="公司注册地址" prop="registered_address" label-width="110px"> 
              <el-input v-model="ruleForm.registered_address" style="width:350px"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="24" class="my_eight">
            <el-form-item class="my_address" prop="actual_Operating"  label="实际经营地址" label-width="103px">
              <el-input v-model="ruleForm.actual_Operating" style="width:350px;"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12" class="my_nine">
            <el-form-item label="开户银行" prop="opening_bank" label-width="110px">
              <el-input v-model="ruleForm.opening_bank" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12" class="my_ten">
            <el-form-item label="开户行账号" prop="bank_account_number" label-width="110px">
              <el-input v-model="ruleForm.bank_account_number" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="12" class="my_eleven">
            <el-form-item label="客户联系人名称" prop="primary_contact" label-width="110px">
              <el-input v-model="ruleForm.primary_contact" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12" class="my_twelve">
            <el-form-item label="客户联系电话" prop="primary_Tel" label-width="110px">
              <el-input v-model="ruleForm.primary_Tel" style="width:135px"></el-input>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="12" class="my_thirteen">
            <el-form-item label="客户联系人性别" prop="customerSex" style="width:250px" label-width="110px">
              <el-radio v-model="ruleForm.customerSex" label="1">男</el-radio>
              <el-radio v-model="ruleForm.customerSex" label="2">女</el-radio>
            </el-form-item>
          </el-col>
          <el-col :span="12" class="my_fourteen">
            <el-form-item label="客户传真号码" prop="customerFax" label-width="110px">
              <el-input v-model="ruleForm.customerFax" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="12" class="my_thirteen">
            <el-form-item label="客户邮政编码" prop="customerPostID" label-width="110px">
              <el-input v-model="ruleForm.customerPostID" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12" class="my_fourteen">
            <el-form-item label="客户电子邮件" prop="customerEmail" label-width="110px">
              <el-input v-model="ruleForm.customerEmail" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="12" class="my_thirteen">
            <el-form-item label="次要联系人" prop="secondary_contact" label-width="110px">
              <el-input v-model="ruleForm.secondary_contact" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12" class="my_secondlaary">
            <el-form-item label="次要联系人号码" prop="secondary_Tel" label-width="110px">
              <el-input v-model="ruleForm.secondary_Tel" style="width:110px"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="18" class="my_time">
            <el-form-item label="客户注册时间" prop="customerRegData" label-width="110px">
              <el-date-picker
                v-model="ruleForm.customerRegData"
                style="width:190px"
                type="datetime"
                placeholder="选择日期时间"
              ></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="18" class="my_timer">
            <el-form-item label="月结时间" prop="monthly_statement_of_time" label-width="110px">
              <el-date-picker
                style="width:190px"
                v-model="ruleForm.monthly_statement_of_time"
                type="datetime"
                placeholder="选择日期时间"
              ></el-date-picker>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12" class="my_thirteen">
            <el-form-item label="业务员编号" label-width="110px">
              <el-input v-model="ruleForm.merchandiserId" readonly  style="width:110px"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="12" class="my_secondlaary">
            <el-form-item label="业务员姓名" label-width="110px">
              <el-input v-model="ruleForm.merchandiserName" readonly   style="width:110px"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-form-item style="margin-top:30px;margin-left:120px">
          <el-button type="success" @click="submitForm('ruleForm')">立即创建</el-button>
          <el-button type="primary" @click="resetForm('ruleForm')">重置</el-button>
          <el-button @click="dialogVisible=true" type="danger">删除</el-button>
        </el-form-item>
        <el-dialog title="提示" :visible.sync="dialogVisible" width="30%" :before-close="handleClose">
          <span>你确定删除吗?</span>
          <span slot="footer" class="dialog-footer">
            <el-button @click="dialogVisible = false">取 消</el-button>
            <el-button type="primary" @click="handleDelete">确 定</el-button>
          </span>
        </el-dialog>
      </el-form>
    </div>
    <div class="customer_right">
      <div class="right_inner">
        <el-table
          :data="tablelist"
          border
          stripe
          ref="form"
          style="width: 100%"
          @row-click="opebDetails"
        >
          <el-table-column prop="customerID" label="客户信息主键"></el-table-column>
          <el-table-column prop="companyAbbreviation" label="客户简称"></el-table-column>
          <el-table-column prop="companyName" label="客户公司全称"></el-table-column>
          <el-table-column prop="primary_contact" label="客户联系人名称"></el-table-column>
          <el-table-column prop="customerEmail" label="客户电子邮件"></el-table-column>
          <el-table-column prop="customerRegData" label="客户注册时间"></el-table-column>
          <el-table-column prop="actual_Operating" label="实际经营地址"></el-table-column>
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
  reqHjKhinfo,
  reqKHGetById,
  reqKHUpadate,
  reqKHDelete,
  reqPagenation,
  reqKHexist
} from "../../../api/index.js";
import { formatDate } from "../../../fiters/common.js";
export default {
  data() {
    //分公司编号验证
    var branchIDRules = (rule, value, callback) => {
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("请输入分公司编号"));
      } else if (!myreg.test(value)) {
        callback(new Error("请输入正确的分公司编号"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    //客户简称验证
    var companyAbbreviationRules = (rule, value, callback) => {
      let myreg = /^[\u4e00-\u9fa5]{1,}$/;
      if (value == "") {
        callback(new Error("请输入客户简称"));
      } else if (!myreg.test(value)) {
        callback(new Error("请输入正确的客户简称"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    //开票类型验证
    var invoiceTypeRules = (rule, value, callback) => {
      if (value != "1" && value != "2") {
        callback(new Error("请选择开票类型"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    //客户公司名称验证
    var companyNameRules = (rule, value, callback) => {
      let myreg = /^[\u4e00-\u9fa5]{1,}$/;
      if (value == "") {
        callback(new Error("请输入客户公司名称"));
      } else if (!myreg.test(value)) {
        callback(new Error("请输入正确的客户公司名称"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    //纳税识别号验证
    var taxpayer_identification_numberRules = (rule, value, callback) => {
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("请输入纳税识别号"));
      } else if (!myreg.test(value)) {
        callback(new Error("请输入正确的纳税识别号"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    // //公司注册地址验证
    // var registered_addressRules = (rule, value, callback) => {
    //   let myreg = /^[\u4e00-\u9fa5]{1,}[A-Za-z1-9]*$/;
    //   if (value == "") {
    //     callback(new Error("请输入公司注册地址"));
    //   } else if (!myreg.test(value)) {
    //     callback(new Error("请输入正确的公司注册地址"));
    //   } else {
    //     callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
    //   }
    // };
    // //实际经营地址验证
    // var actual_OperatingRules = (rule, value, callback) => {
    //   let myreg = /^[\u4e00-\u9fa5]{1,}[A-Za-z1-9]*$/;
    //   if (value == "") {
    //     callback(new Error("请输入实际经营地址"));
    //   } else if (!myreg.test(value)) {
    //     callback(new Error("请输入正确的实际经营地址"));
    //   } else {
    //     callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
    //   }
    // };
    //开户银行验证
    var opening_bankRules = (rule, value, callback) => {
      let myreg = /^[\u4e00-\u9fa5]{1,}$/;
      if (value == "") {
        callback(new Error("请输入开户银行"));
      } else if (!myreg.test(value)) {
        callback(new Error("请输入正确的开户银行"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    //开户行账号验证
    var bank_account_numberRules = (rule, value, callback) => {
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("请输入开户行账号"));
      } else if (!myreg.test(value)) {
        callback(new Error("请输入正确的开户行账号"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    //客户联系人名称验证
    var primary_contactRules = (rule, value, callback) => {
      let myreg = /^[\u4e00-\u9fa5]{1,}$/;
      if (value == "") {
        callback(new Error("请输入客户联系人名称"));
      } else if (!myreg.test(value)) {
        callback(new Error("请输入正确的客户联系人名称"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    //客户联系电话验证
    var primary_TelRules = (rule, value, callback) => {
      let myreg1 = /^1\d{10}$/; //电话规则:区号+号码，区号以0开头，3位或4位号码由7位或8位数字组成区号与号码之间可以无连接符，也可以“-”连接
      let myreg2 = /^0\d{2,3}-?\d{7,8}$/;
      if (value == "") {
        callback(new Error("请输入客户联系电话或手机号"));
      } else if (!myreg1.test(value) && !myreg2.test(value)) {
        callback(new Error("请输入正确的客户联系电话或手机号"));
      } else {
        callback();
      }
    };
    //客户联系人性别验证
    var customerSexRules = (rule, value, callback) => {
      if (value != "1" && value != "2") {
        callback(new Error("请选择客户联系人性别"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    return {
      dialogVisible: false,
      isupdate: false,
      labelPosition: "right",
      paginations: {
        total: 0,
        page_index: 1,
        page_size: 30,
        page_sizes: [10, 20, 30]
      },
      form22: {
        customerID: ""
      },
      tablelist: [],
      ruleForm: {
        merchandiserId: sessionStorage.getItem("userId"),
        merchandiserName: localStorage.getItem("name"),
        customerID: "", //客户信息主键
        companyAbbreviation: "", //客户简称
        invoiceType: "", //开票类型
        companyName: "", //客户名称(客户公司全称[纳税]
        taxpayer_identification_number: "", //纳税识别号
        registered_address: "", //公司注册地址
        actual_Operating: "", //公司实际经营地址
        opening_bank: "", //开户银行
        bank_account_number: "", //开户行账号
        primary_contact: "", //客户联系人名称
        primary_Tel: "", //客户联系电话
        customerSex: "", //客户联系人性别
        customerFax: "", //客户传真号码
        customerPostID: "", //客户邮政编码
        customerEmail: "", //客户电子邮件
        secondary_contact: "", //次要联系人
        secondary_Tel: "", //次要联系人号码
        customerRegData: new Date(), //客户注册时间
        monthly_statement_of_time: new Date(), //月结时间
        branchID: "", //所属分公司(仓库编号)
        id: ""
      },
      rules: {
        //验证规则

        branchID: [{ validator: branchIDRules, trigger: "blur" }],
        companyAbbreviation: [
          { validator: companyAbbreviationRules, trigger: "blur" }
        ],
        invoiceType: [{ validator: invoiceTypeRules, trigger: "change" }],
        companyName: [{ validator: companyNameRules, trigger: "blur" }],
        taxpayer_identification_number: [
          { validator: taxpayer_identification_numberRules, trigger: "blur" }
        ],
        // registered_address: [
        //   { validator: registered_addressRules, trigger: "blur" }
        // ],
        // actual_Operating: [
        //   { validator: actual_OperatingRules, trigger: "blur" }
        // ],
        opening_bank: [{ validator: opening_bankRules, trigger: "blur" }],
        bank_account_number: [
          { validator: bank_account_numberRules, trigger: "blur" }
        ],
        primary_contact: [{ validator: primary_contactRules, trigger: "blur" }],
        primary_Tel: [{ validator: primary_TelRules, trigger: "blur" }],
        customerSex: [{ validator: customerSexRules, trigger: "change" }],
        primary_Tel: [{ validator: primary_TelRules, trigger: "blur" }]
      }
    };
  },
  methods: {
    handleBlur() {
      this.form22.customerID = this.ruleForm.customerID;
      var reg = /^\d{1,9}$/;
      if (!this.form22.customerID) {
        this.$message("客户主键不能为空哦!");
      } else if (!reg.test(this.form22.customerID)) {
        this.$message("客户主键只能为数字并且长度在1-9之间哦!");
      } else {
        this.axios({
          method: "POST",
          // url:"http://"+window.location.host+"/api/services/app/CustomerInfoService/CheckCusId?CustomerID="+this.form22.customerID,
          url:"http://localhost:21021/api/services/app/CustomerInfoService/CheckCusId?CustomerID=" +this.form22.customerID
        }).then(res => {
          if (res.data.result != null) {
            this.$message("该客户号主键已存在!!!");
          }
        });
      }
    },
    //获取用户表格的方法
    async getlist() {
      let res = await reqPagenation(
        this.paginations.page_index,
        this.paginations.page_size
      );

      res.result.items.forEach(value => {
        if (value.customerRegData) {
          value.customerRegData = formatDate(
            new Date(value.customerRegData),
            "yyyy-MM-dd hh:mm"
          );
        }
      });
      this.tablelist = res.result.items;
      this.paginations.total = res.result.totalCount;
    },
    //页码变化方法
    async handleCurrentChange(page) {
      let res1 = await reqPagenation(page, this.paginations.page_size);
      res1.result.items.forEach(value => {
        value.customerRegData = formatDate(
          new Date(value.customerRegData),
          "yyyy-MM-dd hh:mm"
        );
      });
      this.tablelist = res1.result.items;
    },
    //一页多少条方法
    async handleSizeChange(page) {
      this.paginations.page_size = page;
      let res2 = await reqPagenation(1, page);
      res2.result.items.forEach(value => {
        value.customerRegData = formatDate(
          new Date(value.customerRegData),
          "yyyy-MM-dd hh:mm"
        );
      });
      this.paginations.page_index = 1;
      this.tablelist = res2.result.items;
    },
    //删除用户信息的方法
    async handleDelete() {
      this.dialogVisible = false;
      let taskId = this.ruleForm.id;
      let res = await reqKHDelete(taskId);
      if (res.success) {
        this.$message("删除成功");
        this.getlist();
        this.$refs["ruleForm"].resetFields();
      }
    },
    submitForm(formName) {
      this.$refs[formName].validate(async valid => {
        if (valid) {
          if (this.isupdate == false) {
            let result1 = await reqHjKhinfo(JSON.stringify(this.ruleForm));
            if (result1.success) {
              if (result1.result == "该客户编号已存在") {
                this.$message("该客户编号已存在");
              } else {
                this.$message("添加成功");
                this.$refs["ruleForm"].resetFields();
                this.getlist();
              }
            }
          } else {
            let result2 = await reqKHUpadate(this.ruleForm);
            if (result2.success) {
              this.$message("更新成功");
              this.$refs["ruleForm"].resetFields();
              this.getlist();
            }
          }
        } else {
          console.log(err);
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    async opebDetails(row) {
      this.isupdate = true;
      this.ruleForm.id = row.id;
      let res = await reqKHGetById(row.id);
      const {
        customerID,
        actual_Operating,
        branchID,
        companyAbbreviation,
        companyName,
        customerEmail,
        customerFax,
        customerPostID,
        customerRegData,
        customerSex,
        id,
        invoiceType,
        monthly_statement_of_time,
        opening_bank,
        primary_Tel,
        primary_contact,
        registered_address,
        secondary_Tel,
        secondary_contact,
        taxpayer_identification_number,
        bank_account_number
      } = res.result;
      this.ruleForm.customerID = customerID;
      this.ruleForm.companyAbbreviation = companyAbbreviation;
      this.ruleForm.invoiceType = invoiceType;
      this.ruleForm.companyName = companyName;
      this.ruleForm.taxpayer_identification_number = taxpayer_identification_number;
      this.ruleForm.registered_address = registered_address;
      this.ruleForm.actual_Operating = actual_Operating;
      this.ruleForm.opening_bank = opening_bank;
      this.ruleForm.bank_account_number = bank_account_number;
      this.ruleForm.primary_contact = primary_contact;
      this.ruleForm.primary_Tel = primary_Tel;
      this.ruleForm.customerSex = customerSex;
      this.ruleForm.customerFax = customerFax;
      this.ruleForm.customerPostID = customerPostID;
      this.ruleForm.customerEmail = customerEmail;
      this.ruleForm.secondary_contact = secondary_contact;
      this.ruleForm.secondary_Tel = secondary_Tel;
      this.ruleForm.customerRegData = customerRegData;
      this.ruleForm.monthly_statement_of_time = monthly_statement_of_time;
      this.ruleForm.branchID = branchID;
    },
    handleClose(done) {
      this.$confirm("确认关闭？")
        .then(_ => {
          done();
        })
        .catch(_ => {});
    }
  },
  created() {
    this.getlist();
  }
};
</script>




