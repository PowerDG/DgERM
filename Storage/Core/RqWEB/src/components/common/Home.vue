<template>
    <div class="wrapper">
        <v-head></v-head>
        <v-sidebar :items="items"></v-sidebar>
        <div class="content-box" :class="{'content-collapse':$store.getters.optCount}">
            <v-tags info="this.tagsList"></v-tags>
            <div class="content">
                <transition name="move" mode="out-in">
                    <keep-alive :include="tagsList">
                        <router-view></router-view>
                    </keep-alive>
                </transition>
            </div>
        </div>
    </div>
</template>

<script>
    import vHead from './Header.vue';
    import vSidebar from './Sidebar.vue';
    import vTags from './Tags.vue';
    import bus from './bus';
    export default {
        data(){
            return {
                tagsList: [],
                items:JSON.parse(sessionStorage.getItem('items'))
              
            }
        },
        methods:{
        },
       
        components:{
            vHead, vSidebar, vTags
        },
        mounted(){
        },
        created(){
            // 只有在标签页列表里的页面才使用keep-alive，即关闭标签之后就不保存到内存中了。
            bus.$on('tags', msg => {
                let arr = [];
                for(let i = 0, len = msg.length; i < len; i ++){
                    msg[i].name && arr.push(msg[i].name);
                }
                this.tagsList = arr;
            })
        }
    }
</script>
