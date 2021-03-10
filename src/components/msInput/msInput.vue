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
              value-expr="Name"
              v-model="value"
            
              ref="focusItem"

        /> 
        <ms-datepicker  v-else-if="inputType.date" :defaultDate.sync="dateFormat"/>
        <textarea v-else v-model="model" name="" class="input-text" cols="30" rows="10"></textarea>
        <slot></slot>
    </div>
</template>

<script>
import { DxSelectBox } from 'devextreme-vue/select-box';
export default {
    name:"MsInput",
    props:{
        inputType: Object,
        model: {
            type: String,
            default: null
        },
        defaultDate: String,
        focusItem: {
            type: Boolean,
            default: false
        }
    },
    components:{
        DxSelectBox
    }
    ,
    data() {
        return {
            valueX: null,
            date1: Date.now(),
            dataSelect:[
                {Name:"Lê Việt Hoàng",ID:1},
                {Name:"Lê Hoài Nam",ID:2},
                {Name:"Tạ Long Khánh",ID:3},
                {Name:"Nguyễn Hải Long",ID:4},
            ],
            value: null,
            dateFormat:null,
        }
    },
    mounted() {
        if(this.model) this.value = this.model
        if(this.focusItem){
                
                this.$refs['focusItem'].instance.focus();
            }
        this.dateFormat = this.defaultDate;
    },
    methods:{
       
    },
     watch: {
    defaultDate(val) {
     this.dateFormat = val;
     
    },
    value(val){
            this.$emit('update:model',val)
        }
  },

}
</script>

<style >



.dx-dropdowneditor-icon::before {

    background: url(/devextreme-vue-template/img/icon-common.569cfdf3.svg) no-repeat -199px -9px;
    width: 10px;
    height: 6px;
    content: "" !important;
  
    margin-top: -3px;
    left: 50%;
    margin-left: -7px;

    
}



.dx-list-item.dx-state-hover{
    background-color: #ffede2 !important;
}
.input-text{
    height: 100%;
    width: 100%;
    border: 1px solid var(--input-normal-border-color);
    resize: none;
    padding: 0 !important;
    border-radius: 4px;
    box-sizing:content-box;
    font-size: 14px;
}
.input-text:focus{
     border: 1px solid #ec5504;
}
.input-text:focus-within{
    outline: none;
}
.input-text:hover{
    border: 1px solid #ec5504;
}
.ms-input{
    width: 240px;
    /* border: 1px solid #bebebe; */
    border-radius: 4px;
    height: 100%;

}

.dx-state-hover{
    outline: none !important;
}
/* .dx-show-invalid-badge.dx-selectbox.dx-textbox.dx-texteditor.dx-dropdowneditor-button-visible.dx-editor-underlined.dx-texteditor-empty.dx-widget.dx-dropdowneditor.dx-dropdowneditor-field-clickable :focus-within {
    border: 1px solid #ec5504;
} */
.dx-texteditor.dx-editor-underlined::after {
    border-bottom: none !important;
}
.dx-texteditor::before {
    display: none !important;
}

.mx-input-wrapper{
    border-radius: 4px;
    height: 100%;
    border: 1px solid var(--input-normal-border-color); 
    font-size: 14px;

}
.mx-input-wrapper:hover{
    border-radius: 4px;
    border: 1px solid #ec5504;
}
.mx-input:focus-within{
     border: 1px solid #ec5504;
     border-radius: 4px !important;
}
.mx-input:focus{
     border: none;
     outline: none;
}
.mx-input{
    border: none;
    box-shadow: none !important;
}
input.dx-texteditor-input {
    font-size: 14px;
}
.dx-texteditor-container {
   
    border: 1px solid  var(--input-normal-border-color);
     border-radius: 4px;
    height: 100%;
}
.dx-texteditor-container:hover {
    border: 1px solid #ec5504;
    height: 100%;
}
.dx-texteditor-container:focus-within {
   border: 1px solid #ec5504;
    height: 100%;
}
input.dx-texteditor-input {
    padding-left: 10px !important;
}
.mx-icon-calendar{
    width: 24px;
    height: 24px;
    -webkit-mask-image: url(https://amisdemo.misacdn.net/apps/timesheetstatic/img/Icon.569cfdf.svg);
    -moz-mask-image: url(https://amisdemo.misacdn.net/apps/timesheetstatic/img/Icon.569cfdf.svg);
    -ms-mask-image: url(https://amisdemo.misacdn.net/apps/timesheetstatic/img/Icon.569cfdf.svg);
    -o-mask-image: url(https://amisdemo.misacdn.net/apps/timesheetstatic/img/Icon.569cfdf.svg);
    mask-image: url(https://amisdemo.misacdn.net/apps/timesheetstatic/img/Icon.569cfdf.svg);
    -webkit-mask-repeat: no-repeat;
    -moz-mask-repeat: no-repeat;
    -ms-mask-repeat: no-repeat;
    -o-mask-repeat: no-repeat;
    mask-repeat: no-repeat;
    background-color: #666!important;
    -webkit-mask-position: -48px -24px;
    -moz-mask-position: -48px -24px;
    -ms-mask-position: -48px -24px;
    -o-mask-position: -48px -24px;
    mask-position: -48px -24px;
}
textarea.input-text {
    padding: 8px !important;
    height: calc(100% - 16px);
    width: calc(100% - 16px);
    /* margin: 0px; */
}

</style>