import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';

export default defineConfig({
  plugins: [vue()],
  resolve: {
    alias: {
      '@': '/src'
    }
  },
  build: {
    sourcemap: false,
    outDir: 'dist', // Указывает папку для сборки
  },
  server: {
    port: 5173
  },
});
