<template>
  <div>
    <h2 style="text-align: center">就业人数变化趋势</h2>
    <div style="width: 650; height: 450px;">
      <Line :data="employmentTrendData" :options="employmentTrendOptions" />
    </div>
  </div>
</template>

<script>
import {
  Chart,
  LineElement,
  PointElement,
  LinearScale,
  CategoryScale,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import { Line } from "vue-chartjs";

Chart.register(
  LineElement,
  PointElement,
  LinearScale,
  CategoryScale,
  Title,
  Tooltip,
  Legend
);

export default {
  name: "EmploymentTrendChart",
  components: {
    Line,
  },
  data() {
    return {
      employmentTrendData: {
        labels: ["2020", "2021", "2022", "2023", "2024", "2025"],
        datasets: [
          {
            label: "专业对口人数",
            data: [120, 130, 140, 150, 160, 170],
            borderColor: "#5470C6",
            backgroundColor: "rgba(84, 112, 198, 0.5)",
            tension: 0.4,
          },
          {
            label: "非专业对口人数",
            data: [60, 65, 70, 75, 80, 85],
            borderColor: "#91CC75",
            backgroundColor: "rgba(145, 204, 117, 0.5)",
            tension: 0.4,
          },
          {
            label: "基层干部人数",
            data: [15, 18, 20, 22, 25, 28],
            borderColor: "#EE6666",
            backgroundColor: "rgba(238, 102, 102, 0.5)",
            tension: 0.4,
          },
        ],
      },
      employmentTrendOptions: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            display: true,
            position: "top",
          },
          title: {
            display: true,
            text: "就业人数变化趋势",
          },
        },
        scales: {
          x: {
            title: {
              display: true,
              text: "年份",
            },
          },
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: "人数",
            },
          },
        },
      },
    };
  },
};
</script>
