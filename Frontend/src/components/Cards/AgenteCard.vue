<script setup>
    import { computed } from 'vue'
    const props = defineProps({
    agenteBuscado: {
        type: Object,
        required: true,
    },
    })
    
</script>



<template>
  
  <div class="mx-auto rounded-box border border-primary/20 p-6 shadow-lg bg-primary/10">
    
    <div class="mb-4 flex flex-col">
        <h2 class="self-center text-lg font-medium text-primary">{{ agenteBuscado.nombre }} {{ agenteBuscado.apellidos }}</h2>
        <p class="self-start text-sm text-primary">ID#{{ agenteBuscado.id }}</p>
    </div>

    <div class="text-sm">

      <div class="flex justify-between">
        <p class="text-primary">Rango</p>
        <p class="font-medium">{{ agenteBuscado.rango }}</p>
      </div>

      <div class="flex justify-between">
        <p class="text-primary">Activo</p>
        <p class="font-medium">{{ agenteBuscado.activo ? 'Sí' : 'No' }}</p>
      </div>
    </div>
  </div>
</template>

