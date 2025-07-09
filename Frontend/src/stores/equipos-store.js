import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { ref, reactive } from "vue";
import axios from "axios";


export const useEquiposStore = defineStore('equipos-store', ()  => {
    const id = localStorage.getItem('user')
    const equiposPropios = reactive(new Map())
    const equiposMiembro = reactive(new Map())

    function setEquipo(response){
        if (response.ownerId == id) equiposPropios.set(response.id, response);
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

    async function newEquipo(data){
         
         const equipo ={nombre:data.nombre, especialidad:data.especialidad, ownerid:id}
         await axiosInstance.post('Equipo', equipo).then((response) => {
            console.log(response.data);
            setEquipo(response.data)
        });
    }

    async function deleteEquipo(id){
        await axiosInstance.delete(`/Equipo/${id}`).then(this.equiposPropios.delete(id));
        
    }
    
    return {equiposPropios, equiposMiembro, getAllEquipos, newEquipo, deleteEquipo}

})