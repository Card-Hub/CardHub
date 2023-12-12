<script setup lang="ts">
 import { ref } from 'vue';

  const roomCode = ref('');
  const playerName = ref('');
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
      
      <input type="text" id="roomCode" name="roomCode" v-model="roomCode" placeholder="Game Pin" />
      
      <input type="text" id="playerName" name="playerName" v-model="playerName" placeholder="Player Name" />
      
      <a href="/gameboard">
        <button class="btn join-btn">Join</button>
      </a>
      
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