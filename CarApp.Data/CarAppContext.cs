using CarApp.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Data
{
    public class CarAppContext: IdentityDbContext
    {
        public CarAppContext(

            DbContextOptions<CarAppContext> options):base (options)
        {  }

        public DbSet<CarsApp> Cars { get; set; }

    }

    }

