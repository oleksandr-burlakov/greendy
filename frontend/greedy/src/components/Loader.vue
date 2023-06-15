<template>
  <v-icon :size="iconSize" class="loader" icon="mdi-loading"></v-icon>
</template>

<script>
export default {
  props: {
    size: 20
  },
  name: 'Loader.vue',
  data() {
    return {
      iconSize: this.size
    }
  }
}
</script>

<style scoped>
@-moz-keyframes spin {
  100% {
    -moz-transform: rotate(360deg);
  }
}

@-webkit-keyframes spin {
  100% {
    -webkit-transform: rotate(360deg);
  }
}

@keyframes spin {
  100% {
    -webkit-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}

.loader {
  -webkit-animation: spin 1s linear infinite;
  -moz-animation: spin 1s linear infinite;
  animation: spin 1s linear infinite;
  position: absolute;
  top: 40%;
  left: 45%;
}
</style>
