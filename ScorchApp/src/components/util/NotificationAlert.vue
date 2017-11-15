<template>
    <div class="alert notification" id='notification-container'>
      <strong id='notification-msg'></strong>
    </div>
</template>

<script>
export default {
    name: 'notification-alert',
}
</script>

<style lang="scss" scoped>
.notify-active{
    animation: fade 4s linear;
}
.invisible{
    visibility: hidden;
    z-index: -1;
}
.visible{
    visibility: visible;
    z-index: 9999;
}
.notification{
    position: absolute;
    width: 100%;
}
@keyframes fade {
    100% { opacity: 0 }
    0%,50% { opacity: 1 }
}    
</style>