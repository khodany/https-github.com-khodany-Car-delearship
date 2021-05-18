using System;
using System.Collections.Generic;
using System.Text;
using Car_delearship.Models;
using Car_delearship.Models.VehicleModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vehicle = Car_delearship.Models.VehicleModels.Vehicle;

namespace Car_delearship.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Image> Images { set; get; }
        public DbSet<BodyStyle> BodyStyles { set; get; }
        public DbSet<Color> Colors { set; get; }
        public DbSet<Interior> Interiors { get; set; }
        public DbSet<MakeModelVehicle> MakeModelVehicles { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Make> Makes { get; set; }
        //public DbSet<TransmissionTypes> TransmissionTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public ApplicationDbContext()
           
        {
        }
    }
}
