using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LikeButton_Aspnetcore.Models.DB
{
    public partial class LikeButtonContext : DbContext
    {
        public LikeButtonContext()
        {
        }

        public LikeButtonContext(DbContextOptions<LikeButtonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Likes> Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KEQ9BNC\\SQLEXPRESS;Database=LikeButton;user=DESKTOP-KEQ9BNC\\User;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Likes>(entity =>
            {
                entity.ToTable("likes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TotalLikes).HasColumnName("total_likes");
            });
        }
    }
}
