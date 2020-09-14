namespace School_TimeTable
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolDataModel : DbContext
    {
        public SchoolDataModel()
            : base("name=SchoolDataModel")
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Student_name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.User_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
