import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import{ createRouter, createWebHistory } from 'vue-router';
import Register from './components/Register.vue';
import DetailUser from './components/DetailUser.vue';
import Login from './components/Login.vue';
// main.js
import axios from 'axios';

axios.interceptors.request.use(config => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});
const app = createApp(App)
const router = createRouter({
  history: createWebHistory(),
  routes: [
    
    { path: '/', redirect: '/register' },
    {path : '/register', component: Register},
    {path: '/login', component: Login},
    {path : '/detail',component: DetailUser}
  ]
})
app.use(router)
app.mount('#app')
