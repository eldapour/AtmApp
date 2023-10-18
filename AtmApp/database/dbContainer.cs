using AtmApp.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApp.database
{
    class dbContainer : DbContext
    {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Trans> Trans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-US9JT4L;database=dbAtm;Integrated security=true");
        }
    }
}
