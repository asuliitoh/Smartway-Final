<script setup>
import Header from '@/components/Header.vue';
</script>

<template>
    <main class="flex flex-col w-screen h-screen">
        <Header></Header>
        <div class="flex-1 min-h-0 p-10">
            <slot></slot>
        </div>
    </main>
</template>