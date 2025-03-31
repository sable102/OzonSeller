<template>
  <div>
    <h2>Add Product</h2>
    <form @submit.prevent="addProduct">
      <div>
        <label for="name">Name:</label>
        <input type="text" id="name" v-model="name" required />
      </div>
      <div>
        <label for="description">Description:</label>
        <input type="text" id="description" v-model="description" />
      </div>
      <div>
        <label for="quantity">Quantity:</label>
        <input type="number" id="quantity" v-model="quantity" required />
      </div>
      <button type="submit">Add Product</button>
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useStore } from 'vuex';

export default defineComponent({
  name: 'ProductForm',
  setup() {
    const store = useStore();
    const name = ref('');
    const description = ref('');
    const quantity = ref(0);

    const addProduct = () => {
      store.dispatch('products/addProduct', {
        name: name.value,
        description: description.value,
        quantity: quantity.value
      });
      name.value = '';
      description.value = '';
      quantity.value = 0;
    };

    return {
      name,
      description,
      quantity,
      addProduct
    };
  }
});
</script>
