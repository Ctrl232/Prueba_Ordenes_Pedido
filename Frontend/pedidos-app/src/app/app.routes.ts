import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PedidosComponent } from './components/pedidos/pedidos.component';

export const routes: Routes = [
  { path: '', redirectTo: '/pedidos', pathMatch: 'full' },
  { path: 'pedidos', component: PedidosComponent },
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
