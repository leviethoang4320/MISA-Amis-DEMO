<template>
  <div class="menu-item" :class="{'focus': menuItem.onFocus}">
      <ms-dropdown v-if="menuItem.isDropdown" :dropdownItem="dropdownItem"/>
      <ms-router-link v-else :routerLinkItem="routerLinkItem" />
  </div>
</template>

<script>
export default {
    name:"MsMenuItem",
    props:{
        menuItem: Object
    },
    data() {
        return {
            dropdownItem:{
                key: this.menuItem.key,
                name: this.menuItem.name,
                open: false
            },
            routerLinkItem:{
                name: this.menuItem.name,
                url: null
            }
        }
    },
}
</script>

<style scoped>
    @import url(../../styles/components/msMenuItem.css);
    @import url(../../styles/commons/_base.css);
    
</style>