<script setup>
    import GeneralStatsEquipos from '@/components/GeneralStatsEquipos.vue';
    import GeneralStatsOperations from '@/components/GeneralStatsOperations.vue';
    import Card from '@/components/Card.vue';
    import Stat from '@/components/Stat.vue';
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import { router } from '@/router/router';
    function redirectToOperaciones(){
        router.replace({name: 'operaciones'})
    }
</script>

<template>

    <LayoutSection>
        <div class="h-full w-full grid grid-cols-2 gap-10 grid-rows-[1fr_1fr]">

            <Card class="col-start-1 row-start-1">
                <template v-slot:body>
                     <h1 class="text-4xl font-bold tracking-tighter card-title">Bienvenido a CyberPulse Labs</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter ">Gestiona tus operaciones de manera <span class="font-semibold text-primary">eficiente</span> y gestiona tus equipos con otros agentes</p>
                        <div class="grid grid-cols-3 gap-5">
                            <Stat class="col-start-1" v-bind:number="'0'" v-bind:hover="true" v-bind:title="'Agentes Activos'"></Stat>
                            <Stat class="col-start-2" v-bind:number="'0'" v-bind:hover="true" v-bind:title="'Equipos Formados'"></Stat>
                            <Stat class="col-start-3" v-bind:number="'0'" v-bind:hover="true" v-bind:title="'Operaciones Completadas'"></Stat>                
                        </div>
                </template>
            </Card>
            
                <Card class="col-start-1 row-start-2">
                    <template v-slot:body>
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Gestionar agentes</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter">Actualiza periódicamente tu información profesional y credenciales para reflejar con precisión tu trayectoria, reforzar tu credibilidad y abrir nuevas oportunidades de negocio.</p>
                    </template>

                    <template v-slot:actions>
                        <button class="btn">Buscar Agente</button>
                        <button class="btn btn-primary">Editar perfil de agente</button>
                    </template>
                </Card>

                <Card class="col-start-2 row-start-1">
                    <template v-slot:body>
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Gestiona tus equipos</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter">Organiza y supervisa equipos de trabajo, sus miembros agentes y operaciones activas.</p>
                        <GeneralStatsEquipos v-bind:hover="true"></GeneralStatsEquipos>
                    </template>

                    <template v-slot:actions>
                        <button class="btn">Ver Equipos</button>
                        <button class="btn btn-primary">Gestionar Equipos</button>
                    </template>
                    
                </Card>

                <Card>
                    <template v-slot:body>
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Gestiona tus operaciones</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter ">Gestiona todas las operaciones y controla aquellas operaciones en curso.</p>
                        <GeneralStatsOperations v-bind:hover="true"></GeneralStatsOperations>
                    </template>

                    <template v-slot:actions>
                        <button @click="redirectToOperaciones" class="btn">Ver Operaciones</button>
                        <button class="btn btn-primary">Crear Nueva Operación</button>
                    </template>
                </Card>

            </div>
    </LayoutSection>

  
   
</template>

<style scoped>


</style>