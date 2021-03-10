<template>
  <div class="ms-filter">
      <div class="filter-title title-popup center flex">
        <div class="title-text">Bộ Lọc</div>
        <div class="icon icon-close" @click="close()">
        </div>      
      </div>
      <div class="search flex center">
            <div class="icon icon-search"></div>
            <input ref="focusSearch" v-model="searchValue" class="input-search" placeholder="Tìm kiếm" type="text">
      </div>
      <div class="filter-content">
              <div class="item-dragg " 
                :class="{'selected-filter':element.filter }" 
                v-for="element in columnInfo__" :key="element.id"
                 v-show="
                          element.name.toLowerCase().includes(searchValue.toLowerCase()) ||
                          removeAccents(element.name.toLowerCase()).includes(
                            searchValue.toLowerCase()
                          )
                        "
                >
                <div class="select-filter flex">
                    <DxCheckBox :value="element.filter"  @valueChanged="handleValueChange($event,element.id)"/>
                    <span class="dragg-text">{{element.name}}</span>
                </div>
                <DxSelectBox
                    v-if="element.filter"
                    height:36px
                    width:196px
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
                    :value="model"
                    
                    ref="focus"

                /> 
                <DxSelectBox
                       v-if="element.filter"
                    :search-enabled="true"
                    :data-source="null"
                    search-mode="contains"
                    search-expr="Name"
                    :search-timeout = "200"
                    :min-search-length = "0"
                    :show-data-before-search="false"
                    :placeholder = "''"
                    display-expr="Name"
                    value-expr="Name"
                    :value="model"
                    :noDataText="'Không có dữ liệu'"

                /> 
             
        </div>
      </div>
      <div class="popup-toolbar flex" style="height:40px !important; padding: 10px;justify-content: space-between; ">
              <div class="btn-default" @click="close()">
                <ms-button :btnTitle="'Bỏ lọc'"/>
              </div>
              <div class="btn-save" @click="close()" >
                <ms-button :btnTitle="'Lưu'"/>
              </div>
      </div>
  </div>
</template>

<script>
import { DxCheckBox } from 'devextreme-vue/check-box';
import { DxSelectBox } from 'devextreme-vue/select-box';
export default {
    name:"MsFilter",
    components:{
        DxCheckBox,
        DxSelectBox
    },
    props:{
        columnInfo_: Array
    },
    data() {
        return {
            columnInfo__:null,
            dataSelect:[
                {Name:"Bằng",ID:1},
                {Name:"Khác",ID:2},
                {Name:"Trống",ID:3},
                {Name:"Không trống",ID:4},
            ],
            model:"Bằng",
            searchValue:""
        }
    },
    mounted() {
        this.columnInfo__=this.columnInfo_;
    },
    methods: {
        close(){
            this.$emit('close');
        },
        handleValueChange(e,id){
            this.columnInfo__.forEach(element => {
              if(element.id == id){
                    element.filter = e.value;
                }
            
            });
            
        },
        removeAccents(str) {
            var AccentsMap = [
              "aàảãáạăằẳẵắặâầẩẫấậ",
              "AÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬ",
              "dđ",
              "DĐ",
              "eèẻẽéẹêềểễếệ",
              "EÈẺẼÉẸÊỀỂỄẾỆ",
              "iìỉĩíị",
              "IÌỈĨÍỊ",
              "oòỏõóọôồổỗốộơờởỡớợ",
              "OÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢ",
              "uùủũúụưừửữứự",
              "UÙỦŨÚỤƯỪỬỮỨỰ",
              "yỳỷỹýỵ",
              "YỲỶỸÝỴ",
            ];
            for (var i = 0; i < AccentsMap.length; i++) {
              var re = new RegExp("[" + AccentsMap[i].substr(1) + "]", "g");
              var char = AccentsMap[i][0];
              str = str.replace(re, char);
            }
            return str;
          }
    },

}
</script>

<style scoped>
.filter-content{
  height: 355px;
 overflow-y: auto ;
}
.dx-show-invalid-badge.dx-selectbox.dx-textbox.dx-texteditor.dx-dropdowneditor-button-visible.dx-editor-underlined.dx-widget.dx-dropdowneditor.dx-dropdowneditor-field-clickable {
   margin-bottom: 8px;
    height: 38px !important;
    background-color: #fff !important;
    width: 191px;
    margin-left: 9px;
}

.draggable-menu{
  position: absolute;
  z-index: 111111;
   top:170px;
   padding: 10px;
   background: #fff;
   border-radius: 5px;
   -webkit-box-shadow: 0 5px 25px 0 rgb(0 0 0 / 10%);
   box-shadow: 0px 0px 10px 0 rgb(0 0 0 / 15%); 
   padding: 8px;
   margin: 0;
}

.dragg-text{
  width: 150px;
}
.selected-filter{
    background-color: #ffede2;
}
.select-filter{
    color: #333;
    font-weight: 400;
    --vs-primary: 4,24,71;
    --vs-success: 40,199,111;
    --vs-danger: 234,84,85;
    --vs-warning: 255,159,67;
    --vs-dark: 30,30,30;
    --vs-orange: 255,145,0;
    line-height: 1.35715;
    pointer-events: auto;
    visibility: visible;
    -webkit-tap-highlight-color: transparent;
    font-size: 14px;
    border-radius: 6px;
    padding: 11px 6px 8px 10px;
     justify-content: space-between;
    
}
.item-dragg.selected-filter {
    height: 138px;
    border-radius: 4px;
    width: 210px;
}
.draggable-menu .search{
 
    width: 210px;
    margin-left: 10px;

}
.title-text{
  font-size: 20px;
    letter-spacing: .384px!important;
    font-weight: 700;
}
.filter-title{
  height: 30px;
  margin: 0 0 12px ;
  justify-content: space-between;
}
.popup-toolbar {
    display: flex;
    justify-content: flex-end;
    padding: 16px 24px;
    border-radius: 0 0 4px 4px;
    height: 36px;
    border-top: none;
}
.grid-filter{
  height: calc(100vh - 177px);
  width: 203px !important;
  background-color: #ffffff;
  padding: 14px 16px;
  border-radius: 4px;
}
.grid-filter .icon-close{
  margin: 0;
  
}
.grid-filter .search{
  width: 187px;
}
.grid-filter .input-search{
  width: 140px;
}
.filter-title{
  height: 30px;
  margin: 0 0 12px ;
  justify-content: space-between;
}
.title-text{
  font-size: 20px;
    letter-spacing: .384px!important;
    font-weight: 700;
}
.grid-content.on-filter{
  width: calc(100% - 250px);
  margin-right: 15px;
}
</style>
<style>
.dx-dropdowneditor-button.dx-state-active .dx-dropdowneditor-icon::before, .dx-dropdowneditor.dx-dropdowneditor-active .dx-dropdowneditor-icon::before {
    content: "";
    position: absolute;
    display: block;
    width: 24px;
    top: 50%;
        margin-top: -3px;
    left: 50%;
    margin-left: -7px;

}
.dx-list-item-content {
    font-size: 14px;
    padding: 14px 16px 13px;
}
.dx-list .dx-empty-message {
    text-align: left;
    padding: 11px 12px 7px;
    color: #ec5504;
    font-size: 14px;
}
</style>