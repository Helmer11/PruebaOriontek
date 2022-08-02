import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { APIURL } from '../../../shared/APIURL';
import { ClientesTran } from '../../models/Cliente';
import { Observable } from 'rxjs';
import { ClienteDireccionesTran } from 'src/app/models/ClientesDireccion';
@Injectable({
  providedIn: 'root'
})
export class ClientesService {

constructor(private _http: HttpClient) { }



public getListaCliente(): Observable<ClientesTran[]>{
  return this._http.get<ClientesTran[]>(APIURL.cliente.listado);
}

public getdetalleCliente(idcliente: number): Observable<ClienteDireccionesTran[]>{
 return this._http.get<ClienteDireccionesTran[]>(APIURL.cliente.Detalle + idcliente);
}


public getCliente(){
  return this._http.get(APIURL.cliente.listado);
}

public setDireccionCliente(cliente: any){

  const headerOptions = new HttpHeaders({'Content-Type':'application/json'});
  return this._http.post(APIURL.cliente.Direccion, cliente, {headers: headerOptions }  )
}

public setEditaDireccionCliente(cliente: any){
  debugger;
  const headerOptions = new HttpHeaders({'Content-Type':'application/json'});
  return this._http.put(APIURL.cliente.edita, cliente, {headers: headerOptions }  )
}

public SetDeleteDireccion(idDirecccion: number){
  return this._http.get(APIURL.cliente.Eliminar + idDirecccion);
}


}
