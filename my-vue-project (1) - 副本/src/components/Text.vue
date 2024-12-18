<template>
    <div class="container">
      <!-- <el-row class="nav-bar" type="flex" justify="center">
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
      </div> -->
  
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
  import { ref, watch, nextTick } from "vue";
  import { ElInput, ElButton, ElRow, ElCol } from "element-plus";
  import axios from "axios";
  
  export default {
    name: "Text",
    components: {
      ElInput,
      ElButton,
      ElRow,
      ElCol,
    },
    setup() {
      const inputMessage = ref(""); // 存储输入的消息
      const messages = ref([]); // 存储消息列表
  
      // 发送消息
      const sendMessage = async () => {
        const message = inputMessage.value;
        if (!message) return;
  
        // 添加用户消息到消息列表
        messages.value.push({
          content: message,
          type: "user",
        });
  
        // 清空输入框
        inputMessage.value = "";
  
        // 发送请求到服务器
        try {
          const response = await axios.post(
            "https://open.xiaojingai.com/v1/chat/completions",
            {
              model: "gpt-4o-mini",
              messages: [
                {
                  role: "user",
                  content: message,
                },
              ],
            },
            {
              headers: {
                Authorization: "Bearer sk-30TMzkwD0yHHBGpvrP0U6TqKmxDmrwOYb8gQOyriPEggHAhY", // 请替换为你的API密钥
                "Content-Type": "application/json",
              },
            }
          );
  
          const reply = response.data.choices[0].message.content;
          messages.value.push({
            content: reply,
            type: "bot",
            isComplete: false, // 用来标识是否显示完全
          });
        } catch (error) {
          console.error(error);
        }
      };
  
      // 逐字显示的逻辑
      const simulateStreamOutput = () => {
        const lastMessage = messages.value[messages.value.length - 1];
        if (!lastMessage || lastMessage.isComplete) return;
  
        let index = 0;
        const totalLength = lastMessage.content.length;
  
        const interval = setInterval(() => {
          if (index < totalLength) {
            lastMessage.content = lastMessage.content.slice(0, index + 1); // 更新消息内容
            index++;
            nextTick(() => {
              const lastMessageElement = document.getElementById("msg-" + (messages.value.length - 1));
              if (lastMessageElement) {
                lastMessageElement.scrollIntoView({ behavior: "smooth" }); // 滚动到最新消息
              }
            });
          } else {
            clearInterval(interval);
            lastMessage.isComplete = true; // 完成逐字显示
          }
        }, 50); // 每50ms显示一个字符
      };
  
      // 监听 messages 变化，当新消息加入时，开始逐字输出
      watch(messages, (newMessages) => {
        // 只有在最后一条消息是机器人的并且没有完全显示时才开始逐字输出
        const lastMessage = newMessages[newMessages.length - 1];
        if (lastMessage && lastMessage.type === "bot" && !lastMessage.isComplete) {
          simulateStreamOutput(); // 开始逐字输出
        }
      });
  
      // 获取消息对齐方式
      const getMessageAlignment = (item) => {
        return item.type === "user" ? { "text-align": "right" } : { "text-align": "left" };
      };
  
      return {
        inputMessage,
        messages,
        sendMessage,
        simulateStreamOutput,
        getMessageAlignment, // 返回 getMessageAlignment 方法
      };
    },
  };
  </script>
  
  <style scoped>
  .container {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    height: 100vh;
    padding: 20px;
    margin-top: 0;
  }
  
  .message-list {
    flex: 1;
    padding: 10px;
    overflow-y: scroll;
    width: 100%;
    max-width: 600px; /* 控制消息框宽度 */
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
    margin-top: 20px;
    width: 176px;
    max-width: 600px; /* 控制输入框和按钮的宽度 */
  }
  
  .send-button {
    margin-left: 10px;
  }
  </style>
  