import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { ref, reactive } from "vue";


export const useEquiposStore = defineStore('equipos-store', ()  => {
    const id = localStorage.getItem('user')
    const equiposPropios = reactive(new Map())
    const equiposMiembro = reactive(new Map())
    const solicitudes = reactive(new Map())

    function setSolicitudes(response){
        console.log(response.data)
        for (let i =0; i < response.data.length; i++){
            solicitudes.set(response.data[i].equipoId, response.data[i])
        }
    }

    function setEquipo(response){
        
        if (response.ownerId == id) equiposPropios.set(response.id, response);
        else equiposMiembro.set(response.id, response)
    }

    async function setEquipos(response){
        console.log(response.data)
        for (let i = 0 ; i < response.data.length ; i++){
                setEquipo(response.data[i])
            }
    }

    async function getAllEquipos() {
        await axiosInstance.get('Equipo').then((response) => {
            setEquipos(response);
        });
    }

    async function newEquipo(data){
         
         const equipo ={nombre:data.nombre, especialidad:data.especialidad}
         await axiosInstance.post('Equipo', equipo).then((response) => {
            console.log(response.data);
            setEquipo(response.data)
        });
    }

    async function deleteEquipo(id){
        try {
            await axiosInstance.delete(`/Equipo/${id}`);
            if (equiposPropios.delete(id)) console.log("Se ha eliminado el equipo " + id + " correctamente");
        }catch(error){
            console.error("Se ha producido un error durante la eliminación del equipo " + id);
            console.error(error)
        }
        
        
    }

    async function enviarSolicitud(agenteId, equipoId){
        const solicitud = {agenteId: agenteId, equipoId:equipoId};
        console.log(solicitud);
        try{
            await axiosInstance.post('SolicitudEquipo/Enviar', solicitud).then((response) => {console.log(response)})
        }catch(error){
            if (error.status == 409) console.error("Ya existe una solicitud enviada a ese agente")
        }
        
    }

    async function aceptarSolicitud(data){
        const solicitud = {agenteId: agenteId, equipoId:equipoId};
        console.log(solicitud);
        await axiosInstance.put('SolicitudEquipo/Aceptar', solicitud).then((response) => {console.log(response)})
    }

    async function rechazarSolicitud(data){
        const solicitud = {agenteId: agenteId, equipoId:equipoId};
        console.log(solicitud);
        await axiosInstance.put('SolicitudEquipo/Rechazar', solicitud).then((response) => {console.log(response.data)})
    }

    async function getSolicitudes(){
        await axiosInstance.get('SolicitudEquipo').then((response) => {setSolicitudes(response)})
        
    }
    
    return {solicitudes, equiposPropios, equiposMiembro,
        getAllEquipos, newEquipo, deleteEquipo,
        enviarSolicitud, aceptarSolicitud, rechazarSolicitud,
        getSolicitudes}

})