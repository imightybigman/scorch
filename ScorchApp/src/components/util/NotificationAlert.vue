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
    visibility: visible;
}
.visible{
    visibility: hidden;
}
.notification{
    position: absolute;
    width: 100%;
    z-index: 9999;
}
@keyframes fade {
    100% { opacity: 0 }
    0%,50% { opacity: 1 }
}    
</style>