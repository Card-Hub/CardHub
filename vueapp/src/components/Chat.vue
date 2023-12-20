<script setup lang="ts">
import MessageContainer from "/src/components/MessageContainer.vue";

defineProps(["messages"]);
</script>

<template>
  <div>
    <MessageContainer :messages="messages"/>
  </div>
</template>

<style scoped>

</style>