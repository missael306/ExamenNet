using System;
using System.Data.Entity;
using System.Linq;

namespace Examen.Models
{
    public class ExamenContext : DbContext
    {
        public ExamenContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}