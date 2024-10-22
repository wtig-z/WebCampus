<template>
  <el-container class="container">
    <!-- Header -->
    <el-header class="header">
      <h1><i class="fa fa-chart-line"></i> 面向B端大学生就业数据分析可视化平台</h1>
    </el-header>

    <!-- 主体内容 -->
    <el-main>
      <!-- 技术栈展示 -->
      <el-card class="section">
        <h2><i class="fa fa-code"></i> 技术栈展示</h2>
        <el-row :gutter="10" class="tech-tags">
          <el-col :span="24">
            <el-tag type="primary">Vue.js</el-tag>
            <el-tag type="success">ECharts/Chart.js</el-tag>
            <el-tag type="info">Element Plus</el-tag>
            <el-tag type="warning">C# ASP.NET Web API</el-tag>
            <el-tag type="danger">Python</el-tag>
            <el-tag type="dark">SQL Server</el-tag>
          </el-col>
        </el-row>
      </el-card>

      <!-- 平台介绍 -->
      <el-card class="section">
        <h2><i class="fa fa-info-circle"></i> 平台介绍</h2>
        <p>
          该大学生就业数据分析可视化平台将为学校提供全方位的数据支持，帮助其更好地理解毕业生的就业表现，及时调整招生和教学计划，并与市场需求保持同步，为学生的职业发展铺平道路。
        </p>
      </el-card>

      <!-- 功能模块与成果说明 -->
      <el-row :gutter="20" class="section">
        <!-- 功能模块 -->
        <el-col :span="12">
          <el-card>
            <h3><i class="fa fa-tasks"></i> 功能模块</h3>
            <el-list>
              <el-list-item>就业数据分析模块</el-list-item>
              <el-list-item>企业反馈数据分析模块</el-list-item>
              <el-list-item>招生与就业趋势分析模块</el-list-item>
              <el-list-item>教学课程优化建议模块</el-list-item>
            </el-list>
          </el-card>
        </el-col>

        <!-- 成果说明 -->
        <el-col :span="12">
          <el-card>
            <h3><i class="fa fa-check-circle"></i> 成果说明</h3>
            <el-list>
              <el-list-item>可视化平台</el-list-item>
              <el-list-item>就业趋势报告</el-list-item>
              <el-list-item>课程优化建议</el-list-item>
              <el-list-item>其他相关成果</el-list-item>
            </el-list>
          </el-card>
        </el-col>
      </el-row>
    </el-main>

    <!-- Footer -->
    <el-footer class="footer">
      <p>&copy; 2024 大学生就业数据分析平台</p>
    </el-footer>
  </el-container>
</template>

<script>
export default {

};
</script>
