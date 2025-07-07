import axios from 'axios'

//Creación de una instancia Axios global, para todos los componentes Vue.
const axiosInstance = axios.create ( {
  baseURL: 'https://localhost:7038/'
});

export {axiosInstance}
