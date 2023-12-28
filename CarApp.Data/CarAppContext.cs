﻿using CarApp.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Data
{
    public class CarAppContext:DbContext
    {
        public CarAppContext(

            DbContextOptions<CarAppContext> options):base (options)
        { 
        }

        public DbSet<CarsApp> Cars { get; set; }

    }

    }

