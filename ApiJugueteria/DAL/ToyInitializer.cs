using ApiJugueteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiJugueteria.DAL
{
    public class ToyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ToyContext>
    {
        protected override void Seed(ToyContext context)
        {
            var toys = new List<Toy>
            {
            new Toy{Name="Barbie Developer", AgeRestriction = 12, Price = 25.99m, Company = "Mattel", Description = "Descripción 1"},
            new Toy{Name="xyc", AgeRestriction = 5, Price = 75.5m, Company = "Marvel", Description = "Descripción 2"},
            new Toy{Name="abc", AgeRestriction = 18, Price = 99.99m, Company = "Nintendo", Description = "Descripción 3"}
            };
            context.Toys.AddRange(toys);
            context.SaveChanges();
        }
    }
}