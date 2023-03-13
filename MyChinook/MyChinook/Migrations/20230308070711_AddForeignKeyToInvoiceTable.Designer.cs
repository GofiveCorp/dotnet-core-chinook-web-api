﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyChinook.Data;

#nullable disable

namespace MyChinook.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230308070711_AddForeignKeyToInvoiceTable")]
    partial class AddForeignKeyToInvoiceTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyChinook.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupportRepId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("MyChinook.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Address = "11120 Jasper Ave NW",
                            City = "Edmonton",
                            Country = "Canada",
                            Email = "andrew@chinookcorp.com",
                            Fax = "+1 (780) 428-3457",
                            FirstName = "Andrew",
                            HireDate = new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1823),
                            LastName = "Adams",
                            Phone = "+1 (780) 428-9482",
                            PostalCode = "T5K 2N1",
                            State = "AB",
                            Title = "General Manager"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Address = "825 8 Ave SW",
                            City = "Calgary",
                            Country = "Canada",
                            Email = "nancy@chinookcorp.com",
                            Fax = "+1 (403) 262-3322",
                            FirstName = "Nancy",
                            HireDate = new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1874),
                            LastName = "Edwards",
                            Phone = "+1 (403) 262-3443",
                            PostalCode = "T2P 2T3",
                            ReportsTo = 1,
                            State = "AB",
                            Title = "Sales Manager"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Address = "1111 6 Ave SW",
                            City = "Edmonton",
                            Country = "Canada",
                            Email = "jane@chinookcorp.com",
                            Fax = "+1 (403) 262-6712",
                            FirstName = "Jane",
                            HireDate = new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1878),
                            LastName = "Peacock",
                            Phone = "+1 (403) 262-3443",
                            PostalCode = "T2P 5M5",
                            ReportsTo = 2,
                            State = "AB",
                            Title = "Sales Support Agent"
                        },
                        new
                        {
                            EmployeeId = 4,
                            Address = "683 10 Street SW",
                            City = "Edmonton",
                            Country = "Canada",
                            Email = "margaret@chinookcorp.com",
                            Fax = "+1 (403) 263-4289",
                            FirstName = "Margaret",
                            HireDate = new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1881),
                            LastName = "Park",
                            Phone = "+1 (403) 263-4423",
                            PostalCode = "T2P 5G3",
                            ReportsTo = 2,
                            State = "AB",
                            Title = "Sales Support Agent"
                        },
                        new
                        {
                            EmployeeId = 5,
                            Address = "7727B 41 Ave",
                            City = "Edmonton",
                            Country = "Canada",
                            Email = "steve@chinookcorp.com",
                            Fax = "+1 (780) 836-9543",
                            FirstName = "Steve",
                            HireDate = new DateTime(2023, 3, 8, 14, 7, 11, 135, DateTimeKind.Local).AddTicks(1883),
                            LastName = "Johnson",
                            Phone = "+1 (780) 836-9987",
                            PostalCode = "T3B 1Y7",
                            ReportsTo = 2,
                            State = "AB",
                            Title = "Sales Support Agent"
                        });
                });

            modelBuilder.Entity("MyChinook.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<string>("BillingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("MyChinook.Models.Invoice", b =>
                {
                    b.HasOne("MyChinook.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}