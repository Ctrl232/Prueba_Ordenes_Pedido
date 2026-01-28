using Microsoft.EntityFrameworkCore;

namespace OrdeApi.Data  
{
    public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<OrdenPedido> OrdenPedidos { get; set; }
    public DbSet<OrdenDetalle> OrdenDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
        modelBuilder.Entity<OrdenDetalle>().HasKey(o => o.IdDetalle);
        modelBuilder.Entity<OrdenPedido>().HasKey(p => p.IdOrden);
        modelBuilder.Entity<Producto>().HasKey(r => r.IdProducto);

        // Configuraciones de las relaciones (One-to-Many)
        modelBuilder.Entity<OrdenPedido>()
            .HasMany(o => o.OrdenDetalles)
            .WithOne()
            .HasForeignKey(od => od.IdOrden);
        
        modelBuilder.Entity<OrdenDetalle>()
            .HasOne(od => od.Producto)
            .WithMany()
            .HasForeignKey(od => od.IdProducto);
    }
}

}
