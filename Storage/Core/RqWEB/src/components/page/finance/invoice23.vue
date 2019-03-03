<style lang="less" scoped>
.components-container {
  display: flex;
  min-width: 1782px;
  .editor_left {
    width: 500px;
    background: #ffffff;
    padding: 10px 15px;
    border-radius: 10px;
  }
  .editor_right {
    width: calc(100% - 500px);
    box-sizing: border-box;
    padding-left: 22px;
    .right_inner {
      background: #fff;
      padding: 20px;
      border-radius: 10px;
      max-height: 1400px;
    }
  }
  .clearfix:after{
     display: block;
     content:"";
     clear:both;
  }
}
</style>
<style lang="less">
.components-container {
  .el-input__inner {
    border: 0;
    border-bottom: 1px;
    border-color: #c9c9c9;
    border-style: solid;
    border-radius: 0;
    padding: 0;
  }
  .el-button--small {
       width: 100px;
       height: 35px;
       border-radius: 7px;
       margin-right: 30px;
     }
  .el-input__prefix {
       left: -1111111111111111111111111px;
     }
}


</style>


<template>
  <div class="components-container">
    <div class="editor_left">
      <el-table :data="tablelist" border stripe ref="form" @row-click="opebDetails">
        <el-table-column prop="afficheTitle" label="标题"></el-table-column>
        <el-table-column prop="afficheData" label="时间"></el-table-column>
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
    <div class="editor_right">
      <div class="right_inner">
        <div class="editor-title">


          <el-form :model="ruleForm" ref="ruleForm" class="demo-ruleForm">
            <el-row style="padding-top:10px;margin-bottom:18px">
              <el-col :span="16" class="my_first clearfix"  >
                <el-form-item label="标题" prop="shipperAccount_No">
                  <el-input v-model="ruleForm.afficheTitle" style="width:655px"></el-input>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row style="margin-bottom:18px">
              <el-col :span="5" class="my_second">
                <el-form-item label="排序权重" prop="companyAbbreviation">
                  <el-input v-model="ruleForm.sorting" style="width:135px"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="6" class="my_third">
                <el-form-item label="时间" prop="companyAbbreviation">
                  <el-date-picker
                    v-model="ruleForm.afficheData"
                    type="datetime"
                    placeholder="选择日期时间"
                  ></el-date-picker>
                </el-form-item>
              </el-col>
              <el-col :span="13" class="my_four">
                <el-button type="success" @click="handleClick">提交</el-button>
                <el-button type="success" @click="removeCreate">清空新建</el-button>
                <el-button type="danger" @click="dialogVisible=true">删除</el-button>
              </el-col>
            </el-row>
            <el-dialog
              title="提示"
              :visible.sync="dialogVisible"
              width="30%"
              :before-close="handleClose"
            >
              <span>你确定删除吗?</span>
              <span slot="footer" class="dialog-footer">
                <el-button @click="dialogVisible = false">取 消</el-button>
                <el-button type="primary" @click="handleDelete">确 定</el-button>
              </span>
            </el-dialog>
          
          
          
          </el-form>
        
          <el-form :model="itemForm" ref="itemForm" class="demo-ruleForm">
            <el-row style="padding-top:10px;margin-bottom:18px">
              <!-- <el-col :span="6" class="my_first"  >
                <el-form-item label="发票" prop="shipperAccount_No">
                  <el-input v-model="itemForm.InvoiceNo" style="width:120px"></el-input>
                </el-form-item>
              </el-col>       -->
              <el-col :span="4" class="my_first">
                 <el-form-item label="事项" prop="shipperAccount_No">
                  <el-input v-model="itemForm.goods" style="width:160px"></el-input>
                </el-form-item>
              </el-col> 
                <el-col :span="5" class="my_second">
                <el-form-item label="型号" prop="companyAbbreviation">
                  <el-input v-model="itemForm.Specifications" style="width:120px"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="6" class="my_third">
                <el-form-item label="单位" prop="companyAbbreviation">
                  <el-input v-model="itemForm.Unit" style="width:80px"></el-input>
                </el-form-item>
              </el-col>

            </el-row>
            <el-row style="margin-bottom:18px">
              <el-col :span="3" class="my_four">
                <el-form-item label="数量" prop="companyAbbreviation">
                  <el-input v-model="itemForm.Qty" style="width:60px"></el-input>
                </el-form-item>
              </el-col>
                <el-col :span="6" class="my_five">
                 <el-form-item label="单价" prop="companyAbbreviation">
                  <el-input v-model="itemForm.Unit_Price" style="width:80px"></el-input>
                </el-form-item> 
              </el-col>
                <el-col :span="6" class="my_six">
                 <el-form-item label="金额" prop="companyAbbreviation">
                  <el-input v-model="itemForm.Amount" style="width:60px"></el-input>
                </el-form-item>
              </el-col>  
                <el-col :span="5" class="my_serven">
                <el-form-item label="税率" prop="companyAbbreviation">
                  <el-input v-model="itemForm.TaxRate" style="width:50px"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="6" class="my_eight">
                <el-form-item label="税额" prop="companyAbbreviation">
                  <el-input v-model="itemForm.TaxAmount" style="width:90px"></el-input>
                </el-form-item>
              </el-col> 
          
            </el-row>
              
            <el-row style="margin-bottom:18px">
              <el-col :span="13" class="my_four">
                <el-button type="success" @click="handleClick2">提交</el-button>
                <el-button type="success" @click="removeCreate2">清空新建</el-button>
                <el-button type="danger" @click="dialogVisible=true">删除</el-button>
              </el-col>
            </el-row>
            <el-dialog
              title="提示"
              :visible.sync="dialogVisible"
              width="30%"
              :before-close="handleClose"
            >
              <span>你确定删除吗?</span>
              <span slot="footer" class="dialog-footer">
                <el-button @click="dialogVisible = false">取 消</el-button>
                <el-button type="primary" @click="handleDelete">确 定</el-button>
              </span>
            </el-dialog>
          
          
          
          </el-form>
        
        
        </div>
        <div class="editor-container">
          <UE :config="config" ref="ue"></UE>
        </div>
      </div>
    
       
    
    </div>
  </div>
