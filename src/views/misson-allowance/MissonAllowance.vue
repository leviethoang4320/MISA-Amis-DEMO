<template>
  <div>
      <div class="content-header flex center">
        <div v-if="!deleteMode" class="content-header-left flex">
          <div class="title">Quản lý đi công tác</div>
          <div class="status flex center" @click="$bus.$emit('dropdownMenuOpen','status')">
            <div class="status-tile"  style="color: gray; margin-right: 6px;">Trạng thái:</div>
            <b>{{statusNow.name}}</b>
            <div class="icon icon-status"></div>
            <ms-dropdown-menu  :itemKey="'status'" :dropdownMenuItem="status"/>
          </div>
        </div>
        <div v-if="!deleteMode" class="content-header-right flex" >
          <div class="search flex center">
            <div class="icon icon-search"></div>
            <input class="input-search" v-model="search" @change="loadData()" placeholder="Tìm kiếm" type="text">
          </div>
          <div class="btn-add center" @click="openDetail(0)">
            <ms-button :btnTitle="'Thêm '" >
              <div class="icon icon-add"  ></div>
            </ms-button>
          </div>
          <div class="filter" @click="$bus.$emit('filter')">
            <div class="icon icon-filter"></div>
          </div>
        </div>
      <div class=" content-header-del flex center" v-if="deleteMode">
        <div v-if="deleteMode" class="selected flex">
          Đã chọn <b style="margin-left:10px">{{lengthDel}}</b>
        </div>
        <div v-if="deleteMode" class="unselected flex">
          Bỏ chọn 
        </div>
        <div class="btn-quick-del" @click="deleteConfirm()">
          <ms-button :btnTitle="'Xóa '">
              <div class=" icon-quick-del"></div>
          </ms-button>
        </div>
      </div>
      </div> 
      <div class="grid-container">
        <ms-grid @updateFirstData="updateFirstData" @updatePageSize="updatePageSize" :columnInfo="columnInfo" :dataGrid="applications" @onSelectionChanged="changeDel"/>
      </div>
      <misson-allowance-detail v-if="openPopup" :dataDetail="dataDetail" :action="action" @closeDetail="closeDetail"/>
  </div>
</template>

<script>
import ApplicationAPI from '@/api/components/Application/ApplicationAPI.js'

import MissonAllowanceDetail from './MissonAllowanceDetail.vue';

