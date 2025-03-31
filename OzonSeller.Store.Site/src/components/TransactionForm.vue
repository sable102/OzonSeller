<template>
  <div>
    <h2>Add Transaction</h2>
    <form @submit.prevent="addTransaction">
      <div>
        <label for="productId">Product ID:</label>
        <input type="number" id="productId" v-model="productId" required />
      </div>
      <div>
        <label for="type">Type:</label>
        <select id="type" v-model="type" required>
          <option value="Income">Income</option>
          <option value="Expense">Expense</option>
        </select>
      </div>
      <div>
        <label for="quantity">Quantity:</label>
        <input type="number" id="quantity" v-model="quantity" required />
      </div>
      <button type="submit">Add Transaction</button>
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useStore } from 'vuex';

export default defineComponent({
  name: 'TransactionForm',
  setup() {
    const store = useStore();
    const productId = ref(0);
    const type = ref('Income');
    const quantity = ref(0);

    const addTransaction = () => {
      store.dispatch('transactions/addTransaction', {
        productId: productId.value,
        type: type.value,
        quantity: quantity.value
      });
      productId.value = 0;
      type.value = 'Income';
      quantity.value = 0;
    };

    return {
      productId,
      type,
      quantity,
      addTransaction
    };
  }
});
</script>
