<script setup>

import Header from './Header.vue';



</script>

<template>
    <div class="pl-10 pr-10 flex flex-col min-h-screen bg-base-300">
        <Header class="backdrop-blur-lg flex"></Header>
        <div class="flex-1 flex justify-center items-center">

            <div class="grid auto-rows-2 grid-cols-2 gap-10">
            
                <section class="row-start-1 col-start-1 card p-3 shadow-xl shadow-primary/30 hover:shadow-primary/60 hover:scale-101 transition-all duration-300 bg-base-200">
                    <div class="card-body">
                        <h1 class="card-title text-4xl font-bold tracking-tighter">Bienvenido a CyberPulse Labs</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter ">Gestiona tus operaciones de manera <span class="text-primary font-semibold">eficiente</span> y gestiona tus equipos con otros agentes</p>
                        <div class="pt-5 grid grid-cols-3 gap-5">

                            <div class="col-start-1 card shadow-xl bg-base-100 hover:bg-primary/20 transition duration-300">
                                <div class="card-body justify-center items-center">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Agentes Activos</p>
                                </div>
                            </div>

                            <div class="col-start-2 card shadow-xl bg-base-100 hover:bg-primary/20 transition duration-300">
                                <div class="card-body justify-center items-center">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Equipos Formados</p>
                                </div>
                            </div>

                            <div class="col-start-3 card shadow-xl bg-base-100 hover:bg-primary/20 transition duration-300">
                                <div class="card-body justify-center items-center">
                                    <h2 class="card-title"> +0 </h2>
                                    <p class="text-xs">Operaciones Completadas</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            
                <section class="row-start-2 col-start-1 card p-3 shadow-xl shadow-primary/30  hover:shadow-primary/60 hover:scale-101 transition-all duration-300  bg-base-200">
                    <div class="card-body">
                        <h1 class="card-title text-4xl font-bold tracking-tighter">Gestionar agentes</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter">Actualiza periódicamente tu información profesional y credenciales para reflejar con precisión tu trayectoria, reforzar tu credibilidad y abrir nuevas oportunidades de negocio.</p>
                    </div>
                    <div class="card-actions justify-end">
                         <button class="btn">Buscar Agente</button>
                         <button class="btn btn-primary">Editar perfil de agente</button>
                    </div>
                </section>

                <section class="row-start-1 col-start-2 card p-3 shadow-xl shadow-primary/30  hover:shadow-primary/60 hover:scale-101 transition-all duration-300  bg-base-200">
                    <div class="card-body">
                        <h1 class="card-title text-4xl font-bold tracking-tighter">Gestiona tus equipos</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter">Organiza y supervisa equipos de trabajo, sus miembros agentes y operaciones activas.</p>
                        <div class="pt-5 grid grid-cols-2 gap-5">

                            <div class="col-start-1 card shadow-xl bg-base-100 hover:bg-primary/20 transition duration-300">
                                <div class="card-body justify-center items-center stat-card rounded-xl">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Equipos propios</p>
                                </div>
                            </div>

                            <div class="col-start-2 card shadow-xl bg-base-100 hover:bg-primary/20 transition duration-300">
                                <div class="card-body justify-center items-center">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Equipos ajenos</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-actions justify-end">
                         <button class="btn">Ver Equipos</button>
                         <button class="btn btn-primary">Gestionar Equipos</button>
                    </div>
                </section>

                <section class="row-start-2 col-start-2 card p-3 shadow-xl shadow-primary/30 hover:shadow-primary/60 hover:scale-101 transition-all duration-300 bg-base-200">
                    <div class="card-body">
                        <h1 class="card-title text-4xl font-bold tracking-tighter">Gestiona tus operaciones</h1>
                        <p class="pt-3 text-lg leading-tight tracking-tighter ">Gestiona todas las operaciones y controla aquellas operaciones en curso.</p>
                        <div class="pt-5 grid grid-cols-3 gap-5">

                            <div class="col-start-1 card shadow-xl bg-base-100 hover:bg-primary/20 transition duration-300">
                                <div class="card-body justify-center items-center">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Operaciones Planificadas</p>
                                </div>
                            </div>

                            <div class="col-start-2 card shadow-xl bg-base-100 hover:bg-primary/20 transition duration-300">
                                <div class="card-body justify-center items-center">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Operaciones Activas</p>
                                </div>
                            </div>

                            <div class="col-start-3 card shadow-xl bg-base-100 hover:bg-primary/20 transition duration-300">
                                <div class="card-body justify-center items-center">
                                    <h2 class="card-title"> 0 </h2>
                                    <p class="text-xs">Operaciones Completadas</p>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="card-actions justify-end">
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