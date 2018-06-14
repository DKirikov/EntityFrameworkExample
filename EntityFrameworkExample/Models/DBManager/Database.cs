using EntityFrameworkExample.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    public class Database : DbContext
    {
        public Database()
        {
        }

        public Database(String connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany<Student>(s => s.Students)
                .WithMany(c => c.Teachers)
                .Map(cs =>
                {
                    cs.MapLeftKey("TeacherId");
                    cs.MapRightKey("StudentId");
                    cs.ToTable("TeacherStudent");
                });

            base.OnModelCreating(modelBuilder);
        }

        #region Database tables:
        public virtual DbSet<Person> people { get; set; }
        public virtual DbSet<Teacher> teachers { get; set; }
        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<Phone> phones { get; set; }
        #endregion
    }
}
