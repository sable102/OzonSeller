<template>
  <div>
    <h2>Product List</h2>
    <el-table :data="products" style="width: 100%">
      <el-table-column prop="productId" label="ID" width="180" />
      <el-table-column prop="name" label="Name" />
      <el-table-column prop="quantity" label="Quantity" width="120" />
    </el-table>
  </div>
</template>

<script lang="ts">
import { defineComponent, computed, onMounted } from 'vue';
import { useStore } from 'vuex';
import { ElTable, ElTableColumn } from 'element-plus';
import 'element-plus/dist/index.css';

export default defineComponent({
  name: 'ProductList',
  components: {
    ElTable,
    ElTableColumn
  },
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