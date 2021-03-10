<template>
  <div class="ms-popup">
      <div class="popup-bgr"></div>
      <div class="popup-detail">
          <div class="popup-header flex">
              <div class="popup-title">
                  <span style="color:#212121; font-size:24px; font-weight: 700;">{{action}}</span>
                  <span style="color:#212121; font-size:16px; font-weight: 700;"> {{title}}</span>
              </div>
              <div class="icon icon-close" @click="close()"></div>
          </div>
          <div class="popup-content ">
              <slot></slot>
          </div>
          <div class="popup-toolbar flex">
              <div class="btn-del">
                <ms-button :btnTitle="'Hủy'"/>
              </div>
              <div class="btn-save">
                <ms-button :btnTitle="btnTitle"/>
              </div>
          </div>
      </div>
  </div>
</template>

<script>
export default {
    props:{
        action:String,
        title:String,
        status: Number,
        btnTitle:String,
    },
    name:"MsPopup",
    methods:{
        close(){
            if(this.status == 1)
            this.$bus.$emit('close');
            if(this.status == 2)
            this.$bus.$emit('closeTeammate');
            if(this.status == 3)
            this.$bus.$emit('closeDel');
        }
    }

}
</script>

<style scoped>
@import url(../../styles/components/msPopup.css);
</style>