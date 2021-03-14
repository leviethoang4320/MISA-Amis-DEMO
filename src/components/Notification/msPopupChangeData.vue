<template>
  <div class="ms-popup-change">
        <ms-popup :btnTitle="'Lưu'" :confirmPopup="true" :action="'Thông báo'" :status="4" >
            <p>Thông tin đã được thay đổi. Bạn có muốn lưu lại không?</p>
        </ms-popup>

    </div>
</template>

<script>
export default {
    name: "MsPopupChange"

}
</script>

<style >
.no-save .ms-button {
    background-color: white;
    color: #212121;
    margin-right: 20px;
    padding: 0;
    border: 1px solid #bebebe;
    width: 95px !important;
}
.ms-popup-change .popup-content{
    min-height: 0px !important;
    
    margin-bottom: 20px;
    padding: 0px 30px ;
    width: 360px;
}
.ms-popup-change .popup-header{
    padding: auto;
    padding-bottom: 10px;
    height: 50px;
}
.ms-popup-change .popup-toolbar{
   border: none !important;
   padding-top: 0px;
}
.ms-popup-change .popup-detail{
   top: 90px;
    left: calc(50% - 245px);
    z-index: 501;
}
.ms-popup-change .popup-bgr{
    width: 100%;
    background: rgba(0,0,0,0.4);
    position: absolute;
    top: 0px;
    left: 0px;
    height: 100%;
    z-index: 500;
    -webkit-transition: all .250s ease;
    transition: all .250s ease;
    opacity: 9999;
}
</style>