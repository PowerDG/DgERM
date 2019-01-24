## 后台导航**

 - 导航 

* [ ] 货单字段追加
* [x] Execl清单导出
* [x] 隐藏 业务客户-业务管理
* [x] 隐藏 司机车辆
* [ ] 门户查价绑定【1零担/2快递】
* [ ] 货单字段追加
* [x] 添加冲突人员角色时无提醒
* [x] 密码修改功能绑定
* [x] 我的消息-待审核绑数量
* [x] 我的消息-待审核绑列表
* [x] ~2客户管理信息删除接口，后端Swagger 自测无误，配合前端页面测试报405，前端请求方式有误
* [x] ~2订单信息删除接口，后端Swagger 自测无误，配合前端页面测试报405，前端请求方式有误
* [x] ~3客户新增信息做客户编号是否重复检查，若已重复则返回提示重复，否则返回成功。
* [x] ~4客户下拉框对应全称已改为简称
* [x] 6转包快递商--选择优先使用【默认列表】多选框
* [ ] 个人消息数量接口：/api/services/app/Inspection/GetCount?userId=  返回待审核数量
* [ ] 个人审核界面分页接口 :/api/services/app/Inspection/GetAllInspectionBySelf   
* [ ] 客户CustomerID检查是否已存在接口:/api/services/app/CustomerInfoService/CheckCusId?CustomerID=
* [ ] 订单BillNo查重接口：http://localhost:21021/api/services/app/BillInfoService/CheckBillInfo?billNo数据库不存在数据则返回null,有则返回数据DTO.
* [ ] 添加人员账号对名称进行查重 接口：http://localhost:21021/api/services/app/User/CheckUserNameAsync?name=  重复则返回false 不重复则返回 true
* [ ] 添加角色账号对名称进行查重 接口：http://localhost:21021/api/services/app/Role/CheckName?name=  重复则返回false 不重复则返回 true
* [ ] 快递查询物流信息接口：http://localhost:21021/api/services/app/LogisticsInfoService/Getsendinfo?BillNo=  传入订单BillNo 后端判断物流和快递，查询出快递信息，以字典形式返回前端，快递则为：“快递”：信息，自家物流为： “瑞庆”：信息，需对字典物流信息进行处理。
* [ ] 业务结算接口：http://localhost:21021/api/services/app/BillInfoService/Balance接收数组Id。
<<<<<<< .mine
      return "开票成功";
              }
              else
              {
                  return "开票失败";

* [ ] 订单页面图片删除接口：http://localhost:21021/api/Image/api/DeleteImage?taskId=
||||||| .r440
* [ ] 订单页面图片删除接口：http://localhost:21021/api/Image/api/DeleteImage?taskId=
=======
* [ ] 订单页面图片删除接口：http://localhost:21021/api/Image/api/DeleteImage?taskId=00
<<<<<<< .mine
>>>>>>> .r445
||||||| .r448
=======
* [ ] 订单页面图片加载接口，查询出图片的id和url  http://localhost:21021/api/services/app/T_GoodsImg/GetImageUrl?taskId=  参数为订单的BillNo
* [ ] 上传图片后返回ID，根据ID加载图片接口： http://localhost:21021/api/services/app/T_GoodImg/GetMissionById?taskId=
>>>>>>> .r461

------



* [x] ABP发布IIS 

* [x] 货单审核查看

* [x] 清单管理

* [x] 门户提供--查价与查单多选框筛选

------

* [x] Ued--内容管理

* [ ] 截图 确定应付应收  发票打印 索要图片

* [x] 字典。。输出

* [x] 测试  

* [ ] ---迁徙域名

* [x] 检查多国语、、、

* [ ] 门户提供--查价与查单多选框筛选



## **后台导航**
#业务客户"Pages.Staff.Merchandiser",

 - 客户管理"Pages.Staff.Merchandiser",

    - [ ] 调用接口查看是否输入重名的客户公司编号


    GetCustomerIDList下拉框接口 
    
    ​	--非管理员只可见自己的
    ​    1. 接口名： /api/services/app/CustomerInfoService/CreateMission
    ​         作用：创建客户信息所访问的接口，接收完整模型数据，无返回值。
    ​    2. 接口名： /api/services/app/CustomerInfoService/CreateMissionQ
    ​         作用：创建客户信息所访问的接口，接收完整模型数据，返回Id。
    
    3. http://localhost:21021/api/services/app/CustomerInfoService/DeleteMission?taskId=
         删除客户信息接口 参数taskId=ID
    
      4.http://localhost:21021/api/services/app/CustomerInfoService/GetPagedCustomerInfos
    ​     分页查询接口

​         5.http://localhost:21021/api/services/app/CustomerInfoService/UpdateMission  

​           修改接口，无权限则发起修改申请

​        

 - 业务管理"Pages.Staff.Merchandiser",

   ​	--按照客户列表分组 时间段【未签收】

# 物流订单"Pages.Staff.Owner"   
##  订单管理"Pages.RQAssitant",（优先）

- [ ] 调用接口查看是否输入重名的单号 

- [ ] ​    成本保留但转移到【服务与运费】的应付部分

  ​    public string The_cost { get; set; }

  此外的其他费用Copy一份到上面 

  ```csharp
       //public bool isPacking { get; set; } 
  	//public bool isUpstairs { get; set; }
  	#region 应付 
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
      public string The_cost { get; set; } 
      #endregion
  ```

- [ ] Receiving dates 选项转移到 运输方式=【收货期间暂不用，可空】

- [ ] 为在线下单添加是否包装和上楼的字段

          public bool isPacking { get; set; } 
          public bool isUpstairs { get; set;}

- [ ] | 运输方式(航空 AVIATION 陆运 LAND TRANSPORTION)               |
  | ------------------------------------------------------------ |
  | ~~收货期间~~ (0陆运 LAND TRANSPORTION          1当日达SAME-DAY              /2次日达NEXT MOMING) |
  | 原先                                                         |
  | ~~<u>收货期间~~【1当日达SAME-DAY              /2次日达NEXT MOMING)】</u>~~ |

