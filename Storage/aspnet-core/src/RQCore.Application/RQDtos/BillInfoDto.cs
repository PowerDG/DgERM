using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using RQCore.RQEnitity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace RQCore.RQDtos
{

    [AutoMap(typeof(BillInfo))]
    public class BillInfoDto : EntityDto<long>
    {
        public new long? Id { get; set; }

        #region
        #endregion
        public int BillNo { get; set; }
        // public int State { get; set; }
        [DefaultValue(false)]
        public bool IsCandidate { get; set; }

        // public int Version { get; set; }
        public string SendBranchID { get; set; }
        [DefaultValue(false)]
        public bool BillCheck { get; set; }
        public int BillStateID { get; set; }
        public int? ExpressBillNo { get; set; }
        public string ExpressNo { get; set; }
        public string Secondary_contact { get; set; }
        public int Secondary_Tel { get; set; }
        public string MerchandiserName { get; set; }
        public long MerchandiserId { get; set; }
        public string CompanyAbbreviation { get; set; }

        #region 发件人信息

        public string ShipperCompanyName { get; set; }
        public string ShipperAccount_No { get; set; }
        public string ShipperName { get; set; }
        public string ShipperTel { get; set; }
        public string ShipperPostCode { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperProvince { get; set; }
        public string ShipperAddress { get; set; }
        #endregion

        #region 收件人信息
        public string ReceiversCompanyName { get; set; }
        public string ReceiversAccount_No { get; set; }
        public string ReceiversName { get; set; }
        public string ReceivingTel { get; set; }
        public string ReceivingPostCode { get; set; }
        public string ReceivingCity { get; set; }
        public string ReceivingProvince { get; set; }
        public string ReceivingAddress { get; set; }
        #endregion

        #region 尺寸与货物详细说明
       
        public string Totalnumberofpackages { get; set; }
        public string Totalweight { get; set; }
        public string Volume { get; set; }
        public string Measurementrules { get; set; }

        public string Volume_weight { get; set; }
        public string Chargeableweight { get; set; }

        public bool Has_return { get; set; }
        public string SERVICELEVEL { get; set; }
        public string TransportationMode { get; set; }
        public string Receivingdates { get; set; }
        public string CONTENT { get; set; }
       

        public string Value { get; set; }
        public bool HasInsured { get; set; }
        public string PaymentType { get; set; }
        public string CHARGES { get; set; }

        public string OTHER { get; set; }
        #endregion

        #region 应付

        public string The_cost { get; set; }
        public string TRANSPORTATION2 { get; set; }
        public string Remark2 { get; set; }

        public string Distribution2 { get; set; }
        public string Delivery2 { get; set; }
        public string Transfer2 { get; set; }
        public string Packing2 { get; set; }
        public string Pallet2 { get; set; }
        public string Upstairs2 { get; set; }
        public string OTHER2 { get; set; }

        //public string TOTAL_CHARGES2 { get; set; }

        #endregion


        //-支付方式 



        public bool isPacking { get; set; }
        public bool isUpstairs { get; set; }


        //是否启用税点计算
        public bool isTax { get; set; }
        public int Tax_point { get; set; }

        #region 应收

        public string TRANSPORTATION { get; set; }
        public string Remark { get; set; }

        public string Distribution { get; set; }
        public string Delivery { get; set; }
        public string Transfer { get; set; }
        public string Packing { get; set; }
        public string Pallet { get; set; }
        public string Upstairs { get; set; }


        public string Other_fees { get; set; }//!!!!!!!暂无
        public string TOTAL_CHARGES { get; set; }


        #endregion





   


        //public string TRANSPORTATION { get; set; }

        //public int Tax_point { get; set; }
        //public string Distribution { get; set; }
        //public string Delivery { get; set; }
        //public string Transfer { get; set; }
        //public string Packing { get; set; }
        //public string Pallet { get; set; }

        //public string Upstairs { get; set; }
        //public string Other_fees { get; set; }
        //public string Remark { get; set; }
        //public string TOTAL_CHARGES { get; set; }
        //public string The_cost { get; set; }





        public string BillImgUrl { get; set; }
    }


    [AutoMap(typeof(BillInfo))]
    public class BillOnLineDto : EntityDto<long>
    {
        public new long? Id { get; set; }

        public int BillNo { get; set; }
        // public int State { get; set; }
        [DefaultValue(false)]
        public bool IsCandidate { get; set; }

        // public int Version { get; set; }
        public string SendBranchID { get; set; }
        [DefaultValue(false)]
        public bool BillCheck { get; set; }
        public int BillStateID { get; set; }
        //public int? ExpressBillNo { get; set; }
        //public string ExpressNo { get; set; }


        #region
        #endregion

        #region 发件人公司其他

        public string Secondary_contact { get; set; }
        public int Secondary_Tel { get; set; }
        public string MerchandiserName { get; set; }
        public long MerchandiserId { get; set; }
        public string CompanyAbbreviation { get; set; }
        #endregion

        #region  发件人信息 
        public string ShipperCompanyName { get; set; }
        public string ShipperAccount_No { get; set; }
        public string ShipperName { get; set; }
        public string ShipperTel { get; set; }
        public string ShipperPostCode { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperProvince { get; set; }
        public string ShipperAddress { get; set; }
        #endregion

        #region 收件人信息
        public string ReceiversCompanyName { get; set; }
        public string ReceiversAccount_No { get; set; }
        public string ReceiversName { get; set; }
        public string ReceivingTel { get; set; }
        public string ReceivingPostCode { get; set; }
        public string ReceivingCity { get; set; }
        public string ReceivingProvince { get; set; }
        public string ReceivingAddress { get; set; }

        #endregion
        //总件数
        public string Totalnumberofpackages { get; set; }
        //总数量
        public string Totalweight { get; set; }
        //计算过的体积 M^3
        public string Volume { get; set; }
        ////计重体积比例  /5000 或/6000    volume-ratio
        //public string Measurementrules { get; set; }
        ////计重体积
        //public string Volume_weight { get; set; }
        ////计费重量
        //public string Chargeableweight { get; set; }


        ////是否回单
        //public bool Has_return { get; set; }
        //服务类别 快递 【资料 包裹】 物流｛下拉｝
          //服务类别  物流1   快递资料2 快递包裹3  国际运输5  
        public string SERVICELEVEL { get; set; }
        //陆运  航空没说明  航空当日达  航空次日达｛下拉｝

        //0陆运  1航空(没说明)  2航空当日达  3航空次日达 
        public string TransportationMode { get; set; }
        ////收货时间--暂无使用
        //public string Receivingdates { get; set; }
        //内容说明  相当于货物和数量的详情备注
        public string CONTENT { get; set; }
        //货值 
        public string Value { get; set; }
        //是否保价
        public bool HasInsured { get; set; }
        //支付方  谁1发件人/2收件人/3第三方
        public string PaymentType { get; set; }
        //支付方式  1月结/2现金/3支票
        public string CHARGES { get; set; }

        ////税点
        //public int Tax_point { get; set; }
        ////是否启用税点计算
        //public bool isTax { get; set; }
        //!!!!!!!暂无
        //public string Other_fees { get; set; }
        //成本   --应付的统计
        //public string The_cost { get; set; }


        #region 应收

        public bool isPacking { get; set; }
        public bool isUpstairs { get; set; }

        // 运输费 ==物流费
        public string TRANSPORTATION { get; set; }
        // 备注
        public string Remark { get; set; }
        ////送货费 physical production 产品配送 
        //public string Distribution { get; set; }
        ////提货费（可空）

        //public string Delivery { get; set; }
        ////中转费（可空）[On-carriage 转运]
        //public string Transfer { get; set; }
        ////包装费（可空）【可出售托盘】
        //public string Packing { get; set; }
        ////托盘费（可空）
        //public string Pallet { get; set; }
        ////上楼费（可空）
        //public string Upstairs { get; set; }
        //其他
        public string OTHER { get; set; }
        //总计
        public string TOTAL_CHARGES { get; set; }
        #endregion




        //public string BillImgUrl { get; set; }
    }


    public class BillOLDto : EntityDto<long>
    {
        public new long? Id { get; set; }

        public int BillNo { get; set; }
        // public int State { get; set; }
        [DefaultValue(false)]
        public bool IsCandidate { get; set; }

        // public int Version { get; set; }
        public string SendBranchID { get; set; }
        [DefaultValue(false)]
        public bool BillCheck { get; set; }
        public int BillStateID { get; set; }
        //public int? ExpressBillNo { get; set; }
        //public string ExpressNo { get; set; }


        #region
        #endregion

        #region 发件人公司其他

        public string Secondary_contact { get; set; }
        public int Secondary_Tel { get; set; }
        public string MerchandiserName { get; set; }
        public long MerchandiserId { get; set; }
        public string CompanyAbbreviation { get; set; }
        #endregion

        #region  发件人信息 
        public string ShipperCompanyName { get; set; }
        public string ShipperAccount_No { get; set; }
        public string ShipperName { get; set; }
        public string ShipperTel { get; set; }
        public string ShipperPostCode { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperProvince { get; set; }
        public string ShipperAddress { get; set; }
        #endregion

        #region 收件人信息
        public string ReceiversCompanyName { get; set; }
        public string ReceiversAccount_No { get; set; }
        public string ReceiversName { get; set; }
        public string ReceivingTel { get; set; }
        public string ReceivingPostCode { get; set; }
        public string ReceivingCity { get; set; }
        public string ReceivingProvince { get; set; }
        public string ReceivingAddress { get; set; }

        #endregion
        //总件数
        public string Totalnumberofpackages { get; set; }
        //总数量
        public string Totalweight { get; set; }
        //计算过的体积 M^3
        public string Volume { get; set; }
        //计重体积比例  /5000 或/6000    volume-ratio
        public string Measurementrules { get; set; }
        //计重体积
        public string Volume_weight { get; set; }
        //计费重量
        public string Chargeableweight { get; set; }


        //是否回单
        public bool Has_return { get; set; }
        //服务类别 快递 【资料 包裹】 物流｛下拉｝
        public string SERVICELEVEL { get; set; }
        //陆运  航空没说明  航空当日达  航空次日达｛下拉｝
        public string TransportationMode { get; set; }
        //收货时间--暂无使用
        public string Receivingdates { get; set; }
        //内容说明  相当于货物和数量的详情备注
        public string CONTENT { get; set; }
        //货值 
        public string Value { get; set; }
        //是否保价
        public bool HasInsured { get; set; }
        //支付方  谁1发件人/2收件人/3第三方
        public string PaymentType { get; set; }
        //支付方式  1月结/2现金/3支票
        public string CHARGES { get; set; } 
          
        //税点
        public int Tax_point { get; set; }
        //是否启用税点计算
        public bool isTax { get; set; }
        //!!!!!!!暂无
        public string Other_fees { get; set; }
        //成本   --应付的统计
        public string The_cost { get; set; }  


        #region 应收
        // 运输费 ==物流费
        public string TRANSPORTATION { get; set; }
        // 备注
        public string Remark { get; set; }
        //送货费 physical production 产品配送


        public string Distribution { get; set; }
        //提货费（可空）

        public string Delivery { get; set; }
        //中转费（可空）[On-carriage 转运]
        public string Transfer { get; set; }
        //包装费（可空）【可出售托盘】
        public string Packing { get; set; }
        //托盘费（可空）
        public string Pallet { get; set; }
        //上楼费（可空）
        public string Upstairs { get; set; }

        public string OTHER { get; set; }
        //总计
        public string TOTAL_CHARGES { get; set; }
        #endregion 
 



        public string BillImgUrl { get; set; }
    }


    public class SearchBillInfoInput
    {
        public SearchBillInfoInput()
        {
            PageIndex = 1;
            PageSize = 30;
        }
        [DefaultValue(1)]
        public int PageIndex { get; set; }
        [DefaultValue(20)]
        public int PageSize { get; set; }
        public string ExpressNo { get; set; }
        public long UserId { get; set; }
        public string CompanyAbbreviation { get; set; }
        public string ReceivingCity { get; set; }
        public int? BillNo { get; set; }
        public DateTime? CreationTimeS { get; set; }
        public DateTime? CreationTimeE { get; set; }


    }
    public class SearchBusinessExecl
    {
        public string CompanyAbbreviation { get; set; }
        public string ReceivingCity { get; set; }
        public string ExpressNo { get; set; }
        public int? BillNo { get; set; }
        public DateTime? CreationTimeS { get; set; }
        public DateTime? CreationTimeE { get; set; }
    }

    public class BillInfoBusinessDto
    {
        public DateTime CreationTime { get; set; }
        public int BillNo { get; set; }
        public long Id { get; set; }
        public string ShipperCity { get; set; }
        public string ReceivingCity { get; set; }
        public string CONTENT { get; set; }
        public string Totalnumberofpackages { get; set; }
        public string Totalweight { get; set; }
        public string Volume { get; set; }
        public string Delivery { get; set; }
        public string Distribution { get; set; }
        public string TransportationMode { get; set; }
        public string Transfer { get; set; }
        public string Upstairs { get; set; }
        public string Pallet { get; set; }
        public string Other_fees { get; set; }
        public string TOTAL_CHARGES { get; set; }
        public int Tax_point { get; set; }
        public string The_cost { get; set; }
        public string Remark { get; set; }
        public bool Has_return { get; set; }

    }

    [AutoMap(typeof(BillInfo))]
    public class SearchBIllInfoDto
    {
        public long Id { get; set; }

        public int BillStateID { get; set; }
        public string CompanyAbbreviation { get; set; }
        public int BillNo { get; set; }
        public string ShipperCity { get; set; }
        public string ReceivingCity { get; set; }
        public string Volume { get; set; }
        public string Totalweight { get; set; }
        public string Totalnumberofpackages { get; set; }
        public bool BillCheck { get; set; }

    }
}
