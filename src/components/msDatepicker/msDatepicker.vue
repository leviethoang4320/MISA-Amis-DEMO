<template>
  <div class="ms-datepicker">
    <section>
      <date-picker
        v-model="dateFormat"
        type="datetime"
        :default="null"
        valueType = "YYYY-MM-DDTHH:mm:ss"
        format = "DD/MM/YYYY HH:mm"
        :show-time-panel="showTimePanel"
        @close="handleOpenChange"
        :clearable="false"
        placeholder="DD/MM/YYYY HH:mm"
      >
        <template v-slot:footer>
          <button class="mx-btn mx-btn-text" @click="toggleTimePanel">
            {{ showTimePanel ? 'Chọn ngày' : 'Chọn giờ' }}
          </button>
        </template>
      </date-picker>
    </section>
  </div>
</template>

<script>
 import DatePicker from 'vue2-datepicker';
  import 'vue2-datepicker/index.css';
  import 'vue2-datepicker/locale/vi';

export default {
    name:"MsDatepicker",
    components: { DatePicker },
    props:{
      defaultDate:String
    },
  data() {
    return {
      //value1: new Date(),
      value2: [],
      showTimePanel: false,
      showTimeRangePanel: false,
      dateFormat: null,
      
    };
  },
  mounted() {
    
     this.dateFormat = this.defaultDate ;
  },
  watch: {
    defaultDate(val) {
      
     this.dateFormat = val ;
    
    },
    dateFormat(val) {
      this.$emit("update:defaultDate",  val)
      
    }
  },
  methods: {
    toggleTimePanel() {
      this.showTimePanel = !this.showTimePanel;
    },
    toggleTimeRangePanel() {
      this.showTimeRangePanel = !this.showTimeRangePanel;
    },
    handleOpenChange() {
      this.showTimePanel = false;
    },
    handleRangeClose() {
      this.showTimeRangePanel = false;
    },
    
  },
};
</script>
<style >
    .mx-datepicker{
        width: 100%;
    }
    .mx-input {
    display: inline-block;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    width: 100%;
    height: 34px;
    padding: 6px 30px;
    padding-left: 10px;
    font-size: 14px;
    line-height: 1.4;
    color: #555;
    background-color: #fff;
    border: none;
    
    -webkit-box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
    box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
}
.mx-input:focus-within{
    outline: 1px solid #ec5504;
}
.mx-calendar-content .cell.active {
    background-color: var(--date-picker-active-bg);
}

.mx-calendar-content .cell:hover {
    background-color: var(--date-picker-hover-bg);
}
</style>