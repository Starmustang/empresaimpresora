﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using empresaimpresora;

#nullable disable

namespace empresaimpresora.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    [Migration("20240625024828_nuevainterfaz")]
    partial class nuevainterfaz
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("empresaimpresora.Models.Empresa", b =>
                {
                    b.Property<Guid>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Empleados")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresas");

                    b.HasData(
                        new
                        {
                            EmpresaId = new Guid("f83bc361-e443-47f7-89ec-556241277234"),
                            Descripcion = "Empresa desarrolladora de software",
                            Empleados = 1,
                            Nombre = "WIlsoncorp"
                        },
                        new
                        {
                            EmpresaId = new Guid("f83bc361-e443-47f7-89ec-556241277235"),
                            Descripcion = "Empresa desarrolladora de seguridad",
                            Empleados = 8,
                            Nombre = "Jdp"
                        });
                });

            modelBuilder.Entity("empresaimpresora.Models.Impresora", b =>
                {
                    b.Property<Guid>("ImpresoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ImpresoraId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("impresoras");

                    b.HasData(
                        new
                        {
                            ImpresoraId = new Guid("f83bc361-e443-47f7-89ec-556241277236"),
                            EmpresaId = new Guid("f83bc361-e443-47f7-89ec-556241277235"),
                            Modelo = "ltt3",
                            Nombre = "Epson"
                        });
                });

            modelBuilder.Entity("empresaimpresora.Models.Impresora", b =>
                {
                    b.HasOne("empresaimpresora.Models.Empresa", "Empresa")
                        .WithMany("impresoras")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("empresaimpresora.Models.Empresa", b =>
                {
                    b.Navigation("impresoras");
                });
#pragma warning restore 612, 618
        }
    }
}
