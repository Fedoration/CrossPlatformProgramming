using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2Laputin.Models;

namespace WebApplication2Laputin.Data
{
    public class MvcPipeContext : DbContext
    { 
        public MvcPipeContext(DbContextOptions<MvcPipeContext> options)
            : base(options)
        {

        }
        public DbSet<Pipe> Pipe { get; set; }
    }
}
