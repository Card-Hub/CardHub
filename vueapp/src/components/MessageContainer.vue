<script setup lang="ts">

defineProps(["messages"]);

</script>

<template>
  <div ref="messageRef" class="message-container">
    <div v-for="(m, index) in messages" :key="index" class="user-message">
      <div class="message bg-primary">{{ m.message }}</div>
      <div class="from-user">{{ m.user }}</div>
    </div>
  </div>
</template>
