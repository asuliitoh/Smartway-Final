<!--Componente Modal personalizable, con un icono de correcto y con un botón para cerrar el Modal-->
<script setup>
    
    import Modal from './Modal.vue';

    /**
     * Model que define si el Modal es visible o no.
     */
    const visible = defineModel(false)

</script>

<template>
    <Modal>
        <template v-slot:header>
            <div class="flex flex-col items-center self-center w-full text-center ">
                <img src="./icons/check.png" alt="Icono Correcto" class="w-40 h-40 text-center">
                <div class="text-xl font-bold text-primary"><slot name="title"></slot></div>
            </div>
            
        </template>

        <template v-slot:body>
            <slot name="body"></slot>
        </template>

        <template v-slot:actions>
            <button @click="visible = false" type="button" class="btn btn-primary">Cerrar</button>
        </template>

    </Modal>
</template>