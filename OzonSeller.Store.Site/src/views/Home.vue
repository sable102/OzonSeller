<template>
  <div>
    <h1>Inventory Management System</h1>
    <router-link to="/products">Go to Products</router-link>
    <router-link to="/transactions">Go to Transactions</router-link>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'Home'
});
</script>
