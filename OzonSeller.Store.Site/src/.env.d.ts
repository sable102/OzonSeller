/// <reference types="vite/client" />
interface ImportMetaEnv {
  readonly VITE_API_URL: string;
  // Добавьте другие переменные окружения, если они есть
}

interface ImportMeta {
  readonly env: ImportMetaEnv;
}