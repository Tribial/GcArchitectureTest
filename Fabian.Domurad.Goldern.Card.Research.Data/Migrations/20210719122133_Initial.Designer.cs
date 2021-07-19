﻿// <auto-generated />
using System;
using Fabian.Domurad.Golden.Card.Research.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fabian.Domurad.Golden.Card.Research.Data.Migrations
{
    [DbContext(typeof(GcResearchDbContext))]
    [Migration("20210719122133_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fabian.Domurad.Golden.Card.Research.Shared.Model.DeskBookingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookDate");

                    b.HasIndex("DeskId");

                    b.HasIndex("UserId");

                    b.ToTable("DeskBooking");
                });

            modelBuilder.Entity("Fabian.Domurad.Golden.Card.Research.Shared.Model.DeskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeskNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("FloorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsLifted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnavailable")
                        .HasColumnType("bit");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("Tribe")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("Fabian.Domurad.Golden.Card.Research.Shared.Model.FloorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LocalizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LocalizationId");

                    b.ToTable("Floor");
                });

            modelBuilder.Entity("Fabian.Domurad.Golden.Card.Research.Shared.Model.LocalizationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Localization");
                });

            modelBuilder.Entity("Fabian.Domurad.Golden.Card.Research.Shared.Model.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Fabian.Domurad.Golden.Card.Research.Shared.Model.DeskBookingEntity", b =>
                {
                    b.HasOne("Fabian.Domurad.Golden.Card.Research.Shared.Model.DeskEntity", "Desk")
                        .WithMany("DeskBookings")
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fabian.Domurad.Golden.Card.Research.Shared.Model.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fabian.Domurad.Golden.Card.Research.Shared.Model.DeskEntity", b =>
                {
                    b.HasOne("Fabian.Domurad.Golden.Card.Research.Shared.Model.FloorEntity", "Floor")
                        .WithMany("Desks")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fabian.Domurad.Golden.Card.Research.Shared.Model.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Fabian.Domurad.Golden.Card.Research.Shared.Model.FloorEntity", b =>
                {
                    b.HasOne("Fabian.Domurad.Golden.Card.Research.Shared.Model.LocalizationEntity", "Localization")
                        .WithMany("Floors")
                        .HasForeignKey("LocalizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
