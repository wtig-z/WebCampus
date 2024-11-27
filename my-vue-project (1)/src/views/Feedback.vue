<template>
  <div class="body">
    <div class="video-bg">
      <video width="320" height="240" autoplay loop muted>
        <source src="../assets/img/7btrrd.mp4" type="video/mp4" />
      </video>
    </div>
    <div
      :class="isBlack ? 'black-text' : 'white-text'"
      class="dark-light"
      @click="toggleTheme"
    >
      <svg
        viewBox="0 0 24 24"
        stroke="currentColor"
        stroke-width="3"
        fill="red"
        stroke-linecap="round"
        stroke-linejoin="round"
      >
        <path d="M21 12.79A9 9 0 1111.21 3 7 7 0 0021 12.79z" />
      </svg>
    </div>
    <div class="app" style="height: 830px; width: 1050px">
      <div class="header">
        <div class="logo">
          <!-- 可以留空，或者根据需要加入 -->
        </div>
        <div class="nav">
          <router-link class="menu-link" to="/index">平台主页</router-link>

          <router-link class="menu-link" to="/graduate-data"
            >毕业生数据</router-link
          >

          <router-link class="menu-link" to="/job-trend"
            >就业趋势分析</router-link
          >

          <router-link class="menu-link notify is-active" to="/feed-back"
            >企业反馈</router-link
          >
        </div>
        <div class="search-box">
          <input type="text" placeholder="搜索毕业生数据" />
        </div>
        <div class="header-right">
          <div class="notification">
            <span class="notification-number">3</span>
            <svg
              viewBox="0 0 24 24"
              fill="currentColor"
              stroke="currentColor"
              stroke-width="2"
              stroke-linecap="round"
              stroke-linejoin="round"
              class="feather feather-bell"
            >
              <path
                d="M18 8A6 6 0 006 8c0 7-3 9-3 9h18s-3-2-3-9M13.73 21a2 2 0 01-3.46 0"
              />
            </svg>
          </div>
          <svg viewBox="0 0 512 512" fill="currentColor">
            <path
              d="M448.773 235.551A135.893 135.893 0 00451 211c0-74.443-60.557-135-135-135-47.52 0-91.567 25.313-115.766 65.537-32.666-10.59-66.182-6.049-93.794 12.979-27.612 19.013-44.092 49.116-45.425 82.031C24.716 253.788 0 290.497 0 331c0 7.031 1.703 13.887 3.006 20.537l.015.015C12.719 400.492 56.034 436 106 436h300c57.891 0 106-47.109 106-105 0-40.942-25.053-77.798-63.227-95.449z"
            />
          </svg>
          <img
            class="profile-img"
            src="https://images.unsplash.com/photo-1600353068440-6361ef3a86e8?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1000&q=80"
            alt=""
          />
        </div>
      </div>
      <div class="container">
        <div class="left-side">
          <div class="side-wrapper">
            <div class="side-title">数据模块</div>
            <div class="side-menu">
              <a>
                <svg viewBox="0 0 512 512" fill="currentColor">
                  <path
                    d="M497 151H316c-8.401 0-15 6.599-15 15v300c0 8.401 6.599 15 15 15h181c8.401 0 15-6.599 15-15V166c0-8.401-6.599-15-15-15zm-76 270h-30c-8.401 0-15-6.599-15-15s6.599-15 15-15h30c8.401 0 15 6.599 15 15s-6.599 15-15 15zm0-180h-30c-8.401 0-15-6.599-15-15s6.599-15 15-15h30c8.401 0 15 6.599 15 15s-6.599 15-15 15z"
                  />
                  <path
                    d="M15 331h196v60h-75c-8.291 0-15 6.709-15 15s6.709 15 15 15h135v-30h-30v-60h30V166c0-24.814 20.186-45 45-45h135V46c0-8.284-6.716-15-15-15H15C6.716 31 0 37.716 0 46v270c0 8.284 6.716 15 15 15z"
                  />
                </svg>
                <div class="custom-form">
                  <select
                    id="month-select"
                    v-model="form.month"
                    class="select-input"
                  >
                    <option value="" disabled>年份切换</option>
                    <option
                      v-for="month in months"
                      :key="month.value"
                      :value="month.value"
                    >
                      {{ month.label }}
                    </option>
                  </select>
                </div>
              </a>
              <a href="#">
                <svg viewBox="0 0 488.932 488.932" fill="currentColor">
                  <path
                    d="M243.158 61.361v-57.6c0-3.2 4-4.9 6.7-2.9l118.4 87c2 1.5 2 4.4 0 5.9l-118.4 87c-2.7 2-6.7.2-6.7-2.9v-57.5c-87.8 1.4-158.1 76-152.1 165.4 5.1 76.8 67.7 139.1 144.5 144 81.4 5.2 150.6-53 163-129.9 2.3-14.3 14.7-24.7 29.2-24.7 17.9 0 31.8 15.9 29 33.5-17.4 109.7-118.5 192-235.7 178.9-98-11-176.7-89.4-187.8-187.4-14.7-128.2 84.9-237.4 209.9-238.8z"
                  />
                </svg>
                技术匹配分析
              </a>
            </div>
          </div>
          <div class="side-wrapper">
            <div class="side-title">分类</div>
            <div class="side-menu">
              <a href="#">
                <svg viewBox="0 0 512 512" fill="currentColor">
                  <path
                    d="M497 151H316c-8.401 0-15 6.599-15 15v300c0 8.401 6.599 15 15 15h181c8.401 0 15-6.599 15-15V166c0-8.401-6.599-15-15-15zm-76 270h-30c-8.401 0-15-6.599-15-15s6.599-15 15-15h30c8.401 0 15 6.599 15 15s-6.599 15-15 15zm0-180h-30c-8.401 0-15-6.599-15-15s6.599-15 15-15h30c8.401 0 15 6.599 15 15s-6.599 15-15 15z"
                  />
                  <path
                    d="M15 331h196v60h-75c-8.291 0-15 6.709-15 15s6.709 15 15 15h135v-30h-30v-60h30V166c0-24.814 20.186-45 45-45h135V46c0-8.284-6.716-15-15-15H15C6.716 31 0 37.716 0 46v270c0 8.284 6.716 15 15 15z"
                  />
                </svg>
                信息管理与信息系统
              </a>
              <a href="#">
                <svg viewBox="0 0 511.441 511.441" fill="currentColor">
                  <path
                    d="M255.721 347.484L90.22 266.751v106.57l165.51 73.503 165.509-73.503V266.742z"
                  />
                  <path
                    d="M511.441 189.361L255.721 64.617 0 189.361l255.721 124.744 195.522-95.378v111.032h30V204.092z"
                  />
                </svg>
                网络工程
              </a>
            </div>
          </div>
          <div class="side-wrapper">
            <div class="side-title">专业</div>
            <div class="side-menu">
              <a href="#">
                <svg viewBox="0 0 512 512" fill="currentColor">
                  <path
                    d="M467 0H45C20.186 0 0 20.186 0 45v422c0 24.814 20.186 45 45 45h422c24.814 0 45-20.186 45-45V45c0-24.814-20.186-45-45-45zM181 241c41.353 0 75 33.647 75 75s-33.647 75-75 75-75-33.647-75-75c0-8.291 6.709-15 15-15s15 6.709 15 15c0 24.814 20.186 45 45 45s45-20.186 45-45-20.186-45-45-45c-41.353 0-75-33.647-75-75s33.647-75 75-75 75 33.647 75 75c0 8.291-6.709 15-15 15s-15-6.709-15-15c0-24.814-20.186-45-45-45s-45 20.186-45 45 20.186 45 45 45zm180 120h30c8.291 0 15 6.709 15 15s-6.709 15-15 15h-30c-24.814 0-45-20.186-45-45V211h-15c-8.291 0-15-6.709-15-15s6.709-15 15-15h15v-45c0-8.291 6.709-15 15-15s15 6.709 15 15v45h45c8.291 0 15 6.709 15 15s-6.709 15-15 15h-45v135c0 8.276 6.724 15 15 15z"
                  />
                </svg>
                信息管理与信息系统
              </a>
              <a href="#">
                <svg viewBox="0 0 511.441 511.441" fill="currentColor">
                  <path
                    d="M255.721 347.484L90.22 266.751v106.57l165.51 73.503 165.509-73.503V266.742z"
                  />
                  <path
                    d="M511.441 189.361L255.721 64.617 0 189.361l255.721 124.744 195.522-95.378v111.032h30V204.092z"
                  />
                </svg>
                网络工程
              </a>
            </div>
          </div>
        </div>
        <div class="main-container">
          <div class="main-header">
            <a class="menu-link-main" href="#">所有数据</a>
            <div class="header-menu">
              <a class="main-header-link is-active" href="#">统计分析</a>
              <a class="main-header-link" href="#">图表展示</a>
              <a class="main-header-link" href="#">用户反馈</a>
            </div>
          </div>
          <div class="fchart">
            <slot name="content">
              <div class="fchart1">
                <Doughnut :data="chartData" :options="chartOptions" />
                <div class="overall-rating">
                  <span>整体满意度评分：</span>
                  <el-rate
                    v-model="rating"
                    show-text
                    show-score
                    :text-color="ratingColor"
                  />
                  <!-- 评分标准按钮 -->
                  <el-button type="text" @click="centerDialogVisible = true"
                    >查看评分标准</el-button
                  >
                  <!-- 企业反馈按钮 -->
                  <el-button
                    type="text"
                    @click="feedbackDialogVisible = true"
                    style="margin-left: 10px"
                    >企业反馈</el-button
                  >

                  <!-- 评分标准对话框 -->
                  <div v-if="centerDialogVisible" class="custom-dialog">
                    <div class="dialog-overlay" @click="closeDialog"></div>
                    <div class="dialog-content">
                      <div class="dialog-header">
                        <span class="dialog-title"><a>评分标准</a></span>
                        <span class="close-btn" @click="closeDialog"
                          >&times;</span
                        >
                      </div>
                      <div class="dialog-body">
                        <ul>
                          <li>
                            <strong><a>5 星：</a></strong
                            ><a>非常满意，表现优秀，完全符合预期。</a>
                          </li>
                          <li>
                            <strong><a>4 星：</a></strong
                            ><a>满意，表现良好，大部分符合预期。</a>
                          </li>
                          <li>
                            <strong><a>2 星：</a></strong
                            ><a>不满意，有明显不足，需要改进。</a>
                          </li>
                          <li>
                            <strong><a>1 星：</a></strong
                            ><a>非常不满意，表现不达标，严重需要改进。</a>
                          </li>
                        </ul>
                      </div>
                      <div class="dialog-footer">
                        <button @click="closeDialog">关闭</button>
                      </div>
                    </div>
                  </div>

                  <!-- 企业反馈对话框 -->
