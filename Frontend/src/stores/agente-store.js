import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";

export const useAgenteStore = defineStore('agenteStore', {
    state: () => ({
        id: (localStorage.getItem('user')),
        nombre: null,
        apellidos: null,
        rango: null,
        activo: null,
        loaded: false
    }),

    actions: {
        
        setAgenteActual(id){
            this.id = id;
        },

        async getInformacionAgenteActual(){
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
                    console.error("El agente no existe")
                }
                
            }
            return {nombre: this.nombre, apellidos:this.apellidos, rango:this.rango, activo:this.activo}
        },

        async getInformacionAgente(id){

            try {
                const response = await axiosInstance.get(`/Agentes/${id}`);
                return {id:response.data.id,
                    nombre:response.data.nombre,
                    apellidos:response.data.apellidos,
                    rango:response.data.rango,
                    activo:response.data.activo,
                }
            }catch(error){
                console.error("El agente no existe")
            }
            
        },

        async updateInformacionAgenteActual(data){
            if (this.loaded){
                try {
                    const agente = {id:this.id, nombre:data.nombre, apellidos:data.apellidos, rango:data.rango, activo:data.activo}
                    console.log(data)
                    const response = await axiosInstance.put(`/Agentes/${this.id}`, agente)    
                    console.log(response.data)
                    this.nombre=response.data.nombre;
                    this.apellidos=response.data.apellidos;
                    this.rango=response.data.rango;
                    this.activo=response.data.activo;          
                
                }catch(error){
                    if (error.response.status === 400) console.error("No se han introducido datos válidos")
                    else if (error.response.status === 404) console.error("El agente no existe")                   
                }
                
            }
        },

        async updatePasswordAgenteActual(data){
            if (this.loaded){
                try {
                    const peticion = {id:this.id, password:data.password, newPassword:data.newPassword, confirmPassword:data.confirmPassword}
                    console.log(peticion)
                    const response =await axiosInstance.post(`/Agentes/${this.id}/password`, peticion)
                }catch(error){

                    if (error.response.status === 400) console.error("No se han introducido datos válidos")
                    else if (error.response.status === 404) console.error("El agente no existe")
                    else if (error.response.status === 401) console.error("La contraseña actual no es correcta, o la confirmación de la contraseña no coincide con la nueva contraseña")      
                }
                
            }
        }

    }
})