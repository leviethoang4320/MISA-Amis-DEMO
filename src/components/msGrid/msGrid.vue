<template>
  <div class="ms-grid flex">
    <div class="grid-content" :class="{'on-filter': filterPopup}">
      <div class="triangle" v-if="isDraggable"></div>
      <div class="draggable-menu" v-if="isDraggable">
        <ms-draggable :columnInfo_.sync="columnInfo_" @close="isDraggable=!isDraggable"/>
      </div>
      <DxDataGrid
        :data-source="dataGrid"
        :allow-column-reordering="true"
        :allow-column-resizing="true"
        :column-auto-width="true"
        :show-borders="true"
        width="100%"
        height="calc(100vh - 210px)"
        :onContentReady="onContentReady"
        :hoverStateEnabled="true"
        :noDataText="'Không có dữ liệu'"
        :selected-row-keys.sync="selectedRowKeys"
        key-expr="ID"
        @selection-changed="onSelectionChanged">
      >
        <DxColumn
          :width="50"
          :height='45'      
          :fixed="true"
          header-cell-template="icon-header"
          
        />
        
        <DxSelection
          
          :select-all-mode="'page'"
          :show-check-boxes-mode="'always'"
          mode="multiple"
          
        />
      
        <DxColumn
          v-for="(item,index) in columnInfo_" :key="index"
          :caption="item.name"
          :width="200"
          :visible="item.visible"
          :data-field="item.field"
          
        />
        <DxColumn
            :width="120"
            :height="40"
            :fixed="true"
            fixed-position="right"
          cell-template="edit-add"
          
        />
        
        <template #icon-header>
              <div @click="openDraggable()" class="icon-header"></div>
        </template>
        <template #edit-add="{ data }" >
              <div class="flex"> 
                  <div class="edit" @click="editData(data)"></div>
                  <div class="delete" @click="deleteData(data)"></div>
              </div>
        </template>
        <template #checkbox-header >
              <ms-checkbox />
        </template>
      </DxDataGrid>
      <div class="paginate flex center">
        <div class="footer-left">
          <div class="itemCount mgl-20">
            Tổng số bản ghi: <span style="font-weight: 700">{{count}}</span>
          </div>
        </div>
        <div class="footer-right flex center">
          <div class="page-size center flex mgr-20" @click="$bus.$emit('dropdownMenuOpen','paginate')">
            <div class="page-size-info center">10</div>
            <div class="icon icon-select"></div>
            <ms-dropdown-menu  :itemKey="'paginate'" :dropdownMenuItem="pageSizes"/>
          </div>
          <div class="paginate-detail mgr-20">Từ <span style="font-weight: 700">1</span> đến <span style="font-weight: 700">10</span> bản ghi</div>
          <div class="icon icon-prev mgr-20" ></div>
          <div class="icon icon-next mgr-20"></div>
        </div>
      </div>
    </div>
    <div v-if="filterPopup" class="grid-filter">
      <ms-filter :columnInfo_="columnInfo_" @close="filterPopup = !filterPopup;"/>
    </div>
    <ms-popup-delete v-if="deletePopup"/>
  </div>
</template>
<script>
import {
  DxDataGrid,
  DxColumn,
 
  DxSelection  
 
} from 'devextreme-vue/data-grid';



