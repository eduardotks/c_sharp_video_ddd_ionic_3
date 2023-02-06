﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Project.Domain.Enums;
using Project.Infra.Persistence.EF;

namespace Project.Infra.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20180428204342_Setup")]
    partial class Setup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Domain.Entities.Canal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("IdUsuario");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UrlLogo")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Canal");
                });

            modelBuilder.Entity("Project.Domain.Entities.PlayList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("IdUsuario");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("PlayList");
                });

            modelBuilder.Entity("Project.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Project.Domain.Entities.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<Guid?>("IdCanal");

                    b.Property<Guid?>("IdPlayList");

                    b.Property<Guid?>("IdUsuario");

                    b.Property<string>("IdVideoYoutube")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("OrdemNaPlayList");

                    b.Property<int>("Status");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("IdCanal");

                    b.HasIndex("IdPlayList");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("Project.Domain.Entities.Canal", b =>
                {
                    b.HasOne("Project.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("Project.Domain.Entities.PlayList", b =>
                {
                    b.HasOne("Project.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("Project.Domain.Entities.Usuario", b =>
                {
                    b.OwnsOne("Project.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasMaxLength(200);

                            b1.ToTable("Usuario");

                            b1.HasOne("Project.Domain.Entities.Usuario")
                                .WithOne("Email")
                                .HasForeignKey("Project.Domain.ValueObjects.Email", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Project.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnName("PrimeiroNome")
                                .HasMaxLength(50);

                            b1.Property<string>("UltimoNome")
                                .IsRequired()
                                .HasColumnName("UltimoNome")
                                .HasMaxLength(50);

                            b1.ToTable("Usuario");

                            b1.HasOne("Project.Domain.Entities.Usuario")
                                .WithOne("Nome")
                                .HasForeignKey("Project.Domain.ValueObjects.Nome", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Project.Domain.Entities.Video", b =>
                {
                    b.HasOne("Project.Domain.Entities.Canal", "Canal")
                        .WithMany()
                        .HasForeignKey("IdCanal");

                    b.HasOne("Project.Domain.Entities.PlayList", "PlayList")
                        .WithMany()
                        .HasForeignKey("IdPlayList");

                    b.HasOne("Project.Domain.Entities.Usuario", "UsuarioSugeriu")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}