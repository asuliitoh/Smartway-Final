import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import {computed , reactive } from "vue";

/**
 * Store de Operaciones, utilizado para  obtener, crear, eliminar, editar y asignar equipo a operaciones del agente actual.
 */
export const useOperacionesStore = defineStore('operaciones-store', ()  => {

    const operaciones = reactive(new Map()) //Operaciones del agente actual.

    //Número de operaciones planificadas del agente actual.
    const numeroOperacionesPlanificadas = computed(() => {
        var i = 0;
        operaciones.forEach((value, key) => {
            if (value.estado === "Planificado") i=i+1;
        })
        return i;
    })

    //Número de operaciones activas del agente actual.
    const numeroOperacionesActivas = computed(() => {
        var i = 0;
        operaciones.forEach((value, key) => {
            if (value.estado === "Activo") i=i+1;
        })
        return i;
    })

    //Número de operaciones completadas del agente actual.
    const numeroOperacionesCompletadas = computed(() => {
        var i = 0;
        operaciones.forEach((value, key) => {
            if (value.estado === "Completado") i=i+1;
        })
        return i;
    })

    //Función auxiliar para pasar de String con formato 'dd-mm-yyyy' a Date.
    function newDate(date){
        const [d, m, y] = date.split('/').map(Number);
        return new Date(y, m - 1, d);
    }

    //Operaciones del agente actual, aplicadas los filtros.
    const operacionesFiltradas = function (estado, periodo, equipo){

        var op = Array.from(operaciones.entries());
        if (estado && estado !== "ninguno") op = op.filter(([key, value]) => value.estado === estado);
        if (periodo && periodo !== "ninguno") op = op.filter(([key, value]) => {
            const fechaInicio = newDate(value.fechaInicio);
            const fechaFinal = newDate(value.fechaFinal);
            return ((periodo.inicio <= fechaInicio) && (fechaFinal <= periodo.final));

        });
        if (equipo && equipo != "") op = op.filter(([key, value]) => Number(value.equipoId) == Number(equipo));
        return new Map(op);
        }


    //Función utilizada para restaurar el estado de la Store al cerrar sesión el agente actual.
    function clear(){
        operaciones.clear();
    }

    //Función auxiliar utilizada para guardar una operación en el estado de la Store.
    function setOperacion(data){
        operaciones.set(data.id, data);
    }

    //Función auxiliar utilizada para guardar una operación en el estado de la Store.
    function setOperaciones(response){
        for (let i = 0 ; i < response.data.length ; i++){
                setOperacion(response.data[i]);
            }
    }

    //Función utilizada para recuperar las operaciones del agente actual a partir de la API.
    async function getAllOperaciones() {
        try{
            const response = await axiosInstance.get('Operacion');
            setOperaciones(response);      
        }catch(error){
            console.error(error);
        }
        
    }

    //Función utilizada para crear una nueva operación.
    async function newOperacion(data){
        try{
            const response = await axiosInstance.post('Operacion', data);
            operaciones.set(response.data.id, response.data);   
        }catch(error){
            console.error(error);
        }     
    }

    //Función utilizada para eliminar una operación, dado su identificador.
    async function deleteOperacion(id){
        try{
            await axiosInstance.delete(`/Operacion/${id}`);
            this.operaciones.delete(id);
        }catch(error){
            console.error(error);
        }
        
    }
    
    //Función utilizada para devolver una operación determinado dado su identificador.
    //En caso de que no se encuentre ya almacenado en la Store, se obtiene a partir de la API.
    async function getOperacion(id){
        if (operaciones.has(id)) return operaciones.get(id);
        else {
            try{
                const response = await axiosInstance.get(`/Operacion/${id}`);
                setOperacion(response.data);
                return response.data;
            }catch(error){
                console.error(error);
            }
        }
    }

    //Función utilizada para asignar un equipo determinado a una operación determinada, dada sus correspondientes identificadores.
    async function asignarEquipo(operacionId, equipoId){
        try{
                const response = await axiosInstance.put(`/Operacion/${operacionId}/AsignarEquipo/${equipoId}`);
                setOperacion(response.data);
                return response.data;
            }catch(error){
                console.error(error);
            }
    }

    return {operaciones, numeroOperacionesActivas, numeroOperacionesPlanificadas,
    numeroOperacionesCompletadas, getAllOperaciones, newOperacion, deleteOperacion, clear, getOperacion, asignarEquipo, operacionesFiltradas}

})