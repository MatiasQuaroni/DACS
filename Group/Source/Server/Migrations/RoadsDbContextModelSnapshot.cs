﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Persistence;

namespace Server.Migrations
{
    [DbContext(typeof(RoadsDbContext))]
    partial class RoadsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Server.Domain.CustomerInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerInfo");
                });

            modelBuilder.Entity("Server.Domain.Itinerary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Itinerary");
                });

            modelBuilder.Entity("Server.Domain.Leg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EndLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItineraryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StartLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EndLocationId");

                    b.HasIndex("ItineraryId");

                    b.HasIndex("StartLocationId");

                    b.ToTable("Leg");
                });

            modelBuilder.Entity("Server.Domain.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coordinates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Server.Domain.ProfileInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProfileInfo");
                });

            modelBuilder.Entity("Server.Domain.Shipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DestinationAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EstimatedArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ItineraryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Precautions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrackingNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("DestinationAddressId")
                        .IsUnique();

                    b.HasIndex("ItineraryId");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("Server.Domain.ShipmentState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentState")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ShipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ShipmentState");
                });

            modelBuilder.Entity("Server.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfileInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserStateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProfileInfoId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Server.Domain.UserState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserState");
                });

            modelBuilder.Entity("Server.Domain.Leg", b =>
                {
                    b.HasOne("Server.Domain.Location", "EndLocation")
                        .WithMany()
                        .HasForeignKey("EndLocationId");

                    b.HasOne("Server.Domain.Itinerary", "Itinerary")
                        .WithMany("Legs")
                        .HasForeignKey("ItineraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Domain.Location", "StartLocation")
                        .WithMany()
                        .HasForeignKey("StartLocationId");

                    b.Navigation("EndLocation");

                    b.Navigation("Itinerary");

                    b.Navigation("StartLocation");
                });

            modelBuilder.Entity("Server.Domain.Shipment", b =>
                {
                    b.HasOne("Server.Domain.CustomerInfo", "Customer")
                        .WithOne("Shipment")
                        .HasForeignKey("Server.Domain.Shipment", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Domain.Location", "DestinationAddress")
                        .WithOne("Shipment")
                        .HasForeignKey("Server.Domain.Shipment", "DestinationAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Domain.Itinerary", null)
                        .WithMany("Shipments")
                        .HasForeignKey("ItineraryId");

                    b.Navigation("Customer");

                    b.Navigation("DestinationAddress");
                });

            modelBuilder.Entity("Server.Domain.ShipmentState", b =>
                {
                    b.HasOne("Server.Domain.Shipment", "Shipment")
                        .WithMany("States")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("Server.Domain.User", b =>
                {
                    b.HasOne("Server.Domain.ProfileInfo", "ProfileInfo")
                        .WithOne("User")
                        .HasForeignKey("Server.Domain.User", "ProfileInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileInfo");
                });

            modelBuilder.Entity("Server.Domain.UserState", b =>
                {
                    b.HasOne("Server.Domain.User", "User")
                        .WithMany("UserStates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.Domain.CustomerInfo", b =>
                {
                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("Server.Domain.Itinerary", b =>
                {
                    b.Navigation("Legs");

                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("Server.Domain.Location", b =>
                {
                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("Server.Domain.ProfileInfo", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.Domain.Shipment", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Server.Domain.User", b =>
                {
                    b.Navigation("UserStates");
                });
#pragma warning restore 612, 618
        }
    }
}
