
<!-- src/App.vue -->
<template>
  <div id="app">
    <EmploymentBarChart />
  </div>
</template>

<script>
import EmploymentBarChart from '../components/EmploymentBarChart.vue'

export default {
  name: 'App',
  components: {
    EmploymentBarChart
  }
}
</script>

<style lang="less" scoped>
#app {
  max-width: 1000px;
  margin: 50px auto;
  padding: 20px;
}
</style>
