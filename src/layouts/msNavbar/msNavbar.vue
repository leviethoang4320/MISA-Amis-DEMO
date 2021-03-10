<template>
  <div class="ms-navbar flex center">
     <div class="ms-navbar-header flex center ">
       <div class="app-info flex center ">
          <div class="box-app-menu"></div>
          <a class="router-link-active">
            <div class="logo-img">
              
            </div>
          </a>
          <div class="logo-text">Chấm công</div>
       </div>
     </div>
     <div class="ms-navbar-items flex center">
       <div class="item-menu" v-for="(item,index) in  menuItems " :key="index"  @click="focusItem(item.key)">
          <ms-menu-item :menuItem="item" />
       </div>
     </div>
     <div class="ms-navbar-detail">
       <div class="edition">Beta 2.34</div>
       <div class="notify"></div>
       <div class="user"></div>
     </div>
  </div>
</template>

<script>
export default {
  name: "MsNavbar",
  data() {
    return {
      menuItems:[
        {
          onFocus: false,
          key: "dashBoard",
          name:"Tổng quan",
          isDropdown: false
        },
        {
          onFocus: false,
          key: "timeKeeping",
          name:"Chấm công",
          isDropdown: true
        },
        {
          onFocus: false,
          key: "timeShift",
          name:"Ca làm việc",
          isDropdown: true
        },
        {
          onFocus: false,
          key: "application",
          name:"Quản lý đơn",
          isDropdown: true
        },
        {
          onFocus: false,
          key: "report",
          name:"Báo cáo",
          isDropdown: false
        },
        {
          onFocus: false,
          key:"setting",
          name:"Thiết lập",
          isDropdown: false
        }
      ]
    }
  },
  methods: {
    focusItem(key){
      this.menuItems.forEach(element => {
        element.onFocus = false;
        if(element.key.toString()==key.toString()){
          element.onFocus = true;
        }
      });
      this.$bus.$emit('dropdownMenuOpen',key);
    }
  },

}
</script>

<style scoped >
@import url(../../styles/components/msNavbar.css);
@import url(../../styles/commons/_base.css);

</style>