>  - BillNo单号为客服手动输入 单号输完自动后（光标离开输入框）
>
>  - 调用接口查看是否输入重名的单号
>  - 已有货单输入则刷新获取 加载页面
>  - 已有该货单下图片 加载附件图片列表
>
>  客户端  持有Bill货单下属图片List集合【localStorage图片信息变量】 图片上传后返回ID/现有图片Model集合信息
>  添加成功的图片ID加入【localStorage图片信息变量】
>
>  删除图片单独根据图片ID删除   后端返回该图ID 删除成功后【localStorage图片信息变量】去除该图信息
>
>  图片上传后返回ID/现有图片Model集合信息
 - 订单管理"Pages.Staff.Merchandiser",【业务员Div】可编辑

   - [ ] 下拉框选择后  客户公司编号 ，业务员姓名
   - [ ] 

   //14.客户简称下拉框接口 

   export const reqHdKHselectlist=()=>ajax(baseURL+'/api/services/app/CustomerInfoService/GetCustomerIDList')

   //15.客户简称悬浮框接口

   export const reqHdXFlist=(taskId)=>ajax(baseURL+'/api/services/app/CustomerInfoService/GetMissionById',{taskId})

   # ---无法根据表格 获得状态为3

  ##  订单管理"Pages.Staff.Customer_service"【客服Div】可编辑【业务Div】可编辑

    ​	-不输入单号只显示【未签收】，且为隐藏的 
    
    ​	-若已签收查看需要申请
    
    ​	-物流动态输入，快递100跟踪（已完成）



##  转包运商"Pages.Staff.Others",

   ​	--选择优先使用【默认列表】多选框

# 财务管理"Pages.Staff.Financial"

 ## 业务清单"Pages.Staff.Finan

 ## cial"

