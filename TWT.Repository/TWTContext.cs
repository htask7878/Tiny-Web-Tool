using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWT.Model.Models;

namespace TWT.Repository
{
    public class TWTContext : DbContext
    {
        public TWTContext(DbContextOptions<TWTContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
    }
}
