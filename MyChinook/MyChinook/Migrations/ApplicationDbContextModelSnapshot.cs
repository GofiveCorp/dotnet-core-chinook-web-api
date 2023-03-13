﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyChinook.Data;

#nullable disable

namespace MyChinook.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyChinook.Models.Entities.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.Customer", b =>
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

            modelBuilder.Entity("MyChinook.Models.Entities.Employee", b =>
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
                            HireDate = new DateTime(2023, 3, 13, 10, 45, 34, 220, DateTimeKind.Local).AddTicks(6949),
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
                            HireDate = new DateTime(2023, 3, 13, 10, 45, 34, 220, DateTimeKind.Local).AddTicks(6962),
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
                            HireDate = new DateTime(2023, 3, 13, 10, 45, 34, 220, DateTimeKind.Local).AddTicks(6964),
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
                            HireDate = new DateTime(2023, 3, 13, 10, 45, 34, 220, DateTimeKind.Local).AddTicks(6967),
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
                            HireDate = new DateTime(2023, 3, 13, 10, 45, 34, 220, DateTimeKind.Local).AddTicks(6969),
                            LastName = "Johnson",
                            Phone = "+1 (780) 836-9987",
                            PostalCode = "T3B 1Y7",
                            ReportsTo = 2,
                            State = "AB",
                            Title = "Sales Support Agent"
                        });
                });

            modelBuilder.Entity("MyChinook.Models.Entities.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.Invoice", b =>
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

            modelBuilder.Entity("MyChinook.Models.Entities.InvoiceLine", b =>
                {
                    b.Property<int>("InvoiceLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceLineId"));

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TrackID")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceLineId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("TrackID");

                    b.ToTable("InvoiceLine");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.MediaType", b =>
                {
                    b.Property<int>("MediaTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MediaTypeId");

                    b.ToTable("MediaType");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlist");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackId"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("Bytes")
                        .HasColumnType("int");

                    b.Property<string>("Composer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Milliseconds")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TrackId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("GenreId");

                    b.HasIndex("MediaTypeId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.Album", b =>
                {
                    b.HasOne("MyChinook.Models.Entities.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.Invoice", b =>
                {
                    b.HasOne("MyChinook.Models.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.InvoiceLine", b =>
                {
                    b.HasOne("MyChinook.Models.Entities.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyChinook.Models.Entities.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("MyChinook.Models.Entities.Track", b =>
                {
                    b.HasOne("MyChinook.Models.Entities.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyChinook.Models.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyChinook.Models.Entities.MediaType", "MediaType")
                        .WithMany()
                        .HasForeignKey("MediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Genre");

                    b.Navigation("MediaType");
                });
#pragma warning restore 612, 618
        }
    }
}
