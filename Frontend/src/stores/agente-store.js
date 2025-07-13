import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";

/**
 * Store que almacena la información del agente que actualmente ha iniciado sesión.
 */
export const useAgenteStore = defineStore('agenteStore', () => 
    
    {
        
        const id = (localStorage.getItem('user')); //Identificador del agente.
        const nombre = null; //Nombre del agente.
        const apellidos= null; //Apellidos del agente.
        const rango = null; //Rango del agente.
        const activo = null; //Activo del agente.
        const loaded = false; //True si la información se ha cargado, false en caso contrario.
    
        
        //Función que asigna el identificador del agente actual.
        function setAgenteActual(id){
            this.id = id;
        }

        //Función que devuelve la información del agente actual.
        //En caso de que loaded sea false, realiza una consulta GET a la API.
        async function getInformacionAgenteActual(){
            
            if (!this.loaded){
                try {
                    const response =  await axiosInstance.get(`/Agentes/${this.id}`);  
                    this.nombre = response.data.nombre;
                    this.apellidos = response.data.apellidos;
                    this.rango = response.data.rango;
                    this.activo = response.data.activo;
                    this.loaded=true;
                }

                catch(error){
                    console.error("El agente no existe");
                }
                
            }
            return {nombre: this.nombre, apellidos:this.apellidos, rango:this.rango, activo:this.activo}
        };

        //Función que devuelve la información de un agente dado un identificador.
        async function getInformacionAgente(id){

            try {
                const response = await axiosInstance.get(`/Agentes/${id}`);
                return {id:response.data.id,
                    nombre:response.data.nombre,
                    apellidos:response.data.apellidos,
                    rango:response.data.rango,
                    activo:response.data.activo,
                }
            }catch(error){
                console.error("El agente no existe");
            }
            
        };

        //Función que actualiza la información del agente actual.
        async function updateInformacionAgenteActual(data){
            if (this.loaded){
                try {
                    const agente = {id:this.id, nombre:data.nombre, apellidos:data.apellidos, rango:data.rango, activo:data.activo};
                    const response = await axiosInstance.put(`/Agentes/${this.id}`, agente);
                    this.nombre=response.data.nombre;
                    this.apellidos=response.data.apellidos;
                    this.rango=response.data.rango;
                    this.activo=response.data.activo;   
                    return {nombre:this.nombre, apellidos:this.apellidos, rango:this.rango, activo:this.activo}       
                
                }catch(error){
                    if (error.response.status === 400) console.error("No se han introducido datos válidos");
                    else if (error.response.status === 404) console.error("El agente no existe");
                }
                
            }
        };

        //Función que actualiza la contraseña del agente actual.
        async function updatePasswordAgenteActual(data){
            if (this.loaded){
                try {
                    const peticion = {id:this.id, password:data.password, newPassword:data.newPassword, confirmPassword:data.confirmPassword};
                    await axiosInstance.post(`/Agentes/${this.id}/password`, peticion);
                    return true;
                }catch(error){

                    if (error.response.status === 400) console.error("No se han introducido datos válidos");
                    else if (error.response.status === 404) console.error("El agente no existe");
                    else if (error.response.status === 401) console.error("La contraseña actual no es correcta, o la confirmación de la contraseña no coincide con la nueva contraseña");
                    return false;
                }
                
            }
    
    }
    return {id, nombre, apellidos, rango, activo, loaded,
        setAgenteActual, getInformacionAgente, getInformacionAgenteActual,
        updateInformacionAgenteActual, updatePasswordAgenteActual}
})