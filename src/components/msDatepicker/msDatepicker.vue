<template>
  <div class="ms-datepicker">
    <section>
      <date-picker
        v-model="dateFormat"
        type="datetime"
        valueType = "format"
        format = "DD/MM/YYYY HH:mm"
        :show-time-panel="showTimePanel"
        @close="handleOpenChange"
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
     this.dateFormat ? this.defaultDate = this.formatDate(this.defaultDate) : null ;
  },
  watch: {
    defaultDate(val) {
     this.dateFormat = this.formatDate(val) ;
     console.log('a');
    },
    dateFormat(val) {
      this.$emit("update:defaultDate",  this.formatDate2(val))
      console.log('e');
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
    formatDate(date) {
      var now = new Date(date);
      var day = ("0" + now.getDate()).slice(-2);
      var month = ("0" + (now.getMonth()+1)).slice(-2);
      var hour = ("0" + (now.getHours())).slice(-2);
      var minute = ("0" + (now.getMinutes())).slice(-2);
      var today =  (day) + "/" + (month) + "/" +  + now.getFullYear() 
      + " " + (hour)+":"+(minute);
      return today;
    },
    formatDate2(date){
      if(date == null) return null;
        let day = date.substr(0,2);
        let month = date.substr(3,2);
        let year = date.substr(6,4);
        let minute = date.substr(11,2);
        let seconds = date.substr(14,2);
        let a = (new Date(year,month-1,day,minute,seconds)).toString();
       
        return a;
      } 
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
    /* border-radius: 4px; */
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