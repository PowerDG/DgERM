import ajax from './ajax'
const baseURL="http://localhost:21021"
//  const baseURL="http://192.168.1.21:21021"
//   const baseURL = "http://" + window.location.host;
                                            //客户信息模块接口
//1.获取客户信息表格数据
export const reqKhTablelist =()=>ajax(baseURL+'/api/services/app/CustomerInfoService/GetAllMissions')
//2.新建客户信息
export const reqHjKhinfo=(form)=>ajax(baseURL+'/api/services/app/CustomerInfoService/CreateMission',form,'POST')
//3.点击单行查询,返回一行数据
export const reqKHGetById=(taskId)=>ajax(baseURL+'/api/services/app/CustomerInfoService/GetMissionById',{taskId})
//4.更新客户信息
export const reqKHUpadate=(form)=>ajax(baseURL+'/api/services/app/CustomerInfoService/UpdateMission',form,'PUT')
//5.删除客户信息
export const reqKHDelete=(taskId)=>ajax(baseURL+'/api/services/app/CustomerInfoService/DeleteMission',{taskId},'DELETE')
//6.客户分页
export const reqPagenation=(pageIndex,pageSize)=>ajax(baseURL+'/api/services/app/CustomerInfoService/GetPagedCustomerInfos',{pageIndex:pageIndex,pageSize:pageSize})
//7.客户CustomerID检查是否已存在接口
export const reqKHexist=(form)=>ajax(baseURL+'/api/services/app/CustomerInfoService/CheckCusId',form,'POST')
                                         //货单页面模块接口
//1.获取货单页面表格数据
export const reqHdTablelist = ()=> ajax(baseURL+'/api/services/app/BillInfoService/GetAllMissions') 
//2.货单分页
export const reqHdPagenation=(PageIndex,PageSize,Companyquery,ReceivingCity,BillNo,CreationTimeS,CreationTimeE)=>ajax
(baseURL+'/api/services/app/BillInfoService/GetPagedBillInfos',{PageIndex:PageIndex,PageSize:PageSize,Companyquery,ReceivingCity,BillNo,CreationTimeS,CreationTimeE})
//3.新建货单信息
export const reqHjHdinfo=(form)=>ajax(baseURL+'/api/services/app/BillInfoService/CreateMission_user',form,'POST')
//4.快递运商下拉接口
export const reqHdselectlist=()=>ajax(baseURL+'/api/services/app/T_ExpressTypeService/GetAllMession')
//5.货单快递信息接口
export const reqSend100=(com,strl)=>ajax(baseURL+'/api/services/app/Send100Service/Get',{com,strl})
//6.本地快递信息接口
export const reqlocalsend100=(taskId)=>ajax(baseURL+'/api/services/app/LogisticsInfoService/GetLogisticsInfo',{taskId})
//7.接受主键参数 单行查询 返回一行数据
export const reqHdgetrow=(taskId)=>ajax(baseURL+'/api/services/app/BillInfoService/GetMissionById',{taskId})
//8.删除货单信息接口
export const reqHddelete=(taskId)=>ajax(baseURL+'/api/services/app/BillInfoService/DeleteMission_admin',{taskId},'DELETE')
//9.更新货单数据接口
export const reqHdupdate=(form)=>ajax(baseURL+'/api/services/app/BillInfoService/UpdateMission',form,'PUT')
//10.获取目的地城市下拉菜单
export const reqHdCitySelectList=()=>ajax(baseURL+'/api/services/app/PluService/GetAllCity')
//11.物流状态下拉框
export const reqHdWuliuSelectlist=()=>ajax(baseURL+'/api/services/app/LogisticsInfoService/GetLogisticsState')
//12.更新物流信息
export const reqHdwuliuinfo=(taskId)=>ajax(baseURL+'/api/services/app/LogisticsInfoService/GetLogisticsInfo',{taskId})
//13.填写物流信息
export const reqHdOrderstatusinfo=(form)=>ajax(baseURL+'/api/services/app/LogisticsInfoService/CreateMissionQ',form,'POST')
//14.客户简称下拉框接口 
export const reqHdKHselectlist=()=>ajax(baseURL+'/api/services/app/CustomerInfoService/GetCustomerIDList')
//15.客户简称悬浮框接口
export const reqHdXFlist=(taskId)=>ajax(baseURL+'/api/services/app/CustomerInfoService/GetMissionById',{taskId})
//16.获取省份接口接口
export const reqHdReceiveProvince=()=>ajax(baseURL+'/api/services/app/PluService/GetProvince');
//17.根据省份获取城市下拉
export const reqHDReceivecity=(taskId)=>ajax(baseURL+'/api/services/app/PluService/GetCity',{taskId})
//18.货单BillNO查重
export const reqHdBillNoexist=(form)=>ajax(baseURL+'/api/services/app/BillInfoService/CheckBillInfo',form,'POST')
//19.订单页面图片删除接口
export const  reqHdDeleteimg=(taksId)=>ajax(baseURL+'/api/Image/api/DeleteImage',{taksId},'DELETE')
//19.订单图片加载接口
export const  reqHdimgjiazai=(taskId)=>ajax(baseURL+'/api/services/app/T_GoodsImg/GetImageUrl',{taskId})
//19.订单图片加载接口
export const  reqHdimgjiazaiById=(taskId)=>ajax(baseURL+'/api/services/app/T_GoodsImg/GetMissionById',{taskId})

                                    //业务模块接口