export default {
  components: { MissonAllowanceDetail },
    data() {
        return {
            applications: null,
            columnInfo:[
                {
                    id:1,
                    name:"Ngày đề nghị",
                    field:"DateSuggest",
                    visible:true,
                    filter:false,
                    checkDel:false,
                    required: true
                },
                {
                    id:2,
                    name:"Người đề nghị",
                    field:"PeopleSuggestName",
                    visible:true,
                    filter:false,
                    checkDel:false,
                    required: true
                },
                {
                    id:3,
                    name:"Ngày đi",
                    field:"DateMove",
                    visible:true,
                    filter:false,
                    required: false
                },
                {
                    id:4,
                    name:"Người duyệt",
                    field:"CensorName",
                    visible:true,
                    filter:false,
                    checkDel:false,
                    required: true
                },
                {
                    id:5,
                    name:"Ngày về",
                    field:"DateDone",
                    visible:true,
                    filter:false,
                    checkDel:false,
                    required: true
                },
                
                {
                    id:6,
                    name:"Địa điểm công tác",
                    field:"Place",
                    visible:true,
                    filter:false,
                    checkDel:false,
                    required: false
                },
                {
                    id:7,
                    name:"Lý do công tác",
                    field:"Reason",
                    visible:true,
                    filter:false,
                    checkDel:false,
                    required: false
                },
                {
                    id:8,
                    name:"Trạng thái",
                    field:"StatusName",
                    visible:true,
                    filter:false,
                    checkDel:false,
                    required: false
                },
            ],
            dataDetail: null,             
            openPopup:false,
            deleteMode:false,
            lengthDel:0,
            action: null,         
            firstDataItem:1,
            pageSizeNow:15,
            deleteData:null,
            deleteResult: null,
            status: [
            {name: 'Tất cả', value:3,checked:true},
            {name:'Chờ duyệt', value:1,checked:false},
            {name:'Đã duyệt', value:2,checked:false},
            {name: 'Từ chối', value:0,checked:false},        
            ],
            statusNow:{
              value:3,
              name:'Tất cả'
            },
            search:""
        }
    },
  
   mounted() {
     //load dữ liệu
      this.loadData();
      
      //đóng popoup
      this.$bus.$on('closeDetail',()=>{        
        this.closeDetail();
      });

      //mở detail với trạng thái sửa
      this.$bus.$on('openDetail',(data)=>{
        this.openDetail(1);          
        this.dataDetail = data;
      });
      
      //load lại trang để cập nhật dữ liệu
      this.$bus.$on('reload',()=>{
        this.loadData();
      });

      //lọc trạng thái
      this.$bus.$on('checked',(value,itemKey)=>{
        if(itemKey == "status")
        this.status.forEach(element => {
          element.checked = false;
          if(element.value == value){
            element.checked = true;
            this.statusNow.name = element.name;
            this.statusNow.value = value;
            this.loadData();
          }
        });
      });
      
    },
    methods:{
      //load dữ liệu
      async loadData(){
        var pagingData = new Object;
        pagingData.pageSizeNow = this.pageSizeNow;
        pagingData.firstDataItem = this.firstDataItem - 1;
        pagingData.status = this.statusNow.value;
        pagingData.filter = this.search;
        this.applications = (await ApplicationAPI.paging(pagingData)).data;
        // this.applications = response.res;      
        this.applications.res.forEach(element => {
          element.DateSuggest = this.formatDate(element.DateSuggest);
         
          element.DateMove = this.formatDate(element.DateMove);
          
          element.DateDone = this.formatDate(element.DateDone);
         
        });
      },
      //đóng popup detail
      closeDetail(){
        this.openPopup=false;
      },
      //mở Dialog detail với trạng thái 1: sửa, 0: thêm mới
      openDetail(action){
        this.action = action;
        this.dataDetail = null;
        this.openPopup=!this.openPopup;
        
      },
      //xử lý click ckeckbox ở đầu dòng
      changeDel(e){
        this.deleteData = e;
        this.lengthDel = e.length;
        if(e.length > 0 ){
          this.deleteMode = true;
        }
        else this.deleteMode = false;
      },
      //format ngày để hiển thị lên bảng danh sách về yểu dd/mm/yyy hh:mm
      formatDate(date){
        let day = date.substr(8,2);
        let month = date.substr(5,2);
        let year = date.substr(0,4);
        let hour = date.substr(11,2);
        let minute = date.substr(14,2);
        let a = day+"/"+month+"/"+year+" "+hour+":"+minute;
        
        return a;
      },
      //xử lý khi thay đổi vị trí bản ghi bắt đầu
      updateFirstData(val){
        this.firstDataItem = val;
        this.loadData();
      },
      //xử lý khi thay đổi vị trí ban đầu
      updatePageSize(val){
        this.pageSizeNow = val;
        this.loadData();
      },
      //Xóa nhiều
      deleteConfirm(){
        this.deleteResult = (ApplicationAPI.deletes(this.deleteData)).data;
        setTimeout(() => {
          this.loadData();
        }, 500);        
      }
    },
    watch:{
      
    }
}
</script>

<style>
@import url(../../styles/components/msContent.css);
@import url(../../styles/views/misson-allowance.css);
.icon-status{
  -webkit-mask-position: -96px -48px;
    -moz-mask-position: -96px -48px;
    -ms-mask-position: -96px -48px;
    -o-mask-position: -96px -48px;
    mask-position: -96px -48px;
}

</style>
<style scoped>
.ms-dropdown-menu{
  top: 100px;
    left: 254px;
    width: 116px
  
}
.unselected.flex {
    color: #ef292f;
}
.icon-quick-del{
  margin-right: 3px;
  width: 24px;
    height: 24px;
    background: url(https://amisdemo.misacdn.net/apps/timesheetstatic/img/Icon.569cfdf.svg) -168px -24px no-repeat;
}

.selected.flex{
  margin: 20px ;
  margin-left: 0;
}
.btn-quick-del .ms-button{
  background-color: #fff;
  border: 1px solid #ef292f;
  color: #ef292f;
  margin-left: 15px;
  padding-left: 12px;
    padding-right: 15px;

}
</style>
