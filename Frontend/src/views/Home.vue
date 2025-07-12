<script setup>
    import EstadisticasEquipo from '@/components/Estadisticas/EstadisticasEquipo.vue';
    import EstadisticasOperaciones from '@/components/Estadisticas/EstadisticasOperaciones.vue';
    import Card from '@/components/Cards/Card.vue';
    import Stat from '@/components/Estadisticas/Stat.vue';
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import { router } from '@/router/router';
    import { useEstadisticasStore } from '@/stores/estadisticas-store';
import { onBeforeMount } from 'vue';

    const estadisticasStore = useEstadisticasStore();

    function redirectToOperaciones(){
        router.replace({name: 'operaciones'})
    }

    function redirectToEquipos(){
        router.replace({name: 'equipos'})
    }

    function redirectToAgentes(){
        router.replace({name: 'agentes'})
    }

    function getEstadisticas(){
        estadisticasStore.getEstadisticas();
    }

    onBeforeMount(getEstadisticas)

</script>

<template>

    <LayoutSection>
        <div class="h-full w-full grid grid-cols-2 gap-10 grid-rows-[1fr_1fr]">

            <Card class="col-start-1 row-start-1">
                <template v-slot:body>
                     <h1 class="text-4xl font-bold tracking-tighter card-title">Bienvenido a CyberPulse Labs</h1>
                        <p class="pt-3 text-lg font-semibold leading-tight tracking-tighter text-primary ">Gestiona tus operaciones de manera
                        eficiente y gestiona tus equipos con otros agentes</p>
                        <div class="grid grid-cols-3 gap-5">
                            <Stat class="col-start-1" v-bind:number="estadisticasStore.agentesRegistrados" v-bind:hover="true" v-bind:title="'Agentes Activos'"></Stat>
                            <Stat class="col-start-2" v-bind:number="estadisticasStore.equiposFormados" v-bind:hover="true" v-bind:title="'Equipos Formados'"></Stat>
                            <Stat class="col-start-3" v-bind:number="estadisticasStore.operacionesCompletadas" v-bind:hover="true" v-bind:title="'Operaciones Completadas'"></Stat>                
                        </div>
                </template>
            </Card>
            
                <Card @click="redirectToAgentes" class="col-start-1 row-start-2">
                    <template v-slot:body>
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Gestionar agentes</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter"><span class="font-semibold text-primary">Actualiza periódicamente</span>
                        tu información profesional y credenciales para <span class="font-semibold text-primary">reflejar con precisión</span>
                        tu trayectoria, <span class="font-semibold text-primary">reforzar tu credibilidad</span>
                        y <span class="font-semibold text-primary">abrir oportunidades de negocio</span>.</p>
                    </template>
                </Card>

                <Card @click="redirectToEquipos" class="col-start-2 row-start-1">
                    <template v-slot:body>
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Gestiona tus equipos</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter"><span class="font-semibold text-primary">Organiza</span>
                        y <span class="font-semibold text-primary">supervisa</span> equipos de trabajo, sus miembros agentes y operaciones activas.</p>
                        <EstadisticasEquipo v-bind:hover="true"></EstadisticasEquipo>
                    </template>
                    
                </Card>

                <Card @click="redirectToOperaciones">
                    <template v-slot:body>
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Gestiona tus operaciones</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter"> <span class="font-semibold text-primary">Gestiona</span> 
                        todas las operaciones y <span class="font-semibold text-primary">controla</span> aquellas operaciones en curso.</p>
                        <EstadisticasOperaciones v-bind:hover="true"></EstadisticasOperaciones>
                    </template>
                </Card>

            </div>
    </LayoutSection>

  
   
</template>

<style scoped>


</style>