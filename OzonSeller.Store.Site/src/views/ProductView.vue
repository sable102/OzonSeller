<template>
  <div>
    <h1>Products</h1>
    <ProductForm />
    <ProductList />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import ProductList from '../components/ProductList.vue';
import ProductForm from '../components/ProductForm.vue';

export default defineComponent({
  name: 'ProductView',
  components: {
    ProductForm,
    ProductList
  }
});
</script>
