import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { ref, computed , reactive } from "vue";


export const useOperacionesStore = defineStore('operaciones-store', ()  => {

    const operaciones = reactive(new Map())
    const numeroOperacionesPlanificadas = computed(() => {
        var i = 0;
        operaciones.forEach((value, key) => {
            if (value.estado === "PLANIFICADO") i=i+1;
        })
        return i;
    })

    const numeroOperacionesActivas = computed(() => {
        var i = 0;
        operaciones.forEach((value, key) => {
            if (value.estado === "ACTIVO") i=i+1;
        })
        return i;
    })

    
    const numeroOperacionesCompletadas = computed(() => {
        var i = 0;
        operaciones.forEach((value, key) => {
            if (value.estado === "COMPLETADO") i=i+1;
        })
        return i;
    })


    function clear(){
        operaciones.clear()
    }

    function setOperaciones(response){
        for (let i = 0 ; i < response.data.length ; i++){
                operaciones.set(response.data[i].id, response.data[i]);
            }
            
    }

    async function getAllOperaciones() {
        await axiosInstance.get('Operacion').then((response) => {
            setOperaciones(response);      
        });
    }

    async function newOperacion(data){
    
         await axiosInstance.post('Operacion', data).then((response) => {
            operaciones.set(response.data.id, response.data)
        });
    }

    async function deleteOperacion(id){
        await axiosInstance.delete(`/Operacion/${id}`).then(this.operaciones.delete(id));
    }
 
    
    return {operaciones, numeroOperacionesActivas, numeroOperacionesPlanificadas,
        numeroOperacionesCompletadas, getAllOperaciones, newOperacion, deleteOperacion, clear}

})