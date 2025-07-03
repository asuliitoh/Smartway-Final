<script setup>
    import GeneralStatsOperations from '@/components/GeneralStatsOperations.vue';
import Header from '@/components/Header.vue';
</script>

<template>

    <main class="flex flex-col min-h-screen">
        <Header></Header>
            <div class="grid grid-rows-[auto_auto_1fr] grid-cols-3 gap-5">
                
                <label class="w-full row-start-1 shadow-xl rounded-box shadow-primary/10 input col-span-full">
                    <input type="search" placeholder="Buscar Operación" />
                </label>

                <section class="col-span-2 col-start-1 row-start-2 p-5 leading-tight tracking-tighter shadow-xl card shadow-primary/10 bg-base-200 text-primary">
                    <h2 class="self-center card-title">Resumen General</h2>
                    <GeneralStatsOperations class="card-body"></GeneralStatsOperations>
                </section>

                <section class="col-span-2 col-start-1 row-start-3 p-5 shadow-xl card row-span-full shadow-primary/10 bg-base-200">
                    <h2 class="self-center card-title text-primary">Operaciones Totales</h2>
                    <div class="overflow-x-auto card-body">
                        <table class="table table-pin-rows">
                            <thead>
                                 <th>Id</th>
                                 <th>Nombre</th>
                                 <th>Estado</th>
                                 <th>Fecha Inicio</th>
                                 <th>Fecha Fin</th>
                            </thead>
                            <tbody>
                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Planificada</td>
                                    <td>03/07/25</td>
                                    <td>14/07/25</td>
                                </tr>

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Planificada</td>
                                    <td>03/07/25</td>
                                    <td>14/07/25</td>
                                </tr>

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Planificada</td>
                                    <td>03/07/25</td>
                                    <td>14/07/25</td>
                                </tr>

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Planificada</td>
                                    <td>03/07/25</td>
                                    <td>14/07/25</td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </section>

                <section class="col-start-3 row-start-2 p-5 shadow-xl card shadow-primary/10 bg-base-200">
                    
                    <h2 class="card-title text-primary">Crear nueva Operación</h2>
                </section>
                
                <section class="col-start-3 row-start-3 p-5 shadow-xl card shadow-primary/10 bg-base-200">
                    <h2 class="card-title text-primary">Tareas por finalizar</h2>
                </section>

            </div>
    </main>

</template>
