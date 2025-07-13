import { axiosInstance } from "@/api/axios";
import { defineStore } from "pinia";
import { ref } from "vue";

/**
 * Store de estadísticas, utilizado para recuperar las estadísticas generales de la plataforma.
 */
export const useEstadisticasStore = defineStore('estadisticas-store', () => {

    const agentesRegistrados = ref(0); //Número de agentes registrados en la plataforma.
    const equiposFormados = ref(0); //Número de equipos formados en la plataforma.
    const operacionesCompletadas = ref(0); //Número de operaciones completadas en la plataforma.

    //Función utilizada para recuperar las estadísticas generales de la plataforma a partir de la API.
    async function getEstadisticas(){
        const response = await axiosInstance.get('Estadisticas');
        agentesRegistrados.value = response.data.agentesRegistrados;
        equiposFormados.value = response.data.equiposFormados;
        operacionesCompletadas.value = response.data.operacionesCompletadas;

    }

    return {agentesRegistrados,equiposFormados,operacionesCompletadas,getEstadisticas}
});