<div v-if="feedbackDialogVisible" class="custom-dialog">
  <div class="dialog-overlay" @click="closeFeedbackDialog"></div>
  <div class="dialog-content">
    <div class="dialog-header">
      <span class="dialog-title"><a>企业反馈</a></span>
      <span class="close-btn" @click="closeFeedbackDialog">&times;</span>
    </div>
    <div class="dialog-body">
      <a ref="feedbackContent"></a>
  
    </div>
    <div class="dialog-footer">
      <button @click="closeFeedbackDialog">关闭</button>
    </div>
  </div>
</div>

                </div>
              </div>
            </slot>
          </div>
        </div>
      </div>
    </div>

    <!-- 评分标准弹窗
    <el-dialog
      title="评分标准"
      v-model:visible="dialogVisible"
      width="50%"
      :before-close="handleClose"
    >
      <ul>
        <li><strong>5 星：</strong>非常满意，表现优秀，完全符合预期。</li>
        <li><strong>4 星：</strong>满意，表现良好，大部分符合预期。</li>
        <li><strong>2 星：</strong>不满意，有明显不足，需要改进。</li>
        <li><strong>1 星：</strong>非常不满意，表现不达标，严重需要改进。</li>
      </ul>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">关闭</el-button>
      </span>
    </el-dialog> -->
  </div>
