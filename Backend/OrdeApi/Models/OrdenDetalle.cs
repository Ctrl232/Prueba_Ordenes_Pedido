    using System.ComponentModel.DataAnnotations.Schema;  

public class OrdenDetalle
{
    public required int IdDetalle { get; set; }
    public required int IdOrden { get; set; }  
    public required int IdProducto { get; set; }
    public required Producto Producto { get; set; }
    public required int Cantidad { get; set; }
    public required decimal ValorUnitario { get; set; }
    [NotMapped]
    public decimal ValorParcial => Cantidad * ValorUnitario;
}





