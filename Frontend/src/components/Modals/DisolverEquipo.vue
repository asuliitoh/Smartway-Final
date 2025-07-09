<script setup>
    
    import { useEquiposStore } from '@/stores/equipos-store';
    import Modal from './Modal.vue';
    const visible = defineModel(false)
    const equipoStore = useEquiposStore()
    const props = defineProps(["seleccionado"])
    

    async function disolverEquipo(){
        await equipoStore.deleteEquipo(props.seleccionado);
        visible.value=false;
    }


</script>

<template>
     <Modal>
        <template v-slot:header>
            <div class=" text-center flex flex-col self-center items-center w-full">
                <img src="./icons/warning.png" alt="Icono Warning" class="w-40 h-40 text-center">
                <div class="text-xl font-bold text-primary/80">Disolver Equipo</div>
            </div>
        
        </template>

        <template v-slot:body>
            <p class="text-sm text-gray-600">¿Estas seguro de esta acción? Ten en cuenta que aquellas operaciones que tenga asignadas quedarán sin equipo.</p>
        </template>
        <template v-slot:actions>
            <button @click="visible = false" type="button" class="btn ">Cancelar</button>
            <button @click="disolverEquipo" type="button" class="btn btn-primary">Aceptar</button>
        </template>

    </Modal>
</template>