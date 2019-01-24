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
    [AutoMap(typeof(InvoiceInfo))]
    public class InvoiceInfoDto
    { 
        public   int? Id { get; set; } 
        //public int UserID { get; set; }
        //发票批号
        public uint InvoiceserialNo { get; set; }
        public uint InvoiceNo { get; set; } //发票编号

        #region

        #endregion

 

        #region  下半身
        public decimal Total { get; set; }
        public string Price_Plus_Taxes { get; set; }
        public decimal Arabic_Numbers { get; set; }

        public string Payee { get; set; }
        public string Review { get; set; }
        public string Drawer { get; set; }
        public string The_Seller { get; set; }

        #endregion




        #region  其他  标识
        public uint InvoiceStateID { get; set; }
        public uint InvoiceBillNo { get; set; }

        public uint Sorting { get; set; }
        //public string ID { get; set; }

        public bool IsCandidate { get; set; }
        public uint Version { get; set; }
        public uint BillCheck { get; set; }
        public string Claime_Type { get; set; }
        public string Claim_Name { get; set; }


        #endregion


        #region   纳税人信息的
        public string CompanyName { get; set; }
        public string Taxpayer_identification_number { get; set; }

        public string MyCompanyName { get; set; }
        public string MyTaxpayer_identification_number { get; set; }
        #endregion


        #region  搜索

        public int pageIndex { get; set; }

        public int pageSize { get; set; }

        public int Status { get; set; }
        public int BranchID { get; set; } 
        public string BranchName { get; set; }

        #endregion

   
         






    }


    public class SearchInvoiceInput
    {

        //发票批号
        //public string InvoiceserialNo { get; set; }
        //public string InvoiceNo { get; set; } //发票编号


        #region  搜索

        public int pageIndex { get; set; }

        public int pageSize { get; set; }

        //public int Status { get; set; }
        //public int BranchID { get; set; }

        #endregion

        //public string Claime_Type { get; set; }
        //public string Claim_Name { get; set; }
        //public string AfficheTitle { get; set; }


        //public int BranchID { get; set; }

        //public string BranchName { get; set; }



    }
}
