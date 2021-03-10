<template>
  <div class="ms-button flex center">
      <div class="btn-icon">
          <slot></slot>
      </div>
      <div class="tile">{{btnTitle}}</div>
  </div>
</template>

<script>
export default {
    name: "MsButton",
    props:{
        btnTitle:String
    }
}
</script>

<style scoped>
 @import url(../../styles/components/msButton.css);
</style>