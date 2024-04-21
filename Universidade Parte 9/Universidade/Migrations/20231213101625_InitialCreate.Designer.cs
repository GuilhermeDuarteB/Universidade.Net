﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Universidade.Data;

#nullable disable

namespace Universidade.Migrations
{
    [DbContext(typeof(EscolaContexto))]
    [Migration("20231213101625_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Universidade.Models.Curso", b =>
                {
                    b.Property<int>("CursoID")
                        .HasColumnType("int");

                    b.Property<int>("Creditos")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CursoID");

                    b.ToTable("Curso", (string)null);
                });

            modelBuilder.Entity("Universidade.Models.Estudante", b =>
                {
                    b.Property<int>("EstudanteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstudanteID"), 1L, 1);

                    b.Property<DateTime>("DataMatricula")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstudanteID");

                    b.ToTable("Estudantes", (string)null);
                });

            modelBuilder.Entity("Universidade.Models.Matricula", b =>
                {
                    b.Property<int>("MatriculaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatriculaID"), 1L, 1);

                    b.Property<int>("CursoID")
                        .HasColumnType("int");

                    b.Property<int>("EstudanteID")
                        .HasColumnType("int");

                    b.Property<int?>("Nota")
                        .HasColumnType("int");

                    b.HasKey("MatriculaID");

                    b.HasIndex("CursoID");

                    b.HasIndex("EstudanteID");

                    b.ToTable("Matricula", (string)null);
                });

            modelBuilder.Entity("Universidade.Models.Matricula", b =>
                {
                    b.HasOne("Universidade.Models.Curso", "Curso")
                        .WithMany("Matriculas")
                        .HasForeignKey("CursoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Universidade.Models.Estudante", "Estudante")
                        .WithMany("Matriculas")
                        .HasForeignKey("EstudanteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Estudante");
                });

            modelBuilder.Entity("Universidade.Models.Curso", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Universidade.Models.Estudante", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
