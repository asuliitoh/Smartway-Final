<script setup>
    import Modal from './Modal.vue';
    import { ref } from 'vue';
    import { useEquiposStore } from '@/stores/equipos-store';
    //Objeto reactivo para mostrar u ocultar el modal
    const visible = defineModel(false)
    
    //Stores utilizados para la creación del equipo
    const equiposStore = useEquiposStore()

    //Objetos reactivos utilizados para el formulario
    const nombre = ref(null)
    const especialidad = ref(null)


    async function newEquipo(){
        if ((nombre.value != null) && (especialidad.value != null)){
        await equiposStore.newEquipo({
            nombre:nombre.value,
            especialidad:especialidad.value
        }).then(visible.value = false)
        
        }
    }

    function clear(){
        nombre.value = null;
        especialidad.value = null;
        visible.value = false;
    }

</script>

<template>

    <Modal>
        <template v-slot:header>
            <p class="text-xl font-bold text-primary/80">Crear Nuevo Equipo</p>
            <p class="pb-3 text-sm text-gray-600">Escoge un nombre para tu equipo y especifica su especialidad.</p>
        </template>

        <template v-slot:body>
            <div class="flex flex-col gap-4">

                <div class="flex flex-col gap-2">
                    <label class="text-xs label text-primary">Nombre del equipo</label>
                    <input type="text" v-model="nombre" class="w-full input bg-primary/10 border-primary/20" placeholder="Introduce el nombre del equipo">
                </div>

                <div class="flex flex-col gap-2">
                    <label class="text-xs label text-primary">Especialidad del equipo</label>
                    <input type="text" v-model="especialidad" class="w-full input bg-primary/10 border-primary/20" placeholder="Introduce la especialidad del equipo">
                </div>

            </div>            

        </template>

          <template v-slot:actions>
            <button @click="clear" type="button" class="btn">Cancelar</button>
            <button @click="newEquipo" type="button" class="btn btn-primary">Crear</button>
        </template>
        
    </Modal>

</template>