<!--Card es utilizado para definir las secciones que tiene cada página de la plataforma -->
<script setup>
    
    /**
     * Propiedad para indicar si la Card es horizontal o vertical.
     */
    const props = defineProps({
        horizontal: Boolean
    })
</script>

<template>

    <section class="p-3 transition-all duration-300 shadow-xl card shadow-primary/30 hover:shadow-primary/60 hover:scale-101 bg-base-200">
        
        <div class="card-title">
            <slot name="title"></slot>
        </div>

        <div class="card-body" :class="{'flex-row': props.horizontal}">
            <slot name="body"></slot>
        </div>

        <div class="justify-end card-actions">
            <slot name="actions"></slot>
        </div>

    </section>

</template>