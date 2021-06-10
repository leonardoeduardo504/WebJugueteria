using ApiJugueteria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ApiJugueteria.DAL
{
    public class ToyContext : DbContext
    {

        public ToyContext() : base("ToyContext")
        {
        }

        public DbSet<Toy> Toys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}