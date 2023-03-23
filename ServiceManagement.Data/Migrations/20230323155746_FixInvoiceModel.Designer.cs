﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceManagement.Data.Contexts;

#nullable disable

namespace ServiceManagement.Data.Migrations
{
    [DbContext(typeof(ServiceDbContext))]
    [Migration("20230323155746_FixInvoiceModel")]
    partial class FixInvoiceModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RoomService", b =>
                {
                    b.Property<int>("RoomsId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("RoomsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("ServiceRoom", (string)null);
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DayRent")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxRating")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id", "UserId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Avaliable")
                        .HasColumnType("bit");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("RoomService", b =>
                {
                    b.HasOne("ServiceManagement.Core.Entities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceManagement.Core.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Car", b =>
                {
                    b.HasOne("ServiceManagement.Core.Entities.Service", "Service")
                        .WithOne("Car")
                        .HasForeignKey("ServiceManagement.Core.Entities.Car", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Feedback", b =>
                {
                    b.HasOne("ServiceManagement.Core.Entities.Service", "Service")
                        .WithMany("Feedbacks")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Invoice", b =>
                {
                    b.HasOne("ServiceManagement.Core.Entities.Room", "Room")
                        .WithOne("Invoice")
                        .HasForeignKey("ServiceManagement.Core.Entities.Invoice", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Service", b =>
                {
                    b.HasOne("ServiceManagement.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Room", b =>
                {
                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("ServiceManagement.Core.Entities.Service", b =>
                {
                    b.Navigation("Car");

                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
