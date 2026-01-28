using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using OrdeApi.Data;

[Route("api/[controller]")]
[ApiController]
public class OrdenesController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdenesController(AppDbContext context)
    {
        _context = context;
    }

// POST: api/ordenes
    [HttpPost]
public async Task<IActionResult> CrearOrden([FromBody] OrdenPedido ordenPedido)
{
    // Validar que la orden tenga al menos un detalle
    if (ordenPedido.OrdenDetalles == null || !ordenPedido.OrdenDetalles.Any())
    {
        return BadRequest("La orden debe tener al menos un producto.");
    }

    // Validar que el Cliente exista en la base de datos
    var cliente = await _context.Clientes.FindAsync(ordenPedido.IdCliente);
    if (cliente == null)
    {
        return BadRequest("Cliente no encontrado.");
    }

    // Asignar el cliente al objeto OrdenPedido
    ordenPedido.Cliente = cliente;

    // Validar que todos los productos en los detalles existan
    foreach (var detalle in ordenPedido.OrdenDetalles)
    {
        // Aquí buscamos el producto por su IdProducto
        var producto = await _context.Productos.FindAsync(detalle.IdProducto);
        if (producto == null)
        {
            return BadRequest($"El producto con Id {detalle.IdProducto} no existe.");
        }
        // Asignar el objeto Producto al detalle de la orden
        detalle.Producto = producto;
        // Ya no es necesario pasar el IdProducto, solo el producto encontrado
    }

    // Calcular el valor total y la prioridad de la orden
    ordenPedido.ValorTotal = ordenPedido.OrdenDetalles.Sum(d => d.ValorParcial);
    ordenPedido.Prioridad = ObtenerPrioridad(ordenPedido.ValorTotal);

    // Agregar la nueva orden a la base de datos
    _context.OrdenPedidos.Add(ordenPedido);

    // Guardar los cambios en la base de datos
    await _context.SaveChangesAsync();

    // Retornar la respuesta con el objeto creado
    return CreatedAtAction(nameof(GetOrden), new { id = ordenPedido.IdOrden }, ordenPedido);
}



    // PUT: api/ordenes/confirmar/{id}
    [HttpPut("confirmar/{id}")]
    public async Task<IActionResult> ConfirmarOrden(int id)
    {
        var orden = await _context.OrdenPedidos.FindAsync(id);
        if (orden == null)
        {
            return NotFound();
        }

        if (orden.Estado != "Registrado")
        {
            return BadRequest("La orden no está en estado 'Registrado'.");
        }

        orden.Estado = "Confirmado";
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // PUT: api/ordenes/anular/{id}
    [HttpPut("anular/{id}")]
    public async Task<IActionResult> AnularOrden(int id)
    {
        var orden = await _context.OrdenPedidos.FindAsync(id);
        if (orden == null)
        {
            return NotFound();
        }

        if (orden.Estado != "Registrado")
        {
            return BadRequest("La orden no está en estado 'Registrado'.");
        }

        orden.Estado = "Anulado";
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // GET: api/ordenes/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<OrdenPedido>> GetOrden(int id)
    {
        var orden = await _context.OrdenPedidos.Include(o => o.OrdenDetalles)
                                                 .ThenInclude(d => d.Producto)
                                                 .FirstOrDefaultAsync(o => o.IdOrden == id);
        if (orden == null)
        {
            return NotFound();
        }

        return orden;
    }

    private string ObtenerPrioridad(decimal valorTotal)
    {
        if (valorTotal <= 500)
            return "Baja";
        if (valorTotal <= 1000)
            return "Media";
        return "Alta";
    }
}
