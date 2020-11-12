using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Repository : DbContext
    {
        public Repository() : base("myConnectionString")
        {

        }

        public Repository(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasMany(c => c.Items).WithRequired(m => m.Model);
            modelBuilder.Entity<Model>().HasMany(c => c.Positions).WithRequired(m => m.Model);
        }



        public DbSet<Clientt> Clients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Model> Models { get; set; }
        //public DbSet<MyTuple<string, Queue>> Tuples { get; set; }

    }
}
