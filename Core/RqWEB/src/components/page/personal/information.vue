<style scoped lang="less">
    
 .information_show{
     box-sizing: border-box;
     background: #fff;
     border-radius: 20px;
     height:900px;
     .show_inner{
         width:1000px;
         margin: 0 auto;
         padding: 10px;
     }
     span{
         font-size: 15px;
     }
 }
   
    
</style>
<style lang="less">

.information_show {
    .el-input__inner{
        border: 0;
        border-bottom: 1px;
        border-color: #c9c9c9;
        border-style: solid;
        border-radius: 0;
        padding: 0;
    }
    .my_first .el-input__inner{
        margin-left:48px;
        padding-left:18px;
    }
    .my_second .el-input__inner{
        margin-left:25px;
         padding-left:18px;
    }
    .my_third .el-input__inner{
        margin-left:25px;
        padding-left:18px;
    }
    .my_four .el-input__inner{
        margin-left:25px;
        padding-left:18px;
    }
    .my_five .el-input__inner{
        margin-left:15px;
        padding-left:18px;
    }
    .my_six .el-input__inner{
        margin-left:15px;
        padding-left:18px;
    }
}
  
</style>


<template>
    <div class="information">
        <div class="information_show">
             <div class="show_inner">
                  <p style="margin:40px 0 30px 280px ">个人信息</p>
                    <el-row style="margin:40px 0">
                        <el-col :span="9" class="my_first" >
                         <span>用户名</span> <el-input style="width:220px" readonly v-model="userName"></el-input>   
                        </el-col>
                        <el-col :span="9" class="my_second">
                         <span>姓名</span><el-input   style="width:220px" readonly v-model="Name"></el-input>   
                        </el-col>
                    </el-row>
                    <el-row style="margin:40px 0" >
                        <el-col :span="9" class="my_third">
                         <span>分公司编号</span><el-input style="width:220px"   readonly v-model="surname"></el-input>   
                        </el-col>
                        <el-col :span="9" class="my_four">
                         <span>邮箱</span><el-input style="width:220px" readonly v-model="email"></el-input>   
                        </el-col>
                    </el-row>
                     <el-row style="margin:40px 0">
                        <el-col :span="9" class="my_five">
                         <span>最后登录时间</span><el-input style="width:220px" readonly  v-model="last"></el-input>   
                        </el-col>
                        <el-col :span="9" class="my_six">
                         <span>创建时间</span><el-input style="width:220px" readonly v-model="create"></el-input>   
                        </el-col>
                    </el-row>
    
             </div>
            
        </div>  
    </div>
</template>
<script>
   import { formatDate } from "../../../fiters/common.js";
    export default {
        data() {
            return {
              userName:localStorage.getItem('userName'),
              Name:localStorage.getItem('name'),
              surname:localStorage.getItem('surname'),
              email:localStorage.getItem('emailAddress'),
              last:"",
              create:""
            }
        },
       
       mounted(){
            this.create = formatDate(
          new Date(localStorage.getItem('creationTime')),
          "yyyy-MM-dd hh:mm"
          )
           this.last = formatDate(
          new Date(localStorage.getItem('lastLoginTime')),
          "yyyy-MM-dd hh:mm"
          )
       }
    }
</script>

