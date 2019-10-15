using Microsoft.EntityFrameworkCore;
using Promomash.Users.WebApi.DAL.Dto;

namespace Promomash.Users.WebApi.DAL.Context {
    public class UsersDbContext : DbContext {
        public UsersDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserDto> Users { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserDto>().ToTable("User");
            modelBuilder.Entity<UserDto>().HasKey(p => p.Id);
            modelBuilder.Entity<UserDto>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //максимальная длина взята из https://tools.ietf.org/html/rfc5321#section-4.5.3.1.1 плюс один символ на @ - {64}@{255}
            modelBuilder.Entity<UserDto>().Property(p => p.Login).IsRequired().HasMaxLength(320);
            modelBuilder.Entity<UserDto>().Property(p => p.Password).IsRequired().HasMaxLength(32);
            modelBuilder.Entity<UserDto>().Property(p => p.RegionId).IsRequired();

            modelBuilder.Entity<UserDto>().HasIndex(u => u.Login).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}