<script setup>
import { ref } from 'vue';

const props = defineProps({
    number: String,
    title: String,
    hover: Boolean
})

</script>


<template>
     <div class="shadow-xl card bg-base-100" :class="{'hover:bg-primary/20 transition duration-300': props.hover}">
            <div class="items-center justify-center card-body">
                <h2 class="card-title"> {{ props.number }} </h2>
                <p class="text-xs">{{ props.title }}</p>
            </div>
        </div>
</template>