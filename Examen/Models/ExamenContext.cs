using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Examen.Models
{
    public class ExamenContext : DbContext
    {
        #region Attributes
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion                

        #region builder
        public ExamenContext()
            : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Project>().HasRequired(x => x.Category);

        }
        #endregion

    }
}