<script setup lang="ts">
import MessageContainer from "/src/components/MessageContainer.vue";
import { defineProps, defineEmits, ref } from 'vue';

let user = ref("");

const { messages } = defineProps(["messages"]);

const emit = defineEmits<{
  sendMessage: [user: string, message: string]
}>()

const message = ref('');
//check what gpt said, i dont think the the parent sendmessage is being invoked by the child emits button
const handleSubmit = () => {
  console.log('in handleSubmit, message:', message.value); // Check if this logs correctly
  emit('sendMessage', user.value, message.value);
  message.value = '';
};

const logMessage = () => {
  console.log(message.value);
};

</script>

<template>
  <form class="sendMessage" @submit.prevent="handleSubmit">
    <div>
      <MessageContainer :messages="messages" /> <!-- Ensure MessageContainer is properly receiving messages -->
      <input type="text" placeholder="Message..." v-model="message" />
      <button class="btn btn-success" type="submit" :disabled="!message">Send</button>
    </div>
  </form>
</template>

<style scoped>
.message-form {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 20px;
}

.message-form input {
  padding: 8px;
  margin-right: 10px;
  border-radius: 4px;
  border: 1px solid #ccc;
}

.message-form button {
  padding: 8px 16px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.message-form button:disabled {
  background-color: #ccc;
  cursor: not-allowed;
}
</style>