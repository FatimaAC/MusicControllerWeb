﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicController.Entites.Context;

namespace MusicController.Entites.Migrations
{
    [DbContext(typeof(MusicDBContext))]
    partial class MusicDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicController.Entites.Models.Device", b =>
                {
                    b.Property<long>("OutletId")
                        .HasColumnType("bigint");

                    b.Property<string>("DeviceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApprovedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPostedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OutletId", "DeviceId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("MusicController.Entites.Models.Outlet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ApprovedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Outlets");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ImageUrl = "Images/Baladna.png",
                            Name = "Baladna"
                        },
                        new
                        {
                            Id = 2L,
                            ImageUrl = "Images/Basta.png",
                            Name = "Basta"
                        },
                        new
                        {
                            Id = 3L,
                            ImageUrl = "Images/Build It Burger.png",
                            Name = "Build It Burger"
                        },
                        new
                        {
                            Id = 4L,
                            ImageUrl = "Images/Debs w Remman.png",
                            Name = "Debs w Remman"
                        },
                        new
                        {
                            Id = 5L,
                            ImageUrl = "Images/Gahwetna.png",
                            Name = "Gahwetna"
                        },
                        new
                        {
                            Id = 6L,
                            ImageUrl = "Images/Jwala.png",
                            Name = "Jwala"
                        },
                        new
                        {
                            Id = 7L,
                            ImageUrl = "Images/Karaki.png",
                            Name = "Karaki"
                        },
                        new
                        {
                            Id = 8L,
                            ImageUrl = "Images/La Casa.png",
                            Name = "La Casa"
                        },
                        new
                        {
                            Id = 9L,
                            ImageUrl = "Images/Maia.png",
                            Name = "Maia"
                        },
                        new
                        {
                            Id = 10L,
                            ImageUrl = "Images/Meatsmith.png",
                            Name = "Meatsmith"
                        },
                        new
                        {
                            Id = 11L,
                            ImageUrl = "Images/Mokarabia.png",
                            Name = "Mokarabia"
                        },
                        new
                        {
                            Id = 12L,
                            ImageUrl = "Images/Orient Pearl.png",
                            Name = "Orient Pearl"
                        },
                        new
                        {
                            Id = 13L,
                            ImageUrl = "Images/Palma.png",
                            Name = "Palma"
                        },
                        new
                        {
                            Id = 14L,
                            ImageUrl = "Images/Remman Cafe.png",
                            Name = "Remman Cafe"
                        },
                        new
                        {
                            Id = 15L,
                            ImageUrl = "Images/Sazeli Logo.png",
                            Name = "Sazeli Logo"
                        },
                        new
                        {
                            Id = 16L,
                            ImageUrl = "Images/SMAT.png",
                            Name = "SMAT"
                        },
                        new
                        {
                            Id = 17L,
                            ImageUrl = "Images/USTA.png",
                            Name = "USTA"
                        });
                });

            modelBuilder.Entity("MusicController.Entites.Models.Playlist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ApprovedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Frequency")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OutletId")
                        .HasColumnType("bigint");

                    b.Property<string>("Schedule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OutletId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("MusicController.Entites.Models.Track", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("PlaylistId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId")
                        .IsUnique();

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("MusicController.Entites.Models.Device", b =>
                {
                    b.HasOne("MusicController.Entites.Models.Outlet", "Outlet")
                        .WithMany("Devices")
                        .HasForeignKey("OutletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicController.Entites.Models.Playlist", b =>
                {
                    b.HasOne("MusicController.Entites.Models.Outlet", "Outlet")
                        .WithMany("Playlist")
                        .HasForeignKey("OutletId");
                });

            modelBuilder.Entity("MusicController.Entites.Models.Track", b =>
                {
                    b.HasOne("MusicController.Entites.Models.Playlist", "Playlist")
                        .WithOne("Track")
                        .HasForeignKey("MusicController.Entites.Models.Track", "PlaylistId");
                });
#pragma warning restore 612, 618
        }
    }
}
