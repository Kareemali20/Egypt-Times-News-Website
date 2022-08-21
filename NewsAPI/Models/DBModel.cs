using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NewsAPI.Models
{
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel2")
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserNews> User_News { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .HasMany(e => e.Users)
                .WithMany(e => e.News)
                .Map(m => m.ToTable("UserNews"));

            modelBuilder.Entity<News>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.newsDescription)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);


            modelBuilder.Entity<User>()
                .HasMany<News>(src => src.News);
            modelBuilder.Entity<News>()
                .HasMany<User>(x => x.Users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
