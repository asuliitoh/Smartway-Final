<script setup>
    import { ref } from 'vue';
    const props = defineProps({
        placeholder: String
    })
</script>

<template>
     <label class="shadow-xl rounded-box shadow-primary/10 input">
            <input type="search" :placeholder="placeholder"/>
    </label>
</template>