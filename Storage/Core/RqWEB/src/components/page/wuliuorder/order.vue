<style lang="less" scoped >
.orderd {
  background: #ffffff;
  padding: 10px;
  border-radius: 10px;
}


.order {
  min-width: 1800px;
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

.track-rcol {
  width: 911px;
  border: 1px solid #eee;
}
.track-list {
  margin: 20px;
  padding-left: 15px;
  position: relative;
}
.track-list li {
  position: relative;
  line-height: 18px;
  color: #999;
  margin-top: 22px;
}
.track-list li.first {
  color: red;
  padding-top: 0;
  border-left-color: #fff;
}
.track-list li .node-icon {
  position: absolute;
  left: -6px;
  top: 50%;
  width: 11px;
  height: 11px;
  background: url(http://demo.daimabiji.com/3531/img/order-icons.png) -21px -72px
    no-repeat;
}
.track-list li.first .node-icon {
  background-position: 0 -72px;
  top: 0;
}
.track-list li .time {
  margin-right: 20px;
  position: relative;
  top: 4px;
  display: inline-block;
  vertical-align: middle;
}
.track-list li .txt {
  max-width: 600px;
  position: relative;
  top: 4px;

  display: inline-block;
  vertical-align: middle;
}
.track-list li.first .time {
  margin-right: 20px;
  top: -3px;
}
.track-list li.first .txt {
  max-width: 600px;
  top: 0;
}
.track-list li .node-icon {
  left: initial;
  right: -6px;
}
.track-rcol .first .my_first {
  position: relative;
  float: left;
  height: 100%;
}
.track-rcol .first.my_first > span.time {
  position: relative;
  top: 4px;
  display: inline-block;
  vertical-align: middle;
}
.track-rcol .first .my_second {
  padding-left: 24px;
  float: left;
}
.track-rcol .first .my_second .txt {
  position: relative;
  display: inline-block;
  vertical-align: middle;
}
.track-rcol .second .my_first {
  position: relative;
  height: 100%;
  padding: 9px 0 0 0;
  float: left;
}
.track-rcol .my_second {
  float: left;
  border-left: 1px solid #eee;
}
.track-rcol .second .my_second {
  padding: 9px 0 0 14px;
}
.clearfix::after {
  display: block;
  content: "";
  clear: both;
}
</style>
<style lang="less">
.order {
  .el-input__inner {
    border: 0;
    border-bottom: 1px;
    border-color: #c9c9c9;
    border-style: solid;
    border-radius: 0;
    padding: 0;
  }
  .my_first{
    .el-popper{
      margin-top:-5px
    }
  }
 
  .el-table--small td {
    padding: 0 0;
  }
  .el-radio + .el-radio {
    margin-left: 8px;
  }
  .imgload {
    position: relative;
    display: inline-block;
  }
  .mylabel {
    display: inline-block;
    margin-left: 30px;
    width: 180px;
    height: 30px;
    border: 1px solid #d6d6d6;
    vertical-align: middle;
    border-radius: 5px;
    padding: 0 10px 0;
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
</style>

<template>
  <div class="order">
    <div class="order_left">
      <div class="left_top">

        <el-form
          :model="ruleForm"
          :hide-required-asterisk="true"
          ref="ruleForm"
          label-width="72px"
          :rules="rules"
          :label-position="labelPosition"
          class="demo-ruleForm"
        >
          <el-collapse v-model="activeNames" style="width:520px">
            <el-collapse-item v-show="isshow1" title="发件人资料" name="1">
              <hr style="color:#c9c9c9">
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_first">

                       <el-dropdown  placement="top-end">
       <span class="el-dropdown-link">
       <el-form-item label="客户简称" prop="companyAbbreviation">
                    <el-select
                      @change="handleKhJcchange"
                      :disabled="isread1"
                      v-model="ruleForm.companyAbbreviation"
                      style="width:85px"
                    >
                      <el-option
                        v-for="item in options8"
                        :key="item.value"
                        :label="item.name"
                        :value="item.id"
                      ></el-option>
                    </el-select>
                  </el-form-item>
      </span>
      <el-dropdown-menu slot="dropdown"  >
   
        <el-dropdown-item>次要联系人:{{ciyaolianxiren}}</el-dropdown-item>
        <el-dropdown-item>联系方式:{{ciyaolianxifangshi}}</el-dropdown-item>
      </el-dropdown-menu>
    </el-dropdown>
  
  
                </el-col>
                <el-col :span="8" class="my_second">
                  <el-form-item label="账号" prop="shipperAccount_No">
                    <el-input v-model="ruleForm.shipperAccount_No" style="width:85px" disabled></el-input>
                  </el-form-item>
                </el-col>

                <el-col :span="8" class="my_fuwu">
                  <el-form-item label="服务类别" prop="servicelevel">
                    <el-select v-model="ruleForm.servicelevel" @change="fuwuliebiechange" placeholder="请选择" style="width:85px">
                      <el-option
                        v-for="item in options3"
                        :key="item.value"
                        :label="item.label"
                        :value="item.value"
                        :disabled="isread1"
                      ></el-option>
                    </el-select>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_four">
                  <el-form-item label="姓名" prop="shipperName">
                    <el-input v-model="ruleForm.shipperName" :disabled="isread1" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_five">
                  <el-form-item label="单号" prop="billNo">
                    <el-input
                      v-model="ruleForm.billNo"
                      @blur="existblur"
                      :disabled="isread1"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_six">
                  <el-form-item label="业务员" prop="merchandiserName">
                    <el-input v-model="ruleForm.merchandiserName" disabled style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_serven">
                  <el-form-item label="电话" prop="shipperTel">
                    <el-input v-model="ruleForm.shipperTel" :disabled="isread1" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_eight">
                  <el-form-item label="合作快递" prop="expressNo">
                    <el-select v-model="ruleForm.expressNo" :disabled="isread1a" style="width:85px">
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
                    <el-input
                      v-model="ruleForm.expressBillNo"
                      :disabled="isread1b"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-collapse-item>
            <el-collapse-item v-show="isshow2" title="收件人资料" name="2">
              <hr style="color:#c9c9c9">
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_ten">
                  <el-form-item label="账号" prop="receiversAccount_No">
                    <el-input
                      v-model="ruleForm.receiversAccount_No"
                      :disabled="isread2"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_eleven">
                  <el-form-item label="公司" prop="receiversCompanyName">
                    <el-input
                      v-model="ruleForm.receiversCompanyName"
                      :disabled="isread2"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>

                <el-col :span="8" class="my_twelf">
                  <el-form-item label="省份/州" prop="shipperProvince">
                    <el-select
                      v-model="ruleForm.shipperProvince"
                      @change="provincechange"
                      :disabled="isread2"
                      style="width:85px"
                    >
                      <el-option
                        v-for="item in province"
                        :key="item.value"
                        :label="item.name"
                        :value="item.id"
                      ></el-option>
                    </el-select>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_four">
                  <el-form-item label="姓名" prop="receiversName">
                    <el-input
                      v-model="ruleForm.receiversName"
                      :disabled="isread2"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_youbian">
                  <el-form-item label="邮编" prop="receivingPostCode">
                    <el-input
                      v-model="ruleForm.receivingPostCode"
                      :disabled="isread2"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_fiften">
                  <el-form-item label="城市名" prop="receivingCity">
                    <el-select
                      v-model="ruleForm.receivingCity"
                      :disabled="isread2"
                      style="width:85px"
                    >
                      <el-option
                        v-for="item in citylist"
                        :key="item.value"
                        :label="item.name"
                        :value="item.id"
                      ></el-option>
                    </el-select>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="9" class="my_sixten">
                  <el-form-item label="电话" prop="receivingTel">
                    <el-input
                      v-model="ruleForm.receivingTel"
                      :disabled="isread2"
                      style="width:100px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="15" class="my_sevten">
                  <el-form-item label="详细地址" prop="receivingAddress">
                    <el-input
                      v-model="ruleForm.receivingAddress"
                      :disabled="isread2"
                      style="width:200px"
                    ></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-collapse-item>
            <el-collapse-item v-show="isshow3" title="尺寸与重量与货物说明" name="3">
              <hr style="color:#c9c9c9">
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_jianshu">
                  <el-form-item label="件数" prop="totalnumberofpackages">
                    <el-input
                      v-model="ruleForm.totalnumberofpackages"
                      :disabled="isread3"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_zhongliang">
                  <el-form-item label="重量(kg)" label-width="79px" prop="totalweight">
                    <el-input v-model="ruleForm.totalweight" :disabled="isread3" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_tiji">
                  <el-form-item label="体积(m³)" label-width="79px" prop="volume">
                    <el-input
                      v-model="ruleForm.volume"
                      :disabled="isread3"
                      style="width:85px"
                      @focus="handleFocus()"
                    ></el-input>
                  </el-form-item>
                  <el-dialog title="计算体积" :visible.sync="dialogVisible" width="30%">
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
                <el-col :span="8">
                  <el-form-item label="计重比例" prop="measurementrules">
                    <el-select
                      v-model="ruleForm.measurementrules"
                      @change="handleJizhong()"
                      placeholder="请选择"
                      style="width:85px"
                      :disabled="isread3"
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
                  <el-form-item label="体积重量(kg)" label-width="95px" prop="volume_weight">
                    <el-input
                      v-model="ruleForm.volume_weight"
                      :disabled="isread3"
                      style="width:75px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label="计费重量(kg)" label-width="95px" prop="chargeableweight">
                    <el-input
                      v-model="ruleForm.chargeableweight"
                      :disabled="isread3"
                      style="width:75px"
                    ></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8">
                  <el-form-item label="货值(元)" prop="value">
                    <el-input v-model="ruleForm.value" :disabled="isread3" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>

                <el-col :span="8">
                  <el-form-item label="是否投保" prop="hasInsured">
                    <el-radio-group v-model="ruleForm.hasInsured">
                      <el-radio :label="true" style=" color:#c9c9c9;" :disabled="isread3">是</el-radio>
                      <el-radio :label="false" style=" color:#c9c9c9;" :disabled="isread3">否</el-radio>
                    </el-radio-group>
                  </el-form-item>
                </el-col>
                <el-col :span="8" class="my_huidan">
                  <el-form-item label="是否回单" prop="has_return">
                    <el-radio-group v-model="ruleForm.has_return">
                      <el-radio :label="true" style=" color:#c9c9c9;" :disabled="isread3">是</el-radio>
                      <el-radio :label="false" style=" color:#c9c9c9;" :disabled="isread3">否</el-radio>
                    </el-radio-group>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="11">
                  <el-form-item label="运输方式" prop="transportationMode">
                    <el-select
                      v-model="ruleForm.transportationMode"
                      :disabled="isread3"
                      style="width:145px"
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
                <el-col :span="12">
                  <el-form-item label="支付方" prop="paymentType">
                    <el-select
                      v-model="ruleForm.paymentType"
                      :disabled="isread3"
                      placeholder="请选择"
                      style="width:145px"
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
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="24">
                  <el-form-item label="交运货品详细说明" label-width="130px" prop="content">
                    <el-input v-model="ruleForm.content" :disabled="isread3" style="width:340px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-collapse-item>
            <el-collapse-item v-show="isshow4" title="服务与运费支付【应付】" name="4">
              <hr style="color:#c9c9c9">

              <el-row style="padding-top:10px">
                <el-col :span="8">
                  <el-form-item label-width="90px" label="运输费(元)">
                    <el-input
                      v-model="ruleForm.transportation2"
                      :disabled="isread4"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="14">
                  <el-form-item label="备注">
                    <el-input v-model="ruleForm.remark2" :disabled="isread1" style="width:220px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8">
                  <el-form-item label-width="90px" label="送货费(元)">
                    <el-input
                      v-model="ruleForm.distribution2"
                      :disabled="isread4"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label-width="90px" label="提货费(元)">
                    <el-input v-model="ruleForm.delivery2" :disabled="isread4" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label-width="90px" label="中转费(元)">
                    <el-input v-model="ruleForm.transfer2" :disabled="isread4" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8">
                  <el-form-item label-width="90px" label="包装费(元)">
                    <el-input v-model="ruleForm.packing2" :disabled="isread4" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label-width="90px" label="托盘费(元)">
                    <el-input v-model="ruleForm.pallet2" :disabled="isread4" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label-width="90px" label="上楼费(元)">
                    <el-input v-model="ruleForm.upstairs2" :disabled="isread4" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8">
                  <el-form-item label="其他">
                    <el-input v-model="ruleForm.other2" :disabled="isread4" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label="成本(元)">
                    <el-input v-model="jisuanall2" :disabled="isread4" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-collapse-item>
            <el-collapse-item v-show="isshow5" title="服务与运费支付【应收】" name="5">
              <hr style="color:#c9c9c9">
  
              <el-row style="padding-top:10px">
                <el-col :span="8">
                  <el-form-item label="运输费(元)" label-width="90px" prop="transportation">
                    <el-input
                      v-model="ruleForm.transportation"
                      :disabled="isread5"
                      style="width:85px"
                    ></el-input>
                  </el-form-item> 

                </el-col>
                <el-col :span="14" class="my_qtfy">
                  <el-form-item label="备注">
                    <el-input v-model="ruleForm.remark" :disabled="isread5" style="width:220px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8">
                  <el-form-item label-width="90px" label="送货费(元)">
                    <el-input
                      v-model="ruleForm.distribution"
                      :disabled="isread5"
                      style="width:85px"
                    ></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label-width="90px" label="提货费(元)">
                    <el-input v-model="ruleForm.delivery" :disabled="isread5" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label-width="90px" label="中转费(元)">
                    <el-input v-model="ruleForm.transfer" :disabled="isread5" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8" class="my_song">
                  <el-form-item label-width="90px" label="包装费(元)">
                    <el-input v-model="ruleForm.packing" :disabled="isread5" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label-width="90px" label="托盘费(元)">
                    <el-input v-model="ruleForm.pallet" :disabled="isread5" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label-width="90px" label="上楼费(元)">
                    <el-input v-model="ruleForm.upstairs" :disabled="isread5" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row style="padding-top:10px">
                <el-col :span="8">
                  <el-form-item label-width="95px" label="其他费用(元)">
                    <el-input v-model="ruleForm.other_fees" :disabled="isread5" style="width:85px"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :span="8">
                  <el-form-item label="税点" prop="tax_point">
                    <el-select
                      v-model="ruleForm.tax_point"
                      :disabled="isread5"
                      placeholder="请选择"
                      style="width:85px"
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
                <el-col :span="8">
                  <el-form-item label="是否算入税点" label-width="100px">
                    <el-checkbox v-model="ruleForm.isTax" :disabled="isread5"></el-checkbox>
                  </el-form-item>
                </el-col>
              </el-row>

              <el-row style="padding-top:10px">
                <el-col :span="8">
                  <el-form-item label="支付方式" prop="charges">
                    <el-select
                      v-model="ruleForm.charges"
                      :disabled="isread5"
                      placeholder="请选择"
                      style="width:85px"
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
             
                <el-col :span="8">
                  <el-form-item label="总计(元)">
                    <el-input
                      v-model="jisuanall"
                      :disabled="isread5"
                      style="width:140px"
                    ></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-collapse-item>
            <el-collapse-item v-show="isshow6" title="其他" name="6">
                <div
                class="imgload"
                style="padding-bottom:15px"
                v-for="(item,index) in images"
                :key="index"
                @click="showimg(index)" 
              >
                <label  :for="index" class="mylabel">{{item.name}}</label>
                <input type="file"   :disabled="item.isdisabled" @change="changeImg($event,index)" :id="index" style="display:none">
                <img
                  src="../../../assets/img/07.png"
                  alt
                  style="width:25px;height:25px;z-index:10000000000"
                  v-if="!item.name"
                  class="my_img"
              
                >
                <img
                  src="../../../assets/img/删除.png"
                  alt
                  style="width:18px;height:18px;z-index:10000000000"
                  v-else
                  class="my_img"
                   @click.stop="deleteimg(item.id,index)"
                >
              </div>
              <el-dialog  title="图片展示" :visible.sync="dialogVisible9" width="600px" :before-close="handleClose9">
                   
                     <img v-for="(item,index) in imagelist" :key="index" style="display: block;width: 400px;margin: 0 auto;" :src="'http://localhost:21021'+item.name" alt="">
                    <span slot="footer" class="dialog-footer">
                      <el-button @click="dialogVisible9 = false">取 消</el-button>
                      <el-button type="primary" @click="dialogVisible9 = false">确 定</el-button>
                    </span>
              </el-dialog>
              <!-- <div class="imgload" style="padding-bottom:15px">
                <label for="upLoad" class="mylabel">{{imageName}}</label>
                <input
                  type="file"
                  :disabled="isread6"
                  @change="changeImg"
                  id="upLoad"
                  style="display:none"
                >
                <img
                  src="../../../assets/img/07.png"
                  alt
                  style="width:25px;height:25px;z-index:10000000000"
                  v-if="!imageName"
                  class="my_img"
                >
                <img
                  src="../../../assets/img/删除.png"
                  alt
                  style="width:18px;height:18px;z-index:10000000000"
                  v-else
                  class="my_img"
                  @click="removeimages(imageName)"
                >
              </div>
              <ul  class="image_show">
                <li v-for="(item,index) in imagelist" :key="index">
                  <img :src="'http://localhost:21021'+item.name" @click="deleteimg(item.id)">
                </li>
              </ul> -->
            </el-collapse-item>
          </el-collapse>
          <el-row style="margin-top:30px;margin-left:200px">
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
          <h2 style="margin:20px 0 20px 200px;font-size:15px;color:#606266">订单状态跟踪</h2>
          <div class="track-list">
            <ul>
              <li
                class="clearfix"
                v-for="(item,index) in list100"
                :key="index"
                :class="{first:index==0,second:index>0}"
              >
                <div class="my_first">
                  <span class="time">{{item.time}}</span>
                  <i class="node-icon"></i>
                </div>
                <div class="my_second">
                  <span class="txt">{{item.context}}</span>
                </div>
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
            <el-input style="width:128px" v-model="Companyquery"></el-input>
          </el-col>
          <el-col :span="4" class="my_fir">
            <span style="font-size:13px;color:#303133;cursor:pointer">目的地城市</span>
            <el-select placeholder="请选择" style="width:110px" v-model="ReceivingCity">
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
            <el-input style="width:128px;margin-left:8px" v-model="BillNo"></el-input>
          </el-col>
          <el-col :span="7" class="my_fir">
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
          <el-col :span="5">
            <el-button type="primary" style="width:80px" @click="handlequery">查询</el-button>
            <el-button type="danger" style="width:80px" @click="removeCreate">清空新建</el-button>
          </el-col>
        </el-row>
        <el-table
          :data="tablelist"
          :row-class-name="tableRowClassName"
          @row-click="opebDetails"
          style="width: 100%;border:1px solid #c2c2c2;margin-top:12px"
        >
          <el-table-column prop="companyAbbreviation" label="客户简称"></el-table-column>
          <el-table-column prop="billNo" label="单号/合作单号"></el-table-column>
          <el-table-column prop="shipperCity" label="出发地"></el-table-column>
          <el-table-column prop="receivingCity" label="目的地"></el-table-column>
          <el-table-column prop="volume" label="体积(cm3)"></el-table-column>
          <el-table-column prop="totalweight" label="重量(kg)"></el-table-column>
          <el-table-column prop="totalnumberofpackages" label="件数"></el-table-column>
          <el-table-column prop="billStateID" label="货单状态"></el-table-column>
          <el-table-column prop="billCheck" label="已开票">
            <template slot-scope="scope">
              <el-checkbox v-model="scope.row.billCheck"></el-checkbox>
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
              v-model="wuliutiaojian.fillDate"
              type="datetime"
              placeholder="选择日期时间"
              style="width:180px;margin-left:15px"
            ></el-date-picker>
          </el-col>
          <el-col :span="9" class="my_fir mystatus">
            <span style="font-size:13px;color:#303133;cursor:pointer">状态</span>
            <el-select placeholder="请选择" style="width:138px;margin-left:15px" v-model="wuliutiaojian.state">
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
              v-model=" wuliutiaojian.infomation"
            ></el-input>
          </el-col>
        </el-row>
      </div>
    </div>
  </div>
</template>
<script>
import {
  reqHdPagenation, //表格分页
  reqHjHdinfo, //新建接口
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
  reqHdOrderstatusinfo,
  reqHdKHselectlist,
  reqHdXFlist,
  reqUserGetRow,
  reqHdReceiveProvince,
  reqHDReceivecity,
  reqHdDeleteimg,
  reqHdimgjiazai,
  reqHdimgjiazaiById
} from "../../../api/index.js";
import { formatDate } from "../../../fiters/common.js";
export default {
  data() {
    var shipperAccount_NoRules = (rule, value, callback) => {
      //发件人账号验证
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("发件人账号不能为空!"));
      } else if (!myreg.test(value)) {
        callback(new Error("发件人账号只能是数字!"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var shipperNameRules = (rule, value, callback) => {
      //发件人姓名验证
      let myreg = /^[\u4e00-\u9fa5]{1,}$/;
      if (value == "") {
        callback(new Error("发件人姓名不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("姓名只能为汉字!"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var companyAbbreviationRules = (rule, value, callback) => {
      //客户简称

      if (value == "") {
        callback(new Error("客户简称不能为空"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var transportationModeRules = (rule, value, callback) => {
      //运输方式验证
      if (value == "") {
        callback(new Error("运输方式不能为空"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var shipperTelRules = (rule, value, callback) => {
      //发件人电话验证
      let myreg1 = /^1\d{10}$/; //电话规则:区号+号码，区号以0开头，3位或4位号码由7位或8位数字组成区号与号码之间可以无连接符，也可以“-”连接
      let myreg2 = /^0\d{2,3}-?\d{7,8}$/;
      if (value == "") {
        callback(new Error("收件人手机号或电话不能为空"));
      } else if (!myreg1.test(value) && !myreg2.test(value)) {
        callback(new Error("手机号或电话只能为数字"));
      } else {
        callback();
      }
    };
    var receiversAccount_NoRules = (rule, value, callback) => {
      //收件人账号验证
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("收件人账号不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("收件人账号只能是数字"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var receiversNameRules = (rule, value, callback) => {
      //收件人姓名验证
      let myreg = /^[\u4e00-\u9fa5]{1,}$/;
      if (value == "") {
        callback(new Error("收件人姓名不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("收件人姓名只能是中文"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var receiversCompanyNameRules = (rule, value, callback) => {
      if (value == "") {
        callback(new Error("收件人公司名称不能为空"));
      }else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var shipperProvinceRules = (rule, value, callback) => {
      if (value == "") {
        callback(new Error("收件人省份州不能为空"));
      }else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var receivingPostCodeRules = (rule, value, callback) => {
      //收件人邮编验证
      let myreg = /^[1-9][0-9]{5}$/;
      if (value == "") {
        callback(new Error("收件人邮编不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("收件人邮编只能是数字"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var receivingCityRules = (rule, value, callback) => {
      if (value == "") {
        callback(new Error("收件人城市名不能为空"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var receivingTelRules = (rule, value, callback) => {
      //收件人电话验证   //手机号验证规则：11位数字，以1开头。
      let myreg1 = /^1\d{10}$/; //电话规则:区号+号码，区号以0开头，3位或4位号码由7位或8位数字组成区号与号码之间可以无连接符，也可以“-”连接
      let myreg2 = /^0\d{2,3}-?\d{7,8}$/;
      if (value == "") {
        callback(new Error("收件人手机号或电话不能为空"));
      } else if (!myreg1.test(value) && !myreg2.test(value)) {
        callback(new Error("手机号或电话只能是数字"));
      } else {
        callback();
      }
    };
    var totalnumberofpackagesRules = (rule, value, callback) => {
      //总件数验证
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("总件数不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("总件数只能为数字"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var totalweightRules = (rule, value, callback) => {
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("重量不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("重量只能是数字"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var volumeRules = (rule, value, callback) => {
      //体积验证
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("体积不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("体积只能是数字"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var measurementrulesRules = (rule, value, callback) => {
      //计重比例验证
      if (value == "") {
        callback(new Error("计重比例不能为空"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var volume_weightRules = (rule, value, callback) => {
      //体积重量验证
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("体积重量不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("体积重量只能是数字"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var chargeableweightRules = (rule, value, callback) => {
      //计费重量验证
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("计费重量不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("计费重量只能是数字"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var valueRules = (rule, value, callback) => {
      //货值验证
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("货值不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("货值只能是数字"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var hasInsuredRules = (rule, value, callback) => {
      //是否投保
      if (value != true && value != false) {
        callback(new Error("请选择是否投保"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var has_returnRules = (rule, value, callback) => {
      //是否回单
      if (value != true && value != false) {
        callback(new Error("请选择是否回单"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var servicelevelRules = (rule, value, callback) => {
      //服务类别
      if (value == "") {
        callback(new Error("请选择服务类别"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var receivingdatesRules = (rule, value, callback) => {
      //收货期间
      if (value == "") {
        callback(new Error("请选择收货期间"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var paymentTypeRules = (rule, value, callback) => {
      //支付方
      if (value == "") {
        callback(new Error("请选择支付方"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var chargesRules = (rule, value, callback) => {
      //支付方式
      if (value == "") {
        callback(new Error("请选择支付方式"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
    var transportationRules = (rule, value, callback) => {
      //运输费验证
      let myreg = /^\d{1,}$/;
      if (value == "") {
        callback(new Error("运输费不能为空"));
      } else if (!myreg.test(value)) {
        callback(new Error("运输费只能是数字"));
      } else {
        callback(); //验证通过后 不添加callback()函数在验证时是条件会为false
      }
    };
   
    return {
      // isdisabled:false,
      dialogVisible9:false,
      rules: {
        //验证规则
        shipperAccount_No: [
          { validator: shipperAccount_NoRules, trigger: "blur" }
        ],
        shipperName: [{ validator: shipperNameRules, trigger: "blur" }],
        companyAbbreviation: [
          { validator: companyAbbreviationRules, trigger: "blur" }
        ],
        transportationMode: [
          { validator: transportationModeRules, trigger: "change" }
        ],

        shipperTel: [{ validator: shipperTelRules, trigger: "blur" }],
        receiversAccount_No: [
          { validator: receiversAccount_NoRules, trigger: "blur" }
        ],

        receiversCompanyName: [
          { validator: receiversCompanyNameRules, trigger: "blur" }
        ],

        shipperProvince: [{ validator: shipperProvinceRules, trigger: "blur" }],

        receiversName: [{ validator: receiversNameRules, trigger: "blur" }],
        receivingPostCode: [
          { validator: receivingPostCodeRules, trigger: "blur" }
        ],
        receivingCity: [{ validator: receivingCityRules, trigger: "blur" }],
        receivingTel: [{ validator: receivingTelRules, trigger: "blur" }],
        // receivingAddress: [
        //   { validator: receivingAddressRules, trigger: "blur" }
        // ],
        totalnumberofpackages: [
          { validator: totalnumberofpackagesRules, trigger: "blur" }
        ],
        totalweight: [{ validator: totalweightRules, trigger: "blur" }],

        volume: [{ validator: volumeRules, trigger: "change" }],

        measurementrules: [
          { validator: measurementrulesRules, trigger: "change" }
        ],

        volume_weight: [{ validator: volume_weightRules, trigger: "blur" }],
        chargeableweight: [
          { validator: chargeableweightRules, trigger: "blur" }
        ],

        value: [{ validator: valueRules, trigger: "blur" }],

        hasInsured: [{ validator: hasInsuredRules, trigger: "change" }],

        // content: [{ validator: contentRules, trigger: "blur" }],
        has_return: [{ validator: has_returnRules, trigger: "change" }],
        servicelevel: [{ validator: servicelevelRules, trigger: "change" }],

        receivingdates: [{ validator: receivingdatesRules, trigger: "change" }],

        paymentType: [{ validator: paymentTypeRules, trigger: "change" }],

        charges: [{ validator: chargesRules, trigger: "change" }],
        transportation: [{ validator: transportationRules, trigger: "blur" }],
       
      },
      imgid: "",
      // imagelist: [], //图片展示
      images:[
        {
          name:"",
          isdisabled:false,
          id:""
        }
      ],
      imagelist:[],
      isread1: true,
      isread1a:true,
      isread1b:true,
      isread2: true,
      isread3: true,
      isread4: true,
      isread5: true,
      isread6: true,
      isshow1: false,
      isshow2: false,
      isshow3: false,
      isshow4: false,
      isshow5: false,
      isshow6: false,
      list100: [], //物流状态绑定数据
      ReceivingCitylist: [], //筛选条件目的地城市绑定数据
      WUliustatuslist: [], //物流订单下拉框
      date: "", //筛选条件日期
      paginations: {
        //分页相关条件
        total: 0,
        page_index: 1,
        page_size: 30,
        page_sizes: [10, 20, 30]
      },
      Companyquery: "", //筛选条件公司名称
      ReceivingCity: "", //筛选条件目的地城市
      BillNo: "", //筛选条件单号
      CreationTimeS: "", //筛选条件开始时间
      CreationTimeE: "", //筛选条件结束时间
      isupdate: false, //判断新建还是更新的布尔值变量
      tablelist: [], //绑定表格数据
      compnay: [], //发件人资料合作快递绑定数据
      province: [], //省份绑定数据
      citylist: [], //城市绑定
      options1: [
        //发件人资料运输方式下拉

        //0陆运  1航空没说明  2航空当日达  3航空次日达
        // public string TransportationMode { get; set; }
        {
          value: "0",
          label: "陆运"
        },
        {
          value: "1",
          label: "空运"
        },
        {
          value: "2",
          label: "空运当日达"
        },
        {
          value: "3",
          label: "空运次日达"
        }
      ],
      options2: [
        //尺寸计重比例下拉
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
        //服务与运费 服务类别下拉
        {
          value: "1",
          label: "物流"
        },
        {
          value: "2",
          label: "快递资料"
        },
        {
          value: "3",
          label: "快递包裹"
        },
        {
          value: "4",
          label: "快递纸箱"
        },
        {
          value: "5",
          label: "国际运输"
        }
      ],
      options4: [
        //服务与运费 收货期间下拉
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
        //服务与运费 支付方下拉
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
        //服务与运费 支付方式下拉
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
        //服务与运费 税点下拉
        {
          value: 0,
          label: "6%"
        },
        {
          value: 1,
          label: "10%"
        }
      ],
      options8: [], //客户简称下拉框
      activeNames: ["1"], //手风琴默认选择项
      labelPosition: "right", //label定位
      dialogVisible: false, //计算体积弹窗口控制变量
      domains: [
        //体积增加
        {
          value1: "",
          value2: "",
          value3: ""
        }
      ],
      imageName: "",
      ruleForm: {
        //表单所有数据
        id: "",
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
        content:"", //详细说明
        value: "", //货值
        hasInsured: "", //是否投保
        paymentType: "", //支付方
        charges: "", //支付方式
        other: "", //其他

        //应付
        the_cost: 0, //成本
        transportation2: 0, //运输费++
        other2: 0, //其他费用 ++
        distribution2: 0, //送货费++
        delivery2: 0, //提货费++
        transfer2: 0, //中转费++
        packing2: 0, //包装费++
        pallet2: 0, //托盘费++
        upstairs2: 0, //上楼费 ++
        remark2: "", //备注 ++

        //应收
        isPacking: false, //是否包装勾选框++
        isUpstairs: false, //是否上楼勾选框 ++
        isTax: false, //总计应收时是否追加算入税点 ++
        //应收【总计】中  业务员输入且导出清单的字段
        transportation: "", //运输费
        tax_point: 0, //税点
        distribution: 0, //送货费
        delivery: 0, //提货费
        transfer:0, //中转费
        packing: 0, //包装费
        pallet: 0, //托盘费
        upstairs: 0, //上楼费
        other_fees: 0, //其他费用
        remark: "", //备注
        total_CHARGES:0, //总计
        billImgUrl: "string"
      },
      Fillthetime: "",

      wuliutiaojian:{
          state:"",
          fillDate:"",
          infomation:"",
          creatorUserId:sessionStorage.getItem("userId"),
          creationTime:new Date(),
          billNo:""
      },
      ciyaolianxiren:"",
      ciyaolianxifangshi:"",
    };
  },
  methods: {
      handleClose9(done) {
        this.$confirm('确认关闭？')
          .then(_ => {
            done();
          })
          .catch(_ => {});
      },
    
    //单号查重
    existblur() {
      var reg = /^\d{1,}$/;
      if (!this.ruleForm.billNo) {
        this.$message("单号不可以为空哦!!");
      } else if (!reg.test(this.ruleForm.billNo)) {
        this.$message("单号只能为数字哦!!");
      } else {
        this.axios({
          method: "POST",
          //  url:"http://"+window.location.host+"/api/services/app/BillInfoService/CheckBillInfo?billNo="+this.ruleForm.billNo,
          url:
            "http://localhost:21021/api/services/app/BillInfoService/CheckBillInfo?billNo=" +
            this.ruleForm.billNo
        }).then(res => {
          if (res.data.result != null) {
            this.$message("该单号已存在哦!!!");
          }
        });
      }
    },
    //省份下拉变化
    async provincechange(val) {
      let res = await reqHDReceivecity(encodeURI(val));
      this.citylist = res.result;
    },
    async getReceiveProvince() {
      let res = await reqHdReceiveProvince();

      this.province = res.result;
    },
    tableRowClassName({ row, rowIndex }) {
      if (row.billStateID == 1) {
        return "warning-row";
      }
    },
    fuwuliebiechange(val){
      if(val=='1'||val=='5'){
        this.isread1a=true;
        this.isread1b=true
      }else{
        this.isread1a=false;
        this.isread1b=false;
      }
    },
    
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
        this.CreationTimeE
      );
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
        this.CreationTimeE
      );
      this.paginations.page_index = 1;
      this.tablelist = res2.result.items;
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
      if (this.ReceivingCity == "全部") {
        this.ReceivingCity = "";
      }
      let res = await reqHdPagenation(
        this.paginations.page_index,
        this.paginations.page_size,
        encodeURI(this.Companyquery),
        encodeURI(this.ReceivingCity),
        this.BillNo,
        this.CreationTimeS,
        this.CreationTimeE
      );
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
    async removeimages(index) {
      let res = await reqHdDeleteimg(index);
      if(res.success){
        this.$message("删除成功");
        this.images.splice(index, 1);
      }
    
     },
    // //删除图片项函数
    // async removeimages(index) {
    //   let res = await reqHdDeleteimg(index);
    //   if (res.success) {
    //     this.$message("删除成功");
    //     for (var i = 0; i < this.imagelist.length; i++) {
    //       if (this.imagelist[i].id == index) {
    //         this.imagelist.splice(i, 1);
    //       }
    //     }
    //     this.imageName = "";
    //   }
    // },
    // //图片上传函数
    // changeImg(the) {
    //   var imgName = the.target.files[0];
    //   var reader = new FileReader();
    //   reader.readAsDataURL(imgName);

    //   reader.onload = async e => {
    //     if (reader.result) {
    //       let res = await reqimage(reader.result, this.ruleForm.billNo);
    //       this.imageName = res.result;
    //       let res2 = await reqHdimgjiazaiById(res.result);
    //       this.imagelist = this.imagelist.concat(res2.result);
    //     }
    //   };
    // },
    //图片上传函数
    changeImg(the,index) {
      console.log(index)
      var imgName = the.target.files[0];
      var reader = new FileReader();
      reader.readAsDataURL(imgName);
      reader.onload = async  e=>{
        if (reader.result) {
          let res = await reqimage(reader.result,this.ruleForm.billNo);
          let res2=await reqHdimgjiazaiById(res.result)
           const name=res2.result[0].name.split('/')[4]
           this.images[index].name=name
           this.images[index].isdisabled=true
           this.images[index].id=res2.result[0].id
           var imgobj={name:"",isdisabled:false,id:""}
           this.images.push(imgobj);
           this.imagelist=this.imagelist.concat(res2.result)
           console.log(this.imagelist)
             
        }
      };
     
     
    },
    // deleteimg(id) {
    //   this.imageName = id;
    // },

    //展示图片
    showimg(index){
      if(this.images[index].name){
         this.dialogVisible9=true
      }
     
    },
    async deleteimg(id,index){
      let res = await reqHdDeleteimg(id);
      if(res.success){
        this.$message('删除成功')
        this.images.splice(index,1)
      }
    },
    handleJizhong() {
      this.ruleForm.volume_weight = this.Tijiweight;
      this.ruleForm.chargeableweight = this.JifeiWeight;
    },
    //清空新建函数
    removeCreate() {
      this.isupdate = false;
      this.$refs["ruleForm"].resetFields();
    },
    //表单提交
    submitForm(formName) {
      this.$refs[formName].validate(async valid => {
        if (valid) {
          if (this.isupdate == false) {
            this.ruleForm.total_CHARGES=this.jisuanall
            this.ruleForm.the_cost=this.jisuanall2
            let result1 = await reqHjHdinfo(JSON.stringify(this.ruleForm));
            if (result1.success) {
              this.$message("添加成功");
              this.$refs[formName].resetFields();
              this.ruleForm.other = "";
              this.ruleForm.distribution = 0; 
              this.ruleForm.delivery = 0;
              this.ruleForm.transfer = 0;
              this.ruleForm.packing = 0;
              this.ruleForm.pallet = 0;
              this.ruleForm.upstairs = 0;
              this.ruleForm.other_fees =0;
              this.ruleForm.the_cost = "";
              this.ruleForm.total_CHARGES = 0;
              this.ruleForm.remark = "";
              this.ruleForm.isTax=""

              this.ruleForm.transportation2 = "";
              this.ruleForm.other2 = "";
              this.ruleForm.distribution2 = "";
              this.ruleForm.delivery2 = "";
              this.ruleForm.transfer2 = "";
              this.ruleForm.packing2 = "";
              this.ruleForm.pallet2 = "";
              this.ruleForm.upstairs2 = "";
              this.ruleForm.remark2 = "";
              
              this.imageName="";
              this.imagelist=""
              this.getHdtablelist();
            }
          } else {
            let result2 = await reqHdupdate(JSON.stringify(this.ruleForm));
            if (result2.success) {
              this.$message("更新成功");
              this.$refs[formName].resetFields();
              this.ruleForm.other = "";
              this.ruleForm.distribution = "";
              this.ruleForm.delivery = "";
              this.ruleForm.transfer = "";
              this.ruleForm.packing = "";
              this.ruleForm.pallet = "";
              this.ruleForm.upstairs = "";
              this.ruleForm.other_fees = "";
              this.ruleForm.the_cost = "";
              this.ruleForm.total_CHARGES = "";
              this.ruleForm.remark = "";
              this.ruleForm.transportation2 = "";
              this.ruleForm.other2 = "";
              this.ruleForm.distribution2 = "";
              this.ruleForm.delivery2 = "";
              this.ruleForm.transfer2 = "";
              this.ruleForm.packing2 = "";
              this.ruleForm.pallet2 = "";
              this.ruleForm.upstairs2 = "";
              this.ruleForm.remark2 = "";
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
        this.ruleForm.other = "";
        this.ruleForm.distribution = "";
        this.ruleForm.delivery = "";
        this.ruleForm.transfer = "";
        this.ruleForm.packing = "";
        this.ruleForm.pallet = "";
        this.ruleForm.upstairs = "";
        this.ruleForm.other_fees = "";
        this.ruleForm.the_cost = "";
        this.ruleForm.total_CHARGES = "";
        this.ruleForm.remark = "";
        this.ruleForm.transportation2 = "";
        this.ruleForm.other2 = "";
        this.ruleForm.distribution2 = "";
        this.ruleForm.delivery2 = "";
        this.ruleForm.transfer2 = "";
        this.ruleForm.packing2 = "";
        this.ruleForm.pallet2 = "";
        this.ruleForm.upstairs2 = "";
        this.ruleForm.remark2 = "";
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
      let resimg = await reqHdimgjiazai(row.billNo);
      this.imgid = resimg.result.id;
      this.imagelist = resimg.result;
      if (res.result) {
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
        this.ruleForm.transportation2 = res.result.transportatioN2;
        this.ruleForm.other2 = res.result.other2;
        this.ruleForm.distribution2 = res.result.distribution2;
        this.ruleForm.delivery2 = res.result.delivery2;
        this.ruleForm.transfer2 = res.result.transfer2;
        this.ruleForm.packing2 = res.result.packing2;
        this.ruleForm.pallet2 = res.result.pallet2;
        this.ruleForm.upstairs2 = res.result.upstairs2;
        this.ruleForm.remark2 = res.result.remark2;
        this.ruleForm.isTax = res.result.isTax;

        let res2 = await reqHdwuliuinfo(res.result.billNo);
  
        res2.result.forEach(value => {
          value.time = formatDate(new Date(value.time), "yyyy-MM-dd hh:mm");
        })
     
        this.list100 = res2.result;
      } else {
        this.$message("您没有权限查看");
      }
    },
    //获取快递运商下拉接口
    async getsectlist() {
      let res = await reqHdselectlist();
      if (res.success) {
        this.compnay = res.result;
      }
    },
    //获取下拉目的地城市
    async getCitylist() {
      let res = await reqHdCitySelectList();
      res.result.unshift({
        id: "全部",
        name: "全部"
      });

      this.ReceivingCitylist = res.result;
    },
    //获取物流状态下拉框
    async getorderstatus() {
      let res = await reqHdWuliuSelectlist();
      this.WUliustatuslist = res.result;
    },
    //提交物流状态
    async handleStatus() {
      this.wuliutiaojian.billNo=this.ruleForm.billNo     
      let res = await reqHdOrderstatusinfo(JSON.stringify(this.wuliutiaojian));
 
      if (res.success) {
        this.$message("添加成功");
      }
      let res1 = await reqHdwuliuinfo(this.ruleForm.billNo);
    
      res1.result.forEach(value => {
        value.time = formatDate(new Date(value.time), "yyyy-MM-dd hh:mm");
      })
      this.list100 = res1.result;
      this.fillDate = "";
      this.state = "";
      this.infomation = "";
    },
    //获取客户简称下拉框
    async getHdKhselectlist() {
      let res = await reqHdKHselectlist();
      this.options8 = res.result;
    },
    //客户简称悬浮方法
    async handleKhJcchange(val) {
      let res = await reqHdXFlist(val);
      this.ruleForm.merchandiserName = res.result.merchandiserName;
      this.ruleForm.shipperAccount_No = res.result.customerID;
      this.ciyaolianxiren=res.result.secondary_contact;
      this.ciyaolianxifangshi=res.result.secondary_Tel;
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
    jisuanall(){
    

       if(this.ruleForm.isTax){
            if(this.ruleForm.tax_point==0){
                   return  (parseInt(parseInt(this.ruleForm.transportation)+parseInt(this.ruleForm.distribution)+parseInt(this.ruleForm.delivery)+parseInt(this.ruleForm.packing)+parseInt(this.ruleForm.pallet)+parseInt(this.ruleForm.upstairs)+parseInt(this.ruleForm.other_fees))*1.06).toFixed(2)
            }else if(this.ruleForm.tax_point==1){
               return (parseInt(parseInt(this.ruleForm.transportation)+parseInt(this.ruleForm.distribution)+parseInt(this.ruleForm.delivery)+parseInt(this.ruleForm.packing)+parseInt(this.ruleForm.pallet)+parseInt(this.ruleForm.upstairs)+parseInt(this.ruleForm.other_fees))*1.1).toFixed(2)
            }
        
       }else{
          if(this.ruleForm.transportation){
              return parseInt(this.ruleForm.transportation)+parseInt(this.ruleForm.distribution)+parseInt(this.ruleForm.delivery)+parseInt(this.ruleForm.packing)+parseInt(this.ruleForm.pallet)+parseInt(this.ruleForm.upstairs)+parseInt(this.ruleForm.other_fees)
          }
          
       }
    },
    jisuanall2(){
        return parseInt(this.ruleForm.transportation2?this.ruleForm.transportation2:0)+parseInt(this.ruleForm.distribution2?this.ruleForm.distribution2:0)+parseInt(this.ruleForm.delivery2?this.ruleForm.delivery2:0)+parseInt(this.ruleForm.transfer2?this.ruleForm.transfer2:0)+parseInt(this.ruleForm.packing2?this.ruleForm.packing2:0)+parseInt(this.ruleForm.pallet2?this.ruleForm.pallet2:0)+parseInt(this.ruleForm.upstairs2?this.ruleForm.upstairs2:0)
    }
  },
  created() {
    this.getHdtablelist();
    this.getsectlist();
    this.getCitylist(), this.getorderstatus();
    this.getHdKhselectlist();

    this.getReceiveProvince();
  },
  mounted() {
    const permissonlist = JSON.parse(sessionStorage.getItem("permissionslist"));
    if (permissonlist.contains("Pages.BillEditShipper")) {
      this.isread1 = false;
      this.isread1a= false;
      this.isread1b= false;
    }
    if (permissonlist.contains("Pages.BillEditReceiver")) {
      this.isread2 = false;
    }
    if (permissonlist.contains("Pages.BillEditGood")) {
      this.isread3 = false;
    }
    if (permissonlist.contains("Pages.BillEditCost")) {
      this.isread4 = false;
    }
    if (permissonlist.contains("Pages.BillEditCharge")) {
      this.isread5 = false;
    }
    if (permissonlist.contains("Pages.BillEditOther")) {
      this.isread6 = false;
    }
    if (permissonlist.contains("Pages.BillCheckShipper")) {
      this.isshow1 = true;
    }
    if (permissonlist.contains("Pages.BillCheckReceiver")) {
      this.isshow2 = true;
    }
    if (permissonlist.contains("Pages.BillCheckGood")) {
      this.isshow3 = true;
    }
    if (permissonlist.contains("Pages.BillCheckCost")) {
      this.isshow4 = true;
    }
    if (permissonlist.contains("Pages.BillCheckCharge")) {
      this.isshow5 = true;
    }
    if (permissonlist.contains("Pages.BillCheckOther")) {
      this.isshow6 = true;
    }
  }
};
</script>