### 分页筛选
  1.http://localhost:21021/api/services/app/BillInfoService/GetPagedBusiness  业务清单列表页分页接口

   --默认只显示未开票的

   --列表筛选可按照客户公司，快递公司，时间段
### Excel导出下下载

 1.快递查价execl导出：http://localhost:21021/api/Execl/api/ExpressclOut

2.物流查价execl导出:http://localhost:21021/api/Execl/api/PluexeclOut

3.业务清单导出：http://localhost:21021/api/Execl/api/Export

4.快递查价execl导入：http://localhost:21021/api/Execl/api/ExpressInserExecl

5.物流查价execl导入:http://localhost:21021/api/Execl/api/Insertexecl



-   -----系统默认显示以下字段：发票种类，发票代码，发票号码，开票机号，购方名称，购方税号，购方地址电话，购方银行账号，开票日期，报送状态，报送日志，所属月份，合计金额，税率，合计税额，主要商品名称，商品税目，开票人，收款人，复核人，打印标志，作废标志，清单标志，修复标志和作废日期，共24项。

- -----销项情况统计表只需要11项内容，分别为发票种类，发票代码，发票号码，购方税号，开票日期，所属月份，合计金额，税率，合计税额，作废标志和修复标志。 

# 内容新闻"Pages.Staff.Others",
 # - 轮播图"Pages.Staff.Others",

   ​	--前端有插件

 #  新闻管理"Pages.Staff.Others",

   ​	--Ueditor富文本上传

   ​        --/api/UeditorUpload

##司机车辆"Pages.Staff.Others",

 - 车辆管理"Pages.Staff.Others",

 - 车型管理"Pages.Staff.Others",

   ​	--暂无

# 人员角色"Pages.RQAssitant",
 ## 角色分配"Pages.RQAssitant.Roles",
   1.从登陆接口中拿到PermissionscanAssigned 存入localstorage 
​     从localstorage中获取可分配权限列表
   2.右侧表格数据从接口 Role下的/api/services/app/Role/GetAll获取


   RQAdmin除了。。虚拟角色分配助理权力范围

 ##  人员分配"Pages.RQAssitant.Users",

# 审核管理"Pages.Inspection",
  #  待审核项"Pages.Inspection"

    	申请已经做；
     1.货单页面申请查看接口：http://localhost:21021/api/services/app/BillInfoService/GetMissionById
                          一个参数，主键 taskId, 后端判断当前货单是否已签收，
    
    ----------------A若已签收则自动发起查看申请，返回null
                        B若非已签收，则查询数据返回前端。
    2.货单页面申请修改接口：http://localhost:21021/api/services/app/BillInfoService/UpdateMission
                          后端判断当前用户是否管理员，若不是，则发起修改申请
    
    	审核操作与气泡提示尚未
    1. 货单页面修改，查看动作的审核。接口：http://localhost:21021/api/services/app/Inspection/InspectionResult   
                                   目前四个参数：Inspection_No（审核表主键），InspectionState（审核结果，1通过，2驳回），Name（审核人姓名），Actions（申请的操作动作，修改，查看）
                                   POST传参，  JSON.stringify，  contentType: 'application/json',
    
    1. http://localhost:21021/api/services/app/Inspection/GetCount
     待审核数量 需要参数  userId  账户Id
    2. http://localhost:21021/api/services/app/Inspection/GetAllInspectionBySelf
    非管理员只看见自己提交的审核申请，

  - 历史审核"Pages.Inspection"


# 个人设置"Pages.Staff.Owner"  
退出操作 -暂时先返回到登录页
不现实在左边栏  右上角显示
### 个人信息查看
### 密码修改
个人信息查看

