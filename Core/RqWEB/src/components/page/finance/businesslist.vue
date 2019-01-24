<style lang="less" scoped >
.businesslist_right {
  background: #ffffff;
  border-radius: 15px;
  min-width: 1800px;
  .right_inner {
    padding: 10px;
  }
}
</style>

<style lang="less">
.businesslist {
  .el-table--small td {
    padding: 0 0;
  }
  .el-input__inner {
    border: 0;
    border-bottom: 1px;
    border-color: #c9c9c9;
    border-style: solid;
    border-radius: 0;
  }
  .my_checked .el-checkbox{
    margin-top:9px;
  }
}
</style>

<template>
  <div class="businesslist">
    <div class="businesslist_right">
      <div class="right_inner">
        <el-row style="margin:20px 0">
          <el-col :span="2" :offset="1" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">公司名称</span>
            <el-input style="width:88px" v-model="Companyquery"></el-input>
          </el-col>
          <el-col :span="2" :offset="1" class="my_checked">
               <el-checkbox v-model="checked">备选项</el-checkbox>
          </el-col>
          <el-col :span="3" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">目的地城市</span>
            <el-select placeholder="请选择" style="width:110px" v-model="ReceivingCity">
              <el-option
                v-for="item in citylist "
                :key="item.value"
                :label="item.id"
                :value="item.name"
              ></el-option>
            </el-select>
          </el-col>
          <el-col :span="3" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">快递公司</span>
            <el-select placeholder="请选择" style="width:88px" v-model="kuaidiinfo">
              <el-option
                v-for="item in kuaidilist "
                :key="item.value"
                :label="item.name"
                :value="item.id"
              ></el-option>
            </el-select>
          </el-col>
          <el-col :span="2" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">单号</span>
            <el-input style="width:88px;margin-left:8px" v-model="BillNo"></el-input>
          </el-col>
          <el-col :span="5" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">起始日期</span>
            <el-date-picker
              style="width:200px;margin-left:15px"
              v-model="date"
              type="daterange"
              range-separator="至"
              start-placeholder="开始日期"
              end-placeholder="结束日期"
            ></el-date-picker>
          </el-col>
          <el-col :span="4">
            <el-button type="primary" style="width:80px;margin-right:10px" @click="handlequery">查询</el-button>
            <el-button type="warning" @click="handleexport">导出EXCEL</el-button>
            <el-button type="success" style="width:80px" @click="handlejiesuan">结算</el-button>
          </el-col>
        </el-row>
        <el-table
          :data="tablelist"
          stripe
          @selection-change="handleSelectionChange"
          style="width:100%;border:1px solid #c2c2c2;margin-top:12px"
        >
          <el-table-column type="selection" width="55"></el-table-column>
          <el-table-column prop="creationTime" label="业务日期/时间" width="120"></el-table-column>
          <el-table-column prop="billNo" label="公司单号"></el-table-column>
          <el-table-column prop="shipperCity" label="出发地"></el-table-column>
          <el-table-column prop="receivingCity" label="目的地"></el-table-column>
          <el-table-column prop="content" label="类型"></el-table-column>
          <el-table-column prop="totalnumberofpackages" label="件数"></el-table-column>
          <el-table-column prop="totalweight" label="重量"></el-table-column>
          <el-table-column prop="volume" label="体积"></el-table-column>
          <el-table-column prop="delivery" label="提货费"></el-table-column>
          <el-table-column prop="distribution" label="送货费"></el-table-column>
          <el-table-column prop="transportationMode" label="物流费"></el-table-column>
          <el-table-column prop="transfer" label="中转费"></el-table-column>
          <el-table-column prop="upstairs" label="上楼费"></el-table-column>
          <el-table-column prop="pallet" label="托盘费"></el-table-column>
          <el-table-column prop="other_fees" label="其他费用"></el-table-column>
          <el-table-column prop="totaL_CHARGES" label="合计"></el-table-column>
          <el-table-column prop="tax_point" label="税点"></el-table-column>
          <el-table-column prop="the_cost" label="成本"></el-table-column>
          <el-table-column prop="remark" label="备注"></el-table-column>
          <el-table-column prop="has_return" label="是否有回单">
            <template slot-scope="scope">
              <el-checkbox v-model="scope.row.has_return"></el-checkbox>
            </template>
          </el-table-column>
        </el-table>
        <el-dialog
          title="业务清单"
          :visible.sync="dialogVisible"
          width="70%"
          :before-close="handleClose"
        >
          <div class="my_show" style="text-align:center">
            <span>合计总和:</span>
            <el-input v-model="countall" readonly style="width:200px"></el-input>
          </div>
          <div class="my_second" style="text-align:center">
            <span>成本总和:</span>
            <el-input v-model="chenbenall" readonly style="width:200px"></el-input>
          </div>

          <el-table
            :data="tablelist2"
            stripe
            @selection-change="handleSelectionChange2"
            style="width:100%;border:1px solid #c2c2c2;margin-top:12px"
          >
            <el-table-column type="selection" width="55"></el-table-column>
            <el-table-column prop="creationTime" label="业务日期/时间" width="120"></el-table-column>
            <el-table-column prop="billNo" label="公司单号"></el-table-column>
            <el-table-column prop="shipperCity" label="出发地"></el-table-column>
            <el-table-column prop="receivingCity" label="目的地"></el-table-column>
            <el-table-column prop="content" label="类型"></el-table-column>
            <el-table-column prop="totalnumberofpackages" label="件数"></el-table-column>
            <el-table-column prop="totalweight" label="重量"></el-table-column>
            <el-table-column prop="volume" label="体积"></el-table-column>
            <el-table-column prop="tax_point" label="税点"></el-table-column>
            <el-table-column prop="the_cost" label="成本"></el-table-column>
            <el-table-column prop="remark" label="备注"></el-table-column>
            <el-table-column prop="has_return" label="是否有回单">
              <template slot-scope="scope">
                <el-checkbox v-model="scope.row.has_return"></el-checkbox>
              </template>
            </el-table-column>
          </el-table>
          <span slot="footer" class="dialog-footer">
            <el-button @click="dialogVisible = false">取 消</el-button>
            <el-button type="primary" @click="dialogVisible = false">确 定</el-button>
          </span>
        </el-dialog>
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
  reqBussinessPagation, //表格分页
  reqHdCitySelectList,
  reqHdselectlist,
  reqBussinessEXCEL,
  reqBussinessid
} from "../../../api/index.js";
import { formatDate } from "../../../fiters/common.js";
export default {
  data() {
    return {
      dialogVisible: false,
      checked:"",
      kuaidiinfo: "", //快递公司
      ReceivingCity: "",
      Companyquery: "",
      BillNo: "",
      CreationTimeS: "",
      CreationTimeE: "",
      UserId: sessionStorage.getItem("userId"),
      date: "", //筛选条件日期
      paginations: {
        //分页相关条件
        total: 0,
        page_index: 1,
        page_size: 30,
        page_sizes: [10, 20, 30, 50, 100, 200, 500, 1000]
      },
      citylist: [],
      kuaidilist: [],
      chenbenall: 0,
      countall: 0,
      tablelist: [], //绑定表格数据
      tablelist2: [],
      arr:[],
      form: {
        companyAbbreviation: "",
        receivingCity: "",
        expressNo: "",
        billNo: null,
        creationTimeS: null,
        creationTimeE: null
      },
      creationTime: new Date(),
      fillDate: "",
      infomation: "",
      creatorUserId: sessionStorage.getItem("userId")
    };
  },
  methods: {
    handleClose(done) {
      this.$confirm("确认关闭？")
        .then(_ => {
          done();
        })
        .catch(_ => {});
    },
    //非弹窗全选
    async handleSelectionChange(val) {
      val.forEach((v)=>{
        this.arr.push(v.id)
      })
      this.tablelist2 = val;
      this.tablelist2.forEach(v => {
        this.countall += parseInt(v.totaL_CHARGES);
        this.chenbenall += parseInt(v.the_cost);
      });
    },
    //弹窗全选
    handleSelectionChange2(val) {},
    //表格分页
    async getHdtablelist() {
      let res = await reqBussinessPagation(
        this.paginations.page_index,
        this.paginations.page_size,
        this.kuaidiinfo,
        this.UserId,
        encodeURI(this.Companyquery),
        encodeURI(this.ReceivingCity),
        this.BillNo,
        this.CreationTimeS,
        this.CreationTimeE
      );

      res.result.items.forEach(value => {
        value.creationTime = formatDate(
          new Date(value.creationTime),
          "yyyy-MM-dd  hh:mm"
        );
        value.tax_point = value.tax_point == "0" ? "6%" : "10%";
      });

      this.tablelist = res.result.items;
      this.paginations.total = res.result.totalCount;
    },
    //页码变化方法
    async handleCurrentChange(page) {
      let res1 = await reqBussinessPagation(
        page,
        this.paginations.page_size,
        this.kuaidiinfo,
        this.UserId,
        encodeURI(this.Companyquery),
        encodeURI(this.ReceivingCity),
        this.BillNo,
        this.CreationTimeS,
        this.CreationTimeE
      );
      res1.result.items.forEach(value => {
        value.creationTime = formatDate(
          new Date(value.creationTime),
          "yyyy-MM-dd hh:mm"
        );
        value.tax_point = value.tax_point == "0" ? "6%" : "10%";
      });
      this.tablelist = res1.result.items;
      this.paginations.total = res1.result.totalCount;
    },
    //一页大小变化方法
    async handleSizeChange(page) {
      this.paginations.page_size = page;
      let res2 = await reqBussinessPagation(1, page,this.kuaidiinfo,
        this.UserId,
        encodeURI(this.Companyquery),
        encodeURI(this.ReceivingCity),
        this.BillNo,
        this.CreationTimeS,
        this.CreationTimeE);
      res2.result.items.forEach(value => {
        value.creationTime = formatDate(
          new Date(value.creationTime),
          "yyyy-MM-dd hh:mm"
        );
        value.tax_point = value.tax_point == "0" ? "6%" : "10%";
      });
      this.paginations.page_index = 1;
      this.tablelist = res2.result.items;
    },
    //导出EXCEL
    async handleexport() {
      if (this.CreationTimeS) {
        this.CreationTimeS = formatDate(
          new Date(this.date[0]),
          "yyyy-MM-dd hh:mm"
        );
        this.form.creationTimeS = this.CreationTimeS;
      }
      if (this.CreationTimeE) {
        this.CreationTimeE = formatDate(
          new Date(this.date[1]),
          "yyyy-MM-dd hh:mm"
        );
        this.form.creationTimeE = this.CreationTimeE;
      }
      if (this.BillNo) {
        this.form.billNo = this.BillNo;
      }

      if (this.Companyquery) {
        this.from.companyAbbreviation = this.Companyquery;
      }
      if (this.ReceivingCity) {
        this.form.receivingCity = this.ReceivingCity;
      }
      if (this.kuaidiinfo) {
        this.form.expressNo = this.kuaidiinfo;
      }
      this.axios({
        method: "post",   
        // url:"http://"+window.location.host+"/api/Execl/api/Export",
        url: "http://192.168.1.21:21021/api/Execl/api/Export",
        data: JSON.stringify(this.form),
        responseType: "blob"
      }).then(res => {
        // 处理返回的文件流
        const blob = new Blob([res.data]); //new Blob([res])中不加data就会返回下图中[objece objece]内容（少取一层）
        const fileName = "业务清单.xlsx"; //下载文件名称
        const elink = document.createElement("a");
        elink.download = fileName;
        elink.style.display = "none";
        elink.href = URL.createObjectURL(blob);
        document.body.appendChild(elink);
        elink.click();
        URL.revokeObjectURL(elink.href); // 释放URL 对象
        document.body.removeChild(elink);
      });
    },
    //筛选条件方法
    async handlequery() {
      if (this.CreationTimeS) {
        this.CreationTimeS = formatDate(
          new Date(this.date[0]),
          "yyyy-MM-dd hh:mm"
        );
      }
      if (this.CreationTimeE) {
        this.CreationTimeE = formatDate(
          new Date(this.date[1]),
          "yyyy-MM-dd hh:mm"
        );
      }
      let res = await reqBussinessPagation(
        this.paginations.page_index,
        this.paginations.page_size,
        this.kuaidiinfo,
        this.UserId,
        encodeURI(this.Companyquery),
        encodeURI(this.ReceivingCity),
        this.BillNo,
        this.CreationTimeS,
        this.CreationTimeE
      );
      res.result.items.forEach(value => {
        value.creationTime = formatDate(
          new Date(value.creationTime),
          "yyyy-MM-dd hh:mm"
        );
        value.tax_point = value.tax_point == "0" ? "6%" : "10%";
      });
      this.tablelist = res.result.items;
      this.paginations.total = res.result.totalCount;
    },
    //获取目的地城市下拉 快递下拉
    async getselectlist() {
      let res = await reqHdCitySelectList();
      this.citylist = res.result;
      let res1 = await reqHdselectlist();
      this.kuaidilist = res1.result;
    },
    async handlejiesuan(){
      this.dialogVisible=true;
      let res=await reqBussinessid(this.arr)
      if(res.result){
        this.$message('开票成功')
      }
    }
  },

  created() {
    this.getHdtablelist();
    this.getselectlist();
  }
};
</script>





