/*
ajax请求函数模块
返回值: promise对象(异步返回的数据是: response.data)
 */
import axios from 'axios'
import { Loading,Message}  from 'element-ui'
let loading;
function startLoading(){
   loading=Loading.service({
     lock:true,
     text:"拼命加载中...",
     background:'rgba(0,0,0,0.8)'
   })
}
function endLoading(){
  loading.close()
}

axios.interceptors.request.use(
  //加载动画
  config=>{
       startLoading()
    if(sessionStorage.token){
      config.headers.Authorization="Bearer "+sessionStorage.token;
    }
    return config;
  },error=>{
    return Promise.reject(err)
  }
)
axios.interceptors.response.use(
  response=>{
      endLoading();
      return response
  },
  error=>{
      Message.error(error.response.data)
      const {status}=err.response;
      var date=new Date();
      if(date.getTime()-sessionStorage.getItem('date')>28800000){
         Message.error("token失效,请重新登录")
         sessionStorage.removeItem('token')//清除token
         router.push("/login")
      }
      if(status==401){
          Message.error("token失效,请重新登录")
          sessionStorage.removeItem('token')//清除token
          //引入router  import .....
          router.push("/login")
      }
      endLoading()

      Message.error(error.response.data)
      return Promise.reject(error)
  }
)


axios.defaults.headers.post['Content-Type'] = 'application/json';
axios.defaults.headers.put['Content-Type'] = 'application/json';
export default function ajax (url, data={}, type='GET') {
  return new Promise(function (resolve, reject) {
    //  for(var key in data){
    //     if(data[key]==''){
    //        delete data[key]
    //     }
    //  } 
    // 执行异步ajax请求
    
    let promise
    if (type === 'GET') {
      // 准备url query参数数据
      let dataStr = '' //数据拼接字符串
      Object.keys(data).forEach(key => {
        dataStr += key + '=' + data[key] + '&'
     
      })
      if (dataStr !== '') {
        dataStr = dataStr.substring(0, dataStr.lastIndexOf('&'))
        url = url + '?' + dataStr
      }
      // 发送get请求
      promise = axios.get(url)
    }else if (type==='PUT'){
       promise=axios.put(url,data)
    }else if(type==='DELETE'){
        let dataStr = '' 
        Object.keys(data).forEach(key => {
          dataStr += key + '=' + data[key] + '&'
        })
        if (dataStr !== '') {
          dataStr = dataStr.substring(0, dataStr.lastIndexOf('&'))
          url = url + '?' + dataStr
        }
      promise=axios.delete(url,data)
    } 
    else {
      // 发送post请求
      promise = axios.post(url, data)
    }
    promise.then(function (response) {
      // 成功了调用resolve()
      resolve(response.data)
    }).catch(function (error) {
      //失败了调用reject()
      reject(error)
    })
  })
}
