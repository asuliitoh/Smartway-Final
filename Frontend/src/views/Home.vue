<script setup>
    import GeneralStatsOperations from '@/components/GeneralStatsOperations.vue';
import Header from '@/components/Header.vue';
</script>

<template>
    <div class="flex flex-col min-h-screen">
        <Header class="flex"></Header>
        <div class="flex items-center justify-center flex-1">

            <div class="grid grid-cols-2 gap-10 auto-rows-2">
            
                <section class="col-start-1 row-start-1 p-3 transition-all duration-300 shadow-xl card shadow-primary/30 hover:shadow-primary/60 hover:scale-101 bg-base-200">
                    <div class="card-body">
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Bienvenido a CyberPulse Labs</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter ">Gestiona tus operaciones de manera <span class="font-semibold text-primary">eficiente</span> y gestiona tus equipos con otros agentes</p>
                        <div class="grid grid-cols-3 gap-5 pt-5">

                            <div class="col-start-1 transition duration-300 shadow-xl card bg-base-100 hover:bg-primary/20">
                                <div class="items-center justify-center card-body">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Agentes Activos</p>
                                </div>
                            </div>

                            <div class="col-start-2 transition duration-300 shadow-xl card bg-base-100 hover:bg-primary/20">
                                <div class="items-center justify-center card-body">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Equipos Formados</p>
                                </div>
                            </div>

                            <div class="col-start-3 transition duration-300 shadow-xl card bg-base-100 hover:bg-primary/20">
                                <div class="items-center justify-center card-body">
                                    <h2 class="card-title"> +0 </h2>
                                    <p class="text-xs">Operaciones Completadas</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            
                <section class="col-start-1 row-start-2 p-3 transition-all duration-300 shadow-xl card shadow-primary/30 hover:shadow-primary/60 hover:scale-101 bg-base-200">
                    <div class="card-body">
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Gestionar agentes</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter">Actualiza periódicamente tu información profesional y credenciales para reflejar con precisión tu trayectoria, reforzar tu credibilidad y abrir nuevas oportunidades de negocio.</p>
                    </div>
                    <div class="justify-end card-actions">
                         <button class="btn">Buscar Agente</button>
                         <button class="btn btn-primary">Editar perfil de agente</button>
                    </div>
                </section>

                <section class="col-start-2 row-start-1 p-3 transition-all duration-300 shadow-xl card shadow-primary/30 hover:shadow-primary/60 hover:scale-101 bg-base-200">
                    <div class="card-body">
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Gestiona tus equipos</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter">Organiza y supervisa equipos de trabajo, sus miembros agentes y operaciones activas.</p>
                        <div class="grid grid-cols-2 gap-5 pt-5">

                            <div class="col-start-1 transition duration-300 shadow-xl card bg-base-100 hover:bg-primary/20">
                                <div class="items-center justify-center card-body stat-card rounded-xl">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Equipos propios</p>
                                </div>
                            </div>

                            <div class="col-start-2 transition duration-300 shadow-xl card bg-base-100 hover:bg-primary/20">
                                <div class="items-center justify-center card-body">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Equipos ajenos</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="justify-end card-actions">
                         <button class="btn">Ver Equipos</button>
                         <button class="btn btn-primary">Gestionar Equipos</button>
                    </div>
                </section>

                <section class="col-start-2 row-start-2 p-3 transition-all duration-300 shadow-xl card shadow-primary/30 hover:shadow-primary/60 hover:scale-101 bg-base-200">
                    <div class="card-body">
                        <h1 class="text-4xl font-bold tracking-tighter card-title">Gestiona tus operaciones</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter ">Gestiona todas las operaciones y controla aquellas operaciones en curso.</p>
                        <GeneralStatsOperations v-bind:hover="true"></GeneralStatsOperations>
                    </div>
                    <div class="justify-end card-actions">
                         <button class="btn">Ver Operaciones</button>
                         <button class="btn btn-primary">Gestionar Operaciones</button>
                    </div>
                </section>
        
            </div>

        </div>

    </div>
   
</template>

<style scoped>


</style>