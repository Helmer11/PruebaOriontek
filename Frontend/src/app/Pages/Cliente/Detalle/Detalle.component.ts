import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Routes } from '@angular/router';
import { ClientesService } from '../Clientes.service';
import { ClienteDireccionesTran } from '../../../models/ClientesDireccion';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClientesTran } from '../../../models/Cliente';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-Detalle',
  templateUrl: './Detalle.component.html',
  styleUrls: ['./Detalle.component.css']
})
export class DetalleComponent implements OnInit {

    idDetalle!: number;
    Cliente: ClientesTran[]=[];
    Detalle: ClienteDireccionesTran[] =[];
    formDetalle!: FormGroup;


  constructor(private _rutas: ActivatedRoute,
              private _detalleservi: ClientesService,
              private _formB: FormBuilder,
               private _toast:ToastrService ) {
    this.idDetalle = Number( this._rutas.snapshot.paramMap.get('id'));
            if ( this.idDetalle > 0 ) {
              this.getClienteData();
              this.getdetalleCliente();
            } else {
             this.Formulario();
            }
  }

  ngOnInit() {
    this.Formulario();
  }

    Formulario(){
      this.formDetalle = this._formB.group({
        cliente_Nombre: ['', Validators.required],
        cliente_Apellido: ['', Validators.required],
        cliente_Telefono: ['', Validators.required],
        cliente_Celular: ['', Validators.required],
        cliente_Email: ['', Validators.required]
      })
    }

  getdetalleCliente(){
    this._detalleservi.getdetalleCliente(this.idDetalle).subscribe(res =>{
      this.Detalle = res as ClienteDireccionesTran[];
    })
  }

  getClienteData(){
    this._detalleservi.getListaCliente().subscribe(res => {
      this.Cliente = res as ClientesTran[];
        let id = this.Cliente.map(x=> x.clienteId).indexOf(this.idDetalle);
      this.formDetalle.setValue({
        cliente_Nombre: this.Cliente[id].clienteNombre,
        cliente_Apellido: this.Cliente[id].clienteApellido,
        cliente_Telefono: this.Cliente[id].clienteTelefono,
        cliente_Celular: this.Cliente[id].clienteCelular,
        cliente_Email: this.Cliente[id].clienteEmail
      });
    })
  }

  setDireccion(){
    let direccion = {
      ClienteId : this.idDetalle,
      ClienteDireccion: "Calle maldonado #55 sector la Feria"
    }
    this._detalleservi.setDireccionCliente(direccion).subscribe(res => {
          if (res.valueOf() == 1){
            this._toast.success('Se agrego la direccion', 'Exito');
          } else {
            this._toast.error("Hubo un error al momento de insertar la direccion", "Error");
          }
    })
setTimeout(() => {
  window.location.reload();
  this.getdetalleCliente();
}, 2000);
  }


  setEditaDireccion(){
    let direccion = {
      clienteDireccionId:6,
      ClienteId : this.idDetalle,
      ClienteDireccion: "Calle central #128, ensanchez mira flore "
    }
    this._detalleservi.setEditaDireccionCliente(direccion).subscribe(res => {
          if (res.valueOf() == 1){
            this._toast.success('Se agrego la direccion', 'Exito');
          } else {
            this._toast.error("Hubo un error al momento de insertar la direccion", "Error");
          }
    })
    setTimeout(() => {
      window.location.reload();
      this.getdetalleCliente();
    }, 2000);
  }

  setDeleteDireccion(direccionID:number) {
    this._detalleservi.SetDeleteDireccion(direccionID).subscribe(res =>{
        if (res.valueOf() == 1){
          this._toast.success("La Direccion fue eliminada", "Exito");
        } else {
          this._toast.error("No se pudo eliminar la direccion", "Error");
        }
    })
  }




}
