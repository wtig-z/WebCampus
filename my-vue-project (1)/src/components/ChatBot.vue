<template>
    <div class="container">
      <el-row class="nav-bar" type="flex" justify="center">
        <el-col :span="24" class="nav-title"></el-col>
      </el-row>
  
      <div class="message-list" ref="scrollView">
        <div
          class="message-item"
          :style="getMessageAlignment(item)"
          v-for="(item, index) in messages"
          :key="index"
          :id="'msg-' + index"
        >
          <div class="message-content" :class="item.type">
            <div class="message-text" v-html="item.content"></div>
          </div>
        </div>
      </div>
  
      <div class="input-container">
        <el-input
          v-model="inputMessage"
          placeholder="请输入消息"
          class="input"
          @input="handleInput"
          clearable
        />
        <el-button type="primary" @click="sendMessage" class="send-button">发送</el-button>
      </div>
    </div>
  </template>
  
  <script>
  import { ElInput, ElButton, ElRow, ElCol } from "element-plus";
  import axios from "axios";
  
  export default {
    name: "ChatBot",
    components: {
      ElInput,
      ElButton,
      ElRow,
      ElCol,
    },
    data() {
      return {
        inputMessage: "", // 存储输入的消息
        messages: [], // 存储消息列表
        presetPrompts: [
          // 你的预定义提示词数据集
          { role: "system", content: "你是一个友善且专业的聊天机器人。" },
      {
        role: "system",
        content: `

请基于以下毕业生统计数据生成就业分析报告：

1. 2021年毕业生总人数：3293人，男生2086人，占63.34%，女生1207人，占36.65%。
2. 本科毕业生：3292人，专科生1人，涵盖多个院系，包括计算机、数码媒体、外语、游戏、财经、网络技术、电子、管理、软件工程等。
3. 2021年毕业生生源地中，92.71%来自广东省，其余来自全国22个省份。
4. 就业情况：毕业去向落实率94.99%，专业对口率90.01%，平均薪酬5131.55元。
5. 就业行业：41.46%进入信息传输、软件和信息技术服务业，其他行业如批发零售业占10.93%。


以下用人单位对毕业生的评价数据生成分析报告：

1. 2021年通过对300家用人单位的调查，收回有效问卷433份，涉及约670名毕业生，整体评分98.15，满意度98.15%。
2. 各方面的评价如下：
   - 德：工作态度、职业操守、遵纪守法、工作主动性、合作意识等方面评分均为4.80以上，满意度98.38%。
   - 智：再学习能力、创新意识、职业规划能力等方面评分为4.76以上，满意度97.69%。
   - 识：知识结构、外语水平等方面评分为4.76以上，满意度95.38%。
   - 能：专业能力、解决问题能力、业务开拓能力、团队沟通能力等方面评分为4.77以上，满意度96.30%。
   - 体：身体健康状况、心理健康状况、参加体育运动的积极性等方面评分为4.80以上，满意度97.23%。
3. 总体满意度：用人单位整体满意度98.15%，单位综合评价98.15%。

基于上面数据数据回答下面问题，并且不要输出markdown格式给我返回txt文本给我回答就可以了、


`
      }
        ]
      };
    },
    methods: {
      // 发送消息
      async sendMessage() {
        const message = this.inputMessage;
        if (!message) return;
  
        // 添加用户消息到消息列表
        this.messages.push({
          content: message,
          type: "user",
        });
  
        // 清空输入框
        this.inputMessage = "";
  
        // 拼接提示词和用户消息
        const combinedMessages = [
          ...this.presetPrompts, // 将预设提示词加入请求
          {
            role: "user",
            content: message,
          }
        ];
  
        // 发送请求到服务器
        try {
          const response = await axios.post(
            "https://open.xiaojingai.com/v1/chat/completions",
            {
              model: "gpt-4o-mini",
              messages: combinedMessages, // 使用合并后的消息列表
            },
            {
              headers: {
                Authorization: "Bearer sk-30TMzkwD0yHHBGpvrP0U6TqKmxDmrwOYb8gQOyriPEggHAhY", // 请替换为你的API密钥
                "Content-Type": "application/json",
              },
            }
          );
  
          const reply = response.data.choices[0].message.content;
          this.messages.push({
            content: reply,
            type: "bot",
            isComplete: false, // 用来标识是否显示完全
          });
        } catch (error) {
          console.error(error);
        }
      },
  
      // 逐字显示的逻辑
      simulateStreamOutput() {
        const lastMessage = this.messages[this.messages.length - 1];
        if (!lastMessage || lastMessage.isComplete) return;
  
        let index = 0;
        const totalLength = lastMessage.content.length;
  
        const interval = setInterval(() => {
          if (index < totalLength) {
            lastMessage.content = lastMessage.content.slice(0, index + 1); // 更新消息内容
            index++;
            this.$nextTick(() => {
              const lastMessageElement = document.getElementById("msg-" + (this.messages.length - 1));
              if (lastMessageElement) {
                lastMessageElement.scrollIntoView({ behavior: "smooth" }); // 滚动到最新消息
              }
            });
          } else {
            clearInterval(interval);
            lastMessage.isComplete = true; // 完成逐字显示
          }
        }, 50); // 每50ms显示一个字符
      },
  
      // 监听 messages 变化，当新消息加入时，开始逐字输出
      watchMessages() {
        this.$watch('messages', (newMessages) => {
          const lastMessage = newMessages[newMessages.length - 1];
          if (lastMessage && lastMessage.type === "bot" && !lastMessage.isComplete) {
            this.simulateStreamOutput(); // 开始逐字输出
          }
        });
      },
  
      // 获取消息对齐方式
      getMessageAlignment(item) {
        return item.type === "user" ? { "text-align": "right" } : { "text-align": "left" };
      },
    },
    mounted() {
      this.watchMessages(); // 在组件挂载时开始监听 messages 的变化
    },
  };
  </script>
  
  <style scoped>
  .container {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    height: 360px;
    width: 490px; /* 设置宽高为450px */
    padding: 10px;
    border: 1px solid rgba(211, 162, 162, 0.5);/* 为容器添加边框 */
    background-color: rgba(211, 162, 162, 0.5); /* 半透明背景 */
  }
  
  .message-list {
    flex: 1;
    padding: 10px;
    overflow-y: scroll;
    width: 100%;
  }
  
  .message-item {
    display: flex;
    margin-bottom: 10px;
  }
  
  .message-content {
    padding: 10px;
    border-radius: 10px;
    max-width: 80%;
  }
  
  .message-text {
    color: #fff;
    word-wrap: break-word;
  }
  
  .user {
    align-self: flex-end;
    background-color: #60a6ec;
  }
  
  .bot {
    align-self: flex-start;
    background-color: #525352;
  }
  
  .input-container {
    display: flex;
    align-items: center;
    width: 100%;
  }
  
  .input {
    flex: 1;
  }
  
  .send-button {
    margin-left: 10px;
  }
  </style>
  