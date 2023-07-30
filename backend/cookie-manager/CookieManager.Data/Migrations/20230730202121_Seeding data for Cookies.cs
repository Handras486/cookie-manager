using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CookieManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforCookies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Id", "CookieImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("887cd1f7-3eff-4329-ee92-08db8f741f17"), "https://www.shugarysweets.com/wp-content/uploads/2020/05/chocolate-chip-cookies-recipe.jpg", "Chocolate chip" },
                    { new Guid("af729dc0-c127-4193-a7dd-f3b97ce3d15d"), "https://hips.hearstapps.com/hmg-prod/images/macaroon-vs-macaron-1676039139.jpeg", "Macaroon" },
                    { new Guid("db2c4249-09b2-4cea-ee93-08db8f741f17"), "https://en.wikipedia.org/wiki/Fortune_cookie#/media/File:Fortune_cookies.jpg", "Fortune cookie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Id",
                keyValue: new Guid("887cd1f7-3eff-4329-ee92-08db8f741f17"));

            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Id",
                keyValue: new Guid("af729dc0-c127-4193-a7dd-f3b97ce3d15d"));

            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Id",
                keyValue: new Guid("db2c4249-09b2-4cea-ee93-08db8f741f17"));
        }
    }
}
