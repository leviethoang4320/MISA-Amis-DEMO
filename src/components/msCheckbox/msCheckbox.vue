<template>
<div class="ms-checkbox">
    <DxCheckBox v-model="visible_" :onValueChanged="onValueChanged"/>
</div>
  
</template>

<script>
import { DxCheckBox } from 'devextreme-vue/check-box';

export default {
    name:"MsCheckbox",
    props:{
        visible: Boolean
    },
  components: {
    DxCheckBox
  },
  data() {
    return {
      visible_:false
    };
  },
  mounted() {
    this.visible_ = this.visible;
  },
  methods: {
    onValueChanged(e){
      this.$emit('update:check',e.value);
    }
  },
  watch:{
    visible(val){
      this.visible_ = val;
    }
  }
};
</script>
<style>

</style>