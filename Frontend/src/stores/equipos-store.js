import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { ref, computed ,reactive } from "vue";


/**
 * Store de Equipos, encargado de gestionar la creación de equipos, las solicitudes y uniones a equipos,
 * la edición de equipos y la disolución para el agente actualmente logueado.
 */
export const useEquiposStore = defineStore('equipos-store', ()  => {
    
    const id = ref(Number(localStorage.getItem('user'))); //Identificador del agente actual.
    const equiposPropios = reactive(new Map()); //Map que contiene los equipos propios del agente actual.
    const equiposMiembro = reactive(new Map()); //Map que contiene los equipos en los que el agente actual es miembro.
    const solicitudes = reactive(new Map()); //Solicitudes pendientes del agente.
    
    //Número de equipos propios.
    const numeroEquiposPropios = computed(() => {
        return equiposPropios.size;
    }) 

    //Número de equipos ajeno.
    const numeroEquiposAjenos = computed(() => {
        return equiposMiembro.size;
    }) 
    
    //Función utilizada para restarurar el estado de la Store al cerrarse la sesión del agente actual.
    function clear() {
        equiposMiembro.clear();
        equiposPropios.clear();
        solicitudes.clear();
        id.value = null;
    }

    //Función utilizada para inicializar la store al iniciar sesión el agente actual.
    function init() {
        id.value = Number(localStorage.getItem('user'));
    }

    //Función auxiliar utilizada para guardar las solicitudes del agente actual.
    function setSolicitudes(response){
        for (let i =0; i < response.data.length; i++){
            solicitudes.set(response.data[i].equipoId, response.data[i]);
        }
    }

    //Función auxiliar utilizada para guardar un equipo en la Store según si es miembro o no.
    function setEquipo(response){
        if (response.ownerId == id.value) equiposPropios.set(response.id, response);
        else equiposMiembro.set(response.id, response);
    }

    //Función auxiliar utilizada para guardar los equipos en la Store.
    async function setEquipos(response){
        for (let i = 0 ; i < response.data.length ; i++){
                setEquipo(response.data[i]);
            }
    }

    //Función utilizada para recuperar los equipos del agente actual de la API.
    async function getAllEquipos() {
        try{
            const response = await axiosInstance.get('Equipo');
            setEquipos(response);
        }catch(error){
            console.error(error);
        }
        
    }

    //Función utilizada para recuperar un equipo determinado del agente actual de la API, dado un identificador.
    async function getEquipo(id){
        if (equiposPropios.has(id)) return equiposPropios.get(id);
        else if (equiposMiembro.has(id)) return equiposMiembro.get(id);
        else{
            try{
                const response = await axiosInstance.get(`/Equipo/${id}`);
                setEquipo(response.data);
                return response.data;
            }catch(error){
                console.error(error);
            }
            
        }
    
    }

    //Función utilizada para crear un nuevo equipo.
    async function newEquipo(data){
         const equipo ={nombre:data.nombre, especialidad:data.especialidad};
         try{
            const response = await axiosInstance.post('Equipo', equipo);
            setEquipo(response.data);
         }catch(error){
            console.error(error);
         }
    }

    //Función utilizada para eliminar un equipo determinado, dado un identificador.
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
    //Función utilizada para envíar una solicitud para unirse a un equipo determinado, a un agente determinado.
    async function enviarSolicitud(agenteId, equipoId){
        const solicitud = {agenteId: agenteId, equipoId:equipoId};
        try{
            await axiosInstance.post('SolicitudEquipo/Enviar', solicitud).then((response) => {console.log(response)});
        }catch(error){
            if (error.status == 409) console.error("Ya existe una solicitud enviada a ese agente");
        }
        
    }

    //Función utilizada para aceptar una solicitud pendiente.
    async function aceptarSolicitud(id){
        const solicitud = {equipoId:Number(id)};
        try{
            await axiosInstance.put('SolicitudEquipo/Aceptar', solicitud).then((response) => {console.log(response)});
            solicitudes.clear();
            equiposPropios.clear();
            equiposMiembro.clear();
            getSolicitudes();
            getAllEquipos();
        }
        catch(error){
            console.error(error);
        }
        
    }
    //Función utilizada para rechazar una solicitud pendiente.
    async function rechazarSolicitud(id){
        const solicitud = {equipoId:Number(id)};
        try{
            await axiosInstance.put('SolicitudEquipo/Rechazar', solicitud);
        }catch(error){
            console.error(error);
        }
        
    }

    //Función utilizada para obtener las solciitudes pendientes de la API.
    async function getSolicitudes(){
        try{
            const response = await axiosInstance.get('SolicitudEquipo');
            setSolicitudes(response);
        }catch(error){
            console.error(error);
        }
        
    }
    
    //Función utilizada para abandonar un equipo determinado.
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

    //Función utilizada para actualizar la información de un equipo determinado.
    async function actualizarInformacionEquipo(id, nombre, especialidad) {
        const equipo = {id:id, nombre:nombre, especialidad:especialidad};
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