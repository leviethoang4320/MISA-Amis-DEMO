<template>
    <div class="ms-teammate-detail">
        <ms-popup :btnTitle="'Chọn'" :action="'Chọn nhân viên'" :status="2" >
            <div class="teammate-detail-title flex">
                <div class="search flex center">
            <div class="icon icon-search"></div>
                <input id="focusInput" class="input-search" placeholder="Tìm kiếm" type="text">
            </div>
                <DxSelectBox
               
              :search-enabled="true"
              :data-source="null"
              search-mode="contains"
              
              :search-timeout = "200"
              :min-search-length = "0"
              :show-data-before-search="false"
              :placeholder ="'  Chọn đơn vị'"  
                         
              :height ="40"
              :width ="270"

            /> 
            </div>
            <div class="grid-container-teammate">
                <ms-grid :columnInfo="columnInfo" />
            </div>
        </ms-popup>

    </div>
  
</template>

<script>
import { DxSelectBox } from 'devextreme-vue/select-box';

export default {
    name:"MsTeammateDetail",
    components:{
        DxSelectBox
    },
    data() {
        return {
            columnInfo:[
                {
                    id:1,
                    name:"Mã nhân viên",
                    field:"DateSuggest",
                    visible:true
                },
                {
                    id:2,
                    name:"Tên nhân viên",
                    field:"PeopleSuggest",
                    visible:true
                },
                {
                    id:3,
                    name:"Đơn vị công tác",
                    field:"DateMove",
                    visible:true
                },
                {
                    id:4,
                    name:"Điện thoại di động",
                    field:"Censor",
                    visible:true
                },
                {
                    id:5,
                    name:"Email cơ quan",
                    field:"DateDone",
                    visible:true
                },
            ],
            
                
               
        }
    },
    mounted() {

        document.getElementById('focusInput').focus();
        
    },
    methods:{
        
    }
}
</script>

<style>
.ms-teammate-detail{
    height: auto;
    width: 500px;
    margin-bottom: 30px;
}
.grid-container-teammate{
    margin-top: 15px;
}
.ms-teammate-detail .popup-detail{
    left: calc(50% - 424px);
    z-index: 201;
}
.ms-teammate-detail .popup-bgr{
    z-index: 200;
}
.ms-teammate-detail .popup-content{
    overflow: hidden;
}
 .ms-teammate-detail .dx-widget.dx-visibility-change-handler {
    width: 100%;
    height: calc(100vh - 316px) !important;
}
.dx-context-menu.dx-has-context-menu.dx-widget.dx-visibility-change-handler.dx-collection.dx-datagrid{
    display: none;
}
.dx-scrollable-container {
    -webkit-tap-highlight-color: transparent;
    
    width: 100%;
    height: 100%;
}
.dx-placeholder{
    padding-left: 20px;
}

</style>