<!--Home es la página principal tras el inicio de sesión. Muestra estadísticas globales y accesos rápidos a las secciones-->
<script setup>
   
    import EstadisticasEquipo from '@/components/Estadisticas/EstadisticasEquipo.vue';
    import EstadisticasOperaciones from '@/components/Estadisticas/EstadisticasOperaciones.vue';
    import Card from '@/components/Cards/Card.vue';
    import Stat from '@/components/Estadisticas/Stat.vue';
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import { router } from '@/router/router';
    import { useEstadisticasStore } from '@/stores/estadisticas-store';
    import { onBeforeMount } from 'vue';

    /**
     * Store de estadísticas, utilizado para recuperar las estadísticas generales de la plataforma.
     */
    const estadisticasStore = useEstadisticasStore();

    /**
     * Función utilizada para redirigir la vista a la sección Operaciones.
     */
    function redirectToOperaciones(){
        router.replace({name: 'operaciones'});
    }

    /**
     * Función utilizada para redirigir la vista a la sección Equipos.
     */
    function redirectToEquipos(){
        router.replace({name: 'equipos'});
    }

    /**
     * Función utilizada para redirigir la vista a la sección Agentes.
     */
    function redirectToAgentes(){
        router.replace({name: 'agentes'});
    }

    /**
     * Función utilizada para obtener las estadísticas generales de la plataforma.
     */
    function getEstadisticas(){
        estadisticasStore.getEstadisticas();;
    }

    onBeforeMount(getEstadisticas)

</script>

<template>

    <LayoutSection>
        <div class="h-full w-full grid grid-cols-1 lg:grid-cols-2 gap-10 grid-rows-[auto_auto_auto_auto] lg:grid-rows-[1fr_1fr]">

            <Card class="w-full h-full row-start-1 md:col-start-1">
                <template v-slot:body>
                     <div class="shrink-0 h-full w-full grid lg:grid-rows-[auto_auto_auto] xl:grid-rows-[20%_20%_60%] gap-2">
                        <h2 class="h2-home-card">Bienvenido a CyberPulse Labs</h2>
                        <p class="p-card">Gestiona tus operaciones de manera
                        eficiente y gestiona tus equipos con otros agentes</p>
                        <div class="grid grid-cols-1 gap-5 sm:grid-cols-3 xl:grid-cols-3 place-items-center xl:gap-10">
                            <Stat v-bind:number="estadisticasStore.agentesRegistrados" v-bind:hover="true" v-bind:title="'Agentes Activos'"></Stat>
                            <Stat v-bind:number="estadisticasStore.equiposFormados" v-bind:hover="true" v-bind:title="'Equipos Formados'"></Stat>
                            <Stat v-bind:number="estadisticasStore.operacionesCompletadas" v-bind:hover="true" v-bind:title="'Operaciones Completadas'"></Stat>                
                        </div>
                        </div>
                </template>
            </Card>
            
                <Card @click="redirectToAgentes" class="w-full h-full row-start-2 lg:col-start-1">
                    
                    <template v-slot:body>
                        <div class="w-full h-full grid lg:grid-rows-[auto_auto_auto] xl:grid-rows-[20%_20%_60%] gap-2">
                           <h2 class="h2-home-card">Gestionar agentes</h2>
                            <p class="p-card"><span class="font-semibold text-primary">Actualiza periódicamente</span>
                            tu información profesional y credenciales para <span class="font-semibold text-primary">reflejar con precisión</span>
                            tu trayectoria, <span class="font-semibold text-primary">reforzar tu credibilidad</span>
                            y <span class="font-semibold text-primary">abrir oportunidades de negocio</span>.</p>
                        </div>
                    </template>
                </Card>

                <Card @click="redirectToEquipos" class="w-full h-full row-start-3 lg:row-start-1 lg:col-start-2">
                    <template v-slot:body>
                        <div class="w-full h-full grid lg:grid-rows-[auto_auto_auto] xl:grid-rows-[20%_20%_60%] gap-2">
                            <h2 class="h2-home-card">Gestiona tus equipos</h2>
                           <p class="p-card"><span class="font-semibold text-primary">Organiza</span>
                            y <span class="font-semibold text-primary">supervisa</span> equipos de trabajo, sus miembros agentes y operaciones activas.</p>
                            <EstadisticasEquipo v-bind:hover="true"></EstadisticasEquipo>
                        </div>
                        
                    </template>
                    
                </Card>

                <Card @click="redirectToOperaciones" class="w-full h-full row-start-4 lg:row-start-2 lg:col-start-2">
                    <template v-slot:body>
                        <div class="w-full h-full grid lg:grid-rows-[auto_auto_auto] xl:grid-rows-[20%_20%_60%] gap-2">
                            <h2 class="h2-home-card">Gestiona tus operaciones</h2>
                            <p class="p-card"> <span class="font-semibold text-primary">Gestiona</span> 
                            todas las operaciones y <span class="font-semibold text-primary">controla</span> aquellas operaciones en curso.</p>
                            <EstadisticasOperaciones v-bind:hover="true"></EstadisticasOperaciones>
                        </div>
                    </template>
                </Card>

            </div>
    </LayoutSection>

  
   
</template>

<style scoped>


</style>