<template>
  <div class="ms-popup-delete">
        <ms-popup @delete="del()" :btnTitle="'Xóa'" :action="'Cảnh báo'" :status="3" >
            <p>Bạn có chắc muốn xóa Đơn này không?</p>
        </ms-popup>

    </div>
</template>

<script>
import ApplicationAPI from '@/api/components/Application/ApplicationAPI.js'
export default {
    name: "MsPopupDelete",
    props:{
        deleteInfo: Object
    },
    mounted() {
        
        
    },
    methods: {
        del(){
            ApplicationAPI.delete(this.deleteInfo.ApplicationId);
             this.$bus.$emit('closeDel');
              setTimeout(() => {
                this.$bus.$emit('reload');               
                
                }, 500);
        }
    },
}
</script>

<style >

.ms-popup-delete .popup-content{
    min-height: 0px !important;
    
    margin-bottom: 20px;
    padding: 0px 40px ;
    width: 350px;
}
.ms-popup-delete .popup-header{
    padding: auto;
    padding-bottom: 10px;
    height: 50px;
}
.ms-popup-delete .popup-toolbar{
   border: none !important;
   padding-top: 0px;
}
.ms-popup-delete .popup-detail{
   top: 90px;
    left: calc(50% - 245px);
}
.ms-popup-delete .btn-save .ms-button{
    background-color: #ef292f;
    width: 80px;
    padding: 0;
    border: 1px solid #ef292f;
    
}
.ms-popup-delete .btn-save .ms-button:hover{
    background-color: #ed1219;
    width: 80px;
    padding: 0;
    border: 1px solid #ef292f;
    
}
</style>