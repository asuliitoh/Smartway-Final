 
 <script setup>



</script>

<template>

    <dialog class="modal modal-open">
    
        <div class="modal-box text-center">
            <div>
                <slot name="header"></slot>
            </div>

            <div class="p-5">
                <slot name="body"></slot>
            </div>

            <div class="modal-action">
                <slot name="actions"></slot>  
            </div>
            
        </div>

  </dialog>


</template>

    