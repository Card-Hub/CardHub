<script setup lang="ts">
import Lobby from "@/components/Lobby.vue";
import {HubConnection, HubConnectionBuilder, LogLevel} from "@microsoft/signalr";
import {ref} from "vue";
import Chat from "@/components/Chat.vue";

interface UserMessage {
  user: string;
  message: string;
}

const connection = ref<HubConnection | null>(null);
const messages = ref<UserMessage[]>([])
const users = ref<string[]>([])

const joinRoom = async (user: string, room: string) => {
  try {
    const joinConnection = new HubConnectionBuilder()
        .withUrl("https://localhost:7255/chat")
        .configureLogging(LogLevel.Information)
        .build();

    joinConnection.on("ReceiveMessage", (user: string, message: string) => {
      messages.value.push({user, message});
    });

    joinConnection.on("UsersInRoom", (users) => {
      users.value = users;
    });

    joinConnection.onclose(() => {
      connection.value = null;
      messages.value = [];
      users.value = [];
    });

    await joinConnection.start();
    await joinConnection.invoke("JoinRoom", {user, room});
    connection.value = joinConnection;
  } catch (e) {
    console.log("HubConnection ERR --- " + e);
  }
};

const sendMessage = async (message: string) => {
  try {
    if (connection.value !== null)
      await connection.value.invoke("SendMessage", message);
  } catch (e) {
    console.log(e);
  }
};

const closeConnection = async () => {
  try {
    if (connection.value !== null)
      await connection.value.stop();
  } catch (e) {
    console.log(e);
  }
};

</script>

<template>
  <div class="app">
    <h2>MyChat</h2>
    <hr class="line"/>
    <template v-if="connection == null">
      <Lobby @join-lobby="joinRoom"/>
    </template>
    <template v-else>
      <Chat :sendMessage="sendMessage" :messages="messages" :users="users" :closeConnection="closeConnection"/>
    </template>
  </div>
</template>
