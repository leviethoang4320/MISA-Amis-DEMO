<template>
  <div class="ms-dropdown-menu" v-if="dropdownMenuOpen" v-click-outside="onClickOutside" >
      <ul>
          <li class="flex center" :class="{'focusDrop':item.checked}" v-for="(item,index) in dropdownMenuItem" :key="index" @click="$bus.$emit('checked',item.value,itemKey)">
              <div class="drop-item-content"> {{item.name}}</div>
              <div v-if="item.checked" class="icon-check"></div>
          </li>
      </ul>
  </div>
</template>

<script>
import vClickOutside from 'v-click-outside'
export default {
    name:"MsDropdownMenu",
    props:{
        dropdownMenuItem: Array,
        itemKey:String,
    },
    data() {
        return {
            dropdownMenuOpen: false
        }
    },
    mounted() {
         this.$bus.$on('dropdownMenuOpen',(key)=>{
             if(this.itemKey == key){
                this.dropdownMenuOpen = !this.dropdownMenuOpen;
             }
    })
    },
    directives: {
      clickOutside: vClickOutside.directive
    },
     methods: {
      onClickOutside (event) {
        console.log('Clicked outside. Event: ', event);
        this.dropdownMenuOpen = !this.dropdownMenuOpen;
      }
    }
}
</script>

<style lang="css" scoped>
    @import url(../../styles/components/msDropdownMenu.css);
    @import url(../../styles/commons/_base.css);
</style>

