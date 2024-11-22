using Global.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Global.Infrastructure.Data.AppData
{
        public class ApplicationContext : DbContext
        {
            public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
            {
   
            }

            public DbSet<MoradorEntity> Moradores { get; set; }
        public DbSet<MedidorEntity> Medidores { get; set; }
  
        }
    }
