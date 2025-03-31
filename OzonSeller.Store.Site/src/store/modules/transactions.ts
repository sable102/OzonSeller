import axios from 'axios';

interface Transaction {
  transactionId: number;
  productId: number;
  type: string;
  quantity: number;
  date: string;
}

interface TransactionsState {
  transactions: Transaction[];
}

const state: TransactionsState = {
  transactions: []
};

const mutations = {
  SET_TRANSACTIONS(state: TransactionsState, transactions: Transaction[]) {
    state.transactions = transactions;
  },
  ADD_TRANSACTION(state: TransactionsState, transaction: Transaction) {
    state.transactions.push(transaction);
  }
};

const actions = {
  async fetchTransactions({ commit }: any) {
    const response = await axios.get('/api/transactions');
    commit('SET_TRANSACTIONS', response.data);
  },
  async addTransaction({ commit }: any, transaction: Transaction) {
    const response = await axios.post('/api/transactions', transaction);
    commit('ADD_TRANSACTION', response.data);
  }
};

const getters = {
  allTransactions: (state: TransactionsState) => state.transactions
};

export default {
  state,
  mutations,
  actions,
  getters
};
