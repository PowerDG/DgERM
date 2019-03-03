<style lang="less" >
.orderd {
  background: #ffffff;
  padding: 10px;
  border-radius: 10px;
}
.oddd(@width;@pad;@margin;@color:#858585) {
  width: @width;
  padding-left: @pad;
  margin-left: @margin;
  color: @color;
}
.order {
  .order_left {
    float: left;
    .left_top {
      .orderd;
      width: 524px;
    }
    .left_bottom {
      .orderd;
      width: 524px;
      margin-top: 25px;
    }
  }
  .order_right {
    width: calc(100% - 544px);
    box-sizing: border-box;
    padding-left: 10px;
    float: left;
    .right_inner {
      .orderd;
      max-height: 954px;
    }
    .right_bottom {
      .orderd;
      margin-top: 20px;
      height: 132px;
    }
  }
}
.el-table--small td {
  padding: 0 0;
}
.order .el-form-item--mini.el-form-item,
.order .el-form-item--small.el-form-item {
  margin-bottom: 6px;
}
.order .el-input__inner {
  border: 0;
  border-bottom: 1px;
  border-color: #c9c9c9;
  border-style: solid;
  border-radius: 0;
  padding: 0;
}
.order {
  .my_first {
    .el-form-item__label {
      .oddd(55px;10px; "");
    }
  }
  .my_second {
    .el-form-item__label {
      .oddd(68px; "" ;-20px);
    }
  }
  .my_thrid {
    .el-form-item__label {
      .oddd(68px; "" ;-20px);
    }
  }
  .my_four {
    .el-form-item__label {
      .oddd(54px;10px; "");
    }
  }
  .my_five {
    .el-form-item__label {
      .oddd(58px; "" ;-20px);
    }
  }
  .my_six {
    .el-form-item__label {
      .oddd(60px; "" ;-20px);
    }
  }
  .my_serven {
    .el-form-item__label {
      .oddd(52px;10px; "");
    }
  }
  .my_eight {
    .el-form-item__label {
      .oddd(70px; "" ;-20px);
    }
  }
  .my_nine {
    .el-form-item__label {
      .oddd(70px; "" ;-20px);
    }
  }
  .my_ten {
    .el-form-item__label {
      .oddd(55px;10px; "");
    }
  }
  .my_eleven {
    .el-form-item__label {
      .oddd(45px; "" ;-20px);
    }
  }
  .my_twelf {
    .el-form-item__label {
      .oddd(68px; "" ;-20px);
    }
  }
  .my_fiften {
    .el-form-item__label {
      .oddd(55px; "" ;-20px);
    }
  }
  .my_sixten {
    .el-form-item__label {
      .oddd(54px;10px; "");
    }
  }
  .my_sevten {
    .el-form-item__label {
      .oddd(70px; "" ; "");
    }
  }
  .my_youbian {
    .el-form-item__label {
      .oddd(40px; "" ;-20px);
    }
  }
  .my_jianshu {
    .el-form-item__label {
      .oddd(64px;10px; "");
    }
  }
  .my_zhongliang {
    .el-form-item__label {
      .oddd(60px; "" ;-10px);
    }
  }
  .my_tiji {
    .el-form-item__label {
      .oddd(45px; "" ;-10px);
    }
  }
  .my_jizhong {
    .el-form-item__label {
      .oddd(80px;10px; "");
    }
  }
  .my_tjzhong {
    .el-form-item__label {
      .oddd(80px; "" ;-10px);
    }
  }
  .my_jifei {
    .el-form-item__label {
      .oddd(80px; "" ;-10px);
    }
  }
  .my_jiaoyun {
    .el-form-item__label {
      .oddd(140px;10px; "");
    }
  }
  .my_huozhi {
    .el-form-item__label {
      .oddd(60px;10px; "");
    }
  }
  .my_toubao {
    .el-form-item__label {
      .oddd(80px;10px; "");
    }
  }
  .my_huidan {
    .el-form-item__label {
      .oddd(80px;10px; "");
    }
  }
  .my_fuwu {
    .el-form-item__label {
      .oddd(80px;10px; "");
    }
  }
  .my_shouhuo {
    .el-form-item__label {
      .oddd(80px;10px; "");
    }
  }
  .my_shoufa {
    .el-form-item__label {
      .oddd(65px;10px; "");
    }
  }
  .my_fangshi {
    .el-form-item__label {
      .oddd(75px; "" ; "");
    }
  }
  .my_yunshu {
    .el-form-item__label {
      .oddd(75px;10px; "");
    }
  }
  .my_qita {
    .el-form-item__label {
      .oddd(55px; "" ;-15px);
    }
  }
  .my_shui {
    .el-form-item__label {
      .oddd(68px; "" ;-20px);
    }
  }
  .my_song {
    .el-form-item__label {
      .oddd(75px;10px; "");
    }
  }
  .my_tihuo {
    .el-form-item__label {
      .oddd(55px; "" ;-15px);
    }
  }
  .my_zhongzhuan {
    .el-form-item__label {
      .oddd(68px; "" ;-20px);
    }
  }
  .my_qtfy {
    .el-form-item__label {
      .oddd(80px;10px; "");
    }
  }
  .my_beizhu {
    .el-form-item__label {
      .oddd(55px; "" ;-15px);
    }
  }
  .my_all {
    .el-form-item__label {
      .oddd(68px; "" ;-20px);
    }
  }
  .my_fir .el-input__inner {
    background-color: #fff;
    background-image: none;
    border-radius: 4px;
    border: 1px solid #dcdfe6;
    box-sizing: border-box;
    padding: 0 15px;
  }
  .imgload {
    position: relative;
    display: inline-block;
  }
  .mylabel {
    display: inline-block;
    margin-left: 30px;
    width: 150px;
    height: 30px;
    border: 1px solid #d6d6d6;
    vertical-align: middle;
    border-radius: 5px;
    padding: 0 10px 0;
  }
  .el-range-editor--small .el-range-separator {
    line-height: 31px;
  }
  .my_img {
    position: absolute;
    top: 4px;
    right: 10px;
  }
  .right_bottom .my_fir .el-input__inner {
    padding: 0 30px;
  }
  .right_bottom .mystatus .el-input__inner {
    padding: 0 7px;
  }
  .el-textarea {
    vertical-align: middle;
  }
  .el-col-16 {
    margin-top: 30px;
    padding-left: 11px;
  }
}
.track-rcol {
  width: 524px;
  border: 1px solid #eee;
}
.track-list {
  margin: 20px;
  padding-left: 5px;
  position: relative;
  li{
     position: relative;
     padding: 9px 0 0 25px;
     line-height: 18px;
     border-left: 1px solid #d9d9d9;
     color: #999;
     font-size: 14px;
     &.first{
        color: red;
        padding-top: 0;
        border-left-color: #fff;
        .node-icon{
            background-position: 0 -72px; 
        }
        .time{
             margin-right: 20px; 
        }
        .txt{
             max-width: 600px;
        }
     }
    .node-icon{
         position: absolute;
         left: -6px;
         top: 50%;
         width: 11px;
         height: 11px;
         background: url(http://demo.daimabiji.com/3531/img/order-icons.png) -21px -72px
          no-repeat;
    }
    .time{
       margin-right: 20px;
       position: relative;
       top: 4px;
       display: inline-block;
       vertical-align: middle;
    }
    .txt{
        max-width: 600px;
        position: relative;
        top: 4px;
        display: inline-block;
        vertical-align: middle;
    }
  }
}

</style>
<template>
  <div class="order">
    <div class="order_left">
      <div class="left_top">
        <el-form
          :model="ruleForm"
          :hide-required-asterisk="true"	
          ref="ruleForm"
          :rules="rules"
          :label-position="labelPosition"
          class="demo-ruleForm"
        >
          <el-collapse v-model="activeNames" style="width:520px">
            <el-collapse-item title="发件人资料 " name="1">
              <hr style="color:#c9c9c9">
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_first">
                  <el-form-item label="账号" prop="shipperAccount_No">
                    <el-input v-model="ruleForm.shipperAccount_No" style="width:55px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_second">
                  <el-form-item label="客户简称" prop="companyAbbreviation">
                    <el-input v-model="ruleForm.companyAbbreviation" style="width:58px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_thrid">
                  <el-form-item label="运输方式" prop="transportationMode">
                    <el-select v-model="ruleForm.transportationMode" style="width:75px">
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
                <el-col :span="8" class="my_four">
                  <el-form-item label="姓名" prop="shipperName">
                    <el-input v-model="ruleForm.shipperName" style="width:50px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_five">
                  <el-form-item label="单号" prop="billNo">
                    <el-input v-model="ruleForm.billNo" style="width:58px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_six">
                  <el-form-item label="业务员" prop="merchandiserName">
                    <el-input v-model="ruleForm.merchandiserName" style="width:75px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_serven">
                  <el-form-item label="电话" prop="shipperTel">
                    <el-input v-model="ruleForm.shipperTel" style="width:80px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_eight">
                  <el-form-item label="合作快递" prop="expressNo">
                    <el-select v-model="ruleForm.expressNo" style="width:85px">
                      <el-option
                        v-for="item in compnay"
                        :key="item.value"
                        :label="item.name"
                        :value="item.id"
                      ></el-option>
                    </el-select>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_nine">
                  <el-form-item label="合作单号" prop="expressBillNo">
                    <el-input v-model="ruleForm.expressBillNo" style="width:88px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-collapse-item>
            <el-collapse-item title="收件人资料" name="2">
               <hr style="color:#c9c9c9">
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_ten">
                  <el-form-item label="账号" prop="receiversAccount_No">
                    <el-input v-model="ruleForm.receiversAccount_No" style="width:60px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_eleven">
                  <el-form-item label="公司" prop="receiversCompanyName">
                    <el-input v-model="ruleForm.receiversCompanyName" style="width:75px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_twelf">
                  <el-form-item label="省份/州" prop="shipperProvince">
                    <el-input v-model="ruleForm.shipperProvince" style="width:60px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_four">
                  <el-form-item label="姓名" prop="receiversName">
                    <el-input v-model="ruleForm.receiversName" style="width:55px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_youbian">
                  <el-form-item label="邮编" prop="receivingPostCode">
                    <el-input v-model="ruleForm.receivingPostCode" style="width:75px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_fiften">
                  <el-form-item label="城市名" prop="receivingCity">
                    <el-input v-model="ruleForm.receivingCity" style="width:65px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_sixten">
                  <el-form-item label="电话" prop="receivingTel">
                    <el-input v-model="ruleForm.receivingTel" style="width:100px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="13" class="my_sevten">
                  <el-form-item label="详细地址" prop="receivingAddress">
                    <el-input v-model="ruleForm.receivingAddress" style="width:200px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-collapse-item>
            <el-collapse-item title="尺寸与重量与货物说明" name="3">
               <hr style="color:#c9c9c9">
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_jianshu">
                  <el-form-item label="总件数" prop="totalnumberofpackages">
                    <el-input v-model="ruleForm.totalnumberofpackages" style="width:55px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_zhongliang">
                  <el-form-item label="总重量" prop="totalweight">
                    <el-input v-model="ruleForm.totalweight" style="width:58px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_tiji">
                  <el-form-item label="体积" prop="volume">
                    <el-input v-model="ruleForm.volume" style="width:80px" @focus="handleFocus()"></el-input>
                  </el-form-item>
                  <el-dialog
                    title="计算体积"
                    :visible.sync="dialogVisible"
                    width="30%"
                    
                  >
                    <el-form-item v-for="(domain,index) in domains" :key="index" label="体积">
                      <el-col :span="6">
                        <el-input v-model="domain.value1" style="width:70px"></el-input>
                        <span style="margin-left:10px">X</span>
                      </el-col>
                      <el-col :span="6">
                        <el-input v-model="domain.value2" style="width:70px"></el-input>
                        <span style="margin-left:10px">X</span>
                      </el-col>
                      <el-col :span="5">
                        <el-input v-model="domain.value3" style="width:70px"></el-input>
                      </el-col>
                      <span @click="addDomain" class="el-icon-circle-plus-outline"></span>
                      <span
                        @click="removeDomain(domain)"
                        style="margin-left:10px"
                        class="el-icon-remove-outline"
                      ></span>
                    </el-form-item>
                    <span slot="footer" class="dialog-footer">
                      <el-button @click="dialogVisible = false">取 消</el-button>
                      <el-button type="primary" @click="handleClick()">确 定</el-button>
                    </span>
                  </el-dialog>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_jizhong">
                  <el-form-item label="计重比例" prop="measurementrules">
                    <el-select
                      v-model="ruleForm.measurementrules"
                      @change="handleJizhong()"
                      placeholder="请选择"
                      style="width:74px"
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
                <el-col :span="8" class="my_tjzhong">
                  <el-form-item label="体积重量" prop="volume_weight">
                    <el-input v-model="ruleForm.volume_weight" style="width:75px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_jifei">
                  <el-form-item label="计费重量" prop="chargeableweight">
                    <el-input v-model="ruleForm.chargeableweight" style="width:70px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="7" class="my_huozhi">
                  <el-form-item label="货值" prop="value">
                    <el-input v-model="ruleForm.value" style="width:70px"></el-input>
                  </el-form-item>
                </el-col>

                <el-col :span="11" class="my_toubao">
                  <el-form-item label="是否投保" prop="hasInsured">
                    <el-radio-group v-model="ruleForm.hasInsured ">
                      <el-radio :label="true" style=" color:#c9c9c9;">投保</el-radio>
                      <el-radio :label="false" style=" color:#c9c9c9;">不投保</el-radio>
                    </el-radio-group>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="24" class="my_jiaoyun">
                  <el-form-item label="交运货品详细说明" prop="content">
                    <el-input v-model="ruleForm.content" style="width:340px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-collapse-item>
            <el-collapse-item title="服务与运费支付" name="4">
               <hr style="color:#c9c9c9">
              <el-row style="padding-top:10px">
                <el-col :span="13" class="my_huidan">
                  <el-form-item label="是否回单" prop="has_return">
                    <el-radio-group v-model="ruleForm.has_return">
                      <el-radio :label="true" style=" color:#c9c9c9;">回单</el-radio>
                      <el-radio :label="false" style=" color:#c9c9c9;">不回单</el-radio>
                    </el-radio-group>
                  </el-form-item>
                </el-col>
                <el-col :span="11" class="my_fuwu">
                  <el-form-item label="服务类别" prop="servicelevel">
                    <el-select v-model="ruleForm.servicelevel" placeholder="请选择" style="width:90px">
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
                <el-col :span="7" class="my_shouhuo">
                  <el-form-item label="收货期间" prop="receivingdates">
                    <el-select
                      v-model="ruleForm.receivingdates "
                      placeholder="请选择"
                      style="width:70px"
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
                <el-col :span="8" class="my_shoufa">
                  <el-form-item label="支付方" prop="paymentType">
                    <el-select v-model="ruleForm.paymentType" placeholder="请选择" style="width:70px">
                      <el-option
                        v-for="item in options5"
                        :key="item.value"
                        :label="item.label"
                        :value="item.value"
                      ></el-option>
                    </el-select>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_fangshi">
                  <el-form-item label="支付方式" prop="charges">
                    <el-select v-model="ruleForm.charges" placeholder="请选择" style="width:75px">
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
                <el-col :span="8" class="my_yunshu">
                  <el-form-item label="运输费" prop="transportation">
                    <el-input v-model="ruleForm.transportation" style="width:55px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_qita">
                  <el-form-item label="其他">
                    <el-input v-model="ruleForm.other" style="width:65px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_shui">
                  <el-form-item label="税点" prop="tax_point">
                    <el-select v-model="ruleForm.tax_point" placeholder="请选择" style="width:70px">
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
                <el-col :span="8" class="my_song">
                  <el-form-item label="送货费">
                    <el-input v-model="ruleForm.distribution" style="width:55px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_tihuo">
                  <el-form-item label="提货费">
                    <el-input v-model="ruleForm.delivery" style="width:58px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_zhongzhuan">
                  <el-form-item label="中转费">
                    <el-input v-model="ruleForm.transfer" style="width:58px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_song">
                  <el-form-item label="包装费">
                    <el-input v-model="ruleForm.packing" style="width:55px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_tihuo">
                  <el-form-item label="托盘费">
                    <el-input v-model="ruleForm.pallet" style="width:58px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_zhongzhuan">
                  <el-form-item label="上楼费">
                    <el-input v-model="ruleForm.upstairs" style="width:58px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_qtfy">
                  <el-form-item label="其他费用">
                    <el-input v-model="ruleForm.other_fees" style="width:55px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_beizhu">
                  <el-form-item label="成本">
                    <el-input v-model="ruleForm.the_cost" style="width:58px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_all">
                  <el-form-item label="总计">
                    <el-input v-model="ruleForm.total_CHARGES" style="width:58px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="24" class="my_qtfy">
                  <el-form-item label="备注">
                    <el-input v-model="ruleForm.remark" style="width:390px"></el-input>
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
          <el-row style="margin-top:30px;margin-left:280px">
            <el-col :span="24" class="my_huidan">
              <el-form-item>
                <el-button type="success" @click="submitForm('ruleForm')">立即创建</el-button>
                <el-button type="primary" @click="resetForm('ruleForm')">重置</el-button>
                <el-button type="danger" @click="deletcustome">删除</el-button>
              </el-form-item>
            </el-col>
          </el-row>
        </el-form>
      </div>
      <div class="left_bottom">
        <div class="track-rcol">
          <div class="track-list">
            <ul>
              <li :class="{'first':index==0}" v-for="(item,index) in list100" :key="index">
                <i class="node-icon"></i>
                <span class="time">{{item.time}}</span>
                <br>
                <span class="txt">{{item.context}}</span>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <div class="order_right">
      <div class="right_inner" style="background:#fff">
         <el-row>
          <el-col :span="4" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">公司名称</span>
            <el-input  style="width:128px" v-model="Companyquery"></el-input>
          </el-col>
          <el-col :span="4" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">目的地城市</span>
            <el-select  placeholder="请选择" style="width:110px" v-model="ReceivingCity">
              <el-option
                v-for="item in ReceivingCitylist "
                :key="item.value"
                :label="item.id"
                :value="item.name"
              ></el-option>
            </el-select>
          </el-col>
          <el-col :span="4" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">单号</span>
            <el-input  style="width:128px;margin-left:8px" v-model="BillNo"></el-input>
          </el-col>
          <el-col :span="8" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">起始日期</span>
            <el-date-picker
              style="width:240px;margin-left:15px"
              v-model="date"
              type="daterange"
              range-separator="至"
              start-placeholder="开始日期"
              end-placeholder="结束日期"
            ></el-date-picker>
          </el-col>
          <el-col :span="2" >
              <el-button type="primary" style="width:80px" @click="handlequery">查询</el-button>
          </el-col>
        </el-row>
        <el-table :data="tablelist"
          stripe
          @row-click="opebDetails"
          style="width: 100%;border:1px solid #c2c2c2;margin-top:12px"
        >
          <el-table-column prop="companyAbbreviation" label="客户简称"></el-table-column>
          <el-table-column prop="billNo" label="单号/合作单号"></el-table-column>
          <el-table-column prop="shipperCity" label="出发地"></el-table-column>
          <el-table-column prop="receivingCity" label="目的地"></el-table-column>
          <el-table-column prop="volume" label="体积(cm3)"></el-table-column>
          <el-table-column prop="totalweight" label="总重量(kg)"></el-table-column>
          <el-table-column prop="totalnumberofpackages" label="总件数"></el-table-column>
          <el-table-column prop="billCheck"  label="已开票">
            <template slot-scope="scope">
                  <el-checkbox  v-model="scope.row.billCheck"></el-checkbox>
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
      <div class="right_bottom">
        <el-row>
          <el-col :span="7" class="my_fir" style="padding-left:10px">
            <span style="font-size:13px;color:#303133;cursor:pointer">填写时间</span>
            <el-date-picker
              v-model="fillDate"
              type="datetime"
              placeholder="选择日期时间"
              style="width:140px;margin-left:15px"
            ></el-date-picker>
          </el-col>
          <el-col :span="9" class="my_fir mystatus">
            <span style="font-size:13px;color:#303133;cursor:pointer">状态</span>
            <el-select placeholder="请选择" style="width:138px;margin-left:15px" v-model="state">
              <el-option
                v-for="item in WUliustatuslist"
                :key="item.value"
                :label="item.name"
                :value="item.id"
              ></el-option>
            </el-select>
          </el-col>
          <el-col :span="4" class="my_fir">
            <el-button type="danger" @click="handleStatus">提交</el-button>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="16">
            <span style="font-size:13px;color:#303133;cursor:pointer">内容信息</span>
            <el-input
              type="textarea"
              style="width:700px"
              :autosize="{ minRows: 2, maxRows: 4}"
              placeholder="请输入内容"
             v-model="infomation"
            ></el-input>
          </el-col>
        </el-row>
      </div>
    </div>
  </div>
</template>
<script>
import {
  reqHdPagenation,//表格分页
  reqHjHdinfo,//新建接口
  reqSend100,
  reqlocalsend100,
  reqimage,
  reqHdselectlist,
  reqHdgetrow,
  reqHddelete,
  reqHdupdate,
  reqHdCitySelectList,
  reqHdWuliuSelectlist,
  reqHdwuliuinfo,
  reqHdOrderstatusinfo
} from "../../../api/index.js";
import { formatDate } from "../../../fiters/common.js";
export default {
    data() {
      return {
        list100: [],//物流状态绑定数据
        ReceivingCitylist:[],//筛选条件目的地城市绑定数据
        WUliustatuslist:[],//物流订单下拉框
        date:"",//筛选条件日期
        paginations: {//分页相关条件
          total: 0,
          page_index: 1,
          page_size: 30,
          page_sizes: [10, 20, 30]
        },
        Companyquery:"",//筛选条件公司名称
        ReceivingCity:"",//筛选条件目的地城市
        BillNo:'',//筛选条件单号
        CreationTimeS:'',//筛选条件开始时间
        CreationTimeE:'',//筛选条件结束时间
        isupdate: false,//判断新建还是更新的布尔值变量
        tablelist: [],//绑定表格数据
        compnay: [],//发件人资料合作快递绑定数据
        options1: [//发件人资料运输方式下拉
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
        options2: [//尺寸计重比例下拉
          {
            value: "200",
            label: "200"
          },
          {
            value: "175",
            label: "175"
          }
        ],
        options3: [//服务与运费 服务类别下拉
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
        options4: [//服务与运费 收货期间下拉
          {
            value: "1",
            label: "当日达"
          },
          {
            value: "2",
            label: "次日达"
          }
        ],
        options5: [//服务与运费 支付方下拉
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
        options6: [//服务与运费 支付方式下拉
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
        options7: [//服务与运费 税点下拉
          {
            value: 0,
            label: "6%"
          },
          {
            value: 1,
            label: "10%"
          }
        ],
        activeNames: ["1"], //手风琴默认选择项
        labelPosition: "left", //label定位
        dialogVisible: false,//计算体积弹窗口控制变量
        domains: [//体积增加
          {
            value1: "",
            value2: "",
            value3: ""
          }
        ],
        images: [//图片上传增加
          {
            name: ""
          }
        ],
        ruleForm: {//表单所有数据
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
        rules: {//验证规则
          shipperAccount_No: [
            { required: true, message: "账号不能为空", trigger: "blur" }
          ],
          companyAbbreviation: [
            { required: true, message: "客户简称不能为空", trigger: "blur" }
          ],
          transportationMode: [
            { required: true, message: "运输方式不能为空", trigger: "change" }
          ],
          // shipperName: [
          //   { required: true, message: '发件人姓名不能为空', trigger: 'blur' }
          // ],
          billNo: [{ required: true, message: "单号不能为空", trigger: "blur" }],
          merchandiserName: [
            { required: true, message: "业务员", trigger: "blur" }
          ],
          shipperTel: [
            { required: true, message: "电话不能为空", trigger: "blur" }
          ],
          expressNo: [
            { required: true, message: "合作快递不能为空", trigger: "blur" }
          ],
          expressBillNo: [
            { required: true, message: "合作单号不能为空", trigger: "blur" }
          ],
          receiversAccount_No: [
            { required: true, message: "收件人账号不能为空", trigger: "blur" }
          ],
          receiversCompanyName: [
            { required: true, message: "收件人公司不能为空", trigger: "blur" }
          ],
          shipperProvince: [
            { required: true, message: "省份州不能为空", trigger: "blur" }
          ],
          receiversName: [
            { required: true, message: "收件人姓名不能为空", trigger: "blur" }
          ],
          receivingPostCode: [
            { required: true, message: "邮编不能为空", trigger: "blur" }
          ],
          receivingCity: [
            { required: true, message: "城市名不能为空", trigger: "blur" }
          ],
          receivingTel: [
            { required: true, message: "电话不能为空", trigger: "blur" }
          ],
          receivingAddress: [
            { required: true, message: "详细地址不能为空", trigger: "blur" }
          ],
          totalnumberofpackages: [
            { required: true, message: "总件数不能为空", trigger: "blur" }
          ],
          totalweight: [
            { required: true, message: "总重量不能为空", trigger: "blur" }
          ],

          // volume: [
          //   { required: true, message: '体积不能为空', trigger: 'blur' }
          // ],
          measurementrules: [
            { required: true, message: "计重比例不能为空", trigger: "change" }
          ],
          volume_weight: [
            { required: true, message: "体积重量不能为空", trigger: "blur" }
          ],
          chargeableweight: [
            { required: true, message: "计费重量不能为空", trigger: "blur" }
          ],
          value: [{ required: true, message: "货值不能为空", trigger: "blur" }],
          hasInsured: [
            { required: true, message: "投保不能为空", trigger: "blur" }
          ],
          content: [
            { required: true, message: "详细说明不能为空", trigger: "blur" }
          ],
          has_return: [
            { required: true, message: "是否回单不能为空", trigger: "change" }
          ],
          servicelevel: [
            { required: true, message: "服务类别不能为空", trigger: "change" }
          ],
          receivingdates: [
            { required: true, message: "收货期间不能为空", trigger: "change" }
          ],
          paymentType: [
            { required: true, message: "支付方不能为空", trigger: "change" }
          ],
          charges: [
            { required: true, message: "支付方式不能为空", trigger: "change" }
          ],
          transportation: [
            { required: true, message: "运输费不能为空", trigger: "blur" }
          ],
          tax_point: [
            { required: true, message: "税点不能为空", trigger: "change" }
          ]
        },
        Fillthetime:'',
        state:'',
        contentinfo:'',
        creationTime:new Date(),
        fillDate:'',
        infomation:'',
        creatorUserId:sessionStorage.getItem('userId')
      };
    },
    methods: {
      //表格分页
      async getHdtablelist() {
         let res = await reqHdPagenation(
            this.paginations.page_index,
            this.paginations.page_size,
            this.Companyquery,
            this.ReceivingCity,
            this.BillNo,
            this.CreationTimeS,
            this.CreationTimeE
           );
            this.tablelist = res.result.items;
            this.paginations.total = res.result.totalCount;
      },
      //页码变化方法
      async handleCurrentChange(page) {
          let res1 = await reqHdPagenation(
            page, 
            this.paginations.page_size,
            this.Companyquery,
            this.ReceivingCity,
            this.BillNo,
            this.CreationTimeS,
            this.CreationTimeE);
          this.tablelist = res1.result.items;
      },
      //一页大小变化方法
      async handleSizeChange(page) {
        this.paginations.page_size = page;
        let res2 = await reqHdPagenation(
          1, 
          page,
          this.Companyquery,
          this.ReceivingCity,
          this.BillNo,
          this.CreationTimeS,
          this.CreationTimeE);
        this.paginations.page_index = 1;
        this.tablelist = res2.result.items;
      },
      //筛选条件方法
      async handlequery(){
        this.CreationTimeS = formatDate(new Date(this.date[0]), "yyyy-MM-dd hh:mm");
        this.CreationTimeE=formatDate(new Date(this.date[1]), "yyyy-MM-dd hh:mm");
        let res=await reqHdPagenation(
        this.paginations.page_index,
        this.paginations.page_size,
          encodeURI(this.Companyquery) ,
          encodeURI(this.ReceivingCity) ,
          this.BillNo,
          this.CreationTimeS,
          this.CreationTimeE)
          this.tablelist = res.result.items;
          this.paginations.total = res.result.totalCount;
      },
      //计算体积的函数
      handleClick() {
        this.ruleForm.volume = this.TotalTiji;
        this.dialogVisible = false;
      },
      //控制计算体积弹出框函数
      handleFocus() {
        this.dialogVisible = true;
      },
      //减少体积项函数
      removeDomain(item) {
        if (this.domains.length == 1) {
          return;
        }
        var index = this.domains.indexOf(item);
        if (index !== -1) {
          this.domains.splice(index, 1);
        }
      },
      //增加体积项函数
      addDomain() {
        this.domains.push({
          value: ""
        });
      },
    //删除图片项函数
      removeimages(index) {
        this.images.splice(index, 1);
      },
      //图片上传函数
      changeImg(the) {
        var imgName = the.target.files[0];
        var reader = new FileReader();
        reader.readAsDataURL(imgName);
        reader.onload = async function(e) {
          if (reader.result) {
            let res = await reqimage(reader.result, 1);
          }
        };
        var imgObj = {};
        imgObj.name = imgName.name;

        this.images.unshift(imgObj);
      },
      handleJizhong() {
        this.ruleForm.volume_weight = this.Tijiweight;
        this.ruleForm.chargeableweight = this.JifeiWeight;
      },
      //表单提交
      submitForm(formName) {
        this.$refs[formName].validate(async valid => {
          if (valid) {
            if (this.isupdate == false) {
              let result1 = await reqHjHdinfo(JSON.stringify(this.ruleForm));
              console.log(result1);
              if (result1.success) {
                this.$message("添加成功");
                this.$refs[formName].resetFields();
                this.getHdtablelist();
              }
            } else {
              console.log(JSON.stringify(this.ruleForm));
              let result2 = await reqHdupdate(JSON.stringify(this.ruleForm));
              if (result2.success) {
                this.$message("更新成功");
                this.$refs[formName].resetFields();
                this.getHdtablelist();
              }
            }
          } else {
            console.log(err);
            return false;
          }
        });
      },
      //删除用户信息的方法
      async deletcustome() {
        let taskId = this.ruleForm.id;
        let res = await reqHddelete(taskId);
        if (res.success) {
          this.$message("删除成功");
          this.getHdtablelist();
          this.$refs["ruleForm"].resetFields();
        }
      },
      //表单重置
      resetForm(formName) {
        this.$refs[formName].resetFields();
      },
      //表格单击的方法
      async opebDetails(row) {
        this.isupdate = true;
        let res = await reqHdgetrow(row.id);
        this.ruleForm.id = res.result.id;
        this.ruleForm.billNo = res.result.billNo;
        this.ruleForm.expressNo = res.result.expressNo;
        this.ruleForm.expressBillNo = res.result.expressBillNo;
        this.ruleForm.merchandiserName = res.result.merchandiserName;
        this.ruleForm.companyAbbreviation = res.result.companyAbbreviation;
        this.ruleForm.shipperAccount_No = res.result.shipperAccount_No;
        this.ruleForm.shipperName = res.result.shipperName;
        this.ruleForm.shipperTel = res.result.shipperTel;
        this.ruleForm.receivingPostCode = res.result.receivingPostCode;
        this.ruleForm.receivingCity = res.result.receivingCity;
        this.ruleForm.receivingAddress = res.result.receivingAddress;
        this.ruleForm.receiversName = res.result.receiversName;
        this.ruleForm.receivingTel = res.result.receivingTel;
        this.ruleForm.measurementrules = res.result.measurementrules;
        this.ruleForm.receiversAccount_No = res.result.receiversAccount_No;
        this.ruleForm.receiversCompanyName = res.result.receiversCompanyName;
        this.ruleForm.content = res.result.content;
        this.ruleForm.shipperProvince = res.result.shipperProvince;
        this.ruleForm.hasInsured = res.result.has_return;
        this.ruleForm.chargeableweight = res.result.chargeableweight;
        this.ruleForm.volume_weight = res.result.volume_weight;
        this.ruleForm.volume = res.result.volume;
        this.ruleForm.totalweight = res.result.totalweight;
        this.ruleForm.value = res.result.value;
        this.ruleForm.hasInsured = res.result.hasInsured;
        this.ruleForm.has_return = res.result.has_return;
        this.ruleForm.receivingdates = res.result.receivingdates;
        this.ruleForm.paymentType = res.result.paymentType;
        this.ruleForm.totalnumberofpackages = res.result.totalnumberofpackages;
        this.ruleForm.charges = res.result.charges;
        this.ruleForm.transportation = res.result.transportation;
        this.ruleForm.transportationMode = res.result.transportationMode;
        this.ruleForm.other = res.result.other;
        this.ruleForm.servicelevel = res.result.servicelevel;
        this.ruleForm.tax_point = res.result.tax_point;
        this.ruleForm.distribution = res.result.distribution;
        this.ruleForm.delivery = res.result.delivery;
        this.ruleForm.transfer = res.result.transfer;
        this.ruleForm.packing = res.result.transfer;
        this.ruleForm.pallet = res.result.pallet;
        this.ruleForm.upstairs = res.result.upstairs;
        this.ruleForm.other_fees = res.result.other_fees;
        this.ruleForm.remark = res.result.remark;
        this.ruleForm.total_CHARGES = res.result.totaL_CHARGES;
        this.ruleForm.the_cost = res.result.the_cost;
        let res2=await reqHdwuliuinfo(res.result.billNo)
        res2.result.forEach(value => {
          value.time = formatDate(
            new Date(value.time),
            "yyyy-MM-dd hh:mm"
          )}),
        this.list100=res2.result
        
      },
      //获取快递运商下拉接口
      async getsectlist() {
        let res = await reqHdselectlist();
        if (res.success) {
          this.compnay = res.result;
        }
      },
      //获取下拉目的地城市
      async getCitylist(){
        let res=await reqHdCitySelectList()
        this.ReceivingCitylist=res.result;
      },
      //获取物流状态下拉框
      async getorderstatus(){
        let res=await reqHdWuliuSelectlist()
        this.WUliustatuslist=res.result;
      },
      //提交物流状态
      async handleStatus(){
        this.creationTime = formatDate(new Date(this.creationTime), "yyyy-MM-dd hh:mm");
        this.fillDate= formatDate(new Date(this.fillDate), "yyyy-MM-dd hh:mm");
        let res=await reqHdOrderstatusinfo(this.ruleForm.billNo,this.state,this.fillDate,this.infomation,this.creatorUserId,this.creationTime)
        if(res.success){
          this.$message('添加成功')
        }
        let res1=await reqHdwuliuinfo(this.ruleForm.billNo)
         res1.result.forEach(value => {
          value.time = formatDate(
            new Date(value.time),
            "yyyy-MM-dd hh:mm"
          )}),
        this.list100=res1.result
        this.fillDate='';
        this.state='';
        this.infomation=''
      }
  },
    computed: {
      //计算体积
      TotalTiji() {
        let sum = 0;
        this.domains.forEach((item, index) => {
          sum += item.value1 * item.value2 * item.value3;
        });
        return sum;
      },
      //计算重量
      Tijiweight() {
        return parseInt(this.ruleForm.volume * this.ruleForm.measurementrules);
      },
      JifeiWeight() {
        return this.ruleForm.totalweight > this.ruleForm.volume_weight
          ? this.ruleForm.totalweight
          : this.ruleForm.volume_weight;
      },

    },
    created() {
      this.getHdtablelist();
      this.getsectlist();
      this.getCitylist(),
      this.getorderstatus()
    },
 
};
</script>


