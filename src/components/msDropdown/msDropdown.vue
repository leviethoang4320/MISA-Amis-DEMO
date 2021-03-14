<template>
  <div class="ms-dropdown">
    <div class="dropdown-text">{{dropdownItem.name}}</div>
    <div class="dropdown-icon"></div>
    <div>
        <ms-dropdown-menu  :itemKey="itemKey" :dropdownMenuItem="dropdownMenuItem" />
    </div>
  </div>
</template>

<script>

export default {
  name:"MsDropdown",
  props:{
    dropdownItem: Object
  },
  data() {
    return {
      dropdownMenuItem:null,
      dropdownMenuOpen:false,
      dropItemAll:{
        application:[
          {name: "Đơn xin nghỉ",checked:false,value:1},
          {name: "Đề nghị cập nhật công",checked:false,value:2},
          {name: "Đề nghị công tác",checked:false,value:3},
          {name: "Đơn làm thêm giờ",checked:false,value:4},
          {name: "Đơn đi muộn/về sớm",checked:false,value:5},
          {name: "Bảng tổng hợp nghỉ phép",checked:false,value:6}
        ],
        timeKeeping:[
          {name: "Bảng chấm công chi tiết",checked:false,value:1},
          {name: "Bảng chấm công tổng hợp",checked:false,value:2},
          {name: "Dữ liệu máy chấm công",checked:false,value:3},
        ],
        timeShift:[
          {name: "Bảng phân ca tổng hợp",checked:false,value:1},
          {name: "Danh sách ca",checked:false,value:2},
          {name: "Danh sách phân ca chi tiết",checked:false,value:3},
        ],
        
      },
      itemKey: "" 
    }
  },
  mounted() {
    for( var element in this.dropItemAll) {     
      if(this.dropdownItem.key == element.toString()){
        this.dropdownMenuItem = this.dropItemAll[element];
      }
    }

    
    this.itemKey = this.dropdownItem.key;
    this.$bus.$on('checked',(value,key)=>{
      if(this.dropItemAll[key] != null){
        this.dropItemAll[key].forEach(element => {
          element.checked = false;
          if(element.value == value){
            element.checked = true;
          }
        });
      }
    });
  },
  methods:{
    
  }
    
}

</script>

<style>
@import url(../../styles/components/msDropdown.css);
@import url(../../styles/commons/_base.css);
</style>