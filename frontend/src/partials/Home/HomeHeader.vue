<template>
  <div class="home-header">
    <h1>{{title}}</h1>
  </div>
</template>

<script>
export default {
  props: ['title'],
  name: 'HomeHeader'
}
</script>