</template>

<script>
import "element-plus/dist/index.css";
import { Doughnut } from "vue-chartjs";
import { Chart, ArcElement, Tooltip, Legend } from "chart.js";
import {
  ElForm,
  ElFormItem,
  Rate,
  Button,
  Dialog,
  Message,
} from "element-plus";

Chart.register(ArcElement, Tooltip, Legend);

export default {
  name: "FeedBackChart",
  components: {
    Doughnut,
    ElForm,
    ElFormItem,
    Rate,
    ElButton: Button,
    ElDialog: Dialog,
  },
  data() {
    return {
      centerDialogVisible: false,
      feedbackDialogVisible: false,  // 控制企业反馈对话框的显示
      feedbackText:  `目前企业对本学校的满意程度较高，
        通过AI分析，是因为学校在教学质量、设备设施、教师素质等方面
        做了大量的努力，且持续改进，企业反馈普遍积极。`, 
      rating: 3, // 用于存储评分值（如果有需要）
      feedback: "",
      dialogVisible: false, // 控制弹窗显示
      form: {
        month: "",
        region: "2024", // 存储选中的区域值
      },
      months: [
        { label: "2023年", value: "2024" },
        { label: "2022年", value: "2024" },
        { label: "2021年", value: "2024" },
        { label: "2020年", value: "2024" },
        { label: "2019年", value: "2024" },
      ],
      isLightMode: false,
      isBlack: true,
      chartData: {
        labels: ["很满意", "满意", "不满意", "很不满意"],
        datasets: [
          {
            label: "毕业生满意度",
            backgroundColor: ["#1f7a8c", "#76c893", "#ffb703", "#ff595e"],
            data: [37, 59, 2, 2],
            borderWidth: 1,
          },
        ],
      },
      chartOptions: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          title: {
            display: true,
            text: "用人单位对毕业生的总体满意度",
          },
          tooltip: {
            callbacks: {
              label: function (context) {
                let label = context.label || "";
                if (label) {
                  label += ": ";
                }
                label += context.raw + "%";
                return label;
              },
            },
          },
        },
      },
    };
  },
  computed: {
    // 计算整体评分
    overallRating() {
      const data = this.chartData.datasets[0].data;
      const labels = this.chartData.labels;
      // 定义每个标签对应的星级
      const ratingMap = {
        很满意: 5,
        满意: 4,
        不满意: 2,
        很不满意: 1,
      };
      let total = 0;
      let count = 0;
      labels.forEach((label, index) => {
        const value = data[index];
        const stars = ratingMap[label];
        total += value * stars;
        count += value;
      });
      const average = total / count;
      const roundedAverage = Math.round(average * 10) / 10;
      console.log(`计算的整体评分: ${roundedAverage}`); // 添加日志
      this.rating = roundedAverage;
      return roundedAverage;
    },
    // 根据评分动态设置颜色
    ratingColor() {
      if (this.overallRating >= 4.5) return "#ff9900";
      if (this.overallRating >= 3.5) return "#f7ba2a";
      if (this.overallRating >= 2.5) return "#99A9BF";
      return "#ff595e";
    },
  },

  methods: {
    closeFeedbackDialog() {
      this.feedbackDialogVisible = false;
    },
    closeDialog() {
      this.centerDialogVisible = false;
    },
    // 使用 Vue 的 ref 获取元素并逐字显示文本
    typeText(text, speed = 100) {
      let i = 0;
      const element = this.$refs.feedbackContent;
      if (!element) return;  // 如果元素不存在，直接返回
      element.innerHTML = "";  // 清空文本内容
      function type() {
        if (i < text.length) {
          element.innerHTML += text.charAt(i);
          i++;
          setTimeout(type, speed); // 延时模拟逐字输入效果
        }
      }
      type(); // 开始逐字显示
    },
  },
  watch: {
    feedbackDialogVisible(newVal) {
      if (newVal) {
        this.$nextTick(() => {
          this.typeText(this.feedbackText, 100);  // 确保 DOM 渲染完成后再开始逐字显示
        });
      }
    },
  },
};
</script>

