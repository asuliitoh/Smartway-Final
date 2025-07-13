
import { defineStore } from "pinia";
import { axiosInstance } from "@/api/axios";
import { router } from "@/router/router";
import { ref } from "vue";
import { useRoute } from "vue-router";

/**
 * Store encargado del registro e inicio de sesión de un agente.
 */
export const useAuthStore = defineStore('auth', ()  => {

    const user = ref(Number(localStorage.getItem('user'))); //Identificador del agente.
    const lastIdRegistered = ref(null); //Identificador del último agente registrado.
    const token = ref(localStorage.getItem('token')); //Token del agente que ha iniciado sesión.
    const route = useRoute() //Ruta.
    
    //Función utilizada para inicializar la store.
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
        
    //Función utilizada para registrar a un agente dado su nombre, apellidos y contraseña.
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

    //Función utilizada para iniciar sesión dado un identificador y una contraseña.
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

    //Función utilizada para restaurar el estado de la store al cerrar sesión.
    function clear(){
        user.value=null;
        token.value=null;
        localStorage.removeItem('user');
        localStorage.removeItem('token');
        delete axiosInstance.defaults.headers.common.Authorization;
    }

    //Función utilizada para cerrar sesión.
    function logout(){
            clear()
            if (!route.path.includes('login')) router.push({name: 'login'})
        }
    
    //Función utilizada para decodificar un token JWT.
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