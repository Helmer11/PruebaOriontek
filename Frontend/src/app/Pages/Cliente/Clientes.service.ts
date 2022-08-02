import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIURL } from '../../../shared/APIURL';
import { ClientesTran } from '../../models/Cliente';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ClientesService {

constructor(private _http: HttpClient) { }



public getListaCliente(): Observable<ClientesTran[]>{
  return this._http.get<ClientesTran[]>(APIURL.cliente.listado);
}


}
