import axios from 'axios';

interface Product {
  productId: number;
  name: string;
  description: string;
  quantity: number;
}

interface ProductsState {
  products: Product[];
}

const state: ProductsState = {
  products: []
};

const mutations = {
  SET_PRODUCTS(state: ProductsState, products: Product[]) {
    state.products = products;
  },
  ADD_PRODUCT(state: ProductsState, product: Product) {
    state.products.push(product);
  }
};

const actions = {
  async fetchProducts({ commit }: any) {
    const response = await axios.get('/api/products');
    commit('SET_PRODUCTS', response.data);
  },
  async addProduct({ commit }: any, product: Product) {
    const response = await axios.post('/api/products', product);
    commit('ADD_PRODUCT', response.data);
  }
};

const getters = {
  allProducts: (state: ProductsState) => state.products
};

export default {
  state,
  mutations,
  actions,
  getters
};
