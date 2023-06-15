<script setup>
import BaseLayout from './views/layouts/BaseLayout.vue'
import AuthorizedLayout from './views/layouts/AuthorizedLayout.vue'
import { useAuthorizationStore } from './stores/authorization'
const authorization = useAuthorizationStore()
</script>

<template>
  <AuthorizedLayout v-if="authorization.token" />
  <BaseLayout v-else />
</template>
