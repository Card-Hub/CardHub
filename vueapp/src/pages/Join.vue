<!--All UI components created by Rubi Dionisio-->

<script setup lang="ts">
import { ref } from 'vue';


// Signalr components created by Alex Mozqueda
const roomCode = ref('');
const playerName = ref('');

import Lobby from "@/components/Lobby.vue";
import {HubConnection, HubConnectionBuilder, LogLevel} from "@microsoft/signalr";
// import {ref} from "vue";
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
    console.log('in joinroom join.vue');
    const joinConnection = new HubConnectionBuilder()
        .withUrl("https://localhost:7255/chat")
        .configureLogging(LogLevel.Information)
        .build();

    joinConnection.on("ReceiveMessage", (user: string, message: string) => {
      console.log('im right here', message);
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
// messages.value.push({user, message});
const sendMessage = async (user: string, message: string) => {
  try {
    console.log('in sendmessage join.vue', message);
    if (connection.value !== null) {
      
      await connection.value.invoke("sendMessage", user, message);
    }
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
// End Alex Mozqueda's Signalr components
</script>

<template>
  <div>
    <div class="div">
      <img alt="spade" class="spade" src="../assets/spade.svg" width="200" height="200" />
      <img alt="heart" class="heart" src="../assets/heart.svg" width="200" height="200" />
      <img alt="diamond" class="diamond" src="../assets/diamond.svg" width="200" height="200" />
      <img alt="club" class="club" src="../assets/club.svg" width="200" height="200" />

      <header class="header">

        <img alt="cardhub-logo" class="logo" src="../assets/logo.svg" width="200" height="200" />
      </header>

      <body class="body">

        <div class="app">
          
          <h2></h2>
<!--          Alex Created the connextion, Rubi made the UI and set the layout-->
          <hr class="line"/>
          <template v-if="connection == null">
            <Lobby @join-lobby="joinRoom"/>
          </template>
          <template v-else>
            <Chat @send-message="sendMessage" :messages="messages" :users="users" :closeConnection="closeConnection"/>
          </template>
        </div>

  <!--      <input type="text" id="roomCode" name="roomCode" v-model="roomCode" placeholder="Game Pin" />-->
  
  <!--      <input type="text" id="playerName" name="playerName" v-model="playerName" placeholder="Player Name" />-->
  
<!--        <a href="/gameboard">-->
<!--          <button class="btn join-btn">Join</button>-->
<!--        </a>-->
  
        <a href="/">
          <button class="btn back-btn">Back</button>
        </a>
      </body>
    </div>
  </div>
</template>

<style scoped>
.welcome {
  color: white;
  justify-content: center;
  align-items: center;
  text-align: center;
  display: flex;
}
.back-btn {
  background-color: grey;
  border: none;
  color: black;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  font-size: 20px;
  margin: 4px 2px;
  cursor: pointer;
}

.join-btn {
  background-color: darkred;
  border: none;
  color: black;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  font-size: 20px;
  margin: 4px 2px;
  cursor: pointer;
}

.back-btn:hover {
  background-color: grey;
  color: black;
}

.join-btn:hover {
  background-color: grey;
  color: black;
}

.div {
  justify-content: center;
  align-items: center;
  display: flex;
  flex-direction: column;
  background-color: #282828;
  height: 97vh;
  width: 90vw;
}

.spade {
  rotate: 225deg;
  display: flex;
  position: absolute;
  top: 0;
  right: 0;
}

.heart {
  position: absolute;
  bottom: 0;
  right: 0;
}

.diamond {
  rotate: 315deg;
  position: absolute;
  top: 0;
  left: 0;
}

.club {
  rotate: 315deg;
  position: absolute;
  bottom: 0;
  left: 0;
}

.header {
  display: flex;
  flex-direction: column;
  padding-bottom: 40px;
  align-items: center;
  justify-content: center;
  font-size: calc(10px + 2vmin);
  color: white;
}

.body {
  background-color: #282828;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  font-size: calc(10px + 2vmin);
  color: white;
}

.logo {
  pointer-events: none;
  align-items: center;
}

.btn {
  background-color: darkred;
  border: none;
  color: black;
  width: 200px;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  font-size: 20px;
  margin: 4px 2px;
  cursor: pointer;
  border-radius: 10px;
}

</style>