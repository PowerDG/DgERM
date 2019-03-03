<style scoped lang="less">
.forwarder {
  box-sizing: border-box;
  min-width:1750px ;
  .forwarder_inner {
    background: #fff;
    border-radius: 10px;
    padding: 10px;
    .mylabel,.mylabel1{
      display: inline-block;
      background: #67c23a;
      padding:9px 15px;
      font-size: 12px;
      color:#fff;
      border-radius: 4px;
      line-height: 1;
      text-align: center;
      outline: none;
    }
  }
  
}
</style>
<style lang="less">
.forwarder {
  .el-input__inner {
    border: 0;
    border-bottom: 1px;
    border-color: #c9c9c9;
    border-style: solid;
    border-radius: 0;
    padding: 0;
  }
  .el-table--small td{padding:4px;}
  .el-table thead{font-size:15px;color:#232323}
}
 
</style>

<template>
  <div class="forwarder">
    <div class="forwarder_inner">
      <el-row style="margin-bottom:20px">
        <el-col :span="3" :offset="3"  >
          <span style="font-size:14px">快递商名字</span>
          <el-input v-model="expressName" style="width:115px;padding-left:12px"></el-input>
        </el-col>
        <el-col :span="4">
          <span style="padding-right:10px;font-size:14px">是否启用</span>
          <el-select v-model="selected" placeholder="请选择">
            <el-option
              v-for="item in options"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-col>
        <el-col :span="12">
          <el-button type="primary" @click="onSubmit" style="margin-right:20px">查询</el-button>
          <el-button type="success" @click="onUpdate" style="margin-right:20px">更新</el-button>
          <el-button type="success" style="margin-right:20px" @click="kuaidiexport">快递查价导出</el-button>
          <label for="upLoad" class="mylabel">快递查价导入</label>
          <input type="file"  id="upLoad"  @change="kuaidiimportchange" style="display:none">
          <el-button type="success" style="margin:0 30px" @click="wuliuiexport">物流查价导出</el-button>
           <label for="upLoad1" class="mylabel1">物流查价导入</label>
          <input type="file"  id="upLoad1"  @change="wuliuimportchange" style="display:none">
        </el-col>
      </el-row>
      <el-table
        :data="tablelist"
        style="width:100%;"
        stripe
        border
      >
        <el-table-column  prop="expressNo" label="快递商编号"></el-table-column>
        <el-table-column  prop="expressName" label="快递商名字"></el-table-column>
        <el-table-column  prop="remark" label="备注"></el-table-column>
        <el-table-column  prop="isDefaultShow" label="是否启用">
          <template slot-scope="scope">
            <el-checkbox v-model="scope.row.isDefaultShow"></el-checkbox>
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
        style="margin-top:15px;text-align:center"
      ></el-pagination>
    </div>
  </div>
</template>
<script>
import { reqZBYSPagation, reqZBYSupdate,reqkuaidiexport,reqkuaidiimport,reqwuliuexport,reqwuliuimport } from "../../../api/index.js";
export default {
  data() {
    return {
      paginations: {
        total: 0,
        page_index: 1,
        page_size: 30,
        page_sizes: [10, 20, 30]
      },
      options: [
        {
          value: "",
          label: "全部"
        },
        {
          value: "false",
          label: "未启用"
        },
        {
          value: "true",
          label: "已启用"
        }
      ],
      selected: "",
      tablelist: [],
      expressName: "",
      list: []
    };
  },
  methods: {
    async getlist() {
      let res = await reqZBYSPagation(
        this.paginations.page_size,
        this.paginations.page_index,
        this.expressName,
        this.selected
      );
      this.tablelist = res.result.items;
      this.paginations.total = res.result.totalCount;
    },
    //页码变化方法
    async handleCurrentChange(page) {
      let res1 = await reqZBYSPagation(
        this.paginations.page_size,
        page,
        this.expressName,
        this.selected
      );
      this.tablelist = res1.result.items;
    },
    //一页多少条方法
    async handleSizeChange(page) {
      this.paginations.page_size = page;
      let res2 = await reqZBYSPagation(page,1,this.expressName,this.selected);
      this.paginations.page_index = 1;
      this.tablelist = res2.result.items;
    },
    async onSubmit() {
      var reg=/^[\u4E00-\u9FA5A-Za-z]+$/
      if(!reg.test(this.expressName)){
        this.$message('快递商名字有误')
      }else{
        let res = await reqZBYSPagation(
        this.paginations.page_size,
        this.paginations.page_index,
        encodeURI(this.expressName),
        this.selected
      );
        this.tablelist = res.result.items;
        this.paginations.total = res.result.totalCount;
      }
     
    },
    async onUpdate() {
      var arrstart = [];
      var arrend = [];
      for (var i = 0; i < this.tablelist.length; i++) {
        if (this.tablelist[i].isDefaultShow) {
          arrstart.push(this.tablelist[i].expressNo);
        } else {
          arrend.push(this.tablelist[i].expressNo);
        }
      }
      var obj = {};
      obj.ExpressNo_True = arrstart;
      obj.ExpressNo_False = arrend;

      let res = await reqZBYSupdate(JSON.stringify(obj));
      if (res.success) {
        this.$message("更新成功");
        this.getlist();
      }
    },
    kuaidiexport(){
         this.axios({
        method: "post",   
        // url:"http://"+window.location.host+"/api/Execl/api/Export",
        url: "http://localhost:21021/api/Execl/api/ExpressclOut",
        responseType: "blob"
      }).then(res => {
        // 处理返回的文件流
        const blob = new Blob([res.data]); //new Blob([res])中不加data就会返回下图中[objece objece]内容（少取一层）
        const fileName = "快递查价.xlsx"; //下载文件名称
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
    kuaidiimportchange(){
      var file = document.getElementById("upLoad").files[0];
      var form = new FormData();
      form.append('file',file);
       this.axios({
          method: "POST",
          url:"http://localhost:21021/api/Execl/api/ExpressInserExecl",
        
          //  headers:{
          //    'Content-type': 'application/x-www-form-urlencoded'
          // } ,
          data: form ,
          //  url:"http://"+window.location.host+"/api/services/app/BillInfoService/CheckBillInfo?billNo="+this.ruleForm.billNo,
        }).then(res => {
            console.log(res)
            if(res.data.success==true){
              this.$message('上传成功')
            }
        });
    },
    wuliuiexport(){
        this.axios({
        method: "post",   
        // url:"http://"+window.location.host+"/api/Execl/api/Export",
        url: "http://localhost:21021/api/Execl/api/PluexeclOut",
        responseType: "blob"
      }).then(res => {
        // 处理返回的文件流
        const blob = new Blob([res.data]); //new Blob([res])中不加data就会返回下图中[objece objece]内容（少取一层）
        const fileName = "物流查价.xlsx"; //下载文件名称
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
    wuliuimportchange(){
       var file = document.getElementById("upLoad1").files[0];
      var form = new FormData();
      form.append('file',file);
       this.axios({
          method: "POST",
          url:"http://localhost:21021/api/Execl/api/Insertexecl",

          data: form ,
          //  url:"http://"+window.location.host+"/api/services/app/BillInfoService/CheckBillInfo?billNo="+this.ruleForm.billNo,
        }).then(res => {
            if(res.data.success==true){
              this.$message('上传成功')
            }
        });
    }
  },
  created() {
    this.getlist();
  }
};
</script>




