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

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ItineraryInfo");
                });

            modelBuilder.Entity("Server.Domain.Leg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItineraryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItineraryId");

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
                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ProfileInfo");
                });

            modelBuilder.Entity("Server.Domain.Shipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DestinationAddressId")
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

                    b.HasIndex("CustomerId");

                    b.HasIndex("DestinationAddressId");

                    b.HasIndex("ItineraryId");

                    b.ToTable("ShipmentInfo");
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

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Server.Domain.Leg", b =>
                {
                    b.HasOne("Server.Domain.Itinerary", null)
                        .WithMany("Legs")
                        .HasForeignKey("ItineraryId");
                });

            modelBuilder.Entity("Server.Domain.Shipment", b =>
                {
                    b.HasOne("Server.Domain.CustomerInfo", "Customer")
                        .WithMany("Shipments")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Server.Domain.Location", "DestinationAddress")
                        .WithMany("Shipments")
                        .HasForeignKey("DestinationAddressId");

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

            modelBuilder.Entity("Server.Domain.CustomerInfo", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("Server.Domain.Itinerary", b =>
                {
                    b.Navigation("Legs");

                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("Server.Domain.Location", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("Server.Domain.Shipment", b =>
                {
                    b.Navigation("States");
                });
#pragma warning restore 612, 618
        }
    }
}
