using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mivcan7.Models;

namespace Mivcan7.Data
{
    public class Mivcan7Context : DbContext
    {
        public Mivcan7Context (DbContextOptions<Mivcan7Context> options)
            : base(options)
        {
        }

        public DbSet<Mivcan7.Models.ToDo> ToDo { get; set; } = default!;
    }
}
