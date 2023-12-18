<!--Created by Rubi Dionisio, purpose is to allow the routing to happen, separate component so that program doesn't break-->

<script setup lang="ts">
import {onMounted} from "vue";

const name = 'App';

const logMessage = () => {
  console.log('in routing page file');
};

onMounted(() => {
  logMessage();
});

</script>


<template>
  <div class="div">

<!--    <body class="body">-->
    <router-view></router-view>

<!--    </body>-->
  </div>
</template>

<style scoped>

.div{
  background-color: #282828;
  height: 100vh;
  width: 100vw;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

</style>