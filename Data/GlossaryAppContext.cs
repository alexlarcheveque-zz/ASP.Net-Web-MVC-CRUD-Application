using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlossaryApp.Models;

namespace GlossaryApp.Data
{
    public class GlossaryAppContext : DbContext
    {
        public GlossaryAppContext (DbContextOptions<GlossaryAppContext> options)
            : base(options)
        {
        }

        public DbSet<GlossaryApp.Models.Glossary> Glossary { get; set; }
    }
}
