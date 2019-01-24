<style scoped lang="less">
    .password_info{
        box-sizing: border-box;
        background: #fff;
        border-radius: 20px;
        height:900px;
        .info_inner{
            width:500px;
            margin: 0 auto;
            padding: 10px;
          
      }
    }
</style>
<style lang="less">


.password_info{
    .el-input__inner{
        border: 0;
        border-bottom: 1px;
        border-color: #c9c9c9;
        border-style: solid;
        border-radius: 0;
        padding: 0;
    }
    .my_name .el-input__inner{
        margin-left:38px;
    }
    .my_oldpassword .el-input__inner{
        margin-left:38px;
    }
    .my_newpassword .el-input__inner{
        margin-left:38px;
    }
    .el-button{
        margin:30px 0 0 60px;
        padding:8px 20px;
        font-size:18px;
    }
}
  
</style>


<template>
    <div class="password">
         <div class="password_info">
             <div class="info_inner">
                    <p style="margin:60px">密码修改</p>
                    <div class="my_name" style="margin:20px 0">
                         <span>用户名</span> <el-input style="width:135px" v-model="form.userName" > </el-input>
                    </div>
                    <div class="my_oldpassword"  style="margin:20px 0">
                        <span>原密码</span><el-input style="width:135px" v-model="form.currentPassword"></el-input>     
                    </div>
                     <div class="my_newpassword"  style="margin:20px 0">
                        <span>新密码</span><el-input  style="width:135px" v-model="form.newPassword"></el-input>     
                    </div>
                     <div class="my_button">
                     <el-button type="success" @click="updatePassword" size="large" >修改</el-button>
                   </div>    
             </div>
         </div>
      
    </div>
</template>
<script>
 import {requserUpdatePassword} from '../../../api/index.js'
 import router from '../../../router'
    export default {
        data() {
            return {
                form:{
                   userName:"",
                   currentPassword:"",
                   newPassword:"",     
                }
                
            }
        },
       methods:{
          async updatePassword(){
                 var  reg=/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[^]{8,16}$/;
                 if(!reg.test(this.form.newPassword)){
                     this.$message('密码至少包含大写字母，小写字母，数字，且不少于8位')
                 }else{
                   let res=await requserUpdatePassword(JSON.stringify(this.form))
                   if(res.success){
                    this.$message('密码修改成功,请重新登录')
                    this.form.userName="";
                    this.form.currentPassword="";
                    this.form.newPassword="";
                    setTimeout(function(){
                     router.replace('/login')
                    },1000)
                   
                }
           }
                 }
              
       }
       
    }
</script>

