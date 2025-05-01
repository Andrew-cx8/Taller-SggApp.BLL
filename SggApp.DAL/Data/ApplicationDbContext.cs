public class ApplicationDbContext : DbContext
{
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options) { }
public DbSet<Usuario> Usuarios { get; set; }
public DbSet<Categoria> Categorias { get; set; }
public DbSet<Moneda> Monedas { get; set; }
public DbSet<Gasto> Gastos { get; set; }
public DbSet<Presupuesto> Presupuestos { get; set; }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
// Configurar relaciones y restricciones
// Relaciones de Usuario
modelBuilder.Entity<Usuario>()
.HasMany(u => u.Gastos) // Un usuario tiene muchos gastos
.WithOne(g => g.Usuario) // Un gasto pertenece a un usuario
.HasForeignKey(g => g.UsuarioId) // Clave foránea en Gasto
.OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada
modelBuilder.Entity<Usuario>()
.HasMany(u => u.Presupuestos) // Un usuario tiene muchos presupuestos
.WithOne(p => p.Usuario) // Un presupuesto pertenece a un usuario
.HasForeignKey(p => p.UsuarioId) // Clave foránea en Presupuesto
.OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada
// Relaciones de Categoria
modelBuilder.Entity<Categoria>()
.HasMany(c => c.Gastos) // Una categoría tiene muchos gastos
.WithOne(g => g.Categoria) // Un gasto pertenece a una categoría
.HasForeignKey(g => g.CategoriaId) // Clave foránea en Gasto
.OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada
modelBuilder.Entity<Categoria>()
.HasMany(c => c.Presupuestos) // Una categoría tiene muchos presupuestos
.WithOne(p => p.Categoria) // Un presupuesto pertenece a una categoría
.HasForeignKey(p => p.CategoriaId) // Clave foránea en Presupuesto
.OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada
// Relaciones de Moneda
modelBuilder.Entity<Moneda>()
.HasMany(m => m.Gastos) // Una moneda tiene muchos gastos
.WithOne(g => g.Moneda) // Un gasto pertenece a una moneda
.HasForeignKey(g => g.MonedaId) // Clave foránea en Gasto
.OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada
modelBuilder.Entity<Moneda>()
.HasMany(m => m.Presupuestos) // Una moneda tiene muchos presupuestos
.WithOne(p => p.Moneda) // Un presupuesto pertenece a una moneda
.HasForeignKey(p => p.MonedaId) // Clave foránea en Presupuesto
.OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada
// Configuraciones adicionales (opcional)
modelBuilder.Entity<Usuario>()
.HasIndex(u => u.Email) // Índice único para el correo electrónico
.IsUnique();
modelBuilder.Entity<Categoria>()
.HasIndex(c => c.Nombre) // Índice único para el nombre de la categoría
.IsUnique();
modelBuilder.Entity<Moneda>()
.HasIndex(m => m.Codigo) // Índice único para el código ISO de la moneda
.IsUnique();
}
}