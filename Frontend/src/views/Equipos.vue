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
    const equipoSeleccionado = ref(null)
    const solicitudSeleccionada = ref(null)

    function redirectToEquipo(){
        if (equipoSeleccionado.value) router.replace( {name: 'equipo', params: {equipoId:equipoSeleccionado.value}})
    }

    function crearNuevoEquipo(){
        newEquipoModal.value=true
    }

    function isSeleccionada(id){
        return (solicitudSeleccionada && solicitudSeleccionada.value == id)
    }

    function rechazarSolicitud(){
        equiposStore.rechazarSolicitud(solicitudSeleccionada.value)
    }

    function aceptarSolicitud(){
        equiposStore.aceptarSolicitud(solicitudSeleccionada.value)
    }

    function abandonarEquipo(){
        equiposStore.abandonarEquipo(equipoSeleccionado.value)
    }
</script>

<template>
    <LayoutSection>
          <div class="h-full w-full grid grid-rows-[auto_1fr] grid-cols-2 gap-5">
         
                

                <Card class="col-start-1 row-start-1">
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

                <Card class="row-start-1 col-start-2 h-[100%]">
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
                                 <table class="table bg-primary/20 table-pin-rows">
                                    <thead>
                                        <th>Id</th>
                                        <td>Nombre</td>  
                                    </thead>

                                <template v-for="[id, value] in equiposStore.solicitudes">
                                    <tr @click="solicitudSeleccionada = value.equipoId" class="hover:bg-primary/10" :class = "{'bg-primary/20': isSeleccionada(value.equipoId)}">
                                        <th>{{ value.equipoId }}</th>
                                        <td>{{ value.nombre }}</td>
                                    </tr>
                                </template>

                                </table>
                             </div>

                        </div>
                    </template>

                    <template v-slot:actions>
                        <button v-if="solicitudSeleccionada" @click="rechazarSolicitud" type="button" class="btn">Rechazar</button>
                        <button v-if="solicitudSeleccionada" @click="aceptarSolicitud" type="button" class="btn btn-primary">Aceptar</button>
                    </template>

                </Card>

                <Card class="row-start-2 overflow-auto h-[100%]">
                    <template v-slot:title>
                        <h2 class="w-full text-center text-primary"> Equipos propios</h2>
                    </template>

                    <template v-slot:body>
                        <TablaEquipos v-model="equipoSeleccionado" :equipos="equiposStore.equiposPropios"></TablaEquipos>
                    </template>

                    <template v-slot:actions>
                        <button @click="redirectToEquipo" type="button" class="btn">Editar Equipo</button>
                        <button @click="crearNuevoEquipo" type="button" class="btn btn-primary">Crear Nuevo Equipo</button>
                    </template>

                </Card>

                <Card class="col-start-2 row-start-2 overflow-auto">
                    <template v-slot:title>
                        <h2 class="w-full text-center text-primary"> Equipos en los que participas</h2>
                       
                    </template>

                    <template v-slot:body>
                        <TablaEquipos v-model="equipoSeleccionado" :equipos="equiposStore.equiposMiembro"></TablaEquipos>
                    </template>

                    <template v-slot:actions>
                        <button type="button" class="btn">Ver Equipo</button>
                        <button @click="abandonarEquipo" type="button" class="btn btn-primary">Abandonar Equipo</button>
                    </template>

                </Card>

                <NewEquipo v-if="newEquipoModal" v-model="newEquipoModal"></NewEquipo>
                

             </div>
  
    </LayoutSection>
  

</template>
