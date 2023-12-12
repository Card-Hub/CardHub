<script setup lang="ts">
import HelloWorld from './components/HelloWorld.vue'
</script>

<template>
  <div class="div">
    <header class="header">
      <img alt="cardhub-logo" class="logo" src="./assets/logo.svg" width="200" height="200" />
      <h1>Welcome to CardHub!</h1>

      </header>
    
    <body class="body">
      <button class="btn host-btn">Host a Game</button>
      <button class="btn join-btn">Join</button>

<!--    <HelloWorld msg="You did it!" />-->
<!--    </header>-->
    </body>
  </div>
</template>

<style scoped>
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
    height: 90vh;
    width: 90vw;
  }
  
.header {
    background-color: #282828;
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
  }


</style>
