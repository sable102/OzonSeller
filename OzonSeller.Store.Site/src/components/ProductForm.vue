<template>
  <div>
    <h2>Add Product</h2>
    <el-form ref="formRef" @submit.prevent="addProduct" label-width="120px">
      <el-form-item label="Name" required>
        <el-input v-model="name" placeholder="Enter product name" />
      </el-form-item>
      <el-form-item label="Description">
        <el-input v-model="description" placeholder="Enter product description" />
      </el-form-item>
      <el-form-item label="Quantity" required>
        <el-input-number v-model="quantity" :min="0" />
      </el-form-item>
      <el-form-item label="Upload Image" required>
        <el-upload
          class="upload-demo"
          :http-request="uploadFile"
          :file-list="fileList"
          :limit="1"
          :auto-upload="false"
          :on-change="uploadFile"
        >
          <el-button type="primary">Select File</el-button>
        </el-upload>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="addProduct">Add Product</el-button>
        <el-button type="default" @click="resetForm">Reset</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useStore } from 'vuex';
import { ElForm, ElFormItem, ElInput, ElInputNumber, ElButton, ElUpload } from 'element-plus';
import 'element-plus/dist/index.css';
import axios from 'axios';

export default defineComponent({
  name: 'ProductForm',
  components: {
    ElForm,
    ElFormItem,
    ElInput,
    ElInputNumber,
    ElButton,
    ElUpload
  },
  setup() {
    const store = useStore();
    const formRef = ref(null);
    const name = ref('');
    const description = ref('');
    const quantity = ref(0);
    const fileList = ref([]);

    const addProduct = async () => {
      if (!fileList.value.length) {
        alert('Please select a file.');
        return;
      }

      const formData = new FormData();
      formData.append('name', name.value);
      formData.append('description', description.value);
      formData.append('quantity', quantity.value.toString());
      formData.append('imageFile', fileList.value[0].raw);

      try {
        const response = await axios.post('/api/products', formData, {
          headers: {
            'Content-Type': 'multipart/form-data'
          }
        });
        console.log('Product added successfully:', response.data);
        resetForm();
      } catch (error) {
        console.error('Failed to add product:', error);
      }
    };

    const resetForm = () => {
      name.value = '';
      description.value = '';
      quantity.value = 0;
      fileList.value = [];
      formRef.value?.resetFields();
    };

    const uploadFile = (options: any) => {
      const { file } = options;
      fileList.value = [{ name: file.name, raw: file }];
      console.log('File added to fileList:', fileList.value); // Debugging log
    };

    const handleFileChange = (file: any, fileList: any) => {
      console.log('File changed:', file);
      console.log('Updated fileList:', fileList);
    };

    return {
      formRef,
      name,
      description,
      quantity,
      fileList,
      addProduct,
      resetForm,
      uploadFile
    };
  }
});
</script>