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
    [Migration("20250709071753_ChangeEquipo")]
    partial class ChangeEquipo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("SmartwayFinal.Models.Agente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("MemberEquiposId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("OwnerEquiposId")
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

                    b.PrimitiveCollection<string>("MemberId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("OperacionesId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("SmartwayFinal.Models.Operacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.ToTable("Operaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
