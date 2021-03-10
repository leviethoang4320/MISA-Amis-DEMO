<template>
    <div class="misson-allowance">
        <ms-popup :btnTitle="'Lưu'" :action="'Thêm đơn'" :title="' - Công tác'" :status="1" >
        <div class="flex">
          <div class="popup-content-left">
            <div class="popup-content-item center flex" :class="{validate:isValid.PeopleSuggest}" id="focusItem">
                <div class="inputText" >Người đề nghị <span class="required"> *</span></div>
                <ms-input :focusItem="true" :inputType="inputTypeSelect" :model.sync="vPeopleSuggest">
                  <div class="icon icon-error" id="tooltipPeopleSuggest" @mouseenter="toggleDefault"
                       @mouseleave="toggleDefault" v-if="isValid.PeopleSuggest">
                  </div>
                  <DxTooltip
                    :visible="defaultVisible"
                    :close-on-outside-click="false"
                    target="#tooltipPeopleSuggest"
                     position="top"
                  >
                    Người đề nghị không được để trống
                  </DxTooltip>
                </ms-input>
                
            </div>
            <div class="popup-content-item center flex">
                <div class="inputText">Đơn vị công tác </div>
                <input disabled="true" style="height:29px; width:232px"/>
            </div>
            <div class="popup-content-item center flex" :class="{validate:isValid.Censor}">
                <div class="inputText"  >Người duyệt <span class="required"> *</span></div>
                <ms-input :inputType="inputTypeSelect" :model.sync="vCensor">
                  <div class="icon icon-error" v-if="isValid.Censor"></div>
                </ms-input>

            </div>
            <div class="popup-content-item center flex date" :class="{validate:isValid.DateSuggest}">
                <div class="inputText" >Ngày đề nghị <span class="required"> *</span></div>
                <ms-input :inputType="inputTypeDate" :defaultDate.sync="dataDetail_.DateSuggest" >
                  <div class="icon icon-error" v-if="isValid.DateSuggest"></div>
                </ms-input>
            </div>
            <div class="popup-content-item center flex date" :class="{validate:isValid.DateMove}">
                <div class="inputText" >Ngày đi <span class="required"> *</span></div>
                <ms-input :inputType="inputTypeDate" :defaultDate.sync="dataDetail_.DateMove">
                  <div class="icon icon-error" v-if="isValid.DateMove"></div>
                </ms-input>
            </div>
            <div class="popup-content-item center flex date" :class="{validate:isValid.DateDone}">
                <div class="inputText" >Ngày về <span class="required"> *</span></div>
                <ms-input :inputType="inputTypeDate" :defaultDate.sync="dataDetail_.DateDone" >
                  <div class="icon icon-error" v-if="isValid.DateDone"></div>
                </ms-input>
            </div>
            <div class="popup-content-item center flex">
                <div class="inputText" >Địa điểm công tác</div>
                <ms-input :inputType="inputTypeText" :model="dataDetail_.Place" />
            </div>
            <div class="popup-content-item right flex">
                <div class="inputText">Lý do công tác</div>
                <ms-input :inputType="inputTypeText" :model="dataDetail_.Reason" />
            </div>
          </div>
          <div class="popup-content-right">
            <div class="popup-content-item right x flex">
                <div class="inputText">Người liên quan</div>
                <ms-input :inputType="inputTypeSelect"/>
            </div>
            <div class="popup-content-item right x flex">
                <div class="inputText">Yêu cầu hỗ trợ</div>
                <ms-input :inputType="inputTypeText" />
            </div>
            <div class="popup-content-item right x flex">
                <div class="inputText">Người hỗ trợ</div>
                <ms-input :inputType="inputTypeSelect"/>
            </div>
            <div class="popup-content-item right x flex">
                <div class="inputText">Ghi chú</div>
                <ms-input :inputType="inputTypeText"/>
            </div>
            <div class="popup-content-item center x flex" style="witdh=275px">
                <div class="inputText">Trạng thái <span class="required"> *</span></div>
                <ms-input :inputType="inputTypeSelect" :model="dataDetail_.Status">

                </ms-input>
            </div>
          </div>
        </div>
        <div class="teammate">
          <div class="teammate-title">
            Nhân viên đi cùng
          </div>
          <div class="teammate-content center flex">
            <div class="teammate-info">
              Chưa có dữ liệu
            </div>
            <div class="add-teammate center flex" @click="openTeammateDetail()">
              <div class="icon icon-add-teammate">
              </div>
              <div class="text-add">
                Chọn
              </div>
            </div>
          </div>
        </div>

      </ms-popup> 
      <ms-teammate-detail v-if="teammateDetail" />
    </div>
</template>

