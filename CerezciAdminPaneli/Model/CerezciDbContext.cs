using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CerezciDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        public DbSet<AdminInfo> Admins { get; set; }
    }
}
