 
 <script setup>

const props = defineProps({visible: boolean, default:false})

</script>

<template>

    <dialog v-if="props.visible" class="modal modal-open">
    
        <div class="modal-box text-center">
            <header>
                <slot name="header"></slot>
            </header>

            <main>
                <slot name="main"></slot>
            </main>
      
            <slot class="modal-action" name="actions"></slot>  
        </div>

  </dialog>


</template>

    