import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { ref, reactive } from "vue";


export const useOperacionesStore = defineStore('operaciones-store', ()  => {

    const operaciones = reactive(new Map())

    function setOperaciones(response){
        for (let i = 0 ; i < response.data.length ; i++){
                operaciones.set(response.data[i].id, response.data[i]);
            }
            
    }

    async function getAllOperaciones() {
        await axiosInstance.get('Operacion').then((response) => {
            setOperaciones(response);
            console.log(response)
            console.log(operaciones)
        });
    }

    async function newOperacion(data){
    
         await axiosInstance.post('Operacion', data).then((response) => {
            console.log(response.data);
            operaciones.set(response.data.id, response.data)
        });
    }

 
    
    return {operaciones, getAllOperaciones, newOperacion}

})