namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieCatalogueContext : DbContext
    {
        public MovieCatalogueContext()
            : base("name=DatabaseConnection")
        {
        }

        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserMovieMarks> UserMovieMarks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.Movies)
                .HasForeignKey(e => e.MovieId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movies>()
                .HasMany(e => e.UserMovieMarks)
                .WithRequired(e => e.Movies)
                .HasForeignKey(e => e.IdMovie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserMovieMarks)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);
        }
    }
}
