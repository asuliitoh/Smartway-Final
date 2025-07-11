<script setup>
    import EstadisticasEquipo from '@/components/Estadisticas/EstadisticasEquipo.vue';
    import Card from '@/components/Cards/Card.vue';
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Search from '@/components/Search.vue';
    import NewEquipo from '@/components/Modals/NewEquipo.vue';
    import { onBeforeMount, ref } from 'vue';
    import { useEquiposStore } from '@/stores/equipos-store';   
    import TablaEquipos from '@/components/Tablas/TablaEquipos.vue';
    import { router } from '@/router/router';

    const equiposStore = useEquiposStore()
    const newEquipoModal = ref(false);
    const equipoPropioSeleccionado = ref(null)


    function editarEquipo(){
        router.replace( {name: 'equipo', params: {equipoId:equipoPropioSeleccionado.value}})
    }

    function crearNuevoEquipo(){
        newEquipoModal.value=true
    }

    function getAllEquipos(){
        equiposStore.getAllEquipos()
    }

    function getAllSolicitudes(){
        equiposStore.getSolicitudes()
    }

    onBeforeMount(getAllEquipos)
    onBeforeMount(getAllSolicitudes)
</script>

<template>
    <LayoutSection>
          <div class="h-full w-full grid grid-rows-[auto_auto_1fr] grid-cols-2 gap-5">
         
                <Search class="w-full row-start-1 col-span-full" v-bind:placeholder="'Buscar Equipo'"></Search>

                <Card class="col-start-1 row-start-2">
                    <template v-slot:title>
                        <div class="flex flex-row items-center justify-center w-full">
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
                        <div class="flex flex-row items-center justify-center w-full">
                            <h2 class="text-primary ">Solicitudes pendientes</h2>
                        </div>
                    </template>

                    <template v-slot:body>
                        <div class="grid w-full h-full grid-cols-2 gap-5">
                            <p>A continuación se muestran las solicitudes recibidas para unirse a un equipo.
                             Seleccione un equipo y pulse <span class="font-semibold text-primary">Aceptar</span> o  <span class="font-semibold text-primary">Rechazar</span>.</p>

                             <div class="overflow-auto max-h-[10rem]">
                                 <table class="table table-pin-rows">
                                    <thead>
                                        <th>Id</th>
                                        <td>Nombre</td>  
                                    </thead>

                                <template v-for="[id, value] in equiposStore.solicitudes">
                                    <tr>
                                        <th>{{ value.equipoId }}</th>
                                        <td>{{ value.nombre }}</td>
                                    </tr>
                                </template>

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

                <NewEquipo v-if="newEquipoModal" v-model="newEquipoModal"></NewEquipo>
                

             </div>
  
    </LayoutSection>
  

</template>
