<template>
  <div>
      <div class="content-header flex center">
        <div v-if="!deleteMode" class="content-header-left flex">
          <div class="title">Quản lý đi công tác</div>
          <div class="status flex center">
            <div class="status-tile" style="color: gray; margin-right: 6px;">Trạng thái:</div>
            <b>Tất cả</b>
            <div class="icon icon-status"></div>
          </div>
        </div>
        <div v-if="!deleteMode" class="content-header-right flex" >
          <div class="search flex center">
            <div class="icon icon-search"></div>
            <input class="input-search" placeholder="Tìm kiếm" type="text">
          </div>
          <div class="btn-add center" @click="openDetail()">
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
        <div class="btn-quick-del">
          <ms-button :btnTitle="'Xóa '">
              <div class=" icon-quick-del"></div>
          </ms-button>
        </div>
      </div>
      </div> 
      <div class="grid-container">
        <ms-grid :columnInfo="columnInfo" :dataGrid="applications" @onSelectionChanged="changeDel"/>
      </div>
      <misson-allowance-detail v-if="openPopup" :dataDetail="dataDetail"/>
  </div>
</template>

<script>
import service from '@/data.js';
import MissonAllowanceDetail from './MissonAllowanceDetail.vue';
// import { delete } from 'vue/types/umd';
export default {
  components: { MissonAllowanceDetail },
    data() {
        return {
            applications: service.getApplications(),
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
                    field:"PeopleSuggest",
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
                    field:"Censor",
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
                    field:"Status",
                    visible:true,
                    filter:false,
                    checkDel:false,
                    required: false
                },
            ],
             dataDetail: null,
             
             openPopup:false,
              deleteMode:false,
              lengthDel:0
        }
    },
    mounted() {
      this.$bus.$on('close',()=>{
        this.closeDetail();
      });
       this.$bus.$on('openDetail',(data)=>{
            this.openDetail();
            console.log(data, 1)
            this.dataDetail = data;
        })
    },
    methods:{
      closeDetail(){
        this.openPopup=!this.openPopup;
      },
      openDetail(){
        this.dataDetail = null;
        this.openPopup=!this.openPopup;
        
      },
      changeDel(e){
        this.lengthDel = e.length;
        if(e.length > 0 ){
          this.deleteMode = true;
        }
        else this.deleteMode = false;
      }
    }
}
</script>

<style>
@import url(../../styles/components/msContent.css);
.icon-status{
  -webkit-mask-position: -96px -48px;
    -moz-mask-position: -96px -48px;
    -ms-mask-position: -96px -48px;
    -o-mask-position: -96px -48px;
    mask-position: -96px -48px;
}

</style>
<style scoped>
.icon-quick-del{

  width: 24px;
    height: 24px;
    background: url(https://amisdemo.misacdn.net/apps/timesheetstatic/img/Icon.569cfdf.svg) -168px -24px no-repeat;
}

.selected.flex{
  margin: 20px !important;
}
.btn-quick-del .ms-button{
  background-color: #fff;
  border: 1px solid #ef292f;
  color: #ef292f;
  margin-left: 10px;
  padding-left: 12px;
    padding-right: 15px;

}
</style>