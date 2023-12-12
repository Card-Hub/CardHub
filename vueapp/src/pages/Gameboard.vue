<script setup lang="ts">
  
</script>

<template>
  <div class="div">
    <img alt="spade" class="spade" src="../assets/spade.svg" width="200" height="200" />
    <img alt="heart" class="heart" src="../assets/heart.svg" width="200" height="200" />
    <img alt="diamond" class="diamond" src="../assets/diamond.svg" width="200" height="200" />
    <img alt="club" class="club" src="../assets/club.svg" width="200" height="200" />
    <img alt="cardhub-logo" class="logo" src="../assets/logo.svg" width="150" height="150" />
    
    <header class="header">
      <h1 class="welcome">Playing!</h1>
      
      <h2 class="players">Players: </h2>
    </header>

    <body class="body">
    
    </body>
  </div>
</template>

<style scoped>

.header {
  background: linear-gradient(to bottom, darkred, black);
  display: flex;
  flex-direction: column;
  padding-bottom: 40px;
  align-items: center;
  justify-content: center;
  font-size: calc(10px + 2vmin);
  color: white;
  padding: 30px;
  border-radius: 10px;
}

.players {
  background: white;
  color: black;
  justify-content: left;
  align-items: center;
  text-align: left;
  display: flex;
  padding: 20px;
  border-radius: 10px;
}

.welcome {
  color: white;
  justify-content: center;
  align-items: center;
  text-align: center;
  display: flex;
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
  position: absolute;
  top: 15px;
  middle: 0;
  pointer-events: none;
  align-items: center;
}

</style>
