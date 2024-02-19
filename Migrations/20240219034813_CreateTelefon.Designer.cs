﻿// <auto-generated />
using System;
using MediiProgProiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediiProgProiect.Migrations
{
    [DbContext(typeof(MediiProgProiectContext))]
    [Migration("20240219034813_CreateTelefon")]
    partial class CreateTelefon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MediiProgProiect.Models.Cumparare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("MasinaID")
                        .HasColumnType("int");

                    b.Property<int?>("MembruID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MembruID");

                    b.ToTable("Cumparare");
                });

            modelBuilder.Entity("MediiProgProiect.Models.MasinaC", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CumparareID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFabricarii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int?>("VanzatorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CumparareID")
                        .IsUnique()
                        .HasFilter("[CumparareID] IS NOT NULL");

                    b.HasIndex("VanzatorID");

                    b.ToTable("MasinaC");
                });

            modelBuilder.Entity("MediiProgProiect.Models.Membru", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenume")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Membru");
                });

            modelBuilder.Entity("MediiProgProiect.Models.Tip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeTip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tip");
                });

            modelBuilder.Entity("MediiProgProiect.Models.TipMasina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("MasinaCID")
                        .HasColumnType("int");

                    b.Property<int>("MasinaID")
                        .HasColumnType("int");

                    b.Property<int>("TipID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MasinaCID");

                    b.HasIndex("TipID");

                    b.ToTable("TipMasina");
                });

            modelBuilder.Entity("MediiProgProiect.Models.Vanzator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeVanzator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vanzator");
                });

            modelBuilder.Entity("MediiProgProiect.Models.Cumparare", b =>
                {
                    b.HasOne("MediiProgProiect.Models.Membru", "Membru")
                        .WithMany("Cumparari")
                        .HasForeignKey("MembruID");

                    b.Navigation("Membru");
                });

            modelBuilder.Entity("MediiProgProiect.Models.MasinaC", b =>
                {
                    b.HasOne("MediiProgProiect.Models.Cumparare", "Cumparare")
                        .WithOne("MasinaC")
                        .HasForeignKey("MediiProgProiect.Models.MasinaC", "CumparareID");

                    b.HasOne("MediiProgProiect.Models.Vanzator", "Vanzator")
                        .WithMany("MasiniC")
                        .HasForeignKey("VanzatorID");

                    b.Navigation("Cumparare");

                    b.Navigation("Vanzator");
                });

            modelBuilder.Entity("MediiProgProiect.Models.TipMasina", b =>
                {
                    b.HasOne("MediiProgProiect.Models.MasinaC", "MasinaC")
                        .WithMany("TipMasini")
                        .HasForeignKey("MasinaCID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediiProgProiect.Models.Tip", "Tip")
                        .WithMany("TipMasini")
                        .HasForeignKey("TipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasinaC");

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("MediiProgProiect.Models.Cumparare", b =>
                {
                    b.Navigation("MasinaC");
                });

            modelBuilder.Entity("MediiProgProiect.Models.MasinaC", b =>
                {
                    b.Navigation("TipMasini");
                });

            modelBuilder.Entity("MediiProgProiect.Models.Membru", b =>
                {
                    b.Navigation("Cumparari");
                });

            modelBuilder.Entity("MediiProgProiect.Models.Tip", b =>
                {
                    b.Navigation("TipMasini");
                });

            modelBuilder.Entity("MediiProgProiect.Models.Vanzator", b =>
                {
                    b.Navigation("MasiniC");
                });
#pragma warning restore 612, 618
        }
    }
}
