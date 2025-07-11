<script setup>
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Card from '@/components/Cards/Card.vue';
    import Search from '@/components/Search.vue';

</script>

<template>
   <LayoutSection>
    
    <div class="h-full w-full grid grid-cols-[70%_30%] grid-rows-3 gap-5">
        <Card class="col-start-1 row-span-full">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Información de la Operación</p>
                </div>
                

            </template>

            <template v-slot:body>
               
            </template>
        </Card>

        <Card class="col-start-2 row-start-1">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Asignar Equipo</p>
                </div>
            </template>
            
            <template v-slot:body>
             
            </template>

        </Card>

        <Card class="col-start-2 row-start-2">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Modificar Información</p>
                </div>
            </template>

            
            <template v-slot:body>
                <div class="flex flex-col gap-5">
                   
                </div>
                
                
            </template>

            <template v-slot:actions>
               
            </template>
        </Card>

        <Card class="col-start-2 row-start-3">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Eliminar Operación</p>
                </div>
            </template>

            
            <template v-slot:body>
                <div class="flex flex-col gap-5">
                   
                </div>
                
                
            </template>

            <template v-slot:actions>
               
            </template>
        </Card>
    </div>
    
    

   </LayoutSection>
</template>