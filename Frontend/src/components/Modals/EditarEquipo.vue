
<script setup>

</script>

<template>
    
      <Modal>
        <template v-slot:header>
            <p class="text-xl font-bold text-primary/80">Editar Equipo</p>
            <p class="pb-3 text-sm text-gray-600">Edita los datos de tu equipo, gestiona los miembros.</p>
        </template>

        <template v-slot:body>
            <div class="flex flex-col gap-4">

                <div class="flex flex-col gap-2">
                    <label class="text-xs label text-primary">Nombre del equipo</label>
                    <input type="text" v-model="nombre" class="w-full input bg-primary/10 border-primary/20" placeholder="Introduce el nombre del equipo">
                </div>

                <div class="flex flex-col gap-2">
                    <label class="text-xs label text-primary">Especialidad del equipo</label>
                    <input type="text" v-model="especialidad" class="w-full input bg-primary/10 border-primary/20" placeholder="Introduce la especialidad del equipo">
                </div>

            </div>            

        </template>

          <template v-slot:actions>
            <button @click="clear" type="button" class="btn">Cancelar</button>
            <button @click="newEquipo" type="button" class="btn btn-primary">Crear</button>
        </template>
        
    </Modal>
    
</template>