﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TuristickaAgencija;

namespace TuristickaAgencija.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210219153000_TuristickaAgencija5Tabela")]
    partial class TuristickaAgencija5Tabela
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

            modelBuilder.Entity("TuristickaAgencija.Data.Models.OdabirSmjestaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojSobe")
                        .HasColumnType("int");

                    b.Property<int?>("RezervacijaId")
                        .HasColumnType("int");

                    b.Property<int?>("SmjestajId")
                        .HasColumnType("int");

                    b.Property<string>("VrstaSobe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RezervacijaId");

                    b.HasIndex("SmjestajId");

                    b.ToTable("OdabirSmjestaja");
                });

            modelBuilder.Entity("TuristickaAgencija.Data.Models.Placanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<double>("Iznos")
                        .HasColumnType("float");

                    b.Property<string>("NacinPlacanja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RezervacijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RezervacijaId");

                    b.ToTable("Placanje");
                });

            modelBuilder.Entity("TuristickaAgencija.Data.Models.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("TuristickaAgencija.Data.Models.Smjestaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojUgovora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvizijaPoOsobi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Smjestaji");
                });

            modelBuilder.Entity("TuristickaAgencija.Data.Models.Destinacija", b =>
                {
                    b.HasOne("TuristickaAgencija.Data.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("SmjestajId");
                });

            modelBuilder.Entity("TuristickaAgencija.Data.Models.OdabirSmjestaja", b =>
                {
                    b.HasOne("TuristickaAgencija.Data.Models.Rezervacija", "Rezervacija")
                        .WithMany()
                        .HasForeignKey("RezervacijaId");

                    b.HasOne("TuristickaAgencija.Data.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("SmjestajId");
                });

            modelBuilder.Entity("TuristickaAgencija.Data.Models.Placanje", b =>
                {
                    b.HasOne("TuristickaAgencija.Data.Models.Rezervacija", "Rezervacija")
                        .WithMany()
                        .HasForeignKey("RezervacijaId");
                });
#pragma warning restore 612, 618
        }
    }
}
