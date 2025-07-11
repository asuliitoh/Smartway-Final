import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { ref, reactive } from "vue";


export const useOperacionesStore = defineStore('operaciones-store', ()  => {

    const operaciones = reactive(new Map())

    function setOperaciones(response){
        for (let i = 0 ; i < response.data.length ; i++){
                console.log(response.data[i])
                operaciones.set(response.data[i].id, response.data[i]);
            }
            
    }

    async function getAllOperaciones() {
        await axiosInstance.get('Operacion').then((response) => {
            setOperaciones(response);
            
            console.log(response)
            
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
 
    
    return {operaciones, getAllOperaciones, newOperacion, deleteOperacion}

})