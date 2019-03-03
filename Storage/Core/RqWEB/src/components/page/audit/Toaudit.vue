<style scoped lang="less">
.Toaudit {
  box-sizing: border-box;
  .Toaudit_inner {
    background: #fff;
    border-radius: 10px;
    padding: 10px;
  }
}
.clearfix::after{
  display: block;
  content:"";
  clear:both;
}
.main {
  .main_left {
    float: left;
    padding: 10px;
    border-radius: 10px;
    margin-right: 25px;
  }
  
  .main_right {
    float: left;
    padding: 10px;
    border-radius: 10px;
  }
 
}
.main1 {
  .main_left1 {
    float: left;
    padding: 10px;
    width: 45%;
    margin-left: 30px;
  }
  .main_left1:first-child{
    
    border-right: 1px solid #ccc;
  }
  .main_right1 {
    float: left;
    width: 50%;
  }

}
.Toaudit  .bottom_button{
    width: 200px;
    margin: 60px auto;
}
.Toaudit .el-form-item--small.el-form-item{
  margin-bottom:20px;
}

</style>
<style lang="less">
.Toaudit {
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
  .el-dialog {
    height: 760px;
    overflow-y: scroll;
  }
  .el-button--mini,
  .el-button--small {
    margin-right: 20px;
  }
  .el-radio + .el-radio {
    margin-left: 10px;
  }
  .el-input__prefix {
    left: -11111111111111px;
  }
}
</style>
<template>
  <div class="Toaudit">
    <div class="Toaudit_inner">
      <el-table :data="tablelist" style="width:100%;" stripe border @row-click="opebDetails">
        <el-table-column prop="sourceType" label="申请数据源类型" width="120px"></el-table-column>
        <el-table-column prop="sourceNo" label="申请数据源编号" width="140px"></el-table-column>
        <el-table-column prop="startDate" label="申请时间" width="120px"></el-table-column>
        <el-table-column prop="destinationNO" label="目的数据编号" width="140px"></el-table-column>
        <el-table-column prop="version" label="数据版本" width="120px"></el-table-column>
        <el-table-column prop="proposerName" label="申请发起人姓名" width="120px"></el-table-column>
        <el-table-column prop="inspectionState" label="审批状态,0-已申请 ,1-通过 ,2-驳回"></el-table-column>
        <el-table-column prop="inspectionName" label="审批人" width="120px"></el-table-column>
        <el-table-column prop="action" label="查看？修改？删除？"></el-table-column>
        <el-table-column prop="inspectionMemo" label="申请内容备注 "></el-table-column>
        <el-table-column prop="endDate" label="审批时间"></el-table-column>
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
      <el-dialog
        title="货票审核列表"
        :visible.sync="dialogVisible"
        width="70%"
        :before-close="handleClose"
      >
        <div class="main clearfix">
          <div class="main_left">
            <el-form
              :model="ruleForm1"
              ref="ruleForm1"
              :label-position="labelPosition"
              class="demo-ruleForm"
            >
              <el-collapse v-model="activeNames1" style="width:520px" @change="handleChange1">
                <el-collapse-item title="发件人资料 " name="1">
                  <hr style="color:#c9c9c9">
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="账号" prop="shipperAccount_No">
                        <el-input v-model="ruleForm1.shipperAccount_No" readonly style="width:55px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="客户简称" prop="companyAbbreviation">
                        <el-input
                          v-model="ruleForm1.companyAbbreviation"
                          readonly
                          style="width:58px"
                        ></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="运输方式" prop="transportationMode">
                        <el-select
                          v-model="ruleForm1.transportationMode"
                          disabled
                          style="width:75px"
                        >
                          <el-option
                            v-for="item in options1"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="姓名" prop="shipperName">
                        <el-input v-model="ruleForm1.shipperName" readonly style="width:50px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="单号" prop="billNo">
                        <el-input v-model="ruleForm1.billNo" readonly style="width:58px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="业务员" prop="merchandiserName">
                        <el-input v-model="ruleForm1.merchandiserName" readonly style="width:75px"></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="电话" prop="shipperTel">
                        <el-input v-model="ruleForm1.shipperTel" readonly style="width:80px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="合作快递" prop="expressNo">
                        <el-select
                          v-model="ruleForm1.expressNo"
                          readonly
                          style="width:85px"
                          disabled
                        >
                          <el-option
                            v-for="item in compnay"
                            :key="item.value"
                            :label="item.name"
                            :value="item.id"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="合作单号" prop="expressBillNo">
                        <el-input v-model="ruleForm1.expressBillNo" readonly style="width:88px"></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                </el-collapse-item>
                <el-collapse-item title="收件人资料" name="2">
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="账号" prop="receiversAccount_No">
                        <el-input
                          v-model="ruleForm1.receiversAccount_No"
                          readonly
                          style="width:60px"
                        ></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="公司" prop="receiversCompanyName">
                        <el-input
                          v-model="ruleForm1.receiversCompanyName"
                          readonly
                          style="width:75px"
                        ></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="省份/州" prop="shipperProvince">
                        <el-input v-model="ruleForm1.shipperProvince" readonly style="width:60px"></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="姓名" prop="receiversName">
                        <el-input v-model="ruleForm1.receiversName" readonly style="width:55px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="邮编" prop="receivingPostCode">
                        <el-input v-model="ruleForm1.receivingPostCode" readonly style="width:75px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="城市名" prop="receivingCity">
                        <el-input v-model="ruleForm1.receivingCity" readonly style="width:65px"></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="电话" prop="receivingTel">
                        <el-input v-model="ruleForm1.receivingTel" readonly style="width:100px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="13">
                      <el-form-item label="详细地址" prop="receivingAddress">
                        <el-input v-model="ruleForm1.receivingAddress" readonly style="width:200px"></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                </el-collapse-item>
                <el-collapse-item title="尺寸与重量与货物说明" name="3">
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="总件数" prop="totalnumberofpackages">
                        <el-input
                          v-model="ruleForm1.totalnumberofpackages"
                          readonly
                          style="width:55px"
                        ></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="总重量" prop="totalweight">
                        <el-input v-model="ruleForm1.totalweight" readonly style="width:58px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="体积" prop="volume">
                        <el-input v-model="ruleForm1.volume" style="width:80px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="计重比例" prop="measurementrules">
                        <el-select
                          v-model="ruleForm1.measurementrules"
                          placeholder="请选择"
                          style="width:74px"
                          disabled
                        >
                          <el-option
                            v-for="item in options2"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="体积重量" prop="volume_weight">
                        <el-input v-model="ruleForm1.volume_weight" readonly style="width:75px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="计费重量" prop="chargeableweight">
                        <el-input v-model="ruleForm1.chargeableweight" readonly style="width:70px"></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="7">
                      <el-form-item label="货值" prop="value">
                        <el-input v-model="ruleForm1.value" readonly style="width:70px"></el-input>
                      </el-form-item>
                    </el-col>

                    <el-col :span="11">
                      <el-form-item label="是否投保" prop="hasInsured">
                        <el-radio-group v-model="ruleForm1.hasInsured ">
                          <el-radio :label="true" style=" color:#c9c9c9;" disabled>投保</el-radio>
                          <el-radio :label="false" style=" color:#c9c9c9;" disabled>不投保</el-radio>
                        </el-radio-group>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="24">
                      <el-form-item label="交运货品详细说明" prop="content">
                        <el-input v-model="ruleForm1.content" readonly style="width:340px"></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                </el-collapse-item>
                <el-collapse-item title="服务与运费支付" name="4">
                  <el-row style="padding-top:10px">
                    <el-col :span="13">
                      <el-form-item label="是否回单" prop="has_return">
                        <el-radio-group v-model="ruleForm1.has_return">
                          <el-radio :label="true" style=" color:#c9c9c9;" disabled>回单</el-radio>
                          <el-radio :label="false" style=" color:#c9c9c9;" disabled>不回单</el-radio>
                        </el-radio-group>
                      </el-form-item>
                    </el-col>
                    <el-col :span="11">
                      <el-form-item label="服务类别" prop="servicelevel">
                        <el-select
                          v-model="ruleForm1.servicelevel"
                          placeholder="请选择"
                          style="width:90px"
                          disabled
                        >
                          <el-option
                            v-for="item in options3"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="7">
                      <el-form-item label="收货期间" prop="receivingdates">
                        <el-select
                          v-model="ruleForm1.receivingdates "
                          placeholder="请选择"
                          style="width:70px"
                          disabled
                        >
                          <el-option
                            v-for="item in options4"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="支付方" prop="paymentType">
                        <el-select
                          v-model="ruleForm1.paymentType"
                          placeholder="请选择"
                          style="width:70px"
                          disabled
                        >
                          <el-option
                            v-for="item in options5"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="支付方式" prop="charges">
                        <el-select
                          v-model="ruleForm1.charges"
                          placeholder="请选择"
                          style="width:75px"
                          disabled
                        >
                          <el-option
                            v-for="item in options6"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="运输费" prop="transportation">
                        <el-input v-model="ruleForm1.transportation" style="width:55px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="其他">
                        <el-input v-model="ruleForm1.other" style="width:65px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="税点" prop="tax_point">
                        <el-select
                          v-model="ruleForm1.tax_point"
                          placeholder="请选择"
                          style="width:70px"
                          disabled
                        >
                          <el-option
                            v-for="item in options7"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="送货费">
                        <el-input v-model="ruleForm1.distribution" style="width:55px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="提货费">
                        <el-input v-model="ruleForm1.delivery" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="中转费">
                        <el-input v-model="ruleForm1.transfer" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="包装费">
                        <el-input v-model="ruleForm1.packing" style="width:55px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="托盘费">
                        <el-input v-model="ruleForm1.pallet" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="上楼费">
                        <el-input v-model="ruleForm1.upstairs" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="其他费用">
                        <el-input v-model="ruleForm1.other_fees" style="width:55px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="成本">
                        <el-input v-model="ruleForm1.the_cost" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="总计">
                        <el-input v-model="ruleForm1.total_CHARGES" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="24">
                      <el-form-item label="备注">
                        <el-input v-model="ruleForm1.remark" style="width:390px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                </el-collapse-item>
                <el-collapse-item title="其他" name="5">
                  <div
                    class="imgload"
                    style="padding-bottom:15px"
                    v-for="(item,index) in images"
                    :key="index"
                  >
                    <label for="upLoad" class="mylabel">{{item.name}}</label>
                    <input type="file" @change="changeImg" id="upLoad" style="display:none">
                    <img
                      src="../../../assets/img/07.png"
                      alt
                      style="width:25px;height:25px;z-index:10000000000"
                      v-if="!item.name"
                      class="my_img"
                      @click="addimages()"
                    >
                    <img
                      src="../../../assets/img/删除.png"
                      alt
                      style="width:18px;height:18px;z-index:10000000000"
                      v-else
                      class="my_img"
                      @click="removeimages(index)"
                    >
                  </div>
                </el-collapse-item>
              </el-collapse>
            </el-form>
          </div>
          <div class="main_right">
            <el-form
              :model="ruleForm2"
              ref="ruleForm2"
              :label-position="labelPosition"
              class="demo-ruleForm"
            >
              <el-collapse v-model="activeNames2" style="width:520px" @change="handleChange2">
                <el-collapse-item title="发件人资料 " name="1">
                  <hr style="color:#c9c9c9">
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="账号" prop="shipperAccount_No">
                        <el-input v-model="ruleForm2.shipperAccount_No" style="width:55px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="客户简称" prop="companyAbbreviation">
                        <el-input
                          v-model="ruleForm2.companyAbbreviation"
                          style="width:58px"
                          readonly
                        ></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="运输方式" prop="transportationMode">
                        <el-select v-model="ruleForm2.transportationMode" style="width:75px">
                          <el-option
                            v-for="item in options1"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                            disabled
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="姓名" prop="shipperName">
                        <el-input v-model="ruleForm2.shipperName" style="width:50px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="单号" prop="billNo">
                        <el-input v-model="ruleForm2.billNo" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="业务员" prop="merchandiserName">
                        <el-input v-model="ruleForm2.merchandiserName" style="width:75px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="电话" prop="shipperTel">
                        <el-input v-model="ruleForm2.shipperTel" style="width:80px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="合作快递" prop="expressNo">
                        <el-select v-model="ruleForm2.expressNo" style="width:85px">
                          <el-option
                            v-for="item in compnay"
                            :key="item.value"
                            :label="item.name"
                            :value="item.id"
                            disabled
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="合作单号" prop="expressBillNo">
                        <el-input v-model="ruleForm2.expressBillNo" style="width:88px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                </el-collapse-item>
                <el-collapse-item title="收件人资料" name="2">
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="账号" prop="receiversAccount_No">
                        <el-input
                          v-model="ruleForm2.receiversAccount_No"
                          style="width:60px"
                          readonly
                        ></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="公司" prop="receiversCompanyName">
                        <el-input
                          v-model="ruleForm2.receiversCompanyName"
                          style="width:75px"
                          readonly
                        ></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="省份/州" prop="shipperProvince">
                        <el-input v-model="ruleForm2.shipperProvince" style="width:60px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="姓名" prop="receiversName" readonly>
                        <el-input v-model="ruleForm2.receiversName" style="width:55px"></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="邮编" prop="receivingPostCode">
                        <el-input v-model="ruleForm2.receivingPostCode" style="width:75px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="城市名" prop="receivingCity">
                        <el-input v-model="ruleForm2.receivingCity" style="width:65px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="电话" prop="receivingTel">
                        <el-input v-model="ruleForm2.receivingTel" style="width:100px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="13">
                      <el-form-item label="详细地址" prop="receivingAddress">
                        <el-input v-model="ruleForm2.receivingAddress" style="width:200px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                </el-collapse-item>
                <el-collapse-item title="尺寸与重量与货物说明" name="3">
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="总件数" prop="totalnumberofpackages">
                        <el-input
                          v-model="ruleForm2.totalnumberofpackages"
                          style="width:55px"
                          readonly
                        ></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="总重量" prop="totalweight">
                        <el-input v-model="ruleForm2.totalweight" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="体积" prop="volume">
                        <el-input v-model="ruleForm2.volume" style="width:80px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="计重比例" prop="measurementrules">
                        <el-select
                          v-model="ruleForm2.measurementrules"
                          placeholder="请选择"
                          style="width:74px"
                          disabled
                        >
                          <el-option
                            v-for="item in options2"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="体积重量" prop="volume_weight">
                        <el-input v-model="ruleForm2.volume_weight" style="width:75px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="计费重量" prop="chargeableweight">
                        <el-input v-model="ruleForm2.chargeableweight" style="width:70px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="7">
                      <el-form-item label="货值" prop="value">
                        <el-input v-model="ruleForm2.value" style="width:70px" readonly></el-input>
                      </el-form-item>
                    </el-col>

                    <el-col :span="11">
                      <el-form-item label="是否投保" prop="hasInsured">
                        <el-radio-group v-model="ruleForm2.hasInsured ">
                          <el-radio :label="true" style=" color:#c9c9c9;" disabled>投保</el-radio>
                          <el-radio :label="false" style=" color:#c9c9c9;" disabled>不投保</el-radio>
                        </el-radio-group>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="24">
                      <el-form-item label="交运货品详细说明" prop="content">
                        <el-input v-model="ruleForm2.content" style="width:340px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                </el-collapse-item>
                <el-collapse-item title="服务与运费支付" name="4">
                  <el-row style="padding-top:10px">
                    <el-col :span="13">
                      <el-form-item label="是否回单" prop="has_return">
                        <el-radio-group v-model="ruleForm2.has_return">
                          <el-radio :label="true" style=" color:#c9c9c9;" disabled>回单</el-radio>
                          <el-radio :label="false" style=" color:#c9c9c9;" disabled>不回单</el-radio>
                        </el-radio-group>
                      </el-form-item>
                    </el-col>
                    <el-col :span="11">
                      <el-form-item label="服务类别" prop="servicelevel">
                        <el-select
                          v-model="ruleForm2.servicelevel"
                          placeholder="请选择"
                          style="width:90px"
                          disabled
                        >
                          <el-option
                            v-for="item in options3"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="7">
                      <el-form-item label="收货期间" prop="receivingdates">
                        <el-select
                          v-model="ruleForm2.receivingdates "
                          placeholder="请选择"
                          style="width:70px"
                          disabled
                        >
                          <el-option
                            v-for="item in options4"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="支付方" prop="paymentType">
                        <el-select
                          v-model="ruleForm2.paymentType"
                          placeholder="请选择"
                          style="width:70px"
                          disabled
                        >
                          <el-option
                            v-for="item in options5"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="支付方式" prop="charges">
                        <el-select
                          v-model="ruleForm2.charges"
                          placeholder="请选择"
                          style="width:75px"
                          disabled
                        >
                          <el-option
                            v-for="item in options6"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="运输费" prop="transportation">
                        <el-input v-model="ruleForm2.transportation" style="width:55px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8" class="my_qita">
                      <el-form-item label="其他">
                        <el-input v-model="ruleForm2.other" style="width:65px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="税点" prop="tax_point">
                        <el-select
                          v-model="ruleForm2.tax_point"
                          placeholder="请选择"
                          style="width:70px"
                          disabled
                        >
                          <el-option
                            v-for="item in options7"
                            :key="item.value"
                            :label="item.label"
                            :value="item.value"
                          ></el-option>
                        </el-select>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="送货费">
                        <el-input v-model="ruleForm2.distribution" style="width:55px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8" class="my_tihuo">
                      <el-form-item label="提货费">
                        <el-input v-model="ruleForm2.delivery" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="中转费">
                        <el-input v-model="ruleForm2.transfer" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="包装费">
                        <el-input v-model="ruleForm2.packing" style="width:55px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="托盘费">
                        <el-input v-model="ruleForm2.pallet" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="上楼费">
                        <el-input v-model="ruleForm2.upstairs" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="8">
                      <el-form-item label="其他费用">
                        <el-input v-model="ruleForm2.other_fees" style="width:55px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="成本">
                        <el-input v-model="ruleForm2.the_cost" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                    <el-col :span="8">
                      <el-form-item label="总计">
                        <el-input v-model="ruleForm2.total_CHARGES" style="width:58px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                  <el-row style="padding-top:10px">
                    <el-col :span="24">
                      <el-form-item label="备注">
                        <el-input v-model="ruleForm2.remark" style="width:390px" readonly></el-input>
                      </el-form-item>
                    </el-col>
                  </el-row>
                </el-collapse-item>
                <el-collapse-item title="其他" name="5">
                  <div
                    class="imgload"
                    style="padding-bottom:15px"
                    v-for="(item,index) in images"
                    :key="index"
                  >
                    <label for="upLoad" class="mylabel">{{item.name}}</label>
                    <input type="file" @change="changeImg" id="upLoad" style="display:none">
                    <img
                      src="../../../assets/img/07.png"
                      alt
                      style="width:25px;height:25px;z-index:10000000000"
                      v-if="!item.name"
                      class="my_img"
                      @click="addimages()"
                    >
                    <img
                      src="../../../assets/img/删除.png"
                      alt
                      style="width:18px;height:18px;z-index:10000000000"
                      v-else
                      class="my_img"
                      @click="removeimages(index)"
                    >
                  </div>
                </el-collapse-item>
              </el-collapse>
            </el-form>
          </div>
        </div>
        <div class="bottom_button">
          <el-button type="success" @click="handleAgreeHP">同意</el-button>
          <el-button type="primary" @click="handleDisAgreeHP">不同意</el-button>
        </div>
      </el-dialog>
      <el-dialog
        title="客户审核列表"
        :visible.sync="dialogVisible1"
        width="70%"
        :before-close="handleClose1"
      >
        <div class="main1 clearfix">
          <div class="main_left1">
            <el-form :model="ruleForm3" :label-position="labelPosition" ref="ruleForm3">
              <el-row>
                <el-col :span="8" class="my_first">
                  <el-form-item label="客户主键">
                    <el-input v-model="ruleForm3.customerID" style="width:85px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_second">
                  <el-form-item label="分公司编号" >
                    <el-input v-model="ruleForm3.branchID" style="width:85px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="8">
                  <el-form-item label="客户简称">
                    <el-input v-model="ruleForm3.companyAbbreviation" style="width:85px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label="开票类型">
                    <el-radio v-model="ruleForm3.invoiceType" label="1" disabled>普票</el-radio>
                    <el-radio v-model="ruleForm3.invoiceType" label="2" disabled>增票</el-radio>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="客户公司名称">
                    <el-input v-model="ruleForm3.companyName" style="width:125px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="纳税识别号" prop="taxpayer_identification_number">
                    <el-input
                      v-model="ruleForm3.taxpayer_identification_number"
                      style="width:140px"
                      readonly
                    ></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="24">
                  <el-form-item label="公司注册地址">
                    <el-input v-model="ruleForm3.registered_address" style="width:350px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="24">
                  <el-form-item label="实际经营地址">
                    <el-input v-model="ruleForm3.actual_Operating" style="width:350px;" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="开户银行">
                    <el-input v-model="ruleForm3.opening_bank" style="width:145px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="开户行账号">
                    <el-input v-model="ruleForm3.bank_account_number" style="width:145px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="客户联系人名称">
                    <el-input v-model="ruleForm3.primary_contact" style="width:95px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="客户联系电话">
                    <el-input v-model="ruleForm3.primary_Tel" style="width:135px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="客户联系人性别" style="width:250px">
                    <el-radio v-model="ruleForm3.customerSex" label="1" disabled>男</el-radio>
                    <el-radio v-model="ruleForm3.customerSex" label="2" disabled>女</el-radio>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="客户传真号码">
                    <el-input v-model="ruleForm3.customerFax" style="width:125px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="客户邮政编码">
                    <el-input v-model="ruleForm3.customerPostID" style="width:95px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="客户电子邮件">
                    <el-input v-model="ruleForm3.customerEmail" style="width:125px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="次要联系人">
                    <el-input v-model="ruleForm3.secondary_contact" style="width:95px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="次要联系人号码">
                    <el-input v-model="ruleForm3.secondary_Tel" style="width:115px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="24">
                  <el-form-item label="客户注册时间">
                    <el-date-picker
                      v-model="ruleForm3.customerRegData"
                      style="width:300px"
                      type="datetime"
                      placeholder="选择日期时间"
                      disabled
                    ></el-date-picker>
                  </el-form-item>
                </el-col>
              </el-row>

              <el-row>
                <el-col :span="24" class="my_timer">
                  <el-form-item label="月结时间" prop="monthly_statement_of_time">
                    <el-date-picker
                      style="width:320px"
                      v-model="ruleForm3.monthly_statement_of_time"
                      type="datetime"
                      placeholder="选择日期时间"
                      disabled
                    ></el-date-picker>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-form>
          </div>
          <div class="main_left1">
            <el-form :model="ruleForm4" :label-position="labelPosition" ref="ruleForm4">
              <el-row>
                <el-col :span="8" class="my_first">
                  <el-form-item label="客户主键" prop="customerID">
                    <el-input v-model="ruleForm4.customerID" style="width:85px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_second">
                  <el-form-item label="分公司编号" prop="branchID">
                    <el-input v-model="ruleForm4.branchID" style="width:85px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="8">
                  <el-form-item label="客户简称">
                    <el-input v-model="ruleForm4.companyAbbreviation" style="width:85px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label="开票类型">
                    <el-radio v-model="ruleForm4.invoiceType" label="1" disabled>普票</el-radio>
                    <el-radio v-model="ruleForm4.invoiceType" label="2" disabled>增票</el-radio>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="客户公司名称">
                    <el-input v-model="ruleForm4.companyName" style="width:125px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="纳税识别号" prop="taxpayer_identification_number">
                    <el-input
                      v-model="ruleForm4.taxpayer_identification_number"
                      style="width:140px"
                      readonly
                    ></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="24">
                  <el-form-item label="公司注册地址">
                    <el-input v-model="ruleForm4.registered_address" style="width:350px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="24">
                  <el-form-item label="实际经营地址">
                    <el-input v-model="ruleForm4.actual_Operating" style="width:350px;" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="开户银行">
                    <el-input v-model="ruleForm4.opening_bank" style="width:145px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="开户行账号">
                    <el-input v-model="ruleForm4.bank_account_number" style="width:145px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="客户联系人名称">
                    <el-input v-model="ruleForm4.primary_contact" style="width:95px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="客户联系电话">
                    <el-input v-model="ruleForm4.primary_Tel" style="width:135px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="客户联系人性别" style="width:250px">
                    <el-radio v-model="ruleForm4.customerSex" label="1" disabled>男</el-radio>
                    <el-radio v-model="ruleForm4.customerSex" label="2" disabled>女</el-radio>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="客户传真号码">
                    <el-input v-model="ruleForm4.customerFax" style="width:125px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="客户邮政编码">
                    <el-input v-model="ruleForm4.customerPostID" style="width:95px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="客户电子邮件">
                    <el-input v-model="ruleForm4.customerEmail" style="width:125px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="10">
                  <el-form-item label="次要联系人">
                    <el-input v-model="ruleForm4.secondary_contact" style="width:95px" readonly></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="10">
                  <el-form-item label="次要联系人号码">
                    <el-input v-model="ruleForm4.secondary_Tel" style="width:115px" readonly></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row>
                <el-col :span="24">
                  <el-form-item label="客户注册时间">
                    <el-date-picker
                      v-model="ruleForm4.customerRegData"
                      style="width:300px"
                      type="datetime"
                      placeholder="选择日期时间"
                      disabled
                    ></el-date-picker>
                  </el-form-item>
                </el-col>
              </el-row>

              <el-row>
                <el-col :span="24" class="my_timer">
                  <el-form-item label="月结时间" prop="monthly_statement_of_time">
                    <el-date-picker
                      style="width:320px"
                      v-model="ruleForm4.monthly_statement_of_time"
                      type="datetime"
                      placeholder="选择日期时间"
                      disabled
                    ></el-date-picker>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-form>
          </div>
        </div>
        <div class="bottom_button">
          <el-button type="success" @click="handleAgreeCustomer">同意</el-button>
          <el-button type="primary" @click="handleDisAgreeCustomer">不同意</el-button>
        </div>
      </el-dialog>
    </div>
  </div>
