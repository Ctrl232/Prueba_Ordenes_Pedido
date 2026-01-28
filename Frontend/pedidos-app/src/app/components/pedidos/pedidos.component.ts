// src/app/components/pedidos/pedidos.component.ts
import { Component, OnInit } from '@angular/core';
import { PedidoService } from '../../services/pedido.service';

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

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {
  pedidos: OrdenPedido[] = [];

  constructor(private pedidoService: PedidoService) { }

  ngOnInit(): void {
    this.cargarPedidos();
  }

  cargarPedidos(): void {
    this.pedidoService.getPedidos().subscribe((data) => {
      this.pedidos = data;
    });
  }

  confirmarOrden(id: number): void {
    this.pedidoService.confirmarOrden(id).subscribe(() => {
      this.cargarPedidos();  // Recargar la lista después de confirmar
    });
  }

  anularOrden(id: number): void {
    this.pedidoService.anularOrden(id).subscribe(() => {
      this.cargarPedidos();  // Recargar la lista después de anular
    });
  }
}
