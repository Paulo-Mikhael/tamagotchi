﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tamagochi.Data;

#nullable disable

namespace Tamagochi.Migrations
{
    [DbContext(typeof(TamagotchiContext))]
    [Migration("20240323163437_RelacionandoTabelas")]
    partial class RelacionandoTabelas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tamagochi.Model.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Habilidades");
                });

            modelBuilder.Entity("Tamagochi.Model.Mascote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Altura")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mascotes");
                });

            modelBuilder.Entity("Tamagochi.Model.PokemonsUsuario", b =>
                {
                    b.Property<int>("MascoteId")
                        .HasColumnType("int");

                    b.Property<int>("HabilidadeId")
                        .HasColumnType("int");

                    b.HasKey("MascoteId", "HabilidadeId");

                    b.HasIndex("HabilidadeId");

                    b.ToTable("PokemonsUsuarios");
                });

            modelBuilder.Entity("Tamagochi.Model.PokemonsUsuario", b =>
                {
                    b.HasOne("Tamagochi.Model.Ability", "Habilidade")
                        .WithMany("PokemonsUsuario")
                        .HasForeignKey("HabilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tamagochi.Model.Mascote", "Mascote")
                        .WithMany("PokemonsUsuario")
                        .HasForeignKey("MascoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habilidade");

                    b.Navigation("Mascote");
                });

            modelBuilder.Entity("Tamagochi.Model.Ability", b =>
                {
                    b.Navigation("PokemonsUsuario");
                });

            modelBuilder.Entity("Tamagochi.Model.Mascote", b =>
                {
                    b.Navigation("PokemonsUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}