</template>

<script>
import UE from "../../common/UE.vue";
import {
  reqUEd,
  reqNewsPagation,
  reqNesGetById,
  reqNewUpdate,
  reqNewDelete,


  reqInvoiceItemCreate,
  reqInvoiceItemsPagation,
  reqInvoiceItemsGetById,
  reqInvoiceItemUpdate,
  reqInvoiceItemDelete,


    reqInvoiceCreate,
  reqInvoicesPagation,
  reqInvoicesGetById,
  reqInvoiceUpdate,
  reqInvoiceDelete

  
} from "../../../api/index.js";
import { formatDate } from "../../../fiters/common.js";
export default {
  components: { UE },
  data() {
    return {
      dialogVisible: false,
      isupdate: false,
      config: {
        initialFrameWidth: null,
        initialFrameHeight: 750,
        focus: true
      },
      ruleForm: {
        InvoiceNo: "",
        id: "",
        userID: localStorage.getItem("userId"),
        claime_Type: "",
        super_Type: "DefaultValue",
        claim_Name: "DefaultValue",
        afficheTitle: "",
        afficheContent: "",
        afficheData: "",
        branchID: localStorage.getItem("userId"),
        typeName: "Default",
        status: 0,
        sorting: 50,
        pageIndex: 0,
        pageSize: 0
      },
      itemForm: {
        id: 0,
        InvoiceNo: 0,
        InvoiceItemNo: 0,
        goods: "",
        Specifications: "",
        Unit: "",
        Qty: 1,
        Unit_Price: 1,
        Amount: 1,
        TaxRate: 100,
        TaxAmount: 1,
        // InvoiceNo：""，
        // userID: localStorage.getItem("userId"),
        claime_Type: "DefaultValue",
        // super_Type: "DefaultValue",
        claim_Name: "DefaultValue",
        // afficheTitle: "",
        // afficheContent: "",
        // afficheData: "",
        // branchID: localStorage.getItem("userId"),
        // typeName: "Default",
        status: 0,
        sorting: 50,
        pageIndex: 0,
        pageSize: 0
      },


      paginations: {
        total: 0,
        page_index: 1,
        page_size: 20,
        page_sizes: [10, 20, 30]
      },

     
      tablelist: []
      // Id:"",
      // UserID:"",
      // Claime_Type:"",
      // Super_Type:"",
      // Claim_Name:"",
      // AfficheTitle:"",
      // AfficheContent:"",
      // AfficheData:"",
      // BranchID:"",
      // TypeName:"",
      // Status:"",
      // Sorting:"",
    };
  },
  methods: {
    //获取用户表格的方法
    async getlist() {
      let res = await reqNewsPagation(
        this.paginations.page_index,
        this.paginations.page_size
      );
      res.result.items.forEach(value => {
        if (value.afficheData) {
          value.afficheData = formatDate(
            new Date(value.afficheData),
            "yyyy-MM-dd hh:mm"
          );
        }
      });
      this.tablelist = res.result.items;
      this.paginations.total = res.result.totalCount;
    },
    //页码变化方法
    async handleCurrentChange(page) {
      let res = await reqNewsPagation(page, this.paginations.page_size);
      res.result.items.forEach(value => {
        value.afficheData = formatDate(
          new Date(value.afficheData),
          "yyyy-MM-dd hh:mm"
        );
      });
      this.tablelist = res.result.items;
    },
    //一页大小变化方法
    async handleSizeChange(page) {
      this.paginations.page_size = page;
      let res2 = await reqNewsPagation(1, page);
      this.paginations.page_index = 1;
      this.tablelist = res2.result.items;
    },
    async handleClick() {
      if (this.isupdate == false) {
        let content = this.$refs.ue.getUEContent();
        this.ruleForm.afficheContent = content;
        this.ruleForm.claime_Type = this.ruleForm.afficheTitle;
        let res = await reqUEd(JSON.stringify(this.ruleForm));
        if (res.success) {
          this.$message("提交成功");
          this.getlist();
          this.deleteMethods();
        }
      } else {
        let res = await reqNewUpdate(JSON.stringify(this.ruleForm));
        if (res.success) {
          this.$message("更新成功");
          this.getlist();
          this.deleteMethods();
        }
      }
    },

    async handleClick2() {
          console.log(111)
      if (this.isupdate == false) {
        // let content = this.$refs.ue.getUEContent();
        // this.ruleForm.afficheContent = content;
        // this.ruleForm.claime_Type = this.ruleForm.afficheTitle;
          console.log("提交中")
          
          console.log(this.itemForm)
        let res = await reqInvoiceItemCreate(JSON.stringify(this.itemForm));
        if (res.success) {
          this.$message("提交成功");
          this.getlist();
          this.deleteMethods2();
        }
      } else {console.log("更新中")
        let res = await reqInvoiceItemUpdate(JSON.stringify(this.itemForm));
        if (res.success) {
          this.$message("更新成功");
          this.getlist();
          this.deleteMethods2();
        }
      }
    },
    async opebDetails(row) {
      this.isupdate = true;
      let res = await reqNesGetById(row.id)
      console.log(res)
      this.ruleForm.id = res.result.id;
      this.ruleForm.afficheTitle = res.result.afficheTitle;
      this.ruleForm.sorting = res.result.sorting;
      this.ruleForm.afficheData = res.result.afficheData;
      this.$refs.ue.setUEContent(res.result.afficheContent);
    },
    async handleDelete() {
      this.dialogVisible = false;
      console.log(this.ruleForm.id);
      let res = await reqNewDelete(this.ruleForm.id);
      console.log(res)
      if (res.success) {
        this.$message("删除成功");
        this.getlist()
        this.deleteMethods();
      }
    }, 
    async handleDelete2() {
      this.dialogVisible = false;
      console.log(this.ruleForm.id);
      let res = await reqNewDelete(this.ruleForm.id);
      console.log(res)
      if (res.success) {
        this.$message("删除成功");
        this.getlist2()//需要改
        this.deleteMethods2();
      }
    }, 
    //清空新建的方法
    removeCreate(){
        this.isupdate=false;
        this.deleteMethods();
    },removeCreate2(){
        this.isupdate=false;
        this.deleteMethods2();
    },  
    
    deleteMethods() {
      this.ruleForm.afficheTitle = "";
      this.ruleForm.sorting = "";
      this.ruleForm.afficheData = "";
      this.$refs.ue.setUEContent("");
    },deleteMethods2() {
      this.itemForm.goods = "";
      this.itemForm.Specifications = ""; 
      this.itemForm.Unit = ""; 
      this.itemForm.Qty = ""; 
      this.itemForm.Unit_Price = ""; 
      this.itemForm.Amount = ""; 
      this.itemForm.TaxRate = ""; 
      this.itemForm.TaxAmount = ""; 
      this.itemForm.Specifications = ""; 
      // this.$refs.ue.setUEContent("");
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

