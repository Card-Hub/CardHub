<script setup lang="ts">
  import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
  // import { ref } from 'vue';
  // import join from './pages/join.vue';o
  
  //
  // const routes = {
  //   '/pages/join': join,
  // };
  
  // const currentPath = ref(window.location.hash);
  //
  // window.addEventListener('hashchange', () => {
  //   currentPath.value = window.location.hash;
  // });
  
  // const currentView = computed(() => { return routes[currentPath.value.slice(1) || '/'] });
//
</script>

<template>
  <div class="div">
    <img alt="spade" class="spade" src="../assets/spade.svg" width="200" height="200" />
    <img alt="heart" class="heart" src="../assets/heart.svg" width="200" height="200" />
    <img alt="diamond" class="diamond" src="../assets/diamond.svg" width="200" height="200" />
    <img alt="club" class="club" src="../assets/club.svg" width="200" height="200" />
    
    <header class="header">
      
      <img alt="cardhub-logo" class="logo" src="../assets/logo.svg" width="200" height="200" />
      <h1 class="welcome">Welcome to CardHub!</h1>
      </header>
    
    <body class="body">
      <button class="btn host-btn">Host a Game</button>
<!--      <div>-->
      <a href="/join">
        <button class="btn join-btn">Join</button>
      </a>
<!--      <component :is="currentView"/>-->
<!--      </div>-->

    </body>
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
  .host-btn {
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

  .host-btn:hover {
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
