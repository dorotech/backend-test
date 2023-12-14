﻿// <auto-generated />
using System;
using DTech.CityBookStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DTech.CityBookStore.Data.Migrations
{
    [DbContext(typeof(CityBookStoreContext))]
    [Migration("20231214200333_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DTech.CityBookStore.Domain.Books.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Author");

                    b.Property<decimal?>("DimensionHeight")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("DimensionHeight");

                    b.Property<decimal?>("DimensionLength")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("DimensionLength");

                    b.Property<decimal?>("DimensionWidth")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("DimensionWidth");

                    b.Property<int>("Edition")
                        .HasColumnType("int")
                        .HasColumnName("Edition");

                    b.Property<string>("ISBN10")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("ISBN10");

                    b.Property<string>("ISBN13")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("ISBN13");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Language");

                    b.Property<int>("Pages")
                        .HasColumnType("int")
                        .HasColumnName("Pages");

                    b.Property<string>("Publishing")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Publishing");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("ISBN10")
                        .IsUnique()
                        .HasDatabaseName("IX_Book_Unique_ISBN10");

                    b.HasIndex("ISBN13")
                        .IsUnique()
                        .HasDatabaseName("IX_Book_Unique_ISBN13");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("DTech.CityBookStore.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset(7)")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("varchar(350)")
                        .HasColumnName("FullName");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("IsAdmin");

                    b.Property<DateTimeOffset?>("LastLoginDate")
                        .HasColumnType("datetimeoffset(7)")
                        .HasColumnName("LastLoginDate");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Password");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasDatabaseName("IX_Users_Unique_Login");

                    b.ToTable("Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
