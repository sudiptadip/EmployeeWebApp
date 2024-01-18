using Microsoft.EntityFrameworkCore;
using Employee.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) 
        { 

        }

        public DbSet<Employees> Employees { get; set; }

    }
}