```
http://localhost:21021/api/services/app/User/Get?Id=11
--现实用户名 	 -----姓名  
--分公司编号surname	 -邮箱
lastLoginTime最后登录时间
creationTime  创建时间
{
  "result": {
    "userName": "admin6767",
    "name": "string",
    "surname": "99",
    "emailAddress": "admin6767@EQ.com",
    "isActive": true,
    "fullName": "string 99",
    "lastLoginTime": "2019-01-15T15:04:43.926114",
    "creationTime": "2018-12-27T17:54:54.986863",
    "roleNames": [
      "RQADMIN",
      "RQADMINPERMISSIONS",
      "MERCHANDISER",
      "ADMIN",
      "RQASSITANT"
    ],
    "id": 11
  },
  "targetUrl": null,
  "success": true,
  "error": null,
  "unAuthorizedRequest": false,
  "__abp": true
}


```




##  密码修改"Pages.Staff.Owner"

密码修改

```
/api/services/app/User/resetPassword
http://localhost:21021/api/services/app/User/resetPassword?userName=RQADMIN2&currentPassword=123456&newPassword=1234567


curl -X POST "http://localhost:21021/api/services/app/User/resetPassword?userName=RQADMIN2&currentPassword=123456&newPassword=1234567" -H "accept: text/plain" -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjE4IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IlJRQURNSU4xIiwiQXNwTmV0LklkZW50aXR5LlNlY3VyaXR5U3RhbXAiOiJHMkw1WFlHSVZITTZKQzRFREMzNkhVUFk0WEdZWVlYVyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlJRQWRtaW4iLCJzdWIiOiIxOCIsImp0aSI6Ijg4OTAwM2I1LWY4NjgtNGUxZC1iMDVlLTA4YTZiNmVhMzM5OSIsImlhdCI6MTU0NzUzOTU0OSwibmJmIjoxNTQ3NTM5NTQ5LCJleHAiOjE1NDc2MjU5NDksImlzcyI6IlJRQ29yZSIsImF1ZCI6IlJRQ29yZSJ9.QjP7zbIkBKEYww-vU53LHQZBf9tlGgLISO1kkS-gsMo"

```



------



 ###  汉语中国本地化


​    /api/services/app/User/ChangeLanguage

本地化调用完再调用Without

​    http://localhost:21021/api/services/app/User/ChangeLanguage
​    {
​      "languageName": "zh-Hans"
​    }

​    
​    curl -X POST "http://localhost:21021/api/services/app/User/ChangeLanguage" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjE4IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IlJRQURNSU4xIiwiQXNwTmV0LklkZW50aXR5LlNlY3VyaXR5U3RhbXAiOiJHMkw1WFlHSVZITTZKQzRFREMzNkhVUFk0WEdZWVlYVyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlJRQWRtaW4iLCJzdWIiOiIxOCIsImp0aSI6Ijg4OTAwM2I1LWY4NjgtNGUxZC1iMDVlLTA4YTZiNmVhMzM5OSIsImlhdCI6MTU0NzUzOTU0OSwibmJmIjoxNTQ3NTM5NTQ5LCJleHAiOjE1NDc2MjU5NDksImlzcyI6IlJRQ29yZSIsImF1ZCI6IlJRQ29yZSJ9.QjP7zbIkBKEYww-vU53LHQZBf9tlGgLISO1kkS-gsMo" -d "{ \"languageName\": \"zh-Hans\"}"

系统字典：

​    http://localhost:21021/api/services/app/DgDictionaryService/GetSelectList?taskid=TrafficLogStatus

curl -X GET "http://localhost:21021/api/services/app/DgDictionaryService/GetSelectList?taskid=TrafficLogStatus" -H "accept: text/plain" -H "Authorization: null"



  ##  个人信息"Pages.Staff.Owner"   









1.问题  表格点击后 如果想新建？ 处理办法 加个清空按钮

2.如果要打包  首先cd到文件目录  然后运行npm run build命令  等待一会 会有一个dist文件夹  运行这个dist文件夹的 index.html文件







UTC  Vue多选  导航  Ue  轮播

  var tasklist = task.Skip
  ((input.PageIndex - 1) * input.PageSize).
  Take(input.PageSize).ToList();  //获取目标页数据

  MaxResultCount

SkipCount=((input.PageIndex - 1) * input.PageSize).
MaxResultCount=PageSize