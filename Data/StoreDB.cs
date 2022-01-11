using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDTASK.Models;

namespace CRUDTASK.Data
{
    public class StoreDB : DbContext
    {
        public StoreDB (DbContextOptions<StoreDB> options)
            : base(options)
        {
        }

        public DbSet<CRUDTASK.Models.OrderModels> OrderModels { get; set; }
    }
}
