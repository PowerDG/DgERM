
import Vue from 'vue'
import {RECEIVE_PROLIST,SET_TOKEN, SET_ITEM,SET_ROUTE} from './mutation-type'
export default{
     increment(state){
        state.collapse=!state.collapse;
     },
    [RECEIVE_PROLIST](state,{prolist}){
        state.prolist=prolist
    },
   [SET_TOKEN](state,token){
      
       state.token=token
   },
   [SET_ITEM](state,{items}){
     
       state.items=items
   },
   [SET_ROUTE](state,{route}){
      
       state.rout=route
   }
    
}
