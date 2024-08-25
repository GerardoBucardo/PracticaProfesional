using Microsoft.EntityFrameworkCore;
using PrWebN_Capas.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrWebN_Capas.DAL
{
    public class ComunDB : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NFDMETJ\\SQLEXPRESS;Initial Catalog=PracticaDB;Integrated Security=True");
        }
    }
}