//1.表格分页接口
export const reqBussinessPagation=(PageIndex,PageSize,ExpressNo,UserId,CompanyAbbreviation,ReceivingCity,BillNo,CreationTimeS,CreationTimeE)=>ajax(baseURL
        +'/api/services/app/BillInfoService/GetPagedBusiness',{PageIndex,PageSize,ExpressNo,UserId,CompanyAbbreviation,ReceivingCity,BillNo,CreationTimeS,CreationTimeE})



//2.导出EXCEL
export const reqBussinessEXCEL=(form)=>ajax(baseURL+'/api/Execl/api/Export',form,'POST')

//3.业务结算
export const reqBussinessid=(form)=>ajax(baseURL+'/api/services/app/BillInfoService/Balance',form,'POST')
                                     //车辆页面接口
//1.获取车辆管理表格数据
export const reqCLTablelist =()=> ajax(baseURL+'/api/services/app/TruckInfoService/GetMissionById')
//2.车辆分页接口
export const reqCLGetPagedTask=(TruckID,pageIndex,pageSize,TruckNum,TruckEngineNum,TruckRunNum,TruckInsuranceNum,TMID,TruckColor,TruckBuyDate,BranchID,TruckIsVacancy)=>ajax(baseURL+'/api/services/app/TruckInfoService/GetPagedTasks',{TruckID,pageIndex,pageSize,TruckNum,TruckEngineNum,TruckRunNum,TruckInsuranceNum,TMID,TruckColor,TruckBuyDate,BranchID,TruckIsVacancy})

//2.获取车辆型号ID和车辆型号名称
export const reqlistOps=()=>ajax(baseURL+'/api/services/app/TruckInfoService/GetMissionById')
//3.新建车辆信息
export const reqHjCLinfo=(form)=>ajax(baseURL+'/api/services/app/TruckInfoService/CreateMission',form,'POST')
//4.更新车辆信息
export const reqCLUpdate=(form)=>ajax(baseURL+'/api/services/app/TruckInfoService/UpdateMission',form,'PUT')

//1.单独获取分公司编号
export const reqBranchId=()=>ajax(baseURL+'/api/services/app/BranchInfoService/GetBranchIdList')



                                    //转包运商接口
//1.分页接口
export const reqZBYSPagation=(PageSize,PageIndex,ExpressName,IsDefaultShow)=>ajax(baseURL+'/api/services/app/T_ExpressTypeService/GetPagedT_ExpressTypes',{PageSize,PageIndex,ExpressName,IsDefaultShow})

