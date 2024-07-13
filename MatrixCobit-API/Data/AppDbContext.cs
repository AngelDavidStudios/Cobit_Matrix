using Cobit_Matrix.Models;
using Microsoft.EntityFrameworkCore;

namespace MatrixCobit_API.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<MetaEmpresarial> GoalBussiness { get; set; } = default!;
    public DbSet<MetaAlineamiento> GoalAlignment { get; set; } = default!;
    public DbSet<ObjetivosGobierno> GovernmentObjectives { get; set; } = default!;
}