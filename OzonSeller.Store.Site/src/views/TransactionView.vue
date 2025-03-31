<template>
  <div>
    <h1>Transactions</h1>
    <TransactionForm />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import TransactionForm from '../components/TransactionForm.vue';

export default defineComponent({
  name: 'TransactionView',
  components: {
    TransactionForm
  }
});
</script>
