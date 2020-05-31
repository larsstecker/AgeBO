using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeBO.Models
{
    public class BuildOrderContext : DbContext
    {
        public BuildOrderContext(DbContextOptions<BuildOrderContext> options) : base(options)
        {

        }

        public DbSet<BuildOrder> BuildOrders { get; set; }
    }
}