export default {
    name:"MsGrid",
    components: {
    DxDataGrid,
    DxColumn,
   
    DxSelection
  },
  props:{
    columnInfo: Array,
    dataGrid: {
      type:Array,
      default: null
    }
  },
  data() {
    return {
      
      dragging: false,
      isDraggable:false,
      pageSizes: [
        {name: '5', value:5,checked:false},
        {name:'10', value:10,checked:false},
        {name:'20', value:20,checked:false}
      ],
      count: null,
      filterPopup: false,
      deletePopup: false,
      columnInfo_:false,
      selectedRowKeys:null
    };
  },
  mounted() {
    this.columnInfo_ = this.columnInfo;
    this.count = this.dataGrid ? this.dataGrid.length : null;
     this.$bus.$on('closeDel',()=>{
       this.deletePopup = !this.deletePopup;
     }) ;
    this.$bus.$on('checked',(name)=>{
      
      this.pageSizes.forEach(element => {
        element.checked = false;
        if(element.name == name){
          element.checked = true;
        }
      });
    });
    this.$bus.$on('filter',()=>{
      this.filterPopup = ! this.filterPopup;
    });

    console.log(this.columnInfo_)
    
  },
  methods: {
    calculateCellValue(data) {
      return [data.Title, data.FirstName, data.LastName].join(' ');
    },
    openDraggable(){
      this.isDraggable = !this.isDraggable;
    },
    onContentReady(e) {
      e.component.columnOption("command:select", "visibleIndex", 0);
    },
    editData(data){
     this.$bus.$emit('openDetail',data.data);
    },
    deleteData(){
     this.deletePopup=!this.deletePopup;
    },
    onSelectionChanged() {
      //console.log(this.selectedRowKeys);
      this.$emit("onSelectionChanged", this.selectedRowKeys);

    },
  },
  watch:{
    columnInfo(val){
      this.columnInfo_ = val;
    }
  }
};
</script>
<style scoped>
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
  width: 171px;
}
.draggable-menu .search{
 
    width: 210px;
    margin-left: 10px;

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
.page-size-info{
  padding-left: 15px;
  
  font-weight: 500;
}
.icon-next{
  -webkit-mask-position: -240px 0;
    -moz-mask-position: -240px 0;
    -ms-mask-position: -240px 0;
    -o-mask-position: -240px 0;
    mask-position: -240px 0;
}
.icon-prev{
  -webkit-mask-position: -216px 0;
    -moz-mask-position: -216px 0;
    -ms-mask-position: -216px 0;
    -o-mask-position: -216px 0;
    mask-position: -216px 0;
}

.dx-state-hover .edit{
  background: url(../../assets/icon/icon-common.svg) no-repeat -284px -19px;
    width: 30px;
    height: 30px;
    padding: 0 !important ; 
    margin: 0 ; 
    margin-right: 20px;
    background-color: #fff;
    border-radius: 50%;
   
}
.dx-state-hover .delete{
  
  background: url(../../assets/icon/icon-common.svg) no-repeat -166px -21px;
    width: 30px;
    height: 30px;
    padding: 0 !important; 
    margin: 0 !important; 
    background-color: #fff;
    border-radius: 50%;
  
}

.ms-dropdown-menu{
  top: 480px;
    right: 278px;
    width: 80px;
  
}
.paginate{
  height: 61px;
  width: calc(100% - 2px);
  border: 1px solid #e0e0e0;
  background-color: #ffffff;
  border-top: none ;
  border-bottom-right-radius: 4px;
  border-bottom-left-radius: 4px;
  justify-content: space-between;
}
.page-size{
  height: 34px;
  width: 74px;
  border: 1px solid #bebebe;
  border-radius: 4px;
}
#gridContainer {
  height: 440px;
}
.drop-item-content{
  padding-top: 10px;
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
</style>
<style>
.dx-datagrid-table .dx-data-row.dx-state-hover:not(.dx-row-inserted):not(.dx-row-removed):not(.dx-edit-row):not(.dx-row-focused) > td:not(.dx-focused) {
  background-color: #ffede2 !important;
}
.dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused) > td,
.dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused) > tr > td,
.dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused):hover > td,
.dx-datagrid-rowsview
  .dx-selection.dx-row:not(.dx-row-focused):hover
  > tr
  > td {
  background-color: #fff4e5 !important;
  color: #333;
}
.dx-datagrid-rowsview tr:hover td {
  background-color: #ffede2 !important;
}
.dx-datagrid-table .dx-data-row.dx-state-hover {
    cursor: pointer;
    background-color: var(--date-picker-hover-bg) !important;

}
.item-dragg.flex:hover {
  background-color: var(--primary-bg) ;
}

.dx-datagrid .dx-datagrid-content .dx-datagrid-table .dx-row > td.dx-cell-modified:not(.dx-field-item-content):not(.dx-validation-pending):last-of-type, .dx-datagrid .dx-datagrid-content .dx-datagrid-table .dx-row > td.dx-datagrid-invalid:not(.dx-field-item-content):not(.dx-validation-pending):not(.dx-datagrid-select-all):last-of-type, .dx-datagrid .dx-datagrid-content .dx-datagrid-table .dx-row > td:not(.dx-validation-pending):not(.dx-datagrid-select-all):last-of-type {
    padding-right: 18px;
    border-left: hidden !important ;
}

.btn-default .ms-button{
    background-color: white;
    color: #212121;
    margin: 0;
    margin-right: 20px;
    
    height: 35px !important;
    padding: auto ;
    border: 1px solid #bebebe;
    padding: 0px 18px 0px 18px;
}
.btn-save .ms-button{
    
  width: 80px !important;
  padding: 0 !important;
}


