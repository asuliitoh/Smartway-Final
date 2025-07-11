import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { ref, computed ,reactive } from "vue";


export const useEquiposStore = defineStore('equipos-store', ()  => {
    const id = ref(Number(localStorage.getItem('user')))
    const equiposPropios = reactive(new Map())
    const equiposMiembro = reactive(new Map())
    const solicitudes = reactive(new Map())
    
    const numeroEquiposPropios = computed(() => {
        return equiposPropios.size;
    }) 
    const numeroEquiposAjenos = computed(() => {
        return equiposMiembro.size;
    }) 
    
    function clear() {
        equiposMiembro.clear();
        equiposPropios.clear();
        solicitudes.clear();
        id.value = null;
    }

    function init() {
        id.value = Number(localStorage.getItem('user'))
    }

    function setSolicitudes(response){
        for (let i =0; i < response.data.length; i++){
            solicitudes.set(response.data[i].equipoId, response.data[i])
        }
    }

    function setEquipo(response){
        
        if (response.ownerId == id.value) equiposPropios.set(response.id, response);
        else equiposMiembro.set(response.id, response)
    }

    async function setEquipos(response){
        for (let i = 0 ; i < response.data.length ; i++){
                setEquipo(response.data[i])
            }
    }

    async function getAllEquipos() {
        await axiosInstance.get('Equipo').then((response) => {
            setEquipos(response);
        });
    }

    async function getEquipo(id){
        if (equiposPropios.has(id)) return equiposPropios.get(id);
        else if (equiposMiembro.has(id)) return equiposMiembro.get(id);
        else{
            try{
                const response = await axiosInstance.get(`/Equipo/${id}`);
                setEquipo(response.data);
                return response.data;
            }catch(error){
                console.error(error)
            }
            
        }
    
    }

    async function newEquipo(data){
         
         const equipo ={nombre:data.nombre, especialidad:data.especialidad}
         await axiosInstance.post('Equipo', equipo).then((response) => {
            setEquipo(response.data)
        });
    }

    async function deleteEquipo(id){
        if (!equiposPropios.has(id)) return false;
        try {
            await axiosInstance.delete(`/Equipo/${id}`);
            if (equiposPropios.delete(id)) console.log("Se ha eliminado el equipo " + id + " correctamente");
            return true;
        }catch(error){
            console.error("Se ha producido un error durante la eliminación del equipo " + id);
            return false;
        }
        
        
    }

    async function enviarSolicitud(agenteId, equipoId){
        const solicitud = {agenteId: agenteId, equipoId:equipoId};
        try{
            await axiosInstance.post('SolicitudEquipo/Enviar', solicitud).then((response) => {console.log(response)})
        }catch(error){
            if (error.status == 409) console.error("Ya existe una solicitud enviada a ese agente")
        }
        
    }

    async function aceptarSolicitud(id){
        const solicitud = {equipoId:Number(id)};
        try{
            await axiosInstance.put('SolicitudEquipo/Aceptar', solicitud).then((response) => {console.log(response)})
            solicitudes.clear()
            equiposPropios.clear()
            equiposMiembro.clear()
            getSolicitudes()
            getAllEquipos()
        }
        catch(error){
            console.error(error)
        }
        
    }

    async function rechazarSolicitud(id){
        const solicitud = {equipoId:Number(id)};
        console.log(solicitud)
        await axiosInstance.put('SolicitudEquipo/Rechazar', solicitud).then((response) => {console.log(response.data)})
    }

    async function getSolicitudes(){
        await axiosInstance.get('SolicitudEquipo').then((response) => {setSolicitudes(response)})  
    }
    
    async function abandonarEquipo(id){
        if (!equiposMiembro.has(id)) return false;
        try{
            await axiosInstance.put(`/Equipo/${id}/Abandonar`).then(response => console.log(response));
            equiposMiembro.delete(id);
            return true;
        }catch(error){
            console.error(error);
        }
        
    }

    async function actualizarInformacionEquipo(id, nombre, especialidad) {
        const equipo = {id:id, nombre:nombre, especialidad:especialidad};
        console.log(equipo)
        try{
             const response = await axiosInstance.put(`/Equipo/${id}`, equipo);
             setEquipo(response.data);
             return true;

        }catch(error){
            console.error(error);
            return false;
        }
    }

    return {solicitudes, equiposPropios, equiposMiembro, numeroEquiposAjenos, numeroEquiposPropios,
        getAllEquipos, newEquipo, deleteEquipo, enviarSolicitud, aceptarSolicitud, rechazarSolicitud,
        getSolicitudes, clear, init, abandonarEquipo, getEquipo, actualizarInformacionEquipo}

})