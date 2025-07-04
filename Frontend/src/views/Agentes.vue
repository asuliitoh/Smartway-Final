<script setup>
    import Card from '@/components/Card.vue';
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Search from '@/components/Search.vue';
</script>

<template>

    <LayoutSection>
        <div class="h-full w-full grid grid-rows-[50%_50%] grid-cols-[80%_20%] gap-5">
                
            <Card class="row-start-1" v-bind:horizontal="true">
                <template v-slot:body>
                    <div class="w-[25%]">
                                <h2 class="card-title text-primary">Información personal</h2>
                                <p>Modifica tu información personal aqui.</p>  
                    </div>

                    <fieldset class="w-[75%] p-5 border border-gray-300 bg-primary/10 fieldset rounded-box shadow-lg">
                                
                                <div class="flex flex-row w-full gap-5">
                                    <div>
                                        <label class="label text-primary">Nombre</label>
                                        <input type="text" class="input bg-primary/20 border-primary/40" placeholder="Ejemplo">
                                    </div>
                                    
                                    <div>
                                        <label class="label text-primary">Apellidos</label>
                                        <input type="text" class="input bg-primary/20 border-primary/40" placeholder="Ejemplo">
                                    </div>

                                </div>
                                
                                <label class="label text-primary">Rango</label>
                                <input disabled type="text" class="input disabled:bg-primary/20 disabled:border-primary/40" placeholder="Activo">

                                <label class="label text-primary">Estado</label>
                                <input disabled type="text" class="input disabled:bg-primary/20 disabled:border-primary/40" placeholder="Activo">
                            
                            <div class="flex gap-3 justify-self-end">
                                <button type="button" class="btn btn-ghost">Cancelar</button>
                                <button type="button" class="font-semibold btn text-primary hover:text-primary-content btn-primary btn-ghost">Aceptar</button>
                            </div>
                    </fieldset>
                </template>
            </Card>

            <Card class="row-start-2" v-bind:horizontal="true">
                <template v-slot:body>
                    <div class="w-[25%]"> 
                        <h2 class="card-title text-primary">Cambiar contraseña</h2>
                        <p>Introduce tu contraseña actual y la nueva contraseña que desea para actualizarla.</p>
                    </div>
                    
                    <fieldset class="w-[75%] p-5 border border-gray-300 bg-primary/10 fieldset rounded-box shadow-lg">
                        <label class="label text-primary">Contraseña Actual</label>
                        <input type="password" class="input bg-primary/20 border-primary/40" placeholder="Introduce tu contraseña actual">

                        <label class="label text-primary">Contraseña Nueva</label>
                        <input type="password" class="input bg-primary/20 border-primary/40" placeholder="Introduce una nueva contraseña">

                        <label class="label text-primary">Confirmar Contraseña</label>
                        <input type="password" class="input bg-primary/20 border-primary/40" placeholder="Confirme la contraseña nueva">
                        
                        <div class="flex gap-3 justify-self-end">
                            <button type="button" class="btn btn-ghost">Cancelar</button>
                            <button type="button" class="font-semibold btn text-primary hover:text-primary-content btn-primary btn-ghost">Aceptar</button>
                        </div>
                    </fieldset>
                </template>
            </Card>

            <Card class="col-start-2 row-span-full">
                <template v-slot:title>
                    <img src="./icons/buscar.png" alt="Buscar Agente" class="w-fit h-fit">
                    <h2 class="text-primary">Buscar Agente</h2>
                </template>

                <template v-slot:body>
                    <div class="join join-vertical">
                        <p class="self-center pt-3 pb-5 text-sm text-center">Introduzca el <span class="font-semibold text-primary">identificador del agente</span> para ver su información. Pulse Enter para buscar.</p>
                        <Search class="w-[75%] self-center row-start-1 col-span-full" v-bind:placeholder="'Buscar Agente'"></Search>
                        
                    </div>
                </template>
            </Card>

            </div>            
    </LayoutSection>

</template>
