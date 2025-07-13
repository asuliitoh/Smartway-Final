<!--Componente Modal personalizable-->
<template>
    <div class="max-w-none modal modal-open">
        <div class="text-center modal-box">
            <div class="max-w-none">
                <slot name="header"></slot>
            </div>

            <div class="p-5">
                <slot name="body"></slot>
            </div>

            <div class="modal-action">
                <slot name="actions"></slot>  
            </div>
        
        </div>
  </div>
</template>
