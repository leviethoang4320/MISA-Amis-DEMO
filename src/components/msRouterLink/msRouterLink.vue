<template>
  <div class="ms-router-link">
    {{routerLinkItem.name}}
  </div>
</template>

<script>
export default {
    name:"MsRouterLink",
    props:{
        routerLinkItem: Object
    }
}
</script>

<style>
@import url(../../styles/components/msRouterLink.css);
@import url(../../styles/commons/_base.css);
</style>