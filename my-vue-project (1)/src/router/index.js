import { createRouter, createWebHashHistory } from 'vue-router'
import MainLayout from '../views/MainLayout.vue' // 确保 MainLayout 正确导入
import index from '../views/index.vue'
import text from '../views/text.vue'
import LoginPage from '../views/LoginPage.vue'
import ChangePage from '../views/ChangePage.vue'

const routes = [
  {
    path: '/MainLayout',
    name: 'MainLayout',
    component: MainLayout
},
{
    path: '/index',
    name: 'index',
    component: index
},
{
    path: '/text',
    name: 'text',
    component: text
},
{
    path: '/login', // 保持小写路径
    name: 'LoginPage',
    component: LoginPage
},
{
    path: '/change', // 保持小写路径
    name: 'ChangePage',
    component: ChangePage
}

]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
