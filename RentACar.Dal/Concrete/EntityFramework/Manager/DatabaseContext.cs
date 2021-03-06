﻿using RentACar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Concrete.EntityFramework.Manager
{
    public class DatabaseContext : DbContext
    {
        private static DatabaseContext databaseContext;
        static object _lock = new object();
        private DatabaseContext()
        {

        }
        public static DatabaseContext CreateDBWithSingleton()
        {
            lock (_lock)
            {
                if (databaseContext == null)
                {
                    databaseContext = new DatabaseContext();
                }
            }
            return databaseContext;
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<FuelType> FuelType { get; set; }
        public DbSet<GearType> GearType { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Branch> Branch { get; set; }
    }
}
