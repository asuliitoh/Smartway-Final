<!--LayoutSection es un componente utilizado como plantilla para definir todas las vistas.-->
<script setup>
    import Header from '@/components/Header.vue';
</script>

<template>
    <div class="flex flex-col w-screen h-screen overflow-x-hidden">
        <Header></Header>
        <div class="flex-1 min-h-0 p-10 overflow-auto">
            <slot></slot>
        </div>

    </div>
</template>