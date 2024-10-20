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

<style scoped>
:root {
  --color-background: #342a2a; /* 背景颜色 */
  --color-text: #333333; /* 默认文本颜色 */
  --color-primary: #409EFF; /* 主要颜色 */
  --color-header-text: #151010; /* 头部文本颜色 */
  --color-footer-background: #333333; /* 底部背景颜色 */
  --color-footer-text: #130404; /* 底部文本颜色 */
  --color-border: #2d2929; /* 边框颜色 */
  /* 根据需要添加更多变量 */
}

/* Container 样式 */
.container {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  background-color: var(--color-background);
  color: var(--color-text); /* 设置默认文本颜色 */
}

/* Header 样式 */
.header {
  background-color: var(--color-primary);
  color: var(--color-header-text); /* 明确设置头部文本颜色 */
  text-align: center;
  padding: 20px 0;
}

.header h1 {
  margin: 0;
  font-size: 28px;
  font-weight: 600;
  display: flex;
  align-items: center;
  justify-content: center;
  color: var(--color-header-text); /* 确保h1文本颜色正确 */
}

.header h1 i {
  margin-right: 10px;
  font-size: 24px;
  color: var(--color-header-text); /* 确保图标颜色正确 */
}

/* 主体内容样式 */
.el-main {
  padding: 20px;
  flex: 1;
  color: var(--color-text); /* 确保主体内容文本颜色正确 */
}

/* 每个 section 的样式 */
.section {
  margin-bottom: 20px;
  color: var(--color-text); /* 确保section文本颜色正确 */
}

/* Card 标题样式 */
.section h2,
.section h3 {
  margin-bottom: 15px;
  color: var(--color-text); /* 确保标题文本颜色正确 */
  display: flex;
  align-items: center;
}

.section h2 i,
.section h3 i {
  margin-right: 10px;
  font-size: 20px;
  color: var(--color-text); /* 确保图标颜色正确 */
}

/* Footer 样式 */
.footer {
  text-align: center;
  padding: 10px 0;
  background-color: var(--color-footer-background);
  color: var(--color-footer-text); /* 明确设置底部文本颜色 */
}

/* 标签样式调整 */
.tech-tags .el-tag {
  margin: 5px 5px 5px 0;
  color: #ffffff; /* 如果标签背景颜色较深，设置白色字体 */
}

/* 列表样式调整 */
.el-list-item {
  color: var(--color-text); /* 确保列表项文本颜色正确 */
  padding: 5px 0;
  border-bottom: 1px solid var(--color-border);
}

.el-list-item:last-child {
  border-bottom: none;
}

/* Card 组件样式 */
.el-card {
  border-radius: 8px;
  box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
  color: var(--color-text); /* 确保卡片文本颜色正确 */
}

/* 响应式调整 */
@media (max-width: 768px) {
  .container {
    padding: 10px;
  }

  .header h1 {
    font-size: 24px;
  }

  .section h2 {
    font-size: 22px;
  }

  .section h3 {
    font-size: 20px;
  }

  .tech-tags .el-tag {
    display: block;
    margin: 5px 0;
  }
}
</style>