<style lang="less">

.custom-dialog {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.dialog-overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
}

.dialog-content {
  background: #fff;
  border-radius: 8px;
  width: 400px;
  max-width: 90%;
  padding: 20px;
  z-index: 1001;
}

.dialog-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.dialog-title {
  font-size: 20px;
  font-weight: bold;
}

.close-btn {
  font-size: 24px;
  cursor: pointer;
  color: #999;
}

.close-btn:hover {
  color: #000;
}

.dialog-body {
  color: #000;

  margin-top: 20px;
}

.dialog-footer {
  margin-top: 20px;
  display: flex;
  justify-content: flex-end;
}

.dialog-footer button {
  background-color: #007bff;
  color: white;
  border: none;
  padding: 8px 16px;
  border-radius: 4px;
  cursor: pointer;
}

.dialog-footer button:hover {
  background-color: #0056b3;
}

@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap");

.select-input {
  padding: 8px 12px;
  border: 1px solid transparent;
  border-radius: 1px;
  background-color: transparent;
  // color: var(--theme-color);
  font-size: 14px;
  font-weight: 500;
  appearance: none;
  background-image: url("data:image/svg+xml;charset=UTF-8,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 24 24' fill='none' stroke='%23bbb' stroke-width='2' stroke-linecap='round' stroke-linejoin='round' class='feather feather-chevron-down'%3E%3Cpolyline points='6 9 12 15 18 9' /%3E%3C/svg%3E");
  background-repeat: no-repeat;
  background-position: right 10px center;
  background-size: 12px;
  cursor: pointer;

  &:focus {
    outline: none;
    border-color: #3a6df0;
    box-shadow: 0 0 0 2px rgba(40, 110, 150);
  }

  option {
    background-color: white;
    color: black;
  }
}

