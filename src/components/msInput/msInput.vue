<template>
    <div class="ms-input">
        
        <DxSelectBox
                v-if="inputType.select"
              :search-enabled="true"
              :data-source="dataSelect"
              search-mode="contains"
              search-expr="Name"
              :search-timeout = "200"
              :min-search-length = "0"
              :show-data-before-search="false"
              :placeholder = "''"
              display-expr="Name"
              value-expr="EmployeeId"
              v-model="value"
              
              ref="focusItem"

        /> 
        <DxSelectBox
                v-if="inputType.status"
              :search-enabled="true"
              :data-source="status"
              search-mode="contains"
              search-expr="Name"
              :search-timeout = "200"
              :min-search-length = "0"
              :show-data-before-search="false"
              :placeholder = "''"
              display-expr="Name"
              value-expr="ID"
              v-model="value"
              
              ref="focusItem"

        /> 
        <ms-datepicker  v-else-if="inputType.date" :defaultDate.sync="dateFormat"/>
        <DxTagBox
          v-else-if="inputType.tagBox"
          :items="dataSelect"
          :search-enabled="true"
          v-model="tagBoxFormat"
         
          height="100%"
          width="100%"
         
          display-expr="Name"
            value-expr="EmployeeId"
            :placeholder = "''"

        />
        <textarea v-else v-model="value" name="" class="input-text" cols="30" rows="10"></textarea>
        <slot></slot>
    </div>
</template>

<script>
import DxTagBox from 'devextreme-vue/tag-box';
import { DxSelectBox } from 'devextreme-vue/select-box';
export default {
    name:"MsInput",
    props:{
        inputType: Object,
        model: {
           
            default: null
        },
        defaultDate:{
            type: String,
            default: null
        },
        focusItem: {
            type: Boolean,
            default: false
        },
        tagBox:{
            type: String,
            default: null
        },
        selectVal:{
            type: Array,
            default: null
        },
        
    },
    components:{
        DxSelectBox,
        DxTagBox
    }
    ,
    data() {
        return {
           
            dataSelect:null,
            value: null,
            dateFormat:null,
            tagBoxFormat: null,
            status:[
                {ID:1, Name: "Chờ duyệt"},
                {ID:2, Name: "Đã duyệt"},
                {ID:3, Name: "Từ chối"}
            ]
        }
    },
   
    mounted() {

       
            this.dataSelect = this.selectVal;
      
        if(this.model) this.value = this.model;
        this.dateFormat = this.defaultDate;
        if(this.focusItem){
                
                this.$refs['focusItem'].instance.focus();
            }
    
        
        this.tagBoxFormat = this.formatTagbox(this.tagBox);
       
        
    },
    methods:{
       formatTagbox(tagBox){
           if(tagBox)
           return tagBox.split(";");
           else return null;

       }
    },
     watch: {
    
    defaultDate(val) {
     this.dateFormat = val;
     
    },
    model(val){
        this.value = val;
    },
    
    selectVal(val){
        this.dataSelect = val;
    },
    dateFormat(val) {
     this.$emit('update:defaultDate',val)
     
    },
    value(val){
            this.$emit('update:model',val)
        },
    tagBox(val){
        this.tagBoxFormat = this.formatTagbox(val);
    },
        tagBoxFormat(val){
            
            var str = "";
                if(val){
                val.forEach(element => {
                    if(element)
                    str+=(element.toString()+";")
                });
            }
            this.$emit('update:tagBox',str.slice(0,-1));
        }
  },

}
</script>

<style >
@import url(../../styles/components/msGrid.css);

</style>