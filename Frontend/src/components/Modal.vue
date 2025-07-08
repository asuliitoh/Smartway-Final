 
 <script setup>



</script>

<template>

    <dialog class="modal modal-open">
    
        <div class="modal-box text-center">
            <header>
                <slot name="header"></slot>
            </header>

            <body class="p-5">
                <slot name="body"></slot>
            </body>

            <div class="modal-action">
                <slot name="actions"></slot>  
            </div>
            
        </div>

  </dialog>


</template>

    