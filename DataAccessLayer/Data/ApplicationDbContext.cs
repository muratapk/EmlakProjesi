using EntityLayer.Entire;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
       public  DbSet<Villa> Villas { get; set; }
       public DbSet<VillaNumber>VillaNumbers { get; set; }
       public DbSet<Musteri> Musteris { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Villa>().HasData(
        //        new Villa{
        //        Id=1,
        //        Name="Royal Villas",
        //        Description="Rüyalarımdaki Villa",
        //        Price=1000,
        //        ImageUrl="1.jpg",
        //        Occupancy=1,
                
        //        },
        //        new Villa
        //        {
        //            Id = 2,
        //            Name = "Hayal Villası",
        //            Description = "Rüyalarımdaki Villa",
        //            Price = 2000,
        //            ImageUrl = "2.jpg",
        //            Occupancy = 1,

        //        },
        //        new Villa
        //        {
        //            Id = 3,
        //            Name = "Deniz Villası",
        //            Description = "Rüyalarımdaki Villa",
        //            Price = 4000,
        //            ImageUrl = "3.jpg",
        //            Occupancy = 1,

        //        }
        //        );

        //    modelBuilder.Entity<VillaNumber>().HasData(
        //        new VillaNumber
        //        {
        //            Villa_Number=101,
        //            VillaId=1,
        //        },
        //         new VillaNumber
        //         {
        //             Villa_Number = 102,
        //             VillaId = 2,
        //         },
        //         new VillaNumber
        //         {
        //             Villa_Number = 103,
        //             VillaId = 3,
        //         }
        //        );
        //}
    }
}
