<template>
  <div class="ms-content">
    <div class="content-container">
      
      <router-view />

    </div>
  </div>
</template>

<script>
export default {
  name:"MsContent",
  data() {
    return {
     
    }
  },
}
</script>

<style scoped>
@import url(../../styles/components/msContent.css);
@import url(../../styles/commons/_base.css);
</style>