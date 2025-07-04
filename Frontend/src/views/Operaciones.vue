<script setup>
    import GeneralStatsOperations from '@/components/GeneralStatsOperations.vue';
import Header from '@/components/Header.vue';
</script>

<template>

    <main class="flex flex-col w-screen h-screen">
        <Header></Header>
         <div class="flex-1 min-h-0 p-10">

            <div class="h-full w-full grid grid-rows-[auto_auto_1fr] grid-cols-3 gap-5">
                
                <label class="w-full row-start-1 shadow-xl rounded-box shadow-primary/10 input col-span-full">
                    <input type="search" placeholder="Buscar Operación" />
                </label>

                <section class="col-span-2 col-start-1 row-start-2 p-5 leading-tight tracking-tighter transition-all duration-300 shadow-xl card shadow-primary/10 bg-base-200 text-primary hover:shadow-primary/60 hover:scale-101">
                    <h2 class="self-center card-title">Resumen General</h2>
                    <GeneralStatsOperations class="card-body"></GeneralStatsOperations>
                </section>

                <section class="col-span-2 col-start-1 row-start-3 p-5 transition-all duration-300 shadow-xl card row-span-full shadow-primary/10 bg-base-200 hover:shadow-primary/60 hover:scale-101">
                    <h2 class="self-center card-title text-primary">Tabla de Operaciones</h2>
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

                <section class="col-start-3 row-start-2 p-5 transition-all duration-300 shadow-xl card shadow-primary/10 bg-base-200 hover:shadow-primary/60 hover:scale-101">
                    <div class="card-title">
                        <img src="./icons/crear.png" alt="Crear Nueva Operación" class="w-fit h-fit">
                        <h2 class="text-lg text-primary">Crear Nueva Operación</h2>
                    </div>

                    <div class="card-body">
                        <p>Pulsa esta tarjeta para empezar a crear tu nueva operación;
                        al hacer clic se abrirá el formulario donde podrás introducir todos los detalles.</p>
                    </div>
                    
                </section>
                
                <section class="col-start-3 row-start-3 p-5 transition-all duration-300 shadow-xl card shadow-primary/10 bg-base-200 hover:shadow-primary/40 hover:scale-101">
                    <div class="card-title">
                        <img src="./icons/filtro.png" alt="Filtrar Operaciones" class="w-fit h-fit">
                        <h2 class="text-primary">Filtrar Operaciones</h2>
                    </div>

                    <div class="card-body">
                        <p>Seleccione el filtro que desee y pulse <span class="font-bold text-primary">Aplicar</span>
                        para filtrar la tabla de operaciones.</p>
                        <select class="w-full pl-1 text-xs rounded-box bg-primary/10">
                            <option selected>Por Estado</option>
                            <option>Planificada</option>
                            <option>Activa</option>
                            <option>Completada</option>
                        </select>

                        <select class="w-full pl-1 text-xs rounded-box bg-primary/10">
                            <option selected>Por Nombre</option>
                            <option>Orden Ascendente</option>
                            <option>Orden Descendente</option>
                        </select>

                        <checkbox class="w-full pl-2 text-xs rounded-box bg-primary/10">
                           Por Fecha Final
                        </checkbox>

                        <checkbox class="w-full pl-2 text-xs rounded-box bg-primary/10">
                           Por Equipo
                        </checkbox>

                    </div>

                    <div class="justify-end card-actions">
                        <button type="button" class="btn btn-primary">Aplicar</button>
                    </div>
                    
                </section>

            </div>


         </div>
    </main>

</template>
