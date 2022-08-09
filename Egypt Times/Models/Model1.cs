using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Egypt_Times.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.newsDescription)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .HasMany(e => e.People)
                .WithMany(e => e.News)
                .Map(m => m.ToTable("User_News").MapLeftKey("NewsID").MapRightKey("UserID"));

            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
