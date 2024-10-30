<template>
  <div>
    <Bar :data="chartData" :options="chartOptions" />
  </div>
</template>

<script>
import { Bar } from 'vue-chartjs'
import { Chart, BarElement, CategoryScale, LinearScale, Tooltip, Legend, Title } from 'chart.js'

// 注册所需的 Chart.js 组件
Chart.register(BarElement, CategoryScale, LinearScale, Tooltip, Legend, Title)

export default {
  name: 'JobMatchChart',
  components: {
    Bar
  },
  data() {
    return {
      chartData: {
        labels: ['网络工程', '信息管理与信息系统', '本校平均'],
        datasets: [
          {
            label: '岗业对口程度',
            backgroundColor: ['#168aad', '#168aad', '#ffca3a'], // 根据每个条形图的颜色
            data: [65, 55, 67], // 对应的百分比数据
            borderWidth: 1
          }
        ]
      },
      chartOptions: {
        responsive: true,
        maintainAspectRatio: false,
        indexAxis: 'y', // 使条形图水平显示
        plugins: {
          legend: {
            display: false // 隐藏图例
          },
          title: {
            display: true,
            text: '岗业对口程度'
          },
          tooltip: {
            callbacks: {
              label: function(context) {
                return `${context.raw}%`
              }
            }
          }
        },
        scales: {
          x: {
            beginAtZero: true,
            max: 100, // 假设百分比上限为 100
            title: {
              display: true,
              text: '百分比 (%)'
            }
          },
          y: {
            title: {
              display: true,
              // text: '专业'
            }
          }
        }
      }
    }
  }
}
</script>

<style scoped>
div {
  width: 100%;
  height: 300px;
}
</style>
