<!--Componente personalizable que representa una barra de búsqueda-->
<script setup>
    import { ref } from 'vue';

    /**
     * Placeholder de la barra de búsqueda y la función asociada al buscar.
     */
    const props = defineProps({
        placeholder: String,
        function: Function
    })

    /**
     * Evento "searched", emitido cuando se busca.
     */
    const emits = defineEmits(["searched"])
    
    /**
     * Objeto reactivo que almacena el objeto buscado.
     */
    const searchComponent = ref('')

    /**
     * Función utilizada para aplicar la búsqueda. Se utiliza la función pasada como propiedad.
     */
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