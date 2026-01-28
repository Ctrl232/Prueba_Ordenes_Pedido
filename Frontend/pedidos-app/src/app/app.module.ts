// src/app/app.module.ts
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { PedidosComponent } from './components/pedidos/pedidos.component';
import { AppRoutingModule } from './app.routes'; 

@NgModule({
  declarations: [
    AppComponent,
    PedidosComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
