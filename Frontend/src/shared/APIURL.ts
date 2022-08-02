import { environment} from '../environments/environment';


let BASEURL = environment.API;


export let APIURL = {

cliente: {
  listado: BASEURL + "Cliente/ListaCliente",
  Detalle: BASEURL + "Cliente/ClienteDetalle?cliente_ID="
}


}
