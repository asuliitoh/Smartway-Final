import { defineStore } from "pinia";
import { axiosInstance } from "@/main";

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
                await axiosInstance.get(`/Agentes/${this.id}`).then(response => {
                    this.nombre = response.data.nombre;
                    this.apellidos = response.data.apellidos;
                    this.rango = response.data.rango;
                    this.activo = response.data.activo;
                    this.loaded=true;
                })
            }
            return {nombre: this.nombre, apellidos:this.apellidos, rango:this.rango, activo:this.activo}
        },

        async getInformacionAgente(id){
            const response = await axiosInstance.get(`/Agentes/${id}`);
            return {id:response.data.id,
                nombre:response.data.nombre,
                apellidos:response.data.apellidos,
                rango:response.data.rango,
                activo:response.data.activo,
            }
        },

        async updateInformacionAgenteActual(agente){
            if (this.loaded){
                
                const data = {id:this.id, nombre:agente.nombre, apellidos:agente.apellidos, rango:agente.rango, activo:agente.activo}
                console.log(data)
                await axiosInstance.put(`/Agentes/${this.id}`, data).then((response) => {

                    this.nombre=response.data.nombre;
                    this.apellidos=response.data.apellidos;
                    this.rango=response.data.rango;
                    this.activo=response.data.activo;          
                })
                console.log(this.nombre)
                console.log(this.apellidos)
                console.log(this.rango)
                console.log(this.activo)
            }
        }

    }
})