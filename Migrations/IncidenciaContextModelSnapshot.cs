﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Seguimiento.MVVM.Model;

#nullable disable

namespace Seguimiento.Migrations
{
    [DbContext(typeof(IncidenciaContext))]
    partial class IncidenciaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("Seguimiento.MVVM.Model.Incidencia", b =>
                {
                    b.Property<int>("IncidenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HoraFin")
                        .HasColumnType("TEXT");

                    b.Property<string>("HoraInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Instalacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Proyecto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Texto")
                        .HasColumnType("TEXT");

                    b.HasKey("IncidenciaId");

                    b.ToTable("Incidencias");
                });
#pragma warning restore 612, 618
        }
    }
}
