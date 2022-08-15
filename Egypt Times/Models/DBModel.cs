using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Egypt_Times.Models
{
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<UserNews> User_News { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.newsDescription)
                .IsUnicode(false);

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
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Password)
                .IsUnicode(false);


            modelBuilder.Entity<Person>()
                .HasMany<News>(src => src.News);
            modelBuilder.Entity<News>()
                .HasMany<Person>(x => x.People);

            base.OnModelCreating(modelBuilder);

        }
    }
}
