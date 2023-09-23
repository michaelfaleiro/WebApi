using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class AppDbContext : DbContext
{
    private IConfiguration _configuration;
    public DbSet<UsersModel> Users { get; set; }
    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<Produto> Produtos { get; set; }


    public AppDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("Render");
        optionsBuilder.UseNpgsql(connectionString);
    }


}
