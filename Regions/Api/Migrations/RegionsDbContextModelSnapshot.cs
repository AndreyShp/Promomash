﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Promomash.Regions.WebApi.DAL.Context;

namespace Promomash.Regions.WebApi.Migrations
{
    [DbContext(typeof(RegionsDbContext))]
    partial class RegionsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Promomash.Regions.WebApi.DAL.Dto.RegionDto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long?>("ParentId");

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Region");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Китай",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Россия",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Соединенные штаты Америки",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Аньхой",
                            ParentId = 1L,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Фуцзянь",
                            ParentId = 1L,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Московская область",
                            ParentId = 2L,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Тульская область",
                            ParentId = 2L,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Республика Калмыкия",
                            ParentId = 2L,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Рязанская область",
                            ParentId = 2L,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Аляска",
                            ParentId = 3L,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Калифорния",
                            ParentId = 3L,
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 12L,
                            Name = "Флорида",
                            ParentId = 3L,
                            Type = (byte)2
                        });
                });

            modelBuilder.Entity("Promomash.Regions.WebApi.DAL.Dto.RegionDto", b =>
                {
                    b.HasOne("Promomash.Regions.WebApi.DAL.Dto.RegionDto", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
