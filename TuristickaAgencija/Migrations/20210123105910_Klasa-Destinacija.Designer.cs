﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TuristickaAgencija;
using TuristickaAgencija.Data;

namespace TuristickaAgencija.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210123105910_Klasa-Destinacija")]
    partial class KlasaDestinacija
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TuristickaAgencija.Data.Models.Destinacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Drzava")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SmjestajId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SmjestajId");

                    b.ToTable("Destinacije");
                });

            modelBuilder.Entity("TuristickaAgencija.Data.Models.Destinacija", b =>
                {
                    b.HasOne("TuristickaAgencija.Data.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("SmjestajId");
                });
#pragma warning restore 612, 618
        }
    }
}
