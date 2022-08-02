import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../Clientes.service';
import {ClientesTran} from '../../../models/Cliente'



@Component({
  selector: 'app-ListaCliente',
  templateUrl: './ListaCliente.component.html',
  styleUrls: ['./ListaCliente.component.css']
})
export class ListaClienteComponent implements OnInit {


    ListaCliente: ClientesTran[] = [];

  constructor(private _Clientservice: ClientesService ) { }

  ngOnInit() {
    this.getListadoCliente();
  }


  getListadoCliente(){
    this._Clientservice.getListaCliente().subscribe(res =>{
          this.ListaCliente = res;
    });
  }





}
