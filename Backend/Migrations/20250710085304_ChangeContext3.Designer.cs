﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartwayFinal.Models;

#nullable disable

namespace SmartwayFinal.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250710085304_ChangeContext3")]
    partial class ChangeContext3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("AgenteEquipo", b =>
                {
                    b.Property<int>("MiembroEquiposId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MiembrosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MiembroEquiposId", "MiembrosId");

                    b.HasIndex("MiembrosId");

                    b.ToTable("MiembrosEquipo", (string)null);
                });

            modelBuilder.Entity("SmartwayFinal.Models.Agente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rango")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Agentes");
                });

            modelBuilder.Entity("SmartwayFinal.Models.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Especialidad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("SmartwayFinal.Models.Operacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CreadorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EquipoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.ToTable("Operaciones");
                });

            modelBuilder.Entity("AgenteEquipo", b =>
                {
                    b.HasOne("SmartwayFinal.Models.Equipo", null)
                        .WithMany()
                        .HasForeignKey("MiembroEquiposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartwayFinal.Models.Agente", null)
                        .WithMany()
                        .HasForeignKey("MiembrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartwayFinal.Models.Equipo", b =>
                {
                    b.HasOne("SmartwayFinal.Models.Agente", "Owner")
                        .WithMany("OwnerEquipos")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("SmartwayFinal.Models.Operacion", b =>
                {
                    b.HasOne("SmartwayFinal.Models.Equipo", "Equipo")
                        .WithMany("Operaciones")
                        .HasForeignKey("EquipoId");

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("SmartwayFinal.Models.Agente", b =>
                {
                    b.Navigation("OwnerEquipos");
                });

            modelBuilder.Entity("SmartwayFinal.Models.Equipo", b =>
                {
                    b.Navigation("Operaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
