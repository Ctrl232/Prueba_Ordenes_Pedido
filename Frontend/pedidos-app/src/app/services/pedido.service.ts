// src/app/services/pedido.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Producto {
  idProducto: number;
  codigo: string;
  nombre: string;
  valorUnitario: number;
}

interface OrdenDetalle {
  idDetalle: number;
  idOrden: number;
  ordenPedido: string;
  idProducto: number;
  producto: Producto;
  cantidad: number;
  valorUnitario: number;
  valorParcial: number;
}

interface OrdenPedido {
  idOrden: number;
  idCliente: number;
  cliente: any; 
  fechaRegistro: string;
  estado: string;
  direccionEntrega: string;
  prioridad: string;
  valorTotal: number;
  ordenDetalles: OrdenDetalle[];
}

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  private apiUrl = 'http://localhost:5289/api/ordenes';  //  endpoint API

  constructor(private http: HttpClient) { }

  // Obtener lista de pedidos
  getPedidos(): Observable<OrdenPedido[]> {
    return this.http.get<OrdenPedido[]>(this.apiUrl);
  }

  // Confirmar orden
  confirmarOrden(id: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/confirmar/${id}`, {});
  }

  // Anular orden
  anularOrden(id: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/anular/${id}`, {});
  }
}
