<template>
  <div>
    <h2>毕业生就业地区流向图</h2>
    <div id="employmentMap" style="width: 100%; height: 600px;"></div>
  </div>
</template>

<script>
import * as echarts from 'echarts';
import chinaGeoJson from 'china-geojson'; // 使用 geoJSON 形式加载中国地图

export default {
  name: 'EmploymentMap',
  data() {
    return {
      employmentData: [
        { name: '广东', value: 150, description: '珠三角、粤港澳大湾区' },
        { name: '浙江', value: 120, description: '一带一路' },
        { name: '江苏', value: 110, description: '一带一路' },
        { name: '北京', value: 100, description: '新一线城市' },
        { name: '上海', value: 90, description: '新一线城市' },
        { name: '重庆', value: 80, description: '新一线城市' },
        { name: '四川', value: 70, description: '一带一路' },
        { name: '山东', value: 60, description: '一带一路' },
      ]
    };
  },
  mounted() {
    this.initChart();
  },
  methods: {
    initChart() {
      const myChart = echarts.init(document.getElementById('employmentMap'));

      // 注册中国地图的geoJSON数据
      echarts.registerMap('china', chinaGeoJson);

      const option = {
        title: {
          text: '2023届毕业生就业地区流向',
          subtext: '一带一路、珠三角、粤港澳大湾区、新一线城市',
          left: 'center',
        },
        tooltip: {
          trigger: 'item',
          formatter: function (params) {
            const data = params.data || {};
            return `${params.name}<br/>就业人数: ${data.value || 0}<br/>区域: ${data.description || '未知'}`;
          }
        },
        visualMap: {
          min: 0,
          max: 200,
          left: 'left',
          top: 'bottom',
          text: ['高', '低'],
          calculable: true,
          inRange: {
            color: ['#e0ffff', '#006edd']
          }
        },
        series: [
          {
            name: '就业人数',
            type: 'map',
            map: 'china', // 使用刚刚注册的 'china' 地图
            roam: false,
            label: {
              show: true
            },
            data: this.employmentData
          }
        ]
      };

      myChart.setOption(option);

      // 自适应窗口大小变化
      window.addEventListener('resize', function () {
        myChart.resize();
      });
    }
  }
};
</script>

<style scoped>
h2 {
  text-align: center;
  margin-bottom: 20px;
}
</style>
