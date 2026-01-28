public class OrdenPedido
{
    public required int IdOrden { get; set; }

    public required int IdCliente { get; set; } 

    public Cliente? Cliente { get; set; }  

    public required DateTime FechaRegistro { get; set; }
    public required string Estado { get; set; }
    public required string DireccionEntrega { get; set; }
    public required string Prioridad { get; set; }
    public required decimal ValorTotal { get; set; }

    public List<OrdenDetalle> OrdenDetalles { get; set; }
}
