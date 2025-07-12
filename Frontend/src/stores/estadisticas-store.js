import { axiosInstance } from "@/api/axios";
import { defineStore } from "pinia";
import { ref } from "vue";

export const useEstadisticasStore = defineStore('estadisticas-store', () => {

    const agentesRegistrados = ref(0);
    const equiposFormados = ref(0);
    const operacionesCompletadas = ref(0);

    async function getEstadisticas(){
        const response = await axiosInstance.get('Estadisticas');
        agentesRegistrados.value = response.data.agentesRegistrados;
        equiposFormados.value = response.data.equiposFormados;
        operacionesCompletadas.value = response.data.operacionesCompletadas;

    }

    return {agentesRegistrados,equiposFormados,operacionesCompletadas,getEstadisticas}
});