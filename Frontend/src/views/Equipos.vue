<script setup>
import GeneralStatsEquipos from '@/components/GeneralStatsEquipos.vue';
import Header from '@/components/Header.vue';
</script>

<template>

    <main class="flex flex-col w-screen h-screen">
        <Header></Header>
        <div class="flex-1 min-h-0 p-10">
             <div class="h-full w-full grid grid-rows-[auto_auto_1fr] grid-cols-2 gap-5">
                
                <label class="w-full row-start-1 shadow-xl col-span-full rounded-box shadow-primary/10 input">
                    <input type="search" placeholder="Buscar Equipo"/>
                </label>

                <section class="col-start-1 row-start-2 p-5 leading-tight tracking-tighter transition-all duration-300 shadow-xl col-span-full card shadow-primary/10 bg-base-200 text-primary hover:shadow-primary/60 hover:scale-101">
                    <h2 class="self-center card-title">Resumen General</h2>
                    <GeneralStatsEquipos class="card-body"></GeneralStatsEquipos>
                </section>

                <section class="row-start-3 p-5 transition-all duration-300 shadow-xl card shadow-primary/10 bg-base-200 hover:shadow-primary/60 hover:scale-101">
                    <h2 class="self-center font-semibold card-title text-primary"> Equipos propios</h2>
                    <div class="card-body">

                    </div>
                    <div class="justify-end card-actions">
                        <button type="button" class="btn btn-primary">Crear Nuevo Equipo</button>
                        <button type="button" class="btn btn-primary">Disolver Equipo</button>
                    </div>
                </section>

                <section class="col-start-2 row-start-3 p-5 transition-all duration-300 shadow-xl card shadow-primary/10 bg-base-200 hover:shadow-primary/60 hover:scale-101">
                    <h2 class="self-center font-semibold card-title text-primary"> Equipos en los que participas</h2>
                    <div class="card-body">

                    </div>
                    <div class="justify-end card-actions">
                        <button type="button" class="btn btn-primary">Solicitar Abandonar Equipo</button>
                    </div>
                </section>


             </div>
        </div>
    </main>

</template>
