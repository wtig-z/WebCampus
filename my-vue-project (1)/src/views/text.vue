<template>
  <div>
    <h2>毕业生就业地区流向</h2>
    <!-- 使用 :data 代替 :chart-data 渲染条形图 -->
    <Bar v-if="chartData.labels.length" :data="chartData" :options="chartOptions" />
  </div>
</template>

<script>
import { Bar } from 'vue-chartjs'
import { Chart, BarElement, CategoryScale, LinearScale, Title, Tooltip, Legend } from 'chart.js'

// 注册所需的 Chart.js 组件
Chart.register(BarElement, CategoryScale, LinearScale, Title, Tooltip, Legend)

export default {
  name: 'EmploymentRegionChart',
  components: {
    Bar
  },
  data() {
    return {
      // X轴标签
      labels: [
        '一带一路',
        '珠三角地区',
        '粤港澳大湾区',
        '新一线城市'
      ],
      // Y轴数据值
      dataValues: [
        97.4,  // 一带一路
        83.4,  // 珠三角地区
        83.4,  // 粤港澳大湾区
        6.0    // 新一线城市
      ],
      // 图表数据
      chartData: {
        labels: [],
        datasets: []
      },
      // 图表配置
      chartOptions: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: false  // 不显示图例
          },
          title: {
            display: true,
            text: '毕业生就业地区流向'
          },
          tooltip: {
            callbacks: {
              label: function(context) {
                return `${context.parsed.y}%`;  // 工具提示中的显示格式
              }
            }
          }
        },
        scales: {
          y: {
            beginAtZero: true,  // Y轴从0开始
            title: {
              display: true,
              text: '百分比 (%)'  // Y轴标题
            }
          },
          x: {
            title: {
              display: true,
              text: '地区'  // X轴标题
            }
          }
        }
      }
    };
  },
  mounted() {
    // 渲染图表数据
    this.renderChartData();
  },
  methods: {
    // 将数据渲染到 chartData
    renderChartData() {
      this.chartData = {
        labels: this.labels,  // X轴标签
        datasets: [
          {
            label: '就业比例 (%)',  // 数据集标签
            backgroundColor: 'rgba(75, 192, 192, 0.6)',  // 条形图填充颜色
            borderColor: 'rgba(75, 192, 192, 1)',  // 条形图边框颜色
            borderWidth: 1,  // 边框宽度
            data: this.dataValues  // Y轴数据
          }
        ]
      };
    }
  }
};
</script>

<style scoped>
h2 {
  text-align: center;
  margin-bottom: 20px;
}

div {
  width: 100%;
  height: 500px; /* 可根据需要调整高度 */
}
</style>
