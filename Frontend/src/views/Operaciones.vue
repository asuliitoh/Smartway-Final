<script setup>
    import GeneralStatsOperations from '@/components/GeneralStatsOperations.vue';
    import Card from '@/components/Card.vue';
import LayoutSection from '@/layouts/LayoutSection.vue';
import Search from '@/components/Search.vue';
</script>

<template>
    
    <LayoutSection>
        <div class="h-full w-full grid grid-rows-[auto_auto_1fr] grid-cols-3 gap-5">
                
                <Search class="w-full row-start-1 col-span-full" v-bind:placeholder="'Buscar Operación'"></Search>

                <Card class="col-span-2 col-start-1 row-start-2">
                    <template v-slot:title>
                        <div class="flex flex-row items-center justify-center w-full text-center">
                            <img src="./icons/postcard.png" alt="Resumen General">
                            <h2 class="text-primary">Resumen General</h2>
                        </div>
                    </template>
                    <template v-slot:body>
                        
                        <GeneralStatsOperations></GeneralStatsOperations>
                    </template>


                </Card>

                <Card class="col-span-2 col-start-1 row-start-3">
                    <template v-slot:body>
                        <h2 class="self-center card-title text-primary">Tabla de Operaciones</h2>
                        <table class="table overflow-x-auto table-pin-rows">
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
                    </template>
                </Card>

              <Card class="col-start-3 row-start-2 cursor-pointer">
                <template v-slot:title>
                    <img src="./icons/crear.png" alt="Crear Nueva Operación" class="w-fit h-fit">
                    <h2 class="text-lg text-primary">Crear Nueva Operación</h2>
                </template>

                <template v-slot:body>
                    <p>Pulsa esta tarjeta para empezar a crear tu nueva operación;
                    al hacer clic se abrirá el formulario donde podrás introducir todos los detalles.</p>
                </template>
              </Card>

              <Card class="col-start-3 row-start-3">

                <template v-slot:title>
                    <img src="./icons/filtro.png" alt="Filtrar Operaciones" class="w-fit h-fit">
                    <h2 class="text-primary">Filtrar Operaciones</h2>
                </template>

                <template v-slot:body>
                    <div class="join join-vertical">
                        <p class="join-item">Seleccione el filtro que desee y pulse <span class="font-bold text-primary">Aplicar</span>
                        para filtrar la tabla de operaciones.</p>
                    </div>
                    
                        <select class="w-full pl-1 text-xs join-item rounded-box bg-primary/10">
                            <option selected>Por Estado</option>
                            <option>Planificada</option>
                            <option>Activa</option>
                            <option>Completada</option>
                        </select>

                        <select class="w-full pl-1 text-xs join-item rounded-box bg-primary/10">
                            <option selected>Por Nombre</option>
                            <option>Orden Ascendente</option>
                            <option>Orden Descendente</option>
                        </select>

                        <checkbox class="w-full pl-2 text-xs join-item rounded-box bg-primary/10">
                           Por Fecha Final
                        </checkbox>

                        <checkbox class="w-full pl-2 text-xs join-item rounded-box bg-primary/10">
                           Por Equipo
                        </checkbox>

                </template>

                <template v-slot:actions>
                    <button type="button" class="btn btn-primary">Aplicar</button>
                </template>

              </Card>

            </div>
    </LayoutSection>

</template>
