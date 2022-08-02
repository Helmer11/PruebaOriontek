import { Routes, RouterModule } from '@angular/router';
import { ListaClienteComponent } from './Cliente/ListaCliente/ListaCliente.component';
import { DetalleComponent } from './Cliente/Detalle/Detalle.component';

const routes: Routes = [
  { path: "", component: ListaClienteComponent },
  { path: "detalle/:id", component: DetalleComponent },
];

export const AppRoutes = RouterModule.forRoot(routes);