<script>
import { DxTooltip } from 'devextreme-vue/tooltip';
import MsTeammateDetail from "./MsTeammateDetail.vue";
export default {
    name: "MissonAllowanceDetail",
    components:{
      MsTeammateDetail,
      DxTooltip
    },
    props:{
        dataDetail:{
             type: Object,
             default: null
        }
    },
    data() {
        return {
            inputTypeDate:{
               select: false,
               date: true
             },
             inputTypeSelect:{
                select: true,
                date: false
             }
             ,
             inputTypeText:{
                select: false,
                date: false
             },
             dataDetail_:{
                Censor: null,
                DateDone: null,
                DateMove: null,
                DateSuggest: null,
                ID: null,
                PeopleSuggest: null,
                Place: null,
                Reason: null,
                Status: null,
             },
            teammateDetail: false,
            isValid:{
              Censor: null,
              DateDone: null,
              DateMove: null,
              DateSuggest: true,               
              PeopleSuggest: null,
               
            },
            defaultVisible: false,
            

        }
    },
    mounted() {
    
            if(this.dataDetail)
            for(let item in this.dataDetail_){
                
                if(item.toString()=='DateSuggest'||item.toString()=='DateMove'||item.toString()=='DateDone'){
                  this.dataDetail_[item.toString()]=  this.formatDate(this.dataDetail[item.toString()]) ;
                }
                else this.dataDetail_[item.toString()]= this.dataDetail[item.toString()] ;
            }

            this.$bus.$on('closeTeammate',()=>{
            this.teammateDetail = !this.teammateDetail;
             });
            
          
    },
    methods:{
      formatDate(date){
        let day = date.substr(0,2);
        let month = date.substr(3,2);
        let year = date.substr(6,4);
        let a = (new Date(year-1,month-1,day)).toString();
       
        return a;
      },
      openTeammateDetail(){
            this.teammateDetail = !this.teammateDetail;
      },
      toggleDefault() {
      this.defaultVisible = !this.defaultVisible;
    },

    
    },
    computed:{
      vCensor:{
        get(){ return  this.dataDetail_.Censor },
        set(value){
          //handle
          if(value==null){
            this.isValid.Censor = true;
          }
          else this.isValid.Censor = false;
          this.dataDetail_.Censor = value
          
        }
      },
      vPeopleSuggest:{
        get(){ return  this.dataDetail_.PeopleSuggest },
        set(value){
          //handle
          if(value==null){
            this.isValid.PeopleSuggest = true;
          }
          else this.isValid.PeopleSuggest = false;
          this.dataDetail_.PeopleSuggest = value
          
        }
      },
      vDateMove:{
        get(){ return  this.dataDetail_.DateMove },
        set(value){
          //handle
          if(value==null){
            this.isValid.DateMove = true;
          }
          else this.isValid.DateMove = false;
          this.dataDetail_.DateMove = value
          
        }
      },
      vDateDone:{
        get(){ return  this.dataDetail_.DateDone },
        set(value){
          //handle
          if(value==null){
            this.isValid.DateDone = true;
          }
          else this.isValid.DateDone = false;
          this.dataDetail_.DateDone = value
          
        }
      },
      vDateSuggest:{
        get(){ return  this.dataDetail_.DateSuggest },
        set(value){
          //handle
          if(value==null){
            this.isValid.DateSuggest = true;
          }
          else this.isValid.DateSuggest = false;
          this.dataDetail_.DateSuggest = value
          
        }
      },
    }

}
</script>

<style>
.icon-error{
  background-color: #ff6161!important;
  -webkit-mask-position: -240px -72px;
    -moz-mask-position: -240px -72px;
    -ms-mask-position: -240px -72px;
    -o-mask-position: -240px -72px;
    mask-position: -240px -72px;
    position: relative;
    top: -83%;
    right: -79%;
}
.date .icon-error{
  
    top: -83%;
    right: -73%;
}
.validate .dx-texteditor-container {
    border: 1px solid #ff6161 !important;
    
}
.validate .mx-input-wrapper {
    border: 1px solid #ff6161 !important;
}

.x .ms-input {
    width: 275px;
    
}
.right .inputText {
    padding-top: 10px;
}
.add-teammate{
  cursor: pointer;
}
.text-add{
  color: #3c4ada;
  white-space: nowrap;
    font-weight: 500;
}
.teammate-info{
  font-style: italic;
    color: #9fa4b4;
   padding-right: 10px;
    font-size: 14px;
}
.teammate-title{
  font-size: 16px;
    letter-spacing: .256px;
    letter-spacing: .256px;
    font-weight: 700;
    padding-bottom: 20px;
}
.popup-content-item{
  height: 35px;
  margin-bottom: 16px;
  width: 385px;
  justify-content: space-between;
}
.required{
  color: #ff0000;
}
.popup-content-item.right{
  height: 85px;
}
.popup-content-left{
  padding-right: 40px;
}
.input-search{
  border: none;
}
.input-search:focus{
  outline: none !important;
  border: none !important;
}
.search:focus-within{
  border: 1px solid #ec5504 !important;
  
}
.search:hover{
  border: 1px solid #ec5504 !important;
  
}
.dx-show-invalid-badge.dx-selectbox.dx-textbox.dx-texteditor.dx-dropdowneditor-button-visible.dx-editor-underlined.dx-texteditor-empty.dx-widget.dx-dropdowneditor.dx-dropdowneditor-field-clickable {
    height: 100%;
}
.dx-show-invalid-badge.dx-selectbox.dx-textbox.dx-texteditor.dx-dropdowneditor-button-visible.dx-editor-underlined.dx-widget.dx-dropdowneditor.dx-dropdowneditor-field-clickable{
  height: 100%;
}
.icon-add-teammate{
    -webkit-mask-position: -192px -24px;
    -webkit-mask-position-x: -192px;
    -webkit-mask-position-y: -24px;
    -moz-mask-position: -192px -24px;
    -ms-mask-position: -192px -24px;
    -o-mask-position: -192px -24px;
    mask-position: -192px -24px;
    background-color: #3c4ada!important;
}
 
  

.grid-container-teammate{
  width: 800px;
}
</style>
<style scoped>

</style>