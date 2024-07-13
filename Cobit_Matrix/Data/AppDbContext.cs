using Cobit_Matrix.Models;
using Microsoft.EntityFrameworkCore;

namespace Cobit_Matrix.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
    
    public DbSet<MetaAlineamiento> GoalAlignment { get; set; }
    public DbSet<MetaEmpresarial> GoalBussiness { get; set; }
    public DbSet<ObjetivosGobierno> Government { get; set; }
}