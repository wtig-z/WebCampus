<template>
  <MainLayout>
    <template v-slot:content>
      <!-- 这里是子页面特有的内容 -->
       <h1>HWLLO</h1>
    </template>
  </MainLayout>
</template>

<script>
import MainLayout from './MainLayout.vue';

export default{
  components:{
    MainLayout
  }
}

</script>

<style lang="less" scoped>

</style>
