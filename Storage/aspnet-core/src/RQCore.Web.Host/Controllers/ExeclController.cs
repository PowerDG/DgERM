using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Validation;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using RQCore.Controllers;
using RQCore.RQDtos;
using RQCore.RQEnitity;


namespace RQCore.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExeclController : RQCoreControllerBase
    {
        private readonly IRepository<Plu, int> _PluserRepository;
        private readonly IRepository<TruckInfo, long> _userRepository;
        private readonly IRepository<BillInfo, long> _BillInfoRepository;
        private readonly IRepository<Express,int> _ExpressRepository;
        public ExeclController
            (
            IRepository<TruckInfo, long> userRepository,
            IRepository<Plu, int> PluserRepository,
            IRepository<BillInfo, long> BillInfoRepository,
            IRepository<Express, int> ExpressRepository
            )
        {
            _userRepository = userRepository;
            _PluserRepository = PluserRepository;
            _BillInfoRepository = BillInfoRepository;
            _ExpressRepository = ExpressRepository;
        }
        /// <summary>
        /// 物流查价上传
        /// </summary>
        [HttpPost("api/Insertexecl")]
        public void Insertexecl()
        {
            DataTable datatable = new DataTable();
            IFormFileCollection Files = Request.Form.Files;
            if (Files.Count == 1)
            {
                
                foreach (IFormFile File in Files)
                {
                    string name = "物流查价" + DateTime.Now.ToString("YYYY-MM-DD-hh-mm-ss") + ".xlsx";
                    string stream_path = "../EXECL";
                    string path = "../EXECL/" + name;
                    if(!Directory.Exists(stream_path))
                    { Directory.CreateDirectory(stream_path); }

                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        File.CopyTo(stream);
                    }

                    // DataTable dt = ToGetDataTable(path);  //取得datatable
                    DataTable dt = new DataTable();

                    DataColumn dc1 = new DataColumn("Id", Type.GetType("System.String"));
                    DataColumn dc2 = new DataColumn("Province", Type.GetType("System.String"));
                    DataColumn dc3 = new DataColumn("Destination_city", Type.GetType("System.String"));
                    DataColumn dc4 = new DataColumn("Aging", Type.GetType("System.String"));
                    DataColumn dc5 = new DataColumn("Price_Kg", Type.GetType("System.Decimal"));
                    DataColumn dc6 = new DataColumn("Price_Cu", Type.GetType("System.Decimal"));


                    dt.Columns.Add(dc1);
                    dt.Columns.Add(dc2);
                    dt.Columns.Add(dc3);
                    dt.Columns.Add(dc4);
                    dt.Columns.Add(dc5);
                    dt.Columns.Add(dc6);
                    //以上代码完成了DataTable的构架，但是里面是没有任何数据的  
                    FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);  //创建读取数据

                    IWorkbook workBook = new XSSFWorkbook(file);
                    ISheet sheet = null;
                    sheet = workBook.GetSheetAt(0);  //默认取第一页工作簿
                    IRow firstRow = sheet.GetRow(0); //取第一行
                    int cellCount = firstRow.LastCellNum;//第一行最后一个cell的编号 即总的列数
                    int rowCount = sheet.LastRowNum;  //取最后一行，即行的总数
                    for (int i = 1; i <= rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);  //当前行
                        DataRow dr = dt.NewRow();
                        dr[0] = null;
                        dr[1] = row.GetCell(1).ToString();
                        dr[2] = row.GetCell(2).ToString();
                        dr[3] = row.GetCell(3).ToString();
                        dr[4] = Convert.ToDecimal(row.GetCell(4).ToString());
                        dr[5] = Convert.ToDecimal(row.GetCell(5).ToString());

                        dt.Rows.Add(dr);
                    }
                    datatable = dt;
                    //  result = ToinsertDatabase(dt);  //insert 数据库

                    List<string> errors = new List<string>();
                    List<string> fails = new List<string>();
                    var a = dt.Rows;
                    List<PluDto> list = new List<PluDto>();

                    for (int i = 0; i < a.Count; i++)
                    {
                        list.Add(new PluDto()
                        {
                            Id = null,
                            Province = a[i][1].ToString(),
                            Destination_city = a[i][2].ToString(),
                            Aging = a[i][3].ToString(),
                            Price_Kg = Convert.ToDecimal(a[i][4].ToString()),
                            Price_Cu = Convert.ToDecimal(a[i][5].ToString()),
                        });

                    }
                    _PluserRepository.Delete(t=> t.Id>0);  //删除数据库数据
           
                    var lists = Mapper.Map<List<Plu>>(list);
                    foreach (Plu task in lists)  //添加新数据
                    {
                        _PluserRepository.Insert(task);

                    }


                }



            }
            //return datatable;

        }
        /// <summary>
        /// 物流查价下载
        /// </summary>
        /// <returns></returns>
        [DisableValidation]
        [DisableAuditing]
        [HttpPost("api/PluexeclOut")]
        public IActionResult PluexeclOut()
        {
            string fileName = "execl.xlsx";

            var stream = new MemoryStream();
            var messages = from t in _PluserRepository.GetAll()
                           select new PluExeclOut
                           {
                               Province = t.Province,
                               Destination_city = t.Destination_city,
                               Aging = t.Aging,
                               Price_Kg = t.Price_Kg,
                               Price_Cu = t.Price_Cu
                           };
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                // add worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Conversation Message");
                //add head
                worksheet.Cells[1, 1].Value = "省份";
                worksheet.Cells[1, 2].Value = "城市";
                worksheet.Cells[1, 3].Value = "时效";
                worksheet.Cells[1, 4].Value = "重量计价/kg";
                worksheet.Cells[1, 5].Value = "体积计价/m³";

                var rowNum = 2; // rowNum 1 is head  数据循环填充
                foreach (var message in messages)
                {
                    worksheet.Cells["A" + rowNum].Value = message.Province;
                    worksheet.Cells["B" + rowNum].Value = message.Destination_city;
                    worksheet.Cells["C" + rowNum].Value = message.Aging;
                    worksheet.Cells["D" + rowNum].Value = message.Price_Kg;
                    worksheet.Cells["E" + rowNum].Value = message.Price_Cu;


                    rowNum++;
                }
                package.Save();
            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        /// <summary>
        /// 快递查价上传
        /// </summary>
        [DisableValidation]
        [DisableAuditing]
        [HttpPost("api/ExpressInserExecl")]
        public void ExpressInserExecl()
        {
            DataTable datatable = new DataTable();
            IFormFileCollection Files = Request.Form.Files;
            if (Files.Count == 1)
            {

                foreach (IFormFile File in Files)
                {
                    string name = "快递查价" + DateTime.Now.ToString("YYYY-MM-DD-hh-mm-ss") + ".xlsx";
                    string stream_path = "../EXECL/";
                    string path = "../EXECL/" + name;
                    if (!Directory.Exists(stream_path))
                    { Directory.CreateDirectory(stream_path); }

                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        File.CopyTo(stream);
                    }

                    // DataTable dt = ToGetDataTable(path);  //取得datatable
                    DataTable dt = new DataTable();

                    DataColumn dc1 = new DataColumn("Id", Type.GetType("System.String"));
                    DataColumn dc2 = new DataColumn("Type", Type.GetType("System.String"));
                    DataColumn dc3 = new DataColumn("Province", Type.GetType("System.String"));
                    DataColumn dc4 = new DataColumn("Price_Kg", Type.GetType("System.Int32"));
                    DataColumn dc5 = new DataColumn("Price_Kg_One", Type.GetType("System.Int32"));
                    DataColumn dc6 = new DataColumn("Aging", Type.GetType("System.String"));


                    dt.Columns.Add(dc1);
                    dt.Columns.Add(dc2);
                    dt.Columns.Add(dc3);
                    dt.Columns.Add(dc4);
                    dt.Columns.Add(dc5);
                    dt.Columns.Add(dc6);
                    //以上代码完成了DataTable的构架，但是里面是没有任何数据的  
                    FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);  //创建读取数据

                    IWorkbook workBook = new XSSFWorkbook(file);
                    ISheet sheet = null;
                    sheet = workBook.GetSheetAt(0);  //默认取第一页工作簿
                    IRow firstRow = sheet.GetRow(0); //取第一行
                    int cellCount = firstRow.LastCellNum;//第一行最后一个cell的编号 即总的列数
                    int rowCount = sheet.LastRowNum;  //取最后一行，即行的总数
                    for (int i = 1; i <= rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);  //当前行
                        DataRow dr = dt.NewRow();
                        dr[0] = null;
                        dr[1] = row.GetCell(0).ToString();
                        dr[2] = row.GetCell(1).ToString();
                        dr[3] = Convert.ToInt32(row.GetCell(2).ToString());
                        dr[4] = Convert.ToInt32(row.GetCell(3).ToString());
                        dr[5] =row.GetCell(4).ToString();

                        dt.Rows.Add(dr);
                    }
                    datatable = dt;
                    //  result = ToinsertDatabase(dt);  //insert 数据库

                    List<string> errors = new List<string>();
                    List<string> fails = new List<string>();
                    var a = dt.Rows;
                    List<ExpressDto> list = new List<ExpressDto>();

                    for (int i = 0; i < a.Count; i++)
                    {
                        list.Add(new ExpressDto()
                        {
                            Id=null,
                            Type=a[i][1].ToString(),
                            Province=a[i][2].ToString(),
                            Price_Kg=Convert.ToInt32( a[i][3].ToString()),
                            Price_Kg_One=Convert.ToInt32(a[i][4].ToString()),
                            Aging=a[i][5].ToString()
                       });

                    }
                    _PluserRepository.Delete(t => 1 == 1);  //删除数据库数据
                    var lists = Mapper.Map<List<Express>>(list);
                    foreach (Express task in lists)  //添加新数据
                    {
                        _ExpressRepository.Insert(task);

                    }


                }



            }
            //return datatable;

        }

        /// <summary>
        /// 快递查价下载
        /// </summary>
        /// <returns></returns>
        [DisableValidation]
        [DisableAuditing]
        [HttpPost("api/ExpressclOut")]
        public IActionResult ExpressOut()
        {
            string fileName = "execl.xlsx";

            var stream = new MemoryStream();
            var messages = from t in _ExpressRepository.GetAll()
                           select new ExpressExeclOut
                           {
                              Type=t.Type,
                              Province=t.Province,
                              Price_Kg=t.Price_Kg,
                              Price_Kg_One=t.Price_Kg_One,
                              Aging=t.Aging
                           };
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                // add worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Conversation Message");
                //add head
                worksheet.Cells[1, 1].Value = "类型";
                worksheet.Cells[1, 2].Value = "城市";
                worksheet.Cells[1, 3].Value = "首重价格(元/KG)(标准1KG，优惠3KG)";
                worksheet.Cells[1, 4].Value = "续重价格(元/kg)";
                worksheet.Cells[1, 5].Value = "时效";

                var rowNum = 2; // rowNum 1 is head  数据循环填充
                foreach (var message in messages)
                {
                    worksheet.Cells["A" + rowNum].Value = message.Type;
                    worksheet.Cells["B" + rowNum].Value = message.Province;
                    worksheet.Cells["C" + rowNum].Value = message.Price_Kg;
                    worksheet.Cells["D" + rowNum].Value = message.Price_Kg_One;
                    worksheet.Cells["E" + rowNum].Value = message.Aging;


                    rowNum++;
                }
                package.Save();
            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        /// <summary>
        /// 业务下载
        /// </summary>
        /// <param name="BusinessExecl"></param>
        /// <returns></returns>
        [DisableValidation]
        [DisableAuditing]
        [HttpPost("api/Export")]
        public IActionResult Export(SearchBusinessExecl BusinessExecl)
        {

            string fileName = "execl.xlsx";

            var stream = new MemoryStream();
           
            var messages = from t in _BillInfoRepository.GetAll().Where(t => t.IsCandidate == false)
                                    .WhereIf(BusinessExecl.BillNo.HasValue, t => t.BillNo == BusinessExecl.BillNo)
                                    .WhereIf(!BusinessExecl.CompanyAbbreviation.IsNullOrEmpty(), t => t.CompanyAbbreviation == BusinessExecl.CompanyAbbreviation)
                                    .WhereIf(!BusinessExecl.ReceivingCity.IsNullOrEmpty(), t => t.ReceivingCity == BusinessExecl.ReceivingCity)
                                    .WhereIf(BusinessExecl.CreationTimeS.HasValue, t => t.CreationTime >= BusinessExecl.CreationTimeS)
                                    .WhereIf(BusinessExecl.CreationTimeE.HasValue, t => t.CreationTime <= BusinessExecl.CreationTimeE)
                                    .WhereIf(!BusinessExecl.ExpressNo.IsNullOrEmpty(), t => t.ExpressNo == BusinessExecl.ExpressNo)
                           select new BillInfoBusinessDto
                           {
                               CreationTime=t.CreationTime,
                               BillNo=t.BillNo,
                               Id = t.Id,
                               ShipperCity = t.ShipperCity,
                               ReceivingCity = t.ReceivingCity,
                               CONTENT = t.CONTENT,
                               Totalnumberofpackages = t.Totalnumberofpackages,
                               Totalweight = t.Totalweight,
                               Volume = t.Volume,
                               Delivery = t.Delivery,
                               Distribution = t.Distribution,
                               TransportationMode = t.TransportationMode,
                               Transfer = t.Transfer,
                               Upstairs = t.Upstairs,
                               Pallet = t.Pallet,
                               Other_fees = t.Other_fees,
                               TOTAL_CHARGES = t.TOTAL_CHARGES,
                               Tax_point = t.Tax_point,
                               The_cost = t.The_cost,
                               Remark = t.Remark,
                               Has_return = t.Has_return
                           };
           // var columns = new ConversationMessage();
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                // add worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Conversation Message");
                //add head
                worksheet.Cells[1, 1].Value = "CreationTime";
                worksheet.Cells[1, 2].Value = "BillNo";
                worksheet.Cells[1, 3].Value = "ShipperCity";
                worksheet.Cells[1, 4].Value = "ReceivingCity";
                worksheet.Cells[1, 5].Value = "CONTENT";
                worksheet.Cells[1, 6].Value = "Totalnumberofpackages";
                worksheet.Cells[1, 7].Value = "Totalweight";
                worksheet.Cells[1, 8].Value = "Volume";
                worksheet.Cells[1, 9].Value = "Delivery";
                worksheet.Cells[1, 10].Value = "Distribution";
                worksheet.Cells[1, 11].Value = "TransportationMode";
                worksheet.Cells[1, 12].Value = "Transfer";
                worksheet.Cells[1, 13].Value = "Upstairs";
                worksheet.Cells[1, 14].Value = "Pallet";
                worksheet.Cells[1, 15].Value = "Other_fees";
                worksheet.Cells[1, 16].Value = "TOTAL_CHARGES";
                worksheet.Cells[1, 17].Value = "Tax_point";
                worksheet.Cells[1, 18].Value = "The_cost";
                worksheet.Cells[1, 19].Value = "Remark";
                worksheet.Cells[1, 20].Value = "Has_return";

                //add value
                var rowNum = 2; // rowNum 1 is head  数据循环填充
                foreach (var message in messages)
                {
                    worksheet.Cells["A" + rowNum].Value = message.CreationTime;
                    worksheet.Cells["B" + rowNum].Value = message.BillNo;
                    worksheet.Cells["C" + rowNum].Value = message.ShipperCity;
                    worksheet.Cells["D" + rowNum].Value = message.ReceivingCity;
                    worksheet.Cells["E" + rowNum].Value = message.CONTENT;
                    worksheet.Cells["F" + rowNum].Value = message.Totalnumberofpackages;
                    worksheet.Cells["G" + rowNum].Value = message.Totalweight;
                    worksheet.Cells["H" + rowNum].Value = message.Volume;
                    worksheet.Cells["I" + rowNum].Value = message.Delivery;
                    worksheet.Cells["J" + rowNum].Value = message.Distribution;
                    worksheet.Cells["K" + rowNum].Value = message.TransportationMode;
                    worksheet.Cells["L" + rowNum].Value = message.Transfer;
                    worksheet.Cells["M" + rowNum].Value = message.Upstairs;
                    worksheet.Cells["N" + rowNum].Value = message.Pallet;
                    worksheet.Cells["O" + rowNum].Value = message.Other_fees;
                    worksheet.Cells["P" + rowNum].Value = message.TOTAL_CHARGES;
                    worksheet.Cells["Q" + rowNum].Value = message.Tax_point;
                    worksheet.Cells["R" + rowNum].Value = message.The_cost;
                    worksheet.Cells["S" + rowNum].Value = message.Remark;
                    worksheet.Cells["T" + rowNum].Value = message.Has_return;


                    rowNum++;
                }
                package.Save();
            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

    }
}