/* 定义 LESS 的函数，用来动态生成颜色 */
@black-color: black;
@white-color: white;

.setTextColor(@color) {
  color: @color;
}

* {
  outline: none;
  box-sizing: border-box;
}

@dark-color: #333;
@light-color: #fff;

.set-color(@mode) {
  color: if(@mode = "light", @light-color, @dark-color);
}

:root {
  --dropdown-bg: #21242d;
  --theme-bg-color: rgba(16 18 27 / 40%);
  --border-color: rgba(0, 0, 0, 0.25);
  --theme-color: #f9fafb;
  --inactive-color: rgb(113 119 144 / 78%);
  --body-font: "Poppins", sans-serif;
  --hover-menu-bg: rgba(12 15 25 / 30%);
  --content-title-color: #999ba5;
  --content-bg: rgb(146 151 179 / 13%);
  --button-inactive: rgb(249 250 251 / 55%);
  --dropdown-bg: #21242d;
  --dropdown-hover: rgb(42 46 60);
  --popup-bg: rgb(22 25 37);
  --search-bg: #14162b;
  --overlay-bg: rgba(36, 39, 59, 0.3);
  --scrollbar-bg: rgb(1 2 3 / 40%);
}

.light-mode {
  --theme-bg-color: rgb(255 255 255 / 31%);
  --theme-color: #3c3a3a;
  --inactive-color: #333333;
  --button-inactive: #3c3a3a;
  --search-bg: rgb(255 255 255 / 31%);
  --dropdown-bg: #080707;
  --overlay-bg: rgb(255 255 255 / 30%);
  --dropdown-hover: rgb(236 236 236);
  --border-color: rgba(0, 0, 0, 0.35);
  --popup-bg: rgb(12, 11, 11);
  --hover-menu-bg: rgba(255 255 255 / 35%);
  --scrollbar-bg: rgb(255 253 253 / 57%);
  --content-title-color: --theme-color;
}

