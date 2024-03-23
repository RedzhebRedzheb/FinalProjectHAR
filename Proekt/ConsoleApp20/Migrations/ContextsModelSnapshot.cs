﻿// <auto-generated />
using System;
using ConsoleApp20.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp20.Migrations
{
    [DbContext(typeof(Contexts))]
    partial class ContextsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp20.Data.Models.Book_Premiere", b =>
                {
                    b.Property<int>("Premiere_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("book_Id")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Premiere_Id");

                    b.HasIndex("book_Id");

                    b.ToTable("Book_Premiere");
                });

            modelBuilder.Entity("ConsoleApp20.Data.Models.Books", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ConsoleApp20.Data.Models.BooksGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookGenre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BooksGenre");
                });

            modelBuilder.Entity("ConsoleApp20.Data.Models.Film_Premiere", b =>
                {
                    b.Property<int>("film_premiere_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("film_Id")
                        .HasColumnType("int");

                    b.HasKey("film_premiere_Id");

                    b.HasIndex("film_Id");

                    b.ToTable("Film_Premiere");
                });

            modelBuilder.Entity("ConsoleApp20.Data.Models.Films", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("director_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("ConsoleApp20.Data.Models.FilmsGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("FilmsGenres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmsGenre");
                });

            modelBuilder.Entity("ConsoleApp20.Data.Models.Book_Premiere", b =>
                {
                    b.HasOne("ConsoleApp20.Data.Models.Books", "Books")
                        .WithMany()
                        .HasForeignKey("book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");
                });

            modelBuilder.Entity("ConsoleApp20.Data.Models.BooksGenre", b =>
                {
                    b.HasOne("ConsoleApp20.Data.Models.Books", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("ConsoleApp20.Data.Models.Film_Premiere", b =>
                {
                    b.HasOne("ConsoleApp20.Data.Models.Films", "films")
                        .WithMany()
                        .HasForeignKey("film_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("films");
                });

            modelBuilder.Entity("ConsoleApp20.Data.Models.FilmsGenre", b =>
                {
                    b.HasOne("ConsoleApp20.Data.Models.Films", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });
#pragma warning restore 612, 618
        }
    }
}