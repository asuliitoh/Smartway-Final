<script setup>
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Card from '@/components/Cards/Card.vue';
    import Search from '@/components/Search.vue';

</script>

<template>
   <LayoutSection>
    
    <div class="h-full w-full grid grid-cols-[70%_30%] grid-rows-2 gap-5">
        <Card class="row-span-full col-start-1">
            <template v-slot:title>
                <div class="flex flex-row w-full justify-center">
                    <p class="text-primary">Información del Equipo</p>
                </div>

            </template>

            <template v-slot:body>
               
            </template>
        </Card>

        <Card class="row-start-1 col-start-2">
            <template v-slot:title>
                <div class="flex flex-row w-full justify-center">
                    <p class="text-primary">Gestionar Operaciones</p>
                </div>
            </template>

            
            <template v-slot:body>
               <p>Consulte y actualice las operaciones vinculadas al equipo, pulsando sobre la propia operación para acceder a más detalles.</p>
            </template>

        </Card>

        <Card class="row-start-2 col-start-2">
            <template v-slot:title>
                <div class="flex flex-row w-full justify-center">
                    <p class="text-primary">Añadir Agente al Equipo</p>
                </div>
            </template>

            
            <template v-slot:body>
                <div class="flex flex-col gap-5">
                    <p>Para añadir un agente, debe buscarlo a traves de su identificador. En el caso de que exista el agente asociado a dicho
                    identificador, se mostrará su información general y podrá añadirlo mediante <span class="text-primary font-semibold">Añadir</span>.
                    </p>
                    <Search :placeholder="'Buscar Agente'"></Search>
                </div>
                
                
            </template>

            <template v-slot:actions>
                <button type="button" class="btn btn-primary">Añadir</button>
            </template>
        </Card>
    </div>
    
    

   </LayoutSection>
</template>