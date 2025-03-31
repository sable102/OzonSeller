import { createStore } from 'vuex';
import products from './modules/products';
import transactions from './modules/transactions';

export default createStore({
  modules: {
    products,
    transactions
  }
});