</template>
<script>
import {
  reqAuditGetAllInspection,
  reqHdgetrow,
  reqHdselectlist,
  reqHdKHselectlist,
  reqKHGetById,
  reqHdInspection,
  reqCustomerInspection
} from "../../../api/index.js";
import { formatDate } from "../../../fiters/common.js";
export default {
  data() {
    return {
      compnay: [],
      labelPosition: "left",
      activeNames1: ['1','2','3','4'],
      activeNames2: ['1','2','3','4'],
      paginations: {
        total: 0,
        page_index: 1,
        page_size: 30,
        page_sizes: [10, 20, 30]
      },
      Action_Search: "",
      SourceType: "",
      SourceNo: "",
      Sorting: "",
      InspectionState: "",
      InspectionName: "",
      StartDate: "",
      EndDate: "",
      dialogVisible: false,
      dialogVisible1: false,
      tablelist: "",
      ruleForm1: {
        id: 13,
        billNo: "", //单号
        isCandidate: false, //是否在候选
        sendBranchID: 1, //发货分公司(仓库)编号
        billCheck: false, //是否开票
        BillStateID: 1, //货单状态编号
        expressNo: "", //合作快递商家单号
        expressBillNo: "", //合作快递公司单号
        secondary_contact: "string",
        secondary_Tel: 0,
        merchandiserName: "", //业务员姓名
        companyAbbreviation: "", //客户简称
        shipperCompanyName: "string",
        shipperAccount_No: "", //发件人账号
        shipperName: "", //发件人姓名
        shipperTel: "", //电话
        shipperPostCode: "string",
        shipperCity: "string",
        shipperProvince: "", //省份州
        shipperAddress: "string",
        receiversCompanyName: "", //收件人公司
        receiversAccount_No: "", //收件人账号
        receiversName: "", //收件人姓名
        receivingTel: "", //电话
        receivingPostCode: "", //邮编
        receivingCity: "", //城市名
        receivingProvince: "string",
        receivingAddress: "", //详细地址
        totalnumberofpackages: "", //总件数
        totalweight: "", //总重量
        volume: "", //体积
        measurementrules: "", //计重比例
        volume_weight: "", //体积重量
        chargeableweight: "", //计费重量
        has_return: "", //是否回单
        servicelevel: "", //服务类别
        transportationMode: "", //运输方式
        receivingdates: "", //收货期间
        content: "", //详细说明
        value: "", //货值
        hasInsured: "", //是否投保
        paymentType: "", //支付方
        charges: "", //支付方式
        transportation: "", //运输费
        other: "", //其他
        tax_point: "", //税点
        distribution: "", //送货费
        delivery: "", //提货费
        transfer: "", //中转费
        packing: "", //包装费
        pallet: "", //托盘费
        upstairs: "", //上楼费
        other_fees: "", //其他费用
        remark: "", //备注
        total_CHARGES: "", //总计
        the_cost: "", //成本
        billImgUrl: "string"
      },
      ruleForm2: {
        id: 13,
        billNo: "", //单号
        isCandidate: false, //是否在候选
        sendBranchID: 1, //发货分公司(仓库)编号
        billCheck: false, //是否开票
        BillStateID: 1, //货单状态编号
        expressNo: "", //合作快递商家单号
        expressBillNo: "", //合作快递公司单号
        secondary_contact: "string",
        secondary_Tel: 0,
        merchandiserName: "", //业务员姓名
        companyAbbreviation: "", //客户简称
        shipperCompanyName: "string",
        shipperAccount_No: "", //发件人账号
        shipperName: "", //发件人姓名
        shipperTel: "", //电话
        shipperPostCode: "string",
        shipperCity: "string",
        shipperProvince: "", //省份州
        shipperAddress: "string",
        receiversCompanyName: "", //收件人公司
        receiversAccount_No: "", //收件人账号
        receiversName: "", //收件人姓名
        receivingTel: "", //电话
        receivingPostCode: "", //邮编
        receivingCity: "", //城市名
        receivingProvince: "string",
        receivingAddress: "", //详细地址
        totalnumberofpackages: "", //总件数
        totalweight: "", //总重量
        volume: "", //体积
        measurementrules: "", //计重比例
        volume_weight: "", //体积重量
        chargeableweight: "", //计费重量
        has_return: "", //是否回单
        servicelevel: "", //服务类别
        transportationMode: "", //运输方式
        receivingdates: "", //收货期间
        content: "", //详细说明
        value: "", //货值
        hasInsured: "", //是否投保
        paymentType: "", //支付方
        charges: "", //支付方式
        transportation: "", //运输费
        other: "", //其他
        tax_point: "", //税点
        distribution: "", //送货费
        delivery: "", //提货费
        transfer: "", //中转费
        packing: "", //包装费
        pallet: "", //托盘费
        upstairs: "", //上楼费
        other_fees: "", //其他费用
        remark: "", //备注
        total_CHARGES: "", //总计
        the_cost: "", //成本
        billImgUrl: "string"
      },
      ruleForm3: {
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
        customerRegData: "", //客户注册时间
        monthly_statement_of_time: "", //月结时间
        branchID: "", //所属分公司(仓库编号)
        id: ""
      },
      ruleForm4: {
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
        customerRegData: "", //客户注册时间
        monthly_statement_of_time: "", //月结时间
        branchID: "", //所属分公司(仓库编号)
        id: ""
      },
      options1: [
        {
          value: "1",
          label: "陆运"
        },
        {
          value: "2",
          label: "空运"
        },
        {
          value: "3",
          label: "快递"
        },
        {
          value: "4",
          label: "国际"
        }
      ],
      options2: [
        {
          value: "200",
          label: "200"
        },
        {
          value: "175",
          label: "175"
        }
      ],
      options3: [
        {
          value: "1",
          label: "快递资料"
        },
        {
          value: "2",
          label: "包裹"
        },
        {
          value: "3",
          label: "物流"
        },
        {
          value: "4",
          label: "国际运输"
        }
      ],
      options4: [
        {
          value: "1",
          label: "当日达"
        },
        {
          value: "2",
          label: "次日达"
        }
      ],
      options5: [
        {
          value: "1",
          label: "发件人"
        },
        {
          value: "2",
          label: "收件人"
        },
        {
          value: "3",
          label: "第三方"
        }
      ],
      options6: [
        {
          value: "1",
          label: "月结"
        },
        {
          value: "2",
          label: "现金"
        },
        {
          value: "3",
          label: "支票"
        }
      ],
      options7: [
        {
          value: 0,
          label: "6%"
        },
        {
          value: 1,
          label: "10%"
        }
      ],
      options8: [], //客户简称下拉框,
      form:{
         Inspection_No:"",
         InspectionState:"",
         Name:localStorage.getItem('userName'),
         Actions:"" 
      }
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
    handleClose1(done) {
      this.$confirm("确认关闭？")
        .then(_ => {
          done();
        })
        .catch(_ => {});
    },
    async getlist() {
      let res = await reqAuditGetAllInspection(
        this.paginations.page_index,
        this.paginations.page_size,
        this.Action_Search,
        this.SourceType,
        this.SourceNo,
        this.Sorting,
        this.InspectionState,
        this.InspectionName,
        this.StartDate,
        this.EndDate
      );
      res.result.items.forEach(value => {
        value.startDate = formatDate(
          new Date(value.startDate),
          "yyyy-MM-dd hh:mm"
        );
        value.endDate = formatDate(new Date(value.endDate), "yyyy-MM-dd hh:mm");
      });
      this.tablelist = res.result.items;
      this.paginations.total = res.result.totalCount;
    },
     //页码变化方法
    async handleCurrentChange(page) {
       let res = await reqAuditGetAllInspection(
        page,
        this.paginations.page_size,
        this.Action_Search,
        this.SourceType,
        this.SourceNo,
        this.Sorting,
        this.InspectionState,
        this.InspectionName,
        this.StartDate,
        this.EndDate
      );
        res.result.items.forEach(value => {
        value.startDate = formatDate(
          new Date(value.startDate),
          "yyyy-MM-dd hh:mm"
        );
        value.endDate = formatDate(new Date(value.endDate), "yyyy-MM-dd hh:mm");
      });

      this.tablelist = res.result.items;
    },
  //一页多少条方法
    async handleSizeChange(page) {
      this.paginations.page_size = page;
        let res = await reqAuditGetAllInspection(
        1,
       page,
        this.Action_Search,
        this.SourceType,
        this.SourceNo,
        this.Sorting,
        this.InspectionState,
        this.InspectionName,
        this.StartDate,
        this.EndDate
      );
    
    res.result.items.forEach(value => {
        value.startDate = formatDate(
          new Date(value.startDate),
          "yyyy-MM-dd hh:mm"
        );
        value.endDate = formatDate(new Date(value.endDate), "yyyy-MM-dd hh:mm");
      });
      this.paginations.page_index = 1;
      this.tablelist = res.result.items;
    },
    async opebDetails(row) {
  
      if (row.sourceType == "货票") {
        let res1 = await reqHdgetrow(row.sourceNo);
        
        this.ruleForm1 = res1.result;
        let res2 = await reqHdgetrow(row.destinationNO);
        this.ruleForm2 = res2.result;
        this.dialogVisible = true;
        this.form.Inspection_No=row.inspection_No;

        this.form.Actions=row.action;
      } else {
        let res1 = await reqKHGetById(row.sourceNo);
        this.ruleForm3 = res1.result;
        let res2 = await reqKHGetById(row.destinationNO);
        this.form.Inspection_No=row.inspection_No;
        this.form.Actions=row.action;
        this.ruleForm4 = res2.result;
        this.dialogVisible1 = true;
      }
    },
    //获取快递运商下拉接口
    async getsectlist() {
      let res = await reqHdselectlist();
      if (res.success) {
        this.compnay = res.result;
      }
    },
    async getHdKhselectlist() {
      let res = await reqHdKHselectlist();
      this.options8 = res.result;
    },
   async handleAgreeCustomer(){ //客户同意审核 
         this.form.InspectionState=1;
        
      let res= await reqCustomerInspection(JSON.stringify(this.form))
      if(res.success){
        this.$message('审核成功')
        this.dialogVisible1=false;
        this.getlist()
      }
    },
   async  handleDisAgreeCustomer(){  //客户不同意
      this.form.InspectionState=2;
        let res= await reqCustomerInspection(JSON.stringify(this.form))
       if(res.success){
        this.$message('审核成功')
        this.dialogVisible1=false;
        this.getlist()
      }
    },
    async handleAgreeHP(){//货票
      this.form.InspectionState=1;
      let res= await reqHdInspection(JSON.stringify(this.form))
      if(res.success){
        this.$message('审核成功')
        this.dialogVisible=false;
        this.getlist()
      }
    },
    async handleDisAgreeHP(){//货票不同意
        this.form.InspectionState=2;
        let res= await reqHdInspection(JSON.stringify(this.form))
       if(res.success){
        this.$message('审核成功')
        this.dialogVisible=false;
        this.getlist()
      }
    }
  },
  created() {
    this.getlist();
    this.getsectlist();
    this.getHdKhselectlist();
  }
};
</script>




