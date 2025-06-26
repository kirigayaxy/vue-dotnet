FROM node:20.19.1-alpine

WORKDIR /app

# เปิดใช้งาน pnpm
RUN corepack enable && corepack prepare pnpm@latest --activate

# ตั้ง NODE_ENV ให้เป็น development เพื่อให้ติดตั้ง devDependencies ด้วย
ENV NODE_ENV=development

# คัดลอกไฟล์ lock และ package.json ก่อน
COPY ./projectvue/pnpm-lock.yaml ./projectvue/package.json ./

# ติดตั้ง dependencies
RUN pnpm install

# คัดลอก source code ที่เหลือ
COPY ./projectvue/ .

# เปิดพอร์ต Vite
EXPOSE 5173

# รัน dev server
CMD ["pnpm", "run", "dev"]