using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Web;
using System.IO;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories; 
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using RQCore.RQEnitity;
using RQCore.RQAppService;
using RQCore.Controllers;
using System.Data;
using RQCore.RQDtos;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using AutoMapper;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using Abp.Domain.Uow;

namespace RQCore.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : RQCoreControllerBase
    {
        private readonly IRepository<Plu, int> _PluserRepository;
        public readonly IRepository<TruckInfo, long> _userRepository;
        public readonly IRepository<T_GoodsImg, int> _T_GoodsImgRepository;
        public ImageController(IRepository<TruckInfo, long> userRepository, IRepository<Plu, int> PluserRepository, IRepository<T_GoodsImg, int> T_GoodsImgRepository)
        {
            _userRepository = userRepository;
            _PluserRepository = PluserRepository;
            _T_GoodsImgRepository = T_GoodsImgRepository;
        }
        // GET: api/Image
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Image/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(long id)
        {
            var TruckID = id;
            var task = _userRepository.GetAll().FirstOrDefault(t => t.TruckID == TruckID);
            task.TruckPhoto = "1234566789";
            _userRepository.Update(task);
            return "value";
        }

        [HttpPost("api/QualificationOne/Upload")]
        public string Upload(/*IFormCollection Files, int EntId, int CrtUser*/)
        {

            {

                try
                {
                    //var form = Request.Form;//直接从表单里面获取文件名不需要参数
                    // string dd = Files["File"];
                    // var form = Files;//定义接收类型的参数

                    // Hashtable hash = new Hashtable();
                   
                    IFormFileCollection cols = Request.Form.Files;
                    var TruckID_s = Request.Form["TruckID"];
                    long TruckID = Convert.ToInt64(TruckID_s);
                    long size = cols.Sum(f => f.Length);
                    if (cols == null || cols.Count == 0)
                    {
                        return "没有上传文件";
                    }
                    foreach (IFormFile file in cols)
                    {
                        //定义图片数组后缀格式
                        string[] LimitPictureType = { ".JPG", ".JPEG", ".GIF", ".PNG", ".BMP" };
                        //获取图片后缀是否存在数组中
                        string currentPictureExtension = Path.GetExtension(file.FileName).ToUpper();
                        if (LimitPictureType.Contains(currentPictureExtension))
                        {

                            //为了查看图片就不在重新生成文件名称了
                            // var new_path = DateTime.Now.ToString("yyyyMMdd")+ file.FileName;
                            var upload_path = ("../Attach/Truck/" + TruckID + "");
                            var new_path = Path.Combine("../Attach/" + TruckID + "/", file.FileName);
                            if (!Directory.Exists(upload_path))
                            {//如果不存在文件夹则创建
                                Directory.CreateDirectory(upload_path);
                            }
                            else
                            {
                                Directory.Delete(upload_path,true);
                                Directory.CreateDirectory(upload_path);

                            }


                            // var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", new_path);  //Directory.GetCurrentDirectory()  当前目录

                            using (var stream = new FileStream(new_path, FileMode.Create))
                            {
                                var task = _userRepository.GetAll().FirstOrDefault(t => t.TruckID == TruckID);
                                task.TruckPhoto = new_path;
                                _userRepository.Update(task);

                                //再把文件保存的文件夹中
                                file.CopyTo(stream);

                            }
                        }
                        else
                        {
                            return "请上传指定格式的图片";
                        }
                    }

                    return "上传成功";

                }
                catch (Exception)
                {

                    return "上传失败";
                }


            }
        }

        /// <summary>
        /// base64接收图片上传
        /// </summary>
        /// <param name="TruckID">文件夹名称</param>
        /// <param name="Imagestr">base64字符串</param>
        [HttpPost("api/UploadImage")]
        public void UploadImage(dynamic objct)
        {
            long TruckID = Convert.ToInt64(objct.TruckID);
            string Imagestr = Convert.ToString(objct.Imagestr);
            var upload_path = ("../Attach/" + TruckID + "");
            var new_path = Path.Combine("../Attach/" + TruckID + "/Abp.png");
            if (!Directory.Exists(upload_path))
            {//如果不存在文件夹则创建
                Directory.CreateDirectory(upload_path);
            }
            string base64 = Imagestr;
            byte[] bytes = Convert.FromBase64String(base64);
            MemoryStream memStream = new MemoryStream(bytes);
            Bitmap binFormatter = new Bitmap(memStream);
            binFormatter.Save(new_path);

        }

       /// <summary>
       /// 订单图片上传
       /// </summary>
       /// <param name="objct"></param>
       /// <returns></returns>
        [UnitOfWork]
        [HttpPost("api/SaveImage")]
        public int? SaveImage(dynamic objct)
        {
            long BillNo = Convert.ToInt64(objct.BillNo);  //接收主键作为文件夹名称
            
            List<string> Imagestrlist = new List<string>();  //定义集合接收base64数组
            //foreach (dynamic Imagestr in objct.Imagestr)
            //{
                Imagestrlist.Add(Convert.ToString(objct.Imagestr));  //接收数据
           // }
          
       
            string Directory_path = "../RQCore.Web.Host/wwwroot/Attach/BillInfo/" + BillNo;  //文件夹地址
            
           // string filepath = Path.GetDirectoryName(Directory_path);  获取文件所在文件夹
            // 如果不存在就创建file文件夹
            if (!Directory.Exists(Directory_path))
            {
                if (Directory_path != null) Directory.CreateDirectory(Directory_path);  
            }
            else
            {   Directory.Delete(Directory_path,true);
                Directory.CreateDirectory(Directory_path);
            }

            //for (int i=0;i<= Imagestrlist.Count-1;i++)
            //{
                var Format = Imagestrlist[0].Split(new string[2]{ "data:image/",";base64,"},StringSplitOptions.RemoveEmptyEntries)[0];  //接收base64图片格式
                var name = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".jpg";   //图片命名
                var path = Directory_path + "/" + name;   //最终路径
            var path_newUrl = "/Attach/BillInfo/" + BillNo + "/" + name;

                var match = Regex.Match(Imagestrlist[0], "data:image/"+ Format + ";base64,([\\w\\W]*)$");//
                if (match.Success)
                {
                    Imagestrlist[0] = match.Groups[1].Value;
                }
                    var photoBytes = Convert.FromBase64String(Imagestrlist[0]);
                    System.IO.File.WriteAllBytes(path, photoBytes);//输出图片到指定路径


            T_GoodsImg task = new T_GoodsImg
            {
                Id = null,
                TGID= BillNo,
                ImgUrl = path_newUrl
            };
            var result = _T_GoodsImgRepository.InsertAndGetId(task);
            CurrentUnitOfWork.SaveChanges();
            return task.Id;



            //}
        }

        /// <summary>
        /// 车辆信息多图片上传接口
        /// </summary>
        /// <param name="objct"></param>
        [HttpPost("api/TruckInfoImage")]
        public void TruckInfoImage(dynamic objct)
        {
            long TruckId = Convert.ToInt64(objct.TruckId);  //接收主键作为文件夹名称

            List<string> Imagestrlist = new List<string>();  //定义集合接收base64数组
            foreach (dynamic Imagestr in objct.Imagestr)
            {
                Imagestrlist.Add(Convert.ToString(Imagestr));  //接收数据
            }

            string Directory_path = "../RQCore.Web.Host/wwwroot/Attach/TruckInfo/" + TruckId;  //文件夹地址

            // string filepath = Path.GetDirectoryName(Directory_path);  获取文件所在文件夹
            // 如果不存在就创建file文件夹
            if (!Directory.Exists(Directory_path))
            {
                if (Directory_path != null) Directory.CreateDirectory(Directory_path);
            }
            else
            {
                Directory.Delete(Directory_path, true);
                Directory.CreateDirectory(Directory_path);
            }

            //for (int i = 0; i <= Imagestrlist.Count - 1; i++)
            //{
                var Format = Imagestrlist[0].Split(new string[2] { "data:image/", ";base64," }, StringSplitOptions.RemoveEmptyEntries)[0];  //接收base64图片格式
                var name = DateTime.Now.ToString() + ".jpg";   //图片命名
                var path = Directory_path + "/" + name;   //最终路径
            var path_newUrl = "/Attach/BillInfo/" + TruckId + "/" + name;

            var match = Regex.Match(Imagestrlist[0], "data:image/" + Format + ";base64,([\\w\\W]*)$");//
                if (match.Success)
                {
                    Imagestrlist[0] = match.Groups[1].Value;
                }
                var photoBytes = Convert.FromBase64String(Imagestrlist[0]);
                System.IO.File.WriteAllBytes(path, photoBytes);//输出图片到指定路径


            //var task = _userRepository.GetAll().FirstOrDefault(t => t.truck == TruckID);
            //task.TruckPhoto = path;
            //_userRepository.Update(task);


            //}
        }
        
        /// <summary>
        /// 订单页面图片删除接口
        /// </summary>
        /// <param name="taskId"></param>
        [HttpDelete("api/DeleteImage")]
        public void DeleteImage( int taskId)
        {
            var task = _T_GoodsImgRepository.FirstOrDefault(t => t.Id == taskId);
            if (task!=null)
            {
                _T_GoodsImgRepository.Delete(t => t.Id == taskId);
            }
        }
    }
}

