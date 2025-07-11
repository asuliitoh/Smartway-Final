<script setup>
    import Modal from './Modal.vue';
</script>

<template>

    <Modal>
        <template v-slot:header>
            <div class="flex flex-col items-center self-center w-full text-center ">
                <img src="./icons/warning.png" alt="Icono Warning" class="w-40 h-40 text-center">
                <div class="text-xl font-bold text-primary"><slot name="title"></slot></div>
            </div>
            
        </template>

        <template v-slot:body>
            <div class="text-sm text-gray-600">
                <slot name="body"></slot>
            </div>
        </template>

        <template v-slot:actions>
            <slot name="actions"></slot>
        </template>

    </Modal>

</template>