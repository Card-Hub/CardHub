<script setup lang="ts">
import {ref} from "vue";

let user = ref("");
let room = ref("");

const emit = defineEmits<{
  joinLobby: [user: string, room: string]
}>()

const handleSubmit = async () => {
  emit("joinLobby", user.value, room.value);
}

// const joinRoom1 = async (user: string, room: string) => {
//   try {
//     const connection = new HubConnectionBuilder()
//         .withUrl("https://localhost:7255/chat")
//         .configureLogging(LogLevel.Information)
//         .build();
//
//     connection.on("ReceiveMessage", (user, message) => {
//       console.log(user + " says " + message);
//     });
//
//     await connection.start();
//     await connection.invoke("JoinRoom", {user, room})
//   } catch (e) {
//     console.error(e);
//   }
// }

</script>

<template>
  <form class="lobby" @submit.prevent="handleSubmit">
    <div class="form-group">
      <input v-model="user" class="form-control" placeholder="name"/>
      <input v-model="room" class="form-control" placeholder="room"/>
    </div>
    <button class="btn btn-success" type="submit" :disabled="!user || !room">Join</button>
  </form>
</template>

<style scoped>

</style>