html {
  box-sizing: border-box;
  -webkit-font-smoothing: antialiased;
}

body {
  font-family: var(--body-font);
  background-image: url(https://wallpapershome.com/images/wallpapers/macos-big-sur-1280x720-dark-wwdc-2020-22655.jpg);
  background-size: cover;
  background-position: center;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  padding: 2em;
  width: 100%;
  height: 100vh;

  // 强制设置颜色为黑色
  .black-text {
    color: black !important; // 加上 !important 优先级
  }

  .white-text {
    color: white !important; // 加上 !important 优先级
  }
}

body.light-mode {
  .black-text {
    color: black !important;
  }

  .white-text {
    color: white !important;
  }
}

.video-bg {
  position: fixed;
  right: 0;
  top: 0;
  width: 100%;
  height: 100%;

  video {
    width: 100%;
    height: 100%;
    object-fit: cover;
  }
}

img {
  max-width: 100%;
}

.dark-light {
  position: fixed;
  bottom: 50px;
  right: 30px;
  //  background-color: var(--dropdown-bg);
  box-shadow: -1px 3px 8px -1px rgba(0, 0, 0, 0.2);
  padding: 8px;
  border-radius: 50%;
  z-index: 3;
  cursor: pointer;
  svg {
    width: 24px;
    flex-shrink: 0;
    fill: #ffce45;
    stroke: #ffce45;
    transition: 0.5s;
  }
}

.light-mode {
  .dark-light svg {
    color: white;
    fill: transparent;
    //  stroke: var(--theme-color);
    stroke: #080707;
  }
  .profile-img {
    border: 2px solid var(--theme-bg-color);
  }
  .content-section ul {
    background-color: var(--theme-bg-color);
  }
  .pop-up__title {
    border-color: var(--theme-color);
  }
  .dropdown.is-active ul {
    background-color: rgb(255 255 255 / 94%);
  }
}

body.light-mode:before,
body.light-mode .video-bg:before {
  content: "";
  position: absolute;
  left: 0;
  top: 0;
  width: 100%;
  height: 100vh;
  background: linear-gradient(
    180deg,
    rgba(255, 255, 255, 0.72) 0%,
    rgb(255 255 255 / 45%) 100%
  );
  backdrop-filter: saturate(3);
}

.app {
  background-color: var(--theme-bg-color);
  height: 830px;
  width: 1050px;
  margin: 0 auto;

  display: flex;
  flex-direction: column;
  overflow: hidden;
  position: relative;

  border-radius: 14px;
  backdrop-filter: blur(20px);
  -webkit-backdrop-filter: blur(20px);
  font-size: 15px;
  font-weight: 500;

  margin: 0 auto;
  background-color: var(--theme-bg-color);

  display: flex;
  flex-direction: column;
  overflow: hidden;
  position: relative;

  top: -30px;
  border-radius: 14px;
  backdrop-filter: blur(20px);
  -webkit-backdrop-filter: blur(20px);
  font-size: 15px;
  font-weight: 500;
}

.header {
  display: flex;
  align-items: center;
  flex-shrink: 0;
  height: 84px;
  width: 100%;
  border-bottom: 1px solid var(--border-color);
  padding: 0 30px;
  white-space: nowrap;
  @media screen and (max-width: 480px) {
    padding: 0 16px;
  }
  .logo {
    background-image: url("../assets/img/Mylogo.png");
    background-position: center;
    background-size: contain; /* 等比例缩放并完全展示图片 */
    background-repeat: no-repeat;
    width: 934px; /* 设置元素宽度 */
    height: 60px; /* 设置元素高度 */
    opacity: 0.8; /* 设置透明度，值为0到1之间，1为完全不透明 */
  }

  .nav {
    display: flex;
    align-items: center;

    // 对 `a` 标签的样式
    a {
      padding: 20px 30px;
      text-decoration: none;
      color: var(--inactive-color); // 默认使用 inactive 颜色
      border-bottom: 2px solid transparent;
      transition: 0.3s;

      // 媒体查询，最大宽度为 610px 时隐藏部分链接
      @media screen and (max-width: 610px) {
        &:not(.main-header-link) {
          display: none;
        }
      }

      // 设置活跃状态和悬停状态的样式
      &.is-active,
      &:hover {
        color: var(--theme-color); // 在 hover 和 active 状态下使用主题颜色
        border-bottom: 2px solid var(--theme-color); // 边框使用主题颜色
      }
    }
  }
}

.notify {
  position: relative;
  &:before {
    content: "";
    position: absolute;
    background-color: #3a6df0;
    width: 6px;
    height: 6px;
    border-radius: 50%;
    right: 20px;
    top: 16px;
  }
  @media screen and (max-width: 1055px) {
    display: none;
  }
}

.menu-circle {
  width: 15px;
  height: 15px;
  background-color: #f96057;
  border-radius: 50%;
  box-shadow: 24px 0 0 0 #f8ce52, 48px 0 0 0 #5fcf65;
  margin-right: 195px;
  flex-shrink: 0;
  @media screen and (max-width: 945px) {
    display: none;
  }
}

.search-box {
  height: 40px;
  display: flex;
  width: 100%;
  max-width: 400px;
  padding-left: 16px;
  border-radius: 4px;
  input {
    width: 100%;
    height: 100%;
    border: none;
    background-color: var(--search-bg);
    border-radius: 4px;
    font-family: var(--body-font);
    font-size: 15px;
    font-weight: 500;
    padding: 0 20px 0 40px;
    box-shadow: 0 0 0 2px rgb(134 140 160 / 2%);
    background-image: url("data:image/svg+xml;charset=UTF-8,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 56.966 56.966' fill='%23717790c7'%3e%3cpath d='M55.146 51.887L41.588 37.786A22.926 22.926 0 0046.984 23c0-12.682-10.318-23-23-23s-23 10.318-23 23 10.318 23 23 23c4.761 0 9.298-1.436 13.177-4.162l13.661 14.208c.571.593 1.339.92 2.162.92.779 0 1.518-.297 2.079-.837a3.004 3.004 0 00.083-4.242zM23.984 6c9.374 0 17 7.626 17 17s-7.626 17-17 17-17-7.626-17-17 7.626-17 17-17z'/%3e%3c/svg%3e");
    background-size: 14px;
    background-repeat: no-repeat;
    background-position: 16px 48%;
    color: var(--theme-color);
    &::placeholder {
      font-family: var(--body-font);
      color: var(--inactive-color);
      font-size: 15px;
      font-weight: 500;
    }
  }
}

.header-right {
  display: flex;
  align-items: center;
  padding: 0 16px 0 40px;
  margin-left: auto;
  flex-shrink: 0;
  svg {
    width: 22px;
    color: #f9fafb;

    flex-shrink: 0;
  }
}

.notification {
  position: relative;
  &-number {
    position: absolute;
    background-color: #3a6df0;
    width: 16px;
    height: 16px;
    border-radius: 50%;
    font-size: 10px;
    display: flex;
    align-items: center;
    justify-content: center;
    color: #fff;
    right: -6px;
    top: -6px;
  }
  & + svg {
    margin-left: 22px;
    @media screen and (max-width: 945px) {
      display: none;
    }
  }
}

.profile-img {
  width: 32px;
  height: 32px;
  border-radius: 50%;
  object-fit: cover;
  border: 2px solid var(--theme-color);
  margin-left: 22px;
}

.wide {
  .header-menu,
  .header-profile {
    display: none;
  }
  .search-bar {
    max-width: 600px;
    margin: auto;
    transition: 0.4s;
    box-shadow: 0 0 0 1px var(--border-color);
    padding-left: 0;
  }
  .menu-circle {
    margin-right: 0;
  }
}

.container {
  display: flex;
  flex-grow: 1;
  overflow: hidden;
}

.left-side {
  flex-basis: 240px;
  border-right: 1px solid var(--border-color);
  padding: 26px;
  overflow: auto;
  flex-shrink: 0;
  @media screen and (max-width: 945px) {
    display: none;
  }
}

.side-wrapper + .side-wrapper {
  margin-top: 20px;
}

.side-title {
  color: var(--inactive-color);
  margin-bottom: 14px;
}

.side-menu {
  display: flex;
  flex-direction: column;
  white-space: nowrap;
  a {
    text-decoration: none;
    color: var(--theme-color);
    display: flex;
    align-items: center;
    font-weight: 400;
    padding: 10px;
    font-size: 14px;
    border-radius: 6px;
    transition: 0.3s;
    &:hover {
      background-color: var(--hover-menu-bg);
    }
  }
  svg {
    width: 16px;
    margin-right: 8px;
  }
}

.updates {
  position: relative;
  top: 0;
  right: 0;
  margin-left: auto;
  width: 18px;
  height: 18px;
  font-size: 11px;
}

.main-header {
  display: flex;
  align-items: center;
  border-bottom: 1px solid var(--border-color);
  height: 58px;
  flex-shrink: 0;
  .header-menu {
    margin-left: 50px;
    @media screen and (max-width: 1055px) {
      margin: auto;
    }
    a {
      padding: 20px 24px;
    }
  }
}

.main-container {
  display: flex;
  flex-direction: column;
  flex-grow: 1;
}

/* 整体评分展示样式 */
.overall-rating {
  display: flex;
  align-items: center;
  margin-top: 20px;

  span {
    margin-right: 10px;
    font-weight: 500;
    color: var(--theme-color);
  }

  .el-rate {
    margin-right: 10px;
  }

  .el-button {
    font-size: 14px;
    color: var(--theme-color);
  }
}

/* 评分标准弹窗样式 */
.el-dialog__body {
  padding: 20px;
}

.el-dialog ul {
  list-style: none;
  padding: 0;
}

.el-dialog li {
  margin-bottom: 10px;
  font-size: 14px;
  color: var(--theme-color);
}

.el-dialog li strong {
  color: #ff9900;
}

/* 适应不同主题的弹窗内容 */
.light-mode .el-dialog__body {
  background-color: #ffffff;
  color: #000000;
}

.content-section {
  margin-top: 30px;
  display: flex;
  flex-direction: column;
  &-title {
    color: var(--content-title-color);
    margin-bottom: 14px;
  }
  ul {
    display: flex;
    flex-direction: column;
    width: 100%;
    height: 100%;
    justify-content: space-around;
    background-color: var(--content-bg);
    padding-left: 0;
    margin: 0;
    border-radius: 14px;
    border: 1px solid var(--theme-bg-color);
    cursor: pointer;
    li {
      list-style: none;
      padding: 10px 18px;
      display: flex;
      align-items: center;
      font-size: 16px;
      width: 100%;
      height: 100%;
      white-space: nowrap;
      transition: 0.3s;
      &:hover {
        background-color: var(--theme-bg-color);
        &:first-child {
          border-radius: 13px 13px 0 0;
        }
        &:last-child {
          border-radius: 0 0 13px 13px;
        }
      }
      & + li {
        border-top: 1px solid var(--border-color);
      }
    }
    svg {
      width: 28px;
      border-radius: 6px;
      margin-right: 16px;
      flex-shrink: 0;
    }
  }
}

.submit-button {
  margin-top: 20px;
}

.fchart {
  top: 10px;
  display: flex;
  position: relative;
  left: -100px;
  .fchart1 {
    width: 100%;
    height: 400px;
    display: flex;
    flex-direction: column;
    align-items: center;
  }
}
</style>
