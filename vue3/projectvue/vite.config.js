import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

export default defineConfig({
  plugins: [vue()],
  server: {
    host: '0.0.0.0',                    // ฟังทุก interface (สำคัญมาก)
    port: parseInt(process.env.PORT) || 5173, // รับจาก $PORT หากมี, fallback เป็น 5173
  },
})
