<script setup>
import GeneralStatsEquipos from '@/components/GeneralStatsEquipos.vue';
import Card from '@/components/Card.vue';
import LayoutSection from '@/layouts/LayoutSection.vue';
import Search from '@/components/Search.vue';
</script>

<template>
    <LayoutSection>
          <div class="h-full w-full grid grid-rows-[auto_auto_1fr] grid-cols-2 gap-5">
         
                <Search class="w-full row-start-1 col-span-full" v-bind:placeholder="'Buscar Equipo'"></Search>

                <Card class="col-start-1 row-start-2 col-span-full">
                    <template v-slot:title>
                        <div class="flex flex-row items-center justify-center w-full text-center">
                            <img src="./icons/postcard.png" alt="Resumen General">
                            <h2 class="text-primary">Resumen General</h2>
                        </div>
                    </template>

                    <template v-slot:body>
                        <GeneralStatsEquipos></GeneralStatsEquipos>
                    </template>
                </Card>

                <Card class="row-start-3 overflow-auto">
                    <template v-slot:title>
                        <h2 class="w-full text-center text-primary"> Equipos propios</h2>
                    </template>

                    <template v-slot:body>
                        <table class="table table-pin-rows">
                             <thead>
                                 <th>Id</th>
                                 <th>Nombre</th>
                                 <th>Especialidad</th>    
                            </thead>
                            <tbody>
                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr> 

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr> 

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr> 

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr> 

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr> 
                            </tbody>
                        </table>
                    </template>

                    <template v-slot:actions>
                        <button type="button" class="btn btn-primary">Crear Nuevo Equipo</button>
                        <button type="button" class="btn btn-primary">Disolver Equipo</button>
                    </template>

                </Card>

                <Card class="col-start-2 row-start-3 overflow-auto">
                    <template v-slot:title>
                        <h2 class="w-full text-center text-primary"> Equipos en los que participas</h2>
                       
                    </template>

                    <template v-slot:body>
                         <table class="table table-pin-rows">
                             <thead>
                                 <th>Id</th>
                                 <th>Nombre</th>
                                 <th>Especialidad</th>
                                 
                            </thead>
                            <tbody>
                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                 <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>

                                <tr class="transition duration-300 hover:bg-primary/10">
                                    <th>1</th>
                                    <td>Ejemplo</td>
                                    <td>Ejemplo</td>
                                </tr>
                                
                            </tbody>
                        </table>
                    </template>

                    <template v-slot:actions>
                        <button type="button" class="btn btn-primary">Solicitar Abandonar Equipo</button>
                    </template>

                </Card>

             </div>
    </LayoutSection>
   

</template>
