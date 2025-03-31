import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import ProductView from '../views/ProductView.vue';
import TransactionView from '../views/TransactionView.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/products',
    name: 'Products',
    component: ProductView
  },
  {
    path: '/transactions',
    name: 'Transactions',
    component: TransactionView
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