tr.dx-row.dx-data-row.dx-row-lines {
    height: 45px;
}
.dx-state-hover{
  background-color: #ffede2;
  cursor: pointer;
} 
td{
  border-left: none !important;
  border-top:none !important ;
}
.icon-header {
 
    color: white;
    order: 0;
    margin-right: 0px;
    margin-left: 0px;
    z-index: 100;
    display: block;
    position: relative;
    box-sizing: border-box !important;
    outline: none;
    margin: auto;
    margin-left: 16px !important;
    padding: 0;
    width: 22px !important;
    height: 20px !important;
    max-width: 22px !important;
    min-width: 22px !important;
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
    -webkit-mask-position: -242px -26px;
    -moz-mask-position: -242px -26px;
    -ms-mask-position: -242px -26px;
    -o-mask-position: -242px -26px;
    mask-position: -242px -26px;
}
.dx-datagrid-headers .dx-datagrid-table .dx-row > td {
    border-bottom: 1px solid #e0e0e0;
    padding-top: 14px  ;
    padding-bottom: 14px  ; 
    line-height: 16px;
    
    font-size: 14px;
    font-weight: 700;
    letter-spacing: 0.14px;
    color: #212121;
}
.dx-datagrid .dx-row > td {
    /* padding-top: 14px !important;
    padding-bottom: 14px !important; */
    font-size: 14px;
    line-height: 20px;
}
.dx-datagrid .dx-datagrid-content .dx-datagrid-table .dx-row > td.dx-cell-modified:not(.dx-field-item-content):not(.dx-validation-pending):first-of-type, .dx-datagrid .dx-datagrid-content .dx-datagrid-table .dx-row > td.dx-datagrid-invalid:not(.dx-field-item-content):not(.dx-validation-pending):not(.dx-datagrid-select-all):first-of-type, .dx-datagrid .dx-datagrid-content .dx-datagrid-table .dx-row > td:not(.dx-validation-pending):not(.dx-datagrid-select-all):first-of-type{
  padding-left: 0;
}
.triangle{
   background: #fff;
  position: absolute;
   z-index: 1111111;
  top: 162px;
    left: 44px;
}
.triangle::after{
  height: 14px;
  width: 14px;
    background: #fff;
    display: block;
    overflow: hidden;
    content: " ";
   
    -webkit-transform: rotate(-45deg);
    transform: rotate(-45deg);
    /* border: 1px solid #ddd; */
}
.icon-draggable{
  -webkit-mask-position: -312px -72px;
    -moz-mask-position: -312px -72px;
    -ms-mask-position: -312px -72px;
    -o-mask-position: -312px -72px;
    mask-position: -312px -72px;
}
.item-checkbox{
  border-radius: 50%;
    background-color: var(--primary) !important;
}

.dx-datagrid-nodata::before {
    content: "";
    display: inline-block;
    position: absolute;
    left: 50%;
    -webkit-transform: translate(-50%, -120%);
    transform: translate(-50%, -120%);
    width: 80px;
    height: 80px;
    background: url('../../assets/icon/icon2.svg') no-repeat -13px -270px;
    width: 54px;
    height: 68px;
}
tr:hover{
  
}
.dx-header-row.dx-state-hover{
  background-color: #fff;
}
td.dx-command-select.dx-cell-focus-disabled.dx-editor-cell.dx-editor-inline-block{
  width: 50px !important;
}
.dx-checkbox-icon{
  height: 16px !important;
  width: 16px !important;
  border-radius: 4px !important;
}
.grid-content{
  width: 100%;
}
.icon-select{
  -webkit-mask-position: -192px 0;
    -moz-mask-position: -192px 0;
    -ms-mask-position: -192px 0;
    -o-mask-position: -192px 0;
    mask-position: -192px 0;
    padding-left: 30px;
    margin-left: 10px;
}
.dx-scrollbar-horizontal.dx-scrollbar-hoverable.dx-scrollable-scrollbar-active,
.dx-scrollbar-horizontal.dx-scrollbar-hoverable.dx-scrollable-scrollbar-active .dx-scrollable-scroll,
.dx-scrollbar-horizontal.dx-scrollbar-hoverable.dx-state-hover,
.dx-scrollbar-horizontal.dx-scrollbar-hoverable.dx-state-hover .dx-scrollable-scroll {
    height: 10px;
    background: #f1f1f1!important;
}

.dx-scrollbar-vertical.dx-scrollbar-hoverable.dx-scrollable-scrollbar-active,
.dx-scrollbar-vertical.dx-scrollbar-hoverable.dx-scrollable-scrollbar-active .dx-scrollable-scroll,
.dx-scrollbar-vertical.dx-scrollbar-hoverable.dx-state-hover,
.dx-scrollbar-vertical.dx-scrollbar-hoverable.dx-state-hover .dx-scrollable-scroll {
    width: 10px;
    height: 100%;
    background: #f1f1f1!important;
}
.dx-datagrid .dx-row > td {
     padding-top: 5px; 
     padding-bottom: 5px; 
    font-size: 14px;
    line-height: 20px;
}
.dx-scrollable-scroll-content {
    width: 100%;
    height: 100%;
    background: #9e9e9e!important;
    border-radius: 10px;
}
</style>