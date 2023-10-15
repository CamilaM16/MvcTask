using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTask.Models;

namespace MvcTask.Data
{
    public class MvcTaskItemContext : DbContext
    {
        public MvcTaskItemContext (DbContextOptions<MvcTaskItemContext> options)
            : base(options)
        {
        }

        public DbSet<MvcTask.Models.TaskItem> TaskItem { get; set; } = default!;
    }
}
