<script setup>
    import { ref } from 'vue';
    const props = defineProps({
        placeholder: String,
        function: Function
    })

    const emits = defineEmits(["searched"])
    const searchComponent = ref('')

    async function search(){
        const response = await props.function(searchComponent.value)
        emits("searched", response)
        
    }
</script>

<template>
    <form @submit.prevent="search">
        <label class="w-full shadow-xl rounded-box shadow-primary/10 input">
            <input type="search" v-model="searchComponent" :placeholder="placeholder"/>
        </label>
    </form>
     
</template>