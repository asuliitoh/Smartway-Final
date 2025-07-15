<!--Operaciones permite al usuario ver sus operaciones, crear nuevas operaciones y aplicar filtros-->
<script setup>

    import EstadisticasOperaciones from '@/components/Estadisticas/EstadisticasOperaciones.vue';
    import Card from '@/components/Cards/Card.vue';
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import NewOperation from '@/components/Modals/NewOperacion.vue';
    import { ref, computed } from 'vue';
    import TablaOperaciones from '@/components/Tablas/TablaOperaciones.vue';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    import { onBeforeMount } from 'vue';
    import { router } from '@/router/router';
    
    /**
     * Store de Operaciones, utilizado para obtener las opreaciones, crear nuevas operaciones y aplicar filtros.
     */
    const operacionesStore = useOperacionesStore()

    /**
     * Booleano reactivo utilizado para mostrar/ocultar un Modal para la creación de una nueva operación.
     */
    const newOperationModal = ref(false)

    /**
     * Objeto reactivo utilizado para almacenar la operación seleccionada por el agente.
     */
    const operacionSeleccionada = ref(null)
    
    /**
     * Filtro actual de Estado.
     */
    const filtroEstado = ref("ninguno");

    /**
     * Filtro actual de Periodo.
     */
    const filtroPeriodo = ref("ninguno");

    /**
     * Filtro actual de Equipo.
     */
    const filtroEquipo = ref(null);

    /**
     * Fecha de inicio del periodo personalizado.
     */
    const periodoPersonalizadoInicio = ref(null);
    
    /**
     * Fecha final del periodo personalizado.
     */
    const periodoPersonalizadoFinal = ref(null);

    /**
     * Computed que devuelve un objeto {fechaInicio, fechaFinal} según el filtro de periodo elegido.
     */
    const filtroPeriodoObjeto = computed (() => {
        const inicio = new Date();
        const final = new Date(inicio);
    
        if (filtroPeriodo.value === "semana") {
            inicio.setDate(inicio.getDate() - 7);
            return {inicio:inicio, final:final}
        };
        if (filtroPeriodo.value === "mes") {
            inicio.setDate(inicio.getMonth() - 1);
             return {inicio:inicio, final:final}
        }
        
        if (filtroPeriodo.value === "personalizado") {

            if(periodoPersonalizadoInicio.value && periodoPersonalizadoFinal.value) {

                return {inicio: new Date(periodoPersonalizadoInicio.value), final: new Date(periodoPersonalizadoFinal.value) }
            }

            else return null;
        }
    })

    
    /**
     * Función utilizada para obtener las operaciones del agente actual.
     */
    function getOperaciones(){
        operacionesStore.getAllOperaciones();
    }

    /**
     * Función utilizada para redirigir a la vista de la operación seleccionada.
     */
    function redirectToOperacion(){
        if (operacionSeleccionada.value) router.replace({name: 'operacion', params:{operacionId:operacionSeleccionada.value}})
    }

    onBeforeMount(getOperaciones)

</script>

<template>
    
    <LayoutSection>
        <div class="h-full w-full grid  grid-rows-[auto_auto_auto_auto] grid-cols-1 lg:grid-rows-[auto_1fr] lg:grid-cols-3 gap-5">
                
                <Card class="lg:col-span-2 lg:col-start-1 lg:row-start-1">
                    <template v-slot:title>
                        <div class="flex items-center justify-center w-full">
                            <img src="./icons/postcard.png" class="img-section-card" alt="Resumen General">
                            <h2 class="w-auto h2-section-card">Resumen General</h2>
                        </div>
                            
                    </template>
                    <template v-slot:body>
                        <EstadisticasOperaciones></EstadisticasOperaciones>
                    </template>


                </Card>

                <Card class="lg:col-span-2 lg:col-start-1 lg:row-start-2">
                    <template v-slot:title>
                        <h2 class="w-full text-center h2-section-card">Tabla de Operaciones</h2>
                    </template>
                    <template v-slot:body>
                        <TablaOperaciones v-model="operacionSeleccionada" :operaciones="operacionesStore.operacionesFiltradas(filtroEstado, filtroPeriodoObjeto, filtroEquipo)"></TablaOperaciones>
                    </template>

                    <template v-slot:actions>
                        <button v-if="operacionSeleccionada" @click="redirectToOperacion" type="button" class="btn btn-primary">Ver Operación</button>
                    </template>

                </Card>

              <Card @click="newOperationModal = true" class="cursor-pointer lg:col-start-3 lg:row-start-1">
                <template v-slot:title>
                    <img src="./icons/crear.png" alt="Crear Nueva Operación" class="img-section-card">
                    <h2 class="h2-section-card">Crear Nueva Operación</h2>
                </template>

                <template v-slot:body>
                    <p class="p-card">Pulsa esta tarjeta para empezar a crear tu <span class="font-semibold text-primary">nueva operación</span>;
                    al hacer clic se abrirá el formulario donde podrás introducir todos los detalles.</p>
                </template>
              </Card>

              <Card class="lg:col-start-3 lg:row-start-2">

                <template v-slot:title>
                    <img src="./icons/filtro.png" alt="Filtrar Operaciones" class="img-section-card">
                    <h2 class="h2-section-card">Filtrar Operaciones</h2>
                </template>

                <template v-slot:body>
                    <div class>
                        <p class="p-card">Seleccione el filtro que desee y pulse <span class="font-bold text-primary">Aplicar</span>
                        para filtrar la tabla de operaciones.</p>
                    </div>

                    <div class="grid w-full h-full grid-rows-3 place-items-center lg:place-items-stretch">
                        <div>
                            <label class="text-xs break-words text-primary">Estado de la operación</label>
                            <select v-model="filtroEstado" class="w-full pl-1 text-xs border rounded-sm join-item bg-primary/10 border-primary/50">
                                <option selected value="ninguno">Todos los Estados</option>
                                <option value="Planificado">Planificada</option>
                                <option value="Activo">Activa</option>
                                <option value="Completado">Completada</option>
                            </select>
                        </div>
                        
                        <div>
                            <label class="text-xs text-primary">Periodo de Tiempo</label>
                            <select v-model="filtroPeriodo" class="w-full pl-1 text-xs border rounded-sm join-item bg-primary/10 border-primary/50">
                                <option selected value="ninguno">Sin Periodo Concreto</option>
                                <option value="semana">Última Semana</option>
                                <option value="mes">Último Mes</option>
                                <option value="personalizado">Periodo Personalizado</option>
                            </select>
                        </div>

                        <div v-if="filtroPeriodo === 'personalizado'">
                            <input type="date" v-model="periodoPersonalizadoInicio" class="w-full px-2 py-1 border rounded" />
                            <input type="date" v-model="periodoPersonalizadoFinal"  class="w-full px-2 py-1 border rounded" />
                        </div>

                        <div>
                            <label class="text-xs text-primary">Equipo Asignado</label>
                            <input v-model="filtroEquipo" type="search" class="w-full pl-1 text-xs border rounded-sm h-fit join-item bg-primary/10 border-primary/50" placeholder="Introduce el ID del equipo"/>
                        </div>
                        

                    </div>

                        
                </template>

              </Card>
            </div>
        <NewOperation v-if="newOperationModal" v-model="newOperationModal"></NewOperation>
    </LayoutSection>



</template>
