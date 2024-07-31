using ConexaoCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace ConexaoCodeFirst.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {   
        }

        public DbSet<Client> Clients { get; set; }

    }
}
