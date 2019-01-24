<style scoped lang="less">
    .login-wrap{
        position: relative;
        width:100%;
        height:100%;
        background: url('../../../assets/img/login.png') no-repeat;;
        background-size: 100% 100%;
        min-height: 1000px;
        .ms-title{
            font-size:20px;
            color: #fff;
            position: absolute;
            top:15%;
            left:48%;
            margin-left: -278px;
       }
        .ms-login{
            position: absolute;
            left:48%;
            top:43%;
            width:580px;
            height: 355px;
            margin:-185px 0 0 -288px;
            border-radius: 21px;
            background:#fff;
            box-shadow: 0 0 38px rgba(0,0,0,0.26); 
        }
        .login-btn{
            text-align: center;
        }

    }
    
  
 

</style>
<style lang="less">
 .login-wrap .ms-login .el-input{
    margin:30px 0 12px 42px;
 }
.login-wrap  .my_first111 .el-input__inner{
     width:442px;
     height:55px;
     border-radius:28px;
     background: url('../../../assets/img/yhm.png') no-repeat 24px 12px;
     padding-left:66px;
     font-size:18px;
 }
  
 .login-wrap .my_second111 .el-input__inner{
     width:442px;
     height:55px;
     border-radius:28px;
     background: url('../../../assets/img/mm.png') no-repeat 24px 12px;
     padding-left:66px;
     font-size:18px;
 }
 
.login-wrap .ms-login .ms-content{
        padding: 30px;
}
 .login-wrap .ms-login .el-button--small{
     width:150px;
     height:48px;
     border-radius:24px;
     margin:5px;
     font-size:18px;
     background:#235cad;
     color:#fff;
    
 }
</style>

<template>
    <div class="login-wrap">
        <div class="ms-title"><img src="../../../assets/img/ziti.png" alt=""></div>
        <div class="ms-login">
            <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="0px" class="ms-content">
                <el-form-item prop="userNameOrEmailAddress" class="my_login">
                    <el-input v-model="ruleForm.userNameOrEmailAddress" placeholder="username" class="my_first111">
                    
                    </el-input>
                </el-form-item>
                <el-form-item prop="password">
                    <el-input type="password" placeholder="password" class="my_second111" v-model="ruleForm.password" @keyup.enter.native="submitForm('ruleForm')">
                       
                    </el-input>
                </el-form-item>
                <div class="login-btn">
                    <el-button type="primary" @click="submitForm('ruleForm')">登录</el-button>
                  
                </div>
            </el-form>
             <div style="text-align:center;margin-top:-20px">
                       <img src="../../../assets/img/形状2.png" alt="" style="width:3px;height:155px;">      
                    </div>
                    <div style="text-align:center;margin-top:-20px">
                          <img src="../../../assets/img/loginlogo.png" alt="">      
                    </div>
        </div>
        
    </div>
</template>

<script>
 import {reqUserLogin} from '../../../api/index.js' 
    export default {
        data: function(){
            return {
                ruleForm: {
                    userNameOrEmailAddress:'RQADMIN1',
                    password:'12345',
                    rememberClient: true
                },
                rules: {
                    userNameOrEmailAddress: [
                        { required: true, message: '请输入用户名', trigger: 'blur' }
                    ],
                    password: [
                        { required: true, message: '请输入密码', trigger: 'blur' }
                    ]
                }
            }
        },
        methods: {
          submitForm(formName) {
             this.$refs[formName].validate( (valid) => {
                         this.$store.dispatch('reqUserLogin',this.ruleForm).then(()=>{
                         this.$message('登录成功')
                        }).catch(err=>{
                            this.$message.error(err)
                        })
                    })
        }
        }
        
    }
</script>

