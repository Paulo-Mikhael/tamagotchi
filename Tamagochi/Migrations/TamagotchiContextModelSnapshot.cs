﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tamagochi.Data;

#nullable disable

namespace Tamagochi.Migrations
{
    [DbContext(typeof(TamagotchiContext))]
    partial class TamagotchiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tamagochi.Model.Abilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MascoteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascoteId");

                    b.ToTable("ConjuntoHabildades");
                });

            modelBuilder.Entity("Tamagochi.Model.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConjuntoHabilidadesId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConjuntoHabilidadesId");

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

            modelBuilder.Entity("Tamagochi.Model.Abilities", b =>
                {
                    b.HasOne("Tamagochi.Model.Mascote", "Mascote")
                        .WithMany("Habilidades")
                        .HasForeignKey("MascoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascote");
                });

            modelBuilder.Entity("Tamagochi.Model.Ability", b =>
                {
                    b.HasOne("Tamagochi.Model.Abilities", "ConjuntoHabilidades")
                        .WithMany("ConjuntoHabilidades")
                        .HasForeignKey("ConjuntoHabilidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConjuntoHabilidades");
                });

            modelBuilder.Entity("Tamagochi.Model.Abilities", b =>
                {
                    b.Navigation("ConjuntoHabilidades");
                });

            modelBuilder.Entity("Tamagochi.Model.Mascote", b =>
                {
                    b.Navigation("Habilidades");
                });
#pragma warning restore 612, 618
        }
    }
}
