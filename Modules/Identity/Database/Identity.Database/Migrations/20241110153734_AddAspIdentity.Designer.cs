﻿// <auto-generated />
using System;
using BooksReviewApp.Services.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Database.Migrations
{
    [DbContext(typeof(AspIdentityDbContext))]
    [Migration("20241110153734_AddAspIdentity")]
    partial class AddAspIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Identity.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", "identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("18ba8366-df77-441f-9154-1c897892c449"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "036ff30a-2e32-4bae-a398-5dbbb057ed36",
                            Email = "admin@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEBwc0D9KrqRkGC+odV1hteJh4CScOrii577Ikj25aHr0vtgQ+N/Ec/3PGn7/zg197g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f95d22f8-c6c5-4dc6-852d-ebfd266ec680",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Identity.Domain.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Permissions", "identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4ba76686-1e76-438a-97ab-0404fd9a3418"),
                            Name = "Authors.Get"
                        },
                        new
                        {
                            Id = new Guid("058cd99e-567d-44d7-be35-5873dc3e2350"),
                            Name = "Authors.Post"
                        },
                        new
                        {
                            Id = new Guid("f4b7cde5-6907-4e99-b1ef-d0832ed78deb"),
                            Name = "Authors.Put"
                        },
                        new
                        {
                            Id = new Guid("ad5b2993-b60f-428e-8165-5fe5cff7ea82"),
                            Name = "Authors.Patch"
                        },
                        new
                        {
                            Id = new Guid("1eb3c49c-2216-47eb-a787-8886ef63f24b"),
                            Name = "Authors.Delete"
                        },
                        new
                        {
                            Id = new Guid("c3d04ac2-0984-4982-b225-ef519377b8f6"),
                            Name = "Books.Get"
                        },
                        new
                        {
                            Id = new Guid("35578c7a-5379-4fb7-beb7-b155ae67fab5"),
                            Name = "Books.Post"
                        },
                        new
                        {
                            Id = new Guid("a453268d-fa8d-46d6-b99e-0267f90a11f6"),
                            Name = "Books.Put"
                        },
                        new
                        {
                            Id = new Guid("a8cb9cd2-b8f5-46b6-88b8-14ee1a6c715b"),
                            Name = "Books.Patch"
                        },
                        new
                        {
                            Id = new Guid("e3daa6b2-78c9-4862-9e24-cd36964410f5"),
                            Name = "Books.Delete"
                        },
                        new
                        {
                            Id = new Guid("97f1c91f-dbf0-4775-9dc8-5b61c6b3fdbc"),
                            Name = "Favorites.Get"
                        },
                        new
                        {
                            Id = new Guid("c3d471d5-08c5-4129-a2e6-635293f264ea"),
                            Name = "Favorites.Post"
                        },
                        new
                        {
                            Id = new Guid("af9839ee-09ee-4de3-a329-9072d1ecaab3"),
                            Name = "Favorites.Put"
                        },
                        new
                        {
                            Id = new Guid("ff9b4aa0-60e4-486f-afef-74a9edf68491"),
                            Name = "Favorites.Patch"
                        },
                        new
                        {
                            Id = new Guid("9bebba54-95c3-4378-9382-30c3905746df"),
                            Name = "Favorites.Delete"
                        },
                        new
                        {
                            Id = new Guid("eae384bb-d1d3-4a26-b43e-db07753d5273"),
                            Name = "Genres.Get"
                        },
                        new
                        {
                            Id = new Guid("2457aead-e1fc-481d-a936-50fd8950267d"),
                            Name = "Genres.Post"
                        },
                        new
                        {
                            Id = new Guid("8680c769-6b47-4dcc-8648-e24c54f01089"),
                            Name = "Genres.Put"
                        },
                        new
                        {
                            Id = new Guid("0a552f88-9576-4b8e-aa7b-772ac58de122"),
                            Name = "Genres.Patch"
                        },
                        new
                        {
                            Id = new Guid("cf94afe7-45f8-44ee-9033-7964072bbca7"),
                            Name = "Genres.Delete"
                        },
                        new
                        {
                            Id = new Guid("bfddb695-bf36-47f4-8cfb-04898d2c027c"),
                            Name = "Reviews.Get"
                        },
                        new
                        {
                            Id = new Guid("42a5f8cb-d5d2-4818-ae8b-049e4100a032"),
                            Name = "Reviews.Post"
                        },
                        new
                        {
                            Id = new Guid("ff9513df-859a-4b62-823f-7bde983d78db"),
                            Name = "Reviews.Put"
                        },
                        new
                        {
                            Id = new Guid("f1ab4323-38ac-49ae-848e-16cc02f47274"),
                            Name = "Reviews.Patch"
                        },
                        new
                        {
                            Id = new Guid("9284189f-ab1a-404b-ba29-9923b4d5dc57"),
                            Name = "Reviews.Delete"
                        },
                        new
                        {
                            Id = new Guid("9618e262-27bd-407f-b7a8-d4e0f577bfdf"),
                            Name = "Roles.Get"
                        },
                        new
                        {
                            Id = new Guid("80e4e45b-bef8-440d-a004-ebd5da0d9668"),
                            Name = "Roles.Post"
                        },
                        new
                        {
                            Id = new Guid("37066186-d622-4735-9685-b89da53879a5"),
                            Name = "Roles.Put"
                        },
                        new
                        {
                            Id = new Guid("6eafc07a-0f3f-4072-b09b-4a24aa0a9861"),
                            Name = "Roles.Patch"
                        },
                        new
                        {
                            Id = new Guid("e3ebeab6-fd06-447b-a61f-255dbcaba3be"),
                            Name = "Roles.Delete"
                        },
                        new
                        {
                            Id = new Guid("254e2588-081f-4528-8f1c-6a18a94dbe82"),
                            Name = "Users.Get"
                        },
                        new
                        {
                            Id = new Guid("6ce73608-bf33-4709-af9c-d10169c8c26b"),
                            Name = "Users.Post"
                        },
                        new
                        {
                            Id = new Guid("ea1c1da9-ddff-40f8-8e78-14e1466213c9"),
                            Name = "Users.Put"
                        },
                        new
                        {
                            Id = new Guid("3d30b401-e64e-4cd7-9425-4ae561a8aee0"),
                            Name = "Users.Patch"
                        },
                        new
                        {
                            Id = new Guid("6a9d8629-0730-48ce-b991-1031f3dc8c0e"),
                            Name = "Users.Delete"
                        });
                });

            modelBuilder.Entity("Identity.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles", "identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2c0f0d5-405e-4f3d-a77d-9a5efb6f7c41"),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Identity.Domain.Entities.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "identity");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("18ba8366-df77-441f-9154-1c897892c449"),
                            RoleId = new Guid("a2c0f0d5-405e-4f3d-a77d-9a5efb6f7c41")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "identity");
                });

            modelBuilder.Entity("Identity.Domain.Entities.RolePermission", b =>
                {
                    b.HasOne("Identity.Domain.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Identity.Domain.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Identity.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Identity.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Identity.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Identity.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Identity.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Identity.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Identity.Domain.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Identity.Domain.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
