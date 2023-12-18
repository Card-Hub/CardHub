<script setup lang="ts">
// import { defineProps } from 'vue';
import { defineProps, onMounted } from 'vue';

const props = defineProps(["messages"]);

const logMessage = () => {
      console.log(props.messages.value);
    };

onMounted(() => {
  logMessage();
});

</script>

<template>
  <div ref="messageRef" class="message-container">
    <div v-for="(m, index) in props.messages" :key="index" class="user-message">
      <div class="message bg-primary">{{ m.message }}</div>
      <div class="from-user">{{ m.user }}</div>
    </div>
  </div>
</template>
