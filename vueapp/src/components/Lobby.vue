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
      <input v-model="user" class="form-control1" placeholder="Nickname"/>
      <input v-model="room" class="form-control2" placeholder="Game Pin"/>
    </div>
    <button class="btn btn-success" type="submit" :disabled="!user || !room">Join</button>
  </form>
</template>

<style scoped>

@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;500&display=swap');

.lobby{
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  flex-direction: column;
  padding-bottom: 20px;
}

.btn-success{
  background-color: darkred;
  border: none;
  color: black;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  font-size: 20px;
  margin: 4px 2px;
  cursor: pointer;
  border-radius: 10px;
  width: 200px;
}

.btn-success:hover{
  background-color: red;
  color: black;
}

.btn-success:disabled{
  background-color: grey;
  color: black;
}

.btn-success:disabled:hover{
  background-color: grey;
  color: black;
}


.form-group{
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  flex-direction: column;
}

.form-control1{
  width: 200px;
  height: 50px;
  margin: 10px;
  border-radius: 10px;
  border: 2px solid black;
  font-size: 20px;
  text-align: center;
  font-family: 'Poppins', sans-serif;
}

.form-control2{
  width: 200px;
  height: 50px;
  margin: 10px;
  border-radius: 10px;
  border: 2px solid black;
  font-size: 20px;
  text-align: center;
}

</style>