<template>
  <div class="ms-draggable">
    
    <div class="filter-title title-popup center flex">
          <div class="title-text">Tùy chỉnh cột</div>
          <div class="icon icon-close" style="margin:0 !important" @click="close()">
          </div>      
        </div>
        <div class="search flex center">
            <input v-model="searchValue" ref="focusItem" class="input-search" placeholder="Tìm kiếm" type="text">
        </div>
        <div style="height: 295px;overflow: auto; padding-top: 10px;">
          <draggable v-model="columnInfo__">
            <transition-group>
              
              <div :class="{'item-dragg':true} " 
               v-for="element in columnInfo__" :key="element.id"
               v-show="
                  element.name.toLowerCase().includes(searchValue.toLowerCase()) ||
                  removeAccents(element.name.toLowerCase()).includes(
                    searchValue.toLowerCase()
                  )
                "
               >
               <div class="flex" style="justify-content: space-between">
              
                  <DxCheckBox :value="element.visible" @valueChanged="handleValueChange($event,element.id)"  />
                  <span class="dragg-text">{{element.name}}</span>
                  <span class="icon icon-draggable"></span>
                </div>
              </div>
              
            </transition-group>
          </draggable>
        </div>
                  <div class="popup-toolbar flex" style="height:40px !important; padding: 10px;justify-content: space-between;">
              <div class="btn-default">
                <ms-button @click="close()" :btnTitle="'Mặc định'"/>
              </div>
              <div class="btn-save" @click="save()">
                <ms-button :btnTitle="'Lưu'"/>
              </div>
          </div>
  </div>

</template>

<script>
import { DxCheckBox } from 'devextreme-vue/check-box';
import draggable from "vuedraggable";
export default {
  name:"MsDraggable",
  components:{
     draggable,
     DxCheckBox
  },
  props:{
    columnInfo_: Array
  },
  data() {
    return {
      columnInfo__:null,
      searchValue:""
    }
  },
  mounted() {
    this.columnInfo__ = JSON.parse(JSON.stringify(this.columnInfo_));
    this.$refs['focusItem'].focus();
  },
  methods: {
    
    save(){
      this.$emit('update:columnInfo_',this.columnInfo__);
      this.close();
  },
   changeValue(e,id){
      console.log(e,id)
    },
  close(){
    this.$emit('close');
  },
  handleValueChange(e,id){
      
      this.columnInfo__.forEach(element => {
        if(element.id == id){
          element.visible = e.value;
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
  watch: {
    
  }
  
  
}
</script>

<style scoped>
.filter-title.title-popup.center.flex {
    padding-top: 10px;
}
.title-text {
    padding-left: 10px;
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
.item-dragg{
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
.item-dragg:hover{
  background-color: var(--primary-bg);
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
</style>