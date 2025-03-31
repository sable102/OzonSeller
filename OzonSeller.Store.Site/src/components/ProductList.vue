<template>
  <div>
    <h2>Product List</h2>
    <ul>
      <li v-for="product in products" :key="product.productId">
        {{ product.name }} - {{ product.quantity }}
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { defineComponent, computed, onMounted } from 'vue';
import { useStore } from 'vuex';

export default defineComponent({
  name: 'ProductList',
  setup() {
    const store = useStore();
    const products = computed(() => store.getters['products/allProducts']);

    onMounted(() => {
      store.dispatch('products/fetchProducts');
    });

    return {
      products
    };
  }
});
</script>
