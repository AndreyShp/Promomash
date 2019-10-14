using Microsoft.EntityFrameworkCore;
using Promomash.Regions.WebApi.DAL.Dto;

namespace Promomash.Regions.WebApi.DAL.Context {
    public class RegionsDbContext : DbContext {
        public RegionsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<RegionDto> Regions { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<RegionDto>().ToTable("Region");
            modelBuilder.Entity<RegionDto>().HasKey(p => p.Id);
            modelBuilder.Entity<RegionDto>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<RegionDto>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<RegionDto>().Property(p => p.Type).IsRequired();
            modelBuilder.Entity<RegionDto>().Property(p => p.ParentId).IsRequired(false);

            //заполним базу изначальными данными
            InitialRegionsCreator.Create(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}