using iotApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iotApi.Context
{
    public class IotContext : DbContext
    {
        public IotContext(DbContextOptions<IotContext> options) : base(options) {
        }

        public DbSet<Badge> Badges { get; set; }
    }
}
