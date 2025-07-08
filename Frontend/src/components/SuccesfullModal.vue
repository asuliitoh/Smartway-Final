<script setup>
import Modal from './Modal.vue';

const visible = defineModel(false)

</script>

<template>
    <Modal>
        <template v-slot:header>
            <div class=" text-center flex flex-col self-center items-center w-full">
                <img src="./icons/check.png" alt="Icono Correcto" class="w-40 h-40 text-center">
                <div class="text-primary font-bold text-xl"><slot name="title"></slot></div>
            </div>
            
        </template>

        <template v-slot:body>
            <slot name="body"></slot>
        </template>

        <template v-slot:actions>
           
                <form method="dialog">
                    <button @click="visible = false" type="button" class="btn btn-primary">Cerrar</button>
                </form>

        </template>

    </Modal>
</template>