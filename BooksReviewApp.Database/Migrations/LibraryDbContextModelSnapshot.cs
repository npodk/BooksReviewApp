﻿// <auto-generated />
using System;
using BooksReviewApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BooksReviewApp.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Authors", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "American novelist, essayist, and short story writer",
                            Name = "F. Scott",
                            Surname = "Fitzgerald"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "American journalist, novelist, and short-story writer",
                            Name = "Ernest",
                            Surname = "Hemingway"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "English writer, considered one of the most important modernist 20th-century authors",
                            Name = "Virginia",
                            Surname = "Woolf"
                        });
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("PublishingYear")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("WritingYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "It tells the story of Jay Gatsby, a self-made millionaire, and his pursuit of Daisy Buchanan, a wealthy young woman whom he loved in his youth.",
                            ISBN = "9781536216769",
                            Publisher = "Candlewick Press",
                            PublishingYear = 2021,
                            Title = "The Great Gatsby",
                            WritingYear = 1925
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Description = "A dystopian social science fiction novel and cautionary tale.",
                            ISBN = "9780451524935",
                            Publisher = "Penguin Classics",
                            PublishingYear = 2020,
                            Title = "1984",
                            WritingYear = 1949
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Description = "The story of the young and innocent Scout Finch, her brother Jem, and their widowed father, Atticus.",
                            ISBN = "9780060935467",
                            Publisher = "HarperCollins",
                            PublishingYear = 2019,
                            Title = "To Kill a Mockingbird",
                            WritingYear = 1960
                        });
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenres", "dbo");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            BookId = 2,
                            GenreId = 2
                        },
                        new
                        {
                            BookId = 3,
                            GenreId = 3
                        });
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            DateAdded = new DateTime(2024, 5, 3, 10, 18, 22, 537, DateTimeKind.Utc).AddTicks(8222),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            DateAdded = new DateTime(2024, 5, 3, 10, 18, 22, 537, DateTimeKind.Utc).AddTicks(8233),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            DateAdded = new DateTime(2024, 5, 3, 10, 18, 22, 537, DateTimeKind.Utc).AddTicks(8236),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Timeless literature",
                            Name = "Classic"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Complex storytelling",
                            Name = "Novel"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Bleak future",
                            Name = "Dystopian"
                        });
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews", "dbo", t =>
                        {
                            t.HasCheckConstraint("CK_Reviews_Rating", "\"Rating\" BETWEEN 1 AND 5");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Rating = 4,
                            Text = "This book is a timeless masterpiece, capturing the essence of the Roaring Twenties",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            Rating = 5,
                            Text = "This book offers a prophetic and unsettling vision of a dystopian future",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            Rating = 4,
                            Text = "This book is a profound narrative on racial injustice and moral integrity",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "readerjane@example.com",
                            Password = "Pass1234!",
                            Username = "JaneReader"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bookwormtom@example.com",
                            Password = "Secure*9876",
                            Username = "BookwormTom"
                        },
                        new
                        {
                            Id = 3,
                            Email = "litloveralex@example.com",
                            Password = "BookLover$2024",
                            Username = "LitLoverAlex"
                        });
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Book", b =>
                {
                    b.HasOne("BooksReviewApp.Domain.Core.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.BookGenre", b =>
                {
                    b.HasOne("BooksReviewApp.Domain.Core.Entities.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksReviewApp.Domain.Core.Entities.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Favorite", b =>
                {
                    b.HasOne("BooksReviewApp.Domain.Core.Entities.Book", "Book")
                        .WithMany("Favorites")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksReviewApp.Domain.Core.Entities.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Review", b =>
                {
                    b.HasOne("BooksReviewApp.Domain.Core.Entities.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksReviewApp.Domain.Core.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Book", b =>
                {
                    b.Navigation("BookGenres");

                    b.Navigation("Favorites");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.Genre", b =>
                {
                    b.Navigation("BookGenres");
                });

            modelBuilder.Entity("BooksReviewApp.Domain.Core.Entities.User", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
