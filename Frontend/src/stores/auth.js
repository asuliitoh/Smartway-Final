
import { defineStore } from "pinia";
import { axiosInstance } from "@/main";
import { router } from "@/main";
import { useAgenteStore } from "./agente-store";
export const useAuthStore = defineStore('auth', {
    state: () => ({
        user: JSON.parse(localStorage.getItem('user')),
        token: JSON.parse(localStorage.getItem('token'))
    }),

    actions: {

        init(){
            axiosInstance.defaults.headers.common.Authorization = `Bearer ${this.token}`;
        },
        
        register(nombre, apellidos, password){

               axiosInstance.post("/Agentes/registro", {nombre:nombre, apellidos:apellidos ,password:password}).then(response => {    
                console.log(response.data);
            });

        },

        login(id, password) {
             axiosInstance.post("/Agentes/login", {id:id, password:password}).then(response => {
                console.log(response.data);
                this.user = response.data.id;
                this.token = response.data.token;
                localStorage.setItem('user', JSON.stringify(this.user));
                localStorage.setItem('token', JSON.stringify(this.token));
                axiosInstance.defaults.headers.common.Authorization = `Bearer ${this.token}`;
                router.replace({name: 'home'});
            });

        },

        logout(){
            this.user=null;
            localStorage.removeItem('user');
            router.replace({name: 'login'});
        }
    }
})