//2.更新接口
export const reqZBYSupdate=(form)=>ajax(baseURL+'/api/services/app/T_ExpressTypeService/UpdateMission',form,'PUT')
//3.快递查价excel导出
export const reqkuaidiexport=()=>ajax(baseURL+'/api/Execl/api/ExpressclOut')
//4.快递查价excel导入
export const reqkuaidiimport=()=>ajax(baseURL+'/api/Execl/api/ExpressInserExecl')
//物流查价excel导出
export const reqwuliuexport=()=>ajax(baseURL+'/api/Execl/api/PluexeclOut')
//物流查价excel导入
export const reqwuliuimport=()=>ajax(baseURL+'/api/Execl/api/PluexeclOut')

                                   //图片上传接口
//1.图片base64上传接口
export const  reqimage=(form,id)=>ajax(baseURL+'/api/Image/api/SaveImage',{Imagestr:form,BillNo:id},'POST')

                                  //系统设置接口
//1.获取所有信息
export const reqSystemGetAll=()=>ajax(baseURL+'/api/services/app/DgDictionaryService/GetAllMission')
//2.新建接口
export const reqSystemCreate=(form)=>ajax(baseURL+'/api/services/app/DgDictionaryService/CreateMission',form,'POST')
//3.单击获取接口
export const reqSystemGetMissionById=(taskId)=>ajax(baseURL+'/api/services/app/DgDictionaryService/GetMissionById',{taskId})
//4.更新接口
export const reqSystemUpdate=(form)=>ajax(baseURL+'/api/services/app/DgDictionaryService/UpdtaeMission',form,'POST')
//5.删除接口
export const reqSystemDelete=(taskid)=>ajax(baseURL+'/api/services/app/DgDictionaryService/DeleteMission',{taskid},'DELETE')

                                 //新闻模块

//富文本上传
export const reqUEd=(ruleForm)=>ajax(baseURL+'/api/services/app/AfficheInfoService/CreateMission',ruleForm,'POST')
//新闻表格分页
export const reqNewsPagation=(pageIndex,pageSize)=>ajax(baseURL+'/api/services/app/AfficheInfoService/GetPagedRQAfficheInfos',{pageIndex,pageSize})
//根据id表格查询
export const reqNesGetById=(taskId)=>ajax(baseURL+"/api/services/app/AfficheInfoService/GetMissionById",{taskId})
//更新
export const reqNewUpdate=(form)=>ajax(baseURL+'/api/services/app/AfficheInfoService/UpdateMission',form,'PUT')
//删除
export const reqNewDelete=(taskId)=>ajax(baseURL+'/api/services/app/AfficheInfoService/DeleteMission',{taskId},'DELETE')

                                    //审核模块
//1.获取所有信息
export const reqAuditGetAllInspection=(PageIndex,PageSize,Action_Search,SourceType,SourceNo,Sorting,InspectionState,InspectionName,StartDate,EndDate)=>ajax
(baseURL+'/api/services/app/Inspection/GetAllInspection',
{PageIndex,PageSize,Action_Search,SourceType,SourceNo,Sorting,InspectionState,InspectionName,StartDate,EndDate})
//2.货单审核接口
export const reqHdInspection=(form)=>ajax(baseURL+'/api/services/app/Inspection/InspectionResult',form,'POST')
//3.客户审核接口
export const reqCustomerInspection=(form)=>ajax(baseURL+'/api/services/app/Inspection/CustomerInfoResult',form,'POST')
                                  //角色相关接口
//获取所有角色
export const reqRoleGetAll=(SkipCount,MaxResultCount)=>ajax(baseURL+'/api/services/app/Role/GetAll',{SkipCount,MaxResultCount})
//新建角色
export const reqRoleCreate=(form)=>ajax(baseURL+'/api/services/app/Role/Create',form,'POST')
//获取表格一行角色数据
export const reqRoleGetRow=(Id)=>ajax(baseURL+'/api/services/app/Role/Get',{Id})
//修改角色信息
export const reqRoleUpdate=(form)=>ajax(baseURL+'/api/services/app/Role/Update',form,'PUT')


//用户登录
export const reqUserLogin=(form)=>ajax(baseURL+'/api/Authenticate',form,'POST')
//无参获取用户信息
export const requserWithout=()=>ajax(baseURL+'/api/AuthenticateAllWithOut','','POST')
//修改用户密码接口
export const requserUpdatePassword=(form)=>ajax(baseURL+"/api/services/app/User/resetPassword",form,'POST')
//个人消息数量接口
export const reqUsermyinfos=(userId)=>ajax(baseURL+'/api/services/app/Inspection/GetCount',{userId})
//个人审核界面分页接口
export const reqUserinfoinspection=(PageIndex,PageSize)=>ajax(baseURL+'/api/services/app/Inspection/GetAllInspectionBySelf',{PageIndex,PageSize})
                                //用户相关接口
//获取表格分页接口                               
export const reqUserGetAll=(SkipCount,MaxResultCount)=>ajax(baseURL+'/api/services/app/User/GetAll',{SkipCount,MaxResultCount})
//用户创建
export const reqUserCreate=(form)=>ajax(baseURL+'/api/services/app/User/Create',form,'POST')
//点击列表查询
export const reqUserGetRow=(Id)=>ajax(baseURL+'/api/services/app/User/Get',{Id})
//更新接口
export const reqUserUpdate=(form)=>ajax(baseURL+'/api/services/app/User/Update',form,'PUT')

export const reqUserinfo=()=>ajax(baseURL+'/api/services/app/Role/GetAllPermissions')



//人员查重
export const reqUsernameexist=(form)=>ajax(baseURL+'/api/services/app/User/CheckUserNameAsync',form,'POST')


//汉语本地化
export const reqChangeLanguage=(form)=>ajax(baseURL+'/api/services/app/User/ChangeLanguage',form,'POST')

//分公司编号
export const reqBranchIdPer=(taskId)=>ajax(baseURL+'/api/services/app/DgDictionaryService/GetSelectList',{taskId})

        //发票子项相关接口 

//发票子项新建上传
export const reqInvoiceItemCreate=(form)=>ajax(baseURL+'/api/services/app/InvoiceItemService/CreateMissionQ',form,'POST')
//发票子项表格分页
export const reqInvoiceItemsPagation=(taskId)=>ajax(baseURL+'/api/services/app/InvoiceItemService/GetAllMissions',{taskId})
//根据id表格查询
export const reqInvoiceItemsGetById=(taskId)=>ajax(baseURL+"/api/services/app/InvoiceItemService/GetMissionById",{taskId})
//更新
export const reqInvoiceItemUpdate=(form)=>ajax(baseURL+'/api/services/app/InvoiceItemService/UpdateMission',form,'PUT')
//删除
export const reqInvoiceItemDelete=(taskId)=>ajax(baseURL+'/api/services/app/InvoiceItemService/DeleteMission',{taskId},'DELETE')


//发票维护相关接口
// 发票新建上传 
export const reqInvoiceCreate=(form)=>ajax(baseURL+'/api/services/app/InvoiceService/CreateMissionQ',form,'POST')
//发票分页
export const reqInvoicesPagation=(pageIndex,pageSize)=>ajax(baseURL+'/api/services/app/InvoiceService/GetPagedRQAfficheInfos',{pageIndex,pageSize})
//根据id表格查询 
export const reqInvoicesGetById=(taskId)=>ajax(baseURL+"/api/services/app/InvoiceService/GetMissionById",{taskId})
//更新
export const reqInvoiceUpdate=(form)=>ajax(baseURL+'/api/services/app/InvoiceService/UpdateMission',form,'PUT')
//删除
export const reqInvoiceDelete=(taskId)=>ajax(baseURL+'/api/services/app/InvoiceService/DeleteMission',{taskId},'DELETE')
   

