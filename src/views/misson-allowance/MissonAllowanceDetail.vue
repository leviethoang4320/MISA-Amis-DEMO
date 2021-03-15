<template>
    <div class="misson-allowance">
        <ms-popup @save="save()" :btnTitle="'Lưu'" :action="'Thêm đơn'" :title="' - Công tác'" :status="1" >
        <div class="flex">
          <div class="popup-content-left">
            <div class="popup-content-item center flex" :class="{validate:isValid.PeopleSuggest}" id="focusItem">
                <div class="inputText" >Người đề nghị <span class="required"> *</span></div>
                <div class="ms-input">
                    <DxSelectBox
                          
                          :search-enabled="true"
                          :data-source="EmployeeData"
                          search-mode="contains"
                          search-expr="Name"
                          :search-timeout = "200"
                          :min-search-length = "0"
                          :show-data-before-search="false"
                          :placeholder = "''"
                          display-expr="Name"
                          value-expr="EmployeeId"
                          v-model="vPeopleSuggest"
                          
                          ref="focusItem"

                    /> 
                    <div class="icon icon-error" id="tooltipPeopleSuggest" @mouseenter="togglePeopleSuggest"
                        @mouseleave="togglePeopleSuggest" v-if="isValid.PeopleSuggest">
                    </div>
                    <DxTooltip
                      :visible="PeopleSuggestVisible"
                      :close-on-outside-click="false"
                      target="#tooltipPeopleSuggest"
                      position="top"
                    >
                      Người đề nghị không được để trống
                    </DxTooltip>
                </div>                
            </div>

            <div class="popup-content-item center flex">
                <div class="inputText">Đơn vị công tác </div>
                <input v-model="Department.name" disabled="true" style=" width:220px; padding:8px; font-size: 14px"/>
            </div>
            <div class="popup-content-item center flex" :class="{validate:isValid.Censor}">
                <div class="inputText"   >Người duyệt <span class="required"> *</span></div>
                <div class="ms-input" >
                  <DxSelectBox
                         
                        :search-enabled="true"
                        :data-source="CensorData"
                        search-mode="contains"
                        search-expr="Name"
                        :search-timeout = "200"
                        :min-search-length = "0"
                        :show-data-before-search="false"
                        :placeholder = "''"
                        display-expr="Name"
                        value-expr="EmployeeId"
                        v-model="vCensor"
                        
                      
                  /> 
                  <div class="icon icon-error" id="tooltipCensor" @mouseenter="toggleCensor"
                        @mouseleave="toggleCensor" v-if="isValid.Censor">
                  </div>
                    <DxTooltip
                      :visible="CensorVisible"
                      :close-on-outside-click="false"
                      target="#tooltipCensor"
                      position="top"
                    >
                      Người duyệt không được để trống
                    </DxTooltip>
                </div>

            </div>
            <div class="popup-content-item center flex date" :class="{validate:isValid.DateSuggest}">
                <div class="inputText" >Ngày đề nghị <span class="required"> *</span></div>
                <div class="ms-input" >
                  <ms-datepicker  :defaultDate.sync="vDateSuggest"/>
                   <div class="icon icon-error" id="tooltipDateSuggest" @mouseenter="toggleDateSuggest"
                        @mouseleave="toggleDateSuggest" v-if="isValid.DateSuggest">
                  </div>
                    <DxTooltip
                      :visible="DateSuggestVisible"
                      :close-on-outside-click="false"
                      target="#tooltipDateSuggest"
                      position="top"
                    >
                      Ngày đề nghị không được để trống
                    </DxTooltip>

                </div>
            </div>
            <div class="popup-content-item center flex date" :class="{validate:isValid.DateMove}">
                <div class="inputText" >Ngày đi <span class="required"> *</span></div>
                <div class="ms-input"  >
                  <ms-datepicker   :defaultDate.sync="vDateMove"/>
                   <div class="icon icon-error" id="tooltipDateMove" @mouseenter="toggleDateMove"
                        @mouseleave="toggleDateMove" v-if="isValid.DateMove">
                  </div>
                    <DxTooltip
                      :visible="DateMoveVisible"
                      :close-on-outside-click="false"
                      target="#tooltipDateMove"
                      position="top"
                    >
                      Ngày đi không được để trống
                    </DxTooltip>
                </div>
            </div>
            <div class="popup-content-item center flex date" :class="{validate:isValid.DateDone}">
                <div class="inputText" >Ngày về <span class="required"> *</span></div>
                <div class="ms-input" >
                  <ms-datepicker :defaultDate.sync="vDateDone"/>
                   <div class="icon icon-error" id="tooltipDateDone" @mouseenter="toggleDateDone"
                        @mouseleave="toggleDateDone" v-if="isValid.DateDone">
                  </div>
                    <DxTooltip
                      :visible="DateDoneVisible"
                      :close-on-outside-click="false"
                      target="#tooltipDateDone"
                      position="top"
                    >
                      Ngày về không được để trống
                    </DxTooltip>
                </div>
            </div>
            <div class="popup-content-item center flex">
                <div class="inputText" >Địa điểm công tác</div>
                <div class="ms-input">
                <textarea v-model="dataDetail_.Place" name="" class="input-text" cols="30" rows="10"></textarea>
                </div>
            </div>
            <div class="popup-content-item right flex">
                <div class="inputText" >Lý do công tác</div>
                <div class="ms-input"> 
                  <textarea v-model="dataDetail_.Reason"  name="" class="input-text" cols="30" rows="10"></textarea>
                </div>

            </div>
          </div>
          <div class="popup-content-right">
            <div class="popup-content-item right x flex">
                <div class="inputText">Người liên quan</div>
                <div class="ms-input">
                  <DxTagBox
                  
                    :items="EmployeeData"
                    :search-enabled="true"
                    v-model="vPeopleInvol"
                  
                    height="100%"
                    width="100%"
                  
                    display-expr="Name"
                      value-expr="EmployeeId"
                      :placeholder = "''"

                  />
                  <div class="icon-down" ></div>
                </div>
            </div>
            <div class="popup-content-item right x flex">
                <div class="inputText">Yêu cầu hỗ trợ</div>
                <div class="ms-input">
                  <textarea v-model="dataDetail_.RequestSupport"  name="" class="input-text" cols="30" rows="10"></textarea>
                </div>
            </div>
            <div class="popup-content-item right x flex">
                <div class="inputText">Người hỗ trợ</div>
                <div class="ms-input">
                    <DxTagBox
                  
                    :items="EmployeeData"
                    :search-enabled="true"
                    
                    v-model="vPeopleSupport"
                    height="100%"
                    width="100%"
                  
                    display-expr="Name"
                      value-expr="EmployeeId"
                      :placeholder = "''"

                    />
                    <div class="icon-down" ></div>
                </div>
            </div>
            <div class="popup-content-item right x flex">
                <div class="inputText">Ghi chú</div>
                <div class="ms-input">
                  <textarea v-model="dataDetail_.Note"  name="" class="input-text" cols="30" rows="10"></textarea>
                  
                </div>
            </div>
            <div class="popup-content-item center x flex" :class="{validate:isValid.Status}" style="witdh=275px">
                <div class="inputText">Trạng thái <span class="required"> *</span></div>
                <div class="ms-input">
                    <DxSelectBox
                          :search-enabled="true"
                          :data-source="statusData"
                          search-mode="contains"
                          search-expr="Name"
                          :search-timeout = "200"
                          :min-search-length = "0"
                          :show-data-before-search="false"
                          :placeholder = "''"
                          display-expr="Name"
                          value-expr="ID"
                          v-model="dataDetail_.Status"
                          
                          
                        
                    /> 
                  <div class="icon icon-error" v-if="isValid.Status"></div>
                </div>
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
import DxTagBox from 'devextreme-vue/tag-box';
import { DxSelectBox } from 'devextreme-vue/select-box';
import { DxTooltip } from 'devextreme-vue/tooltip';
import MsTeammateDetail from "./MsTeammateDetail.vue";
import ApplicationAPI from '@/api/components/Application/ApplicationAPI.js'
import EmployeeAPI from '@/api/components/Employee/EmployeeAPI.js'
import notify from 'devextreme/ui/notify';
export default {
    name: "MissonAllowanceDetail",
    components:{
      MsTeammateDetail,
      DxTooltip,
      DxSelectBox,
      DxTagBox
    },
    props:{
      dataDetail:{
        type: Object,
        default: null
      },
      action: Number
    },
    data() {
        return {
            statusData:[
                {ID:1, Name: "Chờ duyệt"},
                {ID:2, Name: "Đã duyệt"},
                {ID:0, Name: "Từ chối"}
            ],
            dataDetail_:{
                CensorId: null,
                DateDone: null,
                DateMove: null,
                DateSuggest: null,
                PeopleSuggestId: null,
                Place: null,
                Reason: null,
                Status: 1,
                PeopleInvolIds:null,
                PeopleSupportIds:null,
                RequestSupport: null,
                Note: null
            },
            EmployeeData: null,
            Censor:null,
            teammateDetail: false,
            isValid:{
              Censor: false,
              DateDone: false,
              DateMove: false,
              DateSuggest: false,               
              PeopleSuggest: false,
              Status: false,             
            },
            checkValid: false,
            PeopleSuggestVisible: false,
            CensorVisible: false,
            DateSuggestVisible: false,
            DateMoveVisible: false,
            DateDoneVisible: false,
            vPeopleInvol:null,
            vPeopleSupport:null,
            CensorData:[],
            Department:{
              nam:null,
              ID: null
            },
            PeopleSupportData: []
            

        }
    },
    async created() {
      //load và xử lý dữ liệu tagBox
      if(this.dataDetail)
        this.dataDetail_ = (await ApplicationAPI.getById(this.dataDetail.ApplicationId)).data;
      this.vPeopleInvol = this.formatTagbox(this.dataDetail_.PeopleInvolIds);
      this.vPeopleSupport = this.formatTagbox(this.dataDetail_.PeopleSupportIds);
      this.EmployeeData = (await EmployeeAPI.getAll()).data; 
      if(this.EmployeeData)
      this.EmployeeData.forEach(element => {
        
        
        if(element.EmployeeId == this.dataDetail_.PeopleSuggestId){
          this.Department.name = element.DepartmentName;
          this.Department.ID = element.DepartmentId;
        }
        if(element['Role']==2 && element.DepartmentId == this.Department.ID ){
          
          this.CensorData.push(element);
          
        }
        if( element.DepartmentId == this.Department.ID ){
          
          this.PeopleSupportData.push(element);
          
        }
      });
      
    },
    
    mounted() {
       
      this.$bus.$on('closeTeammate',()=>{
        this.teammateDetail = !this.teammateDetail;
      });
      this.$refs['focusItem'].instance.focus();
              
    },
    methods:{
      /**
       * Mở dialog chọn người đi cùng
       */
      openTeammateDetail(){
            this.teammateDetail = !this.teammateDetail;
      },

      /**
       * các method ẩn hiện tooltip
       */
      togglePeopleSuggest() {
        this.PeopleSuggestVisible = !this.PeopleSuggestVisible;
      },
      toggleCensor() {
        this.CensorVisible = !this.CensorVisible;
      },
      toggleDateSuggest() {
        this.DateSuggestVisible = !this.DateSuggestVisible;
      },
      toggleDateMove() {
        this.DateMoveVisible = !this.DateMoveVisible;
      },
      toggleDateDone() {
        this.DateDoneVisible = !this.DateDoneVisible;
      },
       // convert dữ liệu tagBox dạng Array sang Sting
      convertToString(Ids){
        var str="";
        if(Ids){
          Ids.forEach(element => {
            str+=(element.toString()+";");
          });
          return str;
        }
        else return null;
      },
      /**
       * Xử lý khi nhấn lưu 
       */
      async save(){
        //thự hiện check Validate
        this.checkValid = false;
       
        if(this.dataDetail_.PeopleSuggestId == null){
          this.isValid.PeopleSuggest = true;
          this.checkValid = true;
        }
        if(this.dataDetail_.CensorId == null){
          this.isValid.Censor = true;
          this.checkValid = true;
        }
        if(this.dataDetail_.DateMove == null){
          this.isValid.DateMove = true;
          this.checkValid = true;
        }
        if(this.dataDetail_.DateDone == null){
          this.isValid.DateDone = true;
          this.checkValid = true;
        }
        if(this.dataDetail_.DateSuggest == null){
          this.isValid.DateSuggest = true;
          this.checkValid = true;
        }
        if(this.dataDetail_.Status == null){
          this.isValid.Status = true;
          this.checkValid = true;
        }
       //nếu action = 1 thì thự hiện sửa, 0 thực hiện xóa
        if(this.checkValid==false){
          if(this.action==0){
    
          this.add();
          }
          if(this.action==1){
          
            this.update();
          }
        }
        else notify("Thất bại", "error",500);
        
        
        
        
      },
      /**
       * chuyển chuỗi các string Id về mảng int Id
       */
      formatTagbox(tagBox){
        if(tagBox){         
          tagBox = tagBox.slice(0,-1);
          var listData = tagBox.split(";");
          var data = [];
          listData.forEach(element => {
            if(typeof(element) == "string"){
              data.push(parseInt(element));
            }
            else{
              data.push(element);
            }
          });
          return data;
          }
        else return null;

      },
      /**
       * Thêm mới dữ liệu
       */
      add(){       
        // this.dataDetail_.DateSuggest =  new Date(this.dataDetail_.DateSuggest);
        // this.dataDetail_.DateMove =  new Date(this.dataDetail_.DateMove);
        // this.dataDetail_.DateDone =  new Date(this.dataDetail_.DateDone);
        this.dataDetail_.PeopleInvolIds = this.convertToString(this.vPeopleInvol);
        this.dataDetail_.PeopleSupportIds = this.convertToString(this.vPeopleSupport);
        try {
          ApplicationAPI.insert(this.dataDetail_);
        } catch (error) {
          alert(error)
        } 
        this.$bus.$emit('closeDetail');
         setTimeout(() => {
           notify("Thành công", "success",500);
          this.$bus.$emit('reload');
         
          
        }, 500);
        
      },
      /**
       * Cập nhật dữ liệu
       */
      update(){        
        this.dataDetail_.PeopleInvolIds = this.convertToString(this.vPeopleInvol);
        this.dataDetail_.PeopleSupportIds = this.convertToString(this.vPeopleSupport);
        ApplicationAPI.update(this.dataDetail.ApplicationId,this.dataDetail_);
        this.$bus.$emit('closeDetail');
        setTimeout(() => {
          notify("Thành công", "success",500);
          this.$bus.$emit('reload');         
        }, 500);        
      },
    
    },
    computed:{      
      vCensor:{
        get(){ return  this.dataDetail_.CensorId },
        set(value){
          //handle
          if(value==null){
            this.isValid.Censor = true;
          }
          else this.isValid.Censor = false;
          this.dataDetail_.CensorId = value         
        }
      },
      vPeopleSuggest:{
        get(){ return  this.dataDetail_.PeopleSuggestId },
        set(value){
          //handle
          if(value==null){
            this.isValid.PeopleSuggest = true;
          }
          else this.isValid.PeopleSuggest = false;
          this.dataDetail_.PeopleSuggestId = value;
          this.CensorData = [];
          this.PeopleSupportData = [];
          this.EmployeeData.forEach(element => {
        
        
            if(element.EmployeeId == value){
              this.Department.name = element.DepartmentName;
              this.Department.ID = element.DepartmentId;
            }
            if(element['Role']==2 && element.DepartmentId== this.Department.ID ){
              
              this.CensorData.push(element);
              
            }
            if( element.DepartmentId == this.Department.ID ){
          
              this.PeopleSupportData.push(element);
              
            }
           
          });  
        }
      },
      vDateMove:{
        get(){ if(this.dataDetail_.DateMove)
          return this.dataDetail_.DateMove.toString();
          else return null; },
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
        get(){ if(this.dataDetail_.DateDone)
          return this.dataDetail_.DateDone.toString();
          else return null; },
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
        get(){ 
          if(this.dataDetail_.DateSuggest)
          return this.dataDetail_.DateSuggest.toString();
          else return null;
          },
        set(value){
          //handle
          if(value==null){
            this.isValid.DateSuggest = true;
          }
          else this.isValid.DateSuggest = false;
          this.dataDetail_.DateSuggest = value;         
        }
      },
      vStatus:{
        get(){ return  this.dataDetail_.Status },
        set(value){
          //handle
          if(value==null){
            this.isValid.Status = true;
          }
          else this.isValid.Status = false;
          this.dataDetail_.Status = value
          
        }
      }
    },
    watch: {
      
    }

}
</script>

<style>
@import url(../../styles/views/misson-allowance-detail.css);
</style>
<style scoped>

</style>
