
import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { router } from "@/router/router";
import { ref } from "vue";
import { useRoute } from "vue-router";
export const useAuthStore = defineStore('auth', ()  => {

    const user = ref(Number(localStorage.getItem('user')));
    const lastIdRegistered = ref(null);
    const token = ref(localStorage.getItem('token'));
    const route = useRoute()
    
    function init(){
            if (token.value == null) {
                clear();
                return;
            }
            else {   
                
                const jwtDecoded = this.parseJwt(this.token);
                const now = Math.floor(Date.now() / 1000);
                
                if (jwtDecoded.nbf && (now < jwtDecoded.nbf)){
                    console.warn("Token no válido (aún)");
                    clear()

                }
                else if (jwtDecoded.exp && (now >= jwtDecoded.exp)){
                    console.warn("Token caducado");
                    clear()
                }

                axiosInstance.defaults.headers.common.Authorization = `Bearer ${token.value}`;
            }
            
        }
        
    async function register(nombre, apellidos, password){
            
            try {
                const response = await axiosInstance.post("/Agentes/registro", {nombre:nombre, apellidos:apellidos ,password:password});
                console.log("El registro se ha completado")
                this.lastIdRegistered = response.data.id;
                return true;
            }catch(error){
                console.error("Se ha producido un error en el registro")
                return false;
            }
               

        }

    async function login(id, password) {
        try{
            const response = await axiosInstance.post("/Agentes/login", {id:id, password:password});
            console.log(response.data);
            user.value = response.data.id;
            token.value = response.data.token;
            localStorage.setItem('user', user.value.toString());
            localStorage.setItem('token', token.value);
            axiosInstance.defaults.headers.common.Authorization = `Bearer ${this.token}`;
            router.replace({name: 'home'});
            return true;
            
        }catch(error){
            if (error.response.status === 401) console.error("La contraseña introducida no es correcta")
            else if (error.response.status === 404) console.error("El identificador introducido no pertenece a ningún usuario")
            return false;
        }
        }

    function clear(){
        user.value=null;
        token.value=null;
        localStorage.removeItem('user');
        localStorage.removeItem('token');
        delete axiosInstance.defaults.headers.common.Authorization;
    }

    function logout(){
            clear()
            if (!route.path.includes('login')) router.push({name: 'login'})
        }

    function parseJwt(token) {
            var base64Url = token.split('.')[1];
            var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            }).join(''));

            return JSON.parse(jsonPayload);
        }
    
    return {user,lastIdRegistered,token,init,login,register,logout,parseJwt}
})