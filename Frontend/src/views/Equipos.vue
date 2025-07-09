<script setup>
    import EstadisticasEquipo from '@/components/Estadisticas/EstadisticasEquipo.vue';
    import Card from '@/components/Cards/Card.vue';
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Search from '@/components/Search.vue';
    import NewEquipo from '@/components/Modals/NewEquipo.vue';
    import { onBeforeMount, ref } from 'vue';
    import { useEquiposStore } from '@/stores/equipos-store';
    import DisolverEquipo from '@/components/Modals/DisolverEquipo.vue';
    import TablaEquipos from '@/components/Tablas/TablaEquipos.vue';
    import { router } from '@/router/router';

    const equiposStore = useEquiposStore()
    const newEquipoModal = ref(false);
    const disolverEquipoModal = ref(false);
    const equipoPropioSeleccionado = ref(null)

    function disolverEquipo(){
        console.log(equipoPropioSeleccionado.value)
        if (equipoPropioSeleccionado.value != null) disolverEquipoModal.value = true;
    }

    function editarEquipo(){
        router.replace( {name: 'equipo', params: {equipoId:equipoPropioSeleccionado.value}})
    }

    function crearNuevoEquipo(){
        newEquipoModal.value=true
    }

    function getAllEquipos(){
        equiposStore.getAllEquipos()
    }


    onBeforeMount(getAllEquipos)
</script>

<template>
    <LayoutSection>
          <div class="h-full w-full grid grid-rows-[auto_auto_1fr] grid-cols-2 gap-5">
         
                <Search class="w-full row-start-1 col-span-full" v-bind:placeholder="'Buscar Equipo'"></Search>

                <Card class="col-start-1 row-start-2">
                    <template v-slot:title>
                        <div class="flex flex-row justify-center items-center w-full">
                            <img src="./icons/postcard.png" alt="Resumen General">
                            <h2 class="text-primary">Resumen General</h2>
                        </div>
                    </template>

                    <template v-slot:body>
                        <EstadisticasEquipo></EstadisticasEquipo>
                    </template>
                </Card>

                <Card class="row-start-2 col-start-2 h-[100%]">
                    <template v-slot:title>
                        <div class="flex flex-row justify-center items-center w-full">
                            <h2 class="text-primary ">Equipos posibles a los que unirse</h2>
                        </div>
                    </template>

                    <template v-slot:body>
                        <div class="flex flex-row w-full">
                            <p class="max-w-[50%]">Esta sección muestra los equipos disponibles a los que puedes solicitar unirte.
                             Revisa las opciones y elige el equipo que mejor se ajuste a tus intereses y perfil.</p>

                             <div class="overflow-auto max-w-[50%]">
                                 <table class="table table-pin-rows">
                                    <thead>
                                        <th>Id</th>
                                        <td>Nombre</td>  
                                    </thead>
                                </table>
                             </div>

                        </div>
                    </template>

                </Card>

                <Card class="row-start-3 overflow-auto h-[100%]">
                    <template v-slot:title>
                        <h2 class="w-full text-center text-primary"> Equipos propios</h2>
                    </template>

                    <template v-slot:body>
                        <TablaEquipos v-model="equipoPropioSeleccionado" :equipos="equiposStore.equiposPropios"></TablaEquipos>
                    </template>

                    <template v-slot:actions>
                        <button @click="editarEquipo" type="button" class="btn">Editar Equipo</button>
                        <button @click="crearNuevoEquipo" type="button" class="btn btn-primary">Crear Nuevo Equipo</button>
                        <button @click="disolverEquipo" type="button" class="btn btn-primary">Disolver Equipo</button>
                    </template>

                </Card>

                <Card class="col-start-2 row-start-3 overflow-auto">
                    <template v-slot:title>
                        <h2 class="w-full text-center text-primary"> Equipos en los que participas</h2>
                       
                    </template>

                    <template v-slot:body>
                        <TablaEquipos :equipos="equiposStore.equiposMiembro"></TablaEquipos>
                    </template>

                    <template v-slot:actions>
                        <button type="button" class="btn">Editar Equipo</button>
                        <button type="button" class="btn btn-primary">Abandonar Equipo</button>
                    </template>

                </Card>

                <NewEquipo v-show="newEquipoModal" v-model="newEquipoModal"></NewEquipo>
                <DisolverEquipo v-show="disolverEquipoModal" v-model="disolverEquipoModal" :seleccionado="equipoPropioSeleccionado" ></DisolverEquipo>

             </div>
  
    </LayoutSection>
  

</template>
