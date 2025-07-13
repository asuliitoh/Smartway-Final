import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { ref, computed , reactive } from "vue";


export const useOperacionesStore = defineStore('operaciones-store', ()  => {

    const operaciones = reactive(new Map())
    const numeroOperacionesPlanificadas = computed(() => {
        var i = 0;
        operaciones.forEach((value, key) => {
            if (value.estado === "Planificado") i=i+1;
        })
        return i;
    })

    const numeroOperacionesActivas = computed(() => {
        var i = 0;
        operaciones.forEach((value, key) => {
            if (value.estado === "Activo") i=i+1;
        })
        return i;
    })

    
    const numeroOperacionesCompletadas = computed(() => {
        var i = 0;
        operaciones.forEach((value, key) => {
            if (value.estado === "Completado") i=i+1;
        })
        return i;
    })

    function newDate(date){
        const [d, m, y] = date.split('/').map(Number);
        return new Date(y, m - 1, d);

    }

    const operacionesFiltradas = function (estado, periodo, equipo)
        {
     
        var op = Array.from(operaciones.entries())
        if (estado && estado !== "ninguno") op = op.filter(([key, value]) => value.estado === estado);
        if (periodo && periodo !== "ninguno") op = op.filter(([key, value]) => {
            const fechaInicio = newDate(value.fechaInicio);
            const fechaFinal = newDate(value.fechaFinal);
            return ((periodo.inicio <= fechaInicio) && (fechaFinal <= periodo.final))

        });
        if (equipo && equipo != "") op = op.filter(([key, value]) => Number(value.equipoId) == Number(equipo));
        return new Map(op)
        }


    function clear(){
        operaciones.clear()
    }

    function setOperacion(data){
        operaciones.set(data.id, data);
    }

    function setOperaciones(response){
        for (let i = 0 ; i < response.data.length ; i++){
                setOperacion(response.data[i])
            }

            console.log(operaciones)
            
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

    async function asignarEquipo(operacionId, equipoId){
        try{
                console.log(equipoId)
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