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
          {name: "Đơn xin nghỉ",checked:false},
          {name: "Đề nghị cập nhật công",checked:false},
          {name: "Đề nghị công tác",checked:false},
          {name: "Đơn làm thêm giờ",checked:false},
          {name: "Đơn đi muộn/về sớm",checked:false},
          {name: "Bảng tổng hợp nghỉ phép",checked:false}
        ],
        timeKeeping:[
          {name: "Bảng chấm công chi tiết",checked:false},
          {name: "Bảng chấm công tổng hợp",checked:false},
          {name: "Dữ liệu máy chấm công",checked:false},
        ],
        timeShift:[
          {name: "Bảng phân ca tổng hợp",checked:false},
          {name: "Danh sách ca",checked:false},
          {name: "Danh sách phân ca chi tiết",checked:false},
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
    this.$bus.$on('checked',(name,key)=>{
      if(this.dropItemAll[key] != null){
        this.dropItemAll[key].forEach(element => {
          element.checked = false;
          if(element.name == name){
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