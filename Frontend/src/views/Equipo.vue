<script setup>
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Card from '@/components/Cards/Card.vue';
    import Search from '@/components/Search.vue';
    import DisolverEquipo from '@/components/Modals/DisolverEquipo.vue';
    import { ref } from 'vue';
    import { useAgenteStore } from '@/stores/agente-store';
    import { useEquiposStore } from '@/stores/equipos-store';
    import AgenteCard from '@/components/Cards/AgenteCard.vue';
    
    const equipoStore = useEquiposStore();
    const store = useAgenteStore();
    const agenteBuscado = ref(null)
    const seHaBuscado = ref(false)
    const disolverEquipoModal = ref(false);
    const props = defineProps(["equipoId"]);

    function setAgenteBuscado(agente){
        seHaBuscado.value = true;
        agenteBuscado.value=agente;
    }
     
    function disolverEquipo(){
        disolverEquipoModal.value = true;
    }

    function enviarSolicitud(){
        if (agenteBuscado.value) equipoStore.enviarSolicitud(agenteBuscado.value.id, props.equipoId);
    }
    

    
    async function buscarAgente(id){
        const agente = await store.getInformacionAgente(id);
        return agente;
    }


</script>

<template>
   <LayoutSection>
    
    <div class="h-full w-full grid grid-cols-[70%_30%] grid-rows-[auto_auto_auto] gap-5">
        <Card class="col-start-1 row-span-full">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Información del Equipo</p>
                </div>

                

            </template>

            <template v-slot:body>
               
            </template>
        </Card>

        <Card class="col-start-2 row-start-1">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Gestionar Miembros</p>
                </div>
            </template>

            
            <template v-slot:body>
               <p>Consulte y actualice las operaciones vinculadas al equipo, pulsando sobre la propia operación para acceder a más detalles.</p>
            </template>

        </Card>

        <Card class="col-start-2 row-start-2">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Añadir Agente al Equipo</p>
                </div>
            </template>

            
            <template v-slot:body>
                <div v-if="!agenteBuscado" class="flex flex-col gap-5">
                    <p>Para añadir un agente, debe buscarlo a traves de su identificador. En el caso de que exista el agente asociado a dicho
                    identificador, se mostrará su información general y podrá añadirlo mediante <span class="font-semibold text-primary">Añadir</span>.
                    </p>
                    <Search @searched="(agente) => {setAgenteBuscado(agente)}" v-bind:function="buscarAgente" v-bind:placeholder="'Buscar Agente'"></Search>
                </div>

                <AgenteCard v-else v-bind:agente-buscado="agenteBuscado" class="w-full"></AgenteCard>
                
                
            </template>

            <template v-slot:actions>
                <button v-if="agenteBuscado" @click="agenteBuscado = null" type="button" class="btn">Cancelar</button>
                <button @click="enviarSolicitud" type="button" class="btn btn-primary">Añadir</button>
            </template>
        </Card>

        <Card @click="disolverEquipo" class="col-start-2 row-start-3">
            <template v-slot:title>
                 <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Disolver Equipo</p>
                </div>
            </template>

            <template v-slot:body>
                <p>Una vez eliminada, toda la información asociada a esta operación se perderá definitivamente.
                <span class="font-semibold text-primary">Esta acción no se puede deshacer.</span></p>
        
            </template>

        </Card>
    </div>

     <DisolverEquipo v-model="disolverEquipoModal" :seleccionado="props.equipoId"></DisolverEquipo>
    
   </LayoutSection>

   
</template>