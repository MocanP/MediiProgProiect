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
    [Migration("20240218163150_CvVanzator")]
    partial class CvVanzator
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MediiProgProiect.Models.MasinaC", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataFabricarii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int?>("VanzatorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VanzatorID");

                    b.ToTable("MasinaC");
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

                    b.HasKey("ID");

                    b.ToTable("Vanzator");
                });

            modelBuilder.Entity("MediiProgProiect.Models.MasinaC", b =>
                {
                    b.HasOne("MediiProgProiect.Models.Vanzator", "Vanzator")
                        .WithMany("MasiniC")
                        .HasForeignKey("VanzatorID");

                    b.Navigation("Vanzator");
                });

            modelBuilder.Entity("MediiProgProiect.Models.Vanzator", b =>
                {
                    b.Navigation("MasiniC");
                });
#pragma warning restore 612, 618
        }
    }
}