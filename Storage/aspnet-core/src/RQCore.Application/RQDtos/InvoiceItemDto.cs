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
    [AutoMap(typeof(InvoiceItem))]
    public class InvoiceItemDto
    {


        public    int? Id { get; set; }
        //public int UserID { get; set; }
        //发票批号
        //public string InvoiceserialNo { get; set; } 
        public uint InvoiceNo { get; set; } //发票编号




        #region   清单子项信息
        public int InvoiceItemNo { get; set; }
        public string Goods { get; set; }
        public string Specifications { get; set; }
        public string Unit { get; set; }
        public int Qty { get; set; }
        public decimal Unit_Price { get; set; }
        public int Amount { get; set; }
        public decimal TaxRate { get; set; }

        public decimal TaxAmount { get; set; }
        #endregion


        #region  其他  标识
        public string InvoiceStateID { get; set; }
        public string InvoiceBillNo { get; set; }
        public int Status { get; set; }
        public int BranchID { get; set; }
        //public string ID { get; set; }

        public int Sorting { get; set; }
        //public string IsCandidate { get; set; }
        //public string Version { get; set; } 
        //public string BillCheck { get; set; } 
        public string Claime_Type { get; set; }
        public string Claim_Name { get; set; }


        //public long? CreatorUserId { get; set; }
        //public DateTime CreationTime { get; set; }
        //public long? LastModifierUserId { get; set; }
        //public DateTime? LastModificationTime { get; set; }
        //public long? DeleterUserId { get; set; }
        //public DateTime? DeletionTime { get; set; }
        //public bool IsDeleted { get; set; }
        #endregion





    }

    [AutoMap(typeof(InvoiceItem))]
    public class  InvoiceItemInput
    {
        #region  搜索

        public int pageIndex { get; set; }

        public int pageSize { get; set; }
        //public int BranchID { get; set; }

        #endregion

        public int? Id { get; set; }

        public uint InvoiceNo { get; set; } //发票编号
 

        #region   清单子项信息
        public int InvoiceItemNo { get; set; }
        public string Goods { get; set; }
        public string Specifications { get; set; }
        public string Unit { get; set; }
        public int Qty { get; set; }
        public decimal Unit_Price { get; set; }
        public int Amount { get; set; }
        public decimal TaxRate { get; set; }

        public decimal TaxAmount { get; set; }
        #endregion
    }


    public class SearchInvoiceItemInput
    {

        //发票批号
        public uint InvoiceserialNo { get; set; }
        public uint InvoiceNo { get; set; } //发票编号


        #region  搜索

        public int pageIndex { get; set; }

        public int pageSize { get; set; }

        public int Status { get; set; }
        //public int BranchID { get; set; }

        #endregion

        public string Claime_Type { get; set; }
        public string Claim_Name { get; set; }
        public string AfficheTitle { get; set; }


        public int? BranchID { get; set; }

        public string BranchName { get; set; }



    }
}
