﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicController.Entites.Context;

namespace MusicController.Entites.Migrations
{
    [DbContext(typeof(MusicDBContext))]
    [Migration("20210107092551_column lenghts added")]
    partial class columnlenghtsadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicController.Entites.Models.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ApprovedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("DeviceDetail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<long>("OutletId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusMessage")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("StatusPostedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OutletId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("MusicController.Entites.Models.Outlet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256)
                        .HasDefaultValue("Welcome123");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

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

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Frequency")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<long>("OutletId")
                        .HasColumnType("bigint");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

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

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnName("time")
                        .HasColumnType("time");

                    b.Property<long>("PlaylistId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnName("time")
                        .HasColumnType("time");

                    b.Property<string>("TrackURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

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
                        .HasForeignKey("OutletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicController.Entites.Models.Track", b =>
                {
                    b.HasOne("MusicController.Entites.Models.Playlist", "Playlist")
                        .WithMany("Track")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
