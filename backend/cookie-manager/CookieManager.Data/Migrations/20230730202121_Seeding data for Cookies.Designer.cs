﻿// <auto-generated />
using System;
using CookieManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CookieManager.Data.Migrations
{
    [DbContext(typeof(CookieManagerDbContext))]
    [Migration("20230730202121_Seeding data for Cookies")]
    partial class SeedingdataforCookies
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CookieManager.Models.Cookie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CookieImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cookies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af729dc0-c127-4193-a7dd-f3b97ce3d15d"),
                            CookieImageUrl = "https://hips.hearstapps.com/hmg-prod/images/macaroon-vs-macaron-1676039139.jpeg",
                            Name = "Macaroon"
                        },
                        new
                        {
                            Id = new Guid("db2c4249-09b2-4cea-ee93-08db8f741f17"),
                            CookieImageUrl = "https://en.wikipedia.org/wiki/Fortune_cookie#/media/File:Fortune_cookies.jpg",
                            Name = "Fortune cookie"
                        },
                        new
                        {
                            Id = new Guid("887cd1f7-3eff-4329-ee92-08db8f741f17"),
                            CookieImageUrl = "https://www.shugarysweets.com/wp-content/uploads/2020/05/chocolate-chip-cookies-recipe.jpg",
                            Name = "Chocolate chip"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}