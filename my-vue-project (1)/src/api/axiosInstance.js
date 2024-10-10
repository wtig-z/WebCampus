// src/api/axiosInstance.js
import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:5185/api', // 后端 API 的基础 URL
  timeout: 10000, // 请求超时时间
});

// 请求拦截器，可以在这里添加认证 Token 等
axiosInstance.interceptors.request.use(
  config => {
    // 如果有需要添加的请求头，可以在这里添加
    // const token = localStorage.getItem('token');
    // if (token) {
    //   config.headers.Authorization = `Bearer ${token}`;
    // }
    return config;
  },
  error => Promise.reject(error)
);

// 响应拦截器，处理全局错误
axiosInstance.interceptors.response.use(
  response => response,
  error => {
    // 处理错误，例如未授权、服务器错误等
    return Promise.reject(error);
  }
);

export default axiosInstance;
