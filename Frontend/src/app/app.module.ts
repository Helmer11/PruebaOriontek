import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutes } from './Pages/App.routing';
import { ListaClienteComponent } from './Pages/Cliente/ListaCliente/ListaCliente.component';

@NgModule({
  declarations: [
    AppComponent,
    ListaClienteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutes,
    HttpClientModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
