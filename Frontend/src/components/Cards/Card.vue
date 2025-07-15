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

    <section class="p-1 transition-all duration-300 shadow-xl sm:p-2 md:p-3 card shadow-primary/30 hover:shadow-primary/60 hover:scale-101 bg-base-200">
        
        <div id="title" class="card-title">
            <slot name="title"></slot>
        </div>

        <div id="body" class="card-body @container" :class="{'md:flex-row': props.horizontal}">
            <slot name="body"></slot>
        </div>

        <div id="actions" class="justify-end card-actions">
            <slot name="actions"></slot>
        </div>

    </section>

</template>
