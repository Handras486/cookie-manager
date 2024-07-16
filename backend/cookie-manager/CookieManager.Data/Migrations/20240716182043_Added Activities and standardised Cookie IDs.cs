using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CookieManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedActivitiesandstandardisedCookieIDs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[,]
                {
                    { new Guid("3dd00032-6164-424a-a199-cbbfc2bdf60a"), "drinks", "London", new DateTime(2024, 11, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7670), "Activity 4 months in future", "Future Activity 4", "Yet another pub" },
                    { new Guid("74714ff8-8b95-482f-9e8e-210209a41ac6"), "drinks", "London", new DateTime(2024, 10, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7664), "Activity 3 months in future", "Future Activity 3", "Another pub" },
                    { new Guid("79f99a97-412b-4a84-8e9b-325026da928f"), "drinks", "London", new DateTime(2024, 12, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7672), "Activity 5 months in future", "Future Activity 5", "Just another pub" },
                    { new Guid("99db7608-675a-4a72-9260-3066be5b140d"), "culture", "Paris", new DateTime(2024, 6, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7646), "Activity 1 month ago", "Past Activity 2", "Louvre" },
                    { new Guid("a19029ae-75e3-4585-93c2-006bf26c1efa"), "culture", "London", new DateTime(2024, 8, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7649), "Activity 1 month in future", "Future Activity 1", "Natural History Museum" },
                    { new Guid("a84977fc-a97d-4bf1-9882-1c1d87783c81"), "drinks", "London", new DateTime(2024, 5, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7634), "Activity 2 months ago", "Past Activity 1", "Pub" },
                    { new Guid("afcdc9cb-8f6c-4ad7-96bd-150ee2e95811"), "music", "London", new DateTime(2025, 1, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7675), "Activity 6 months in future", "Future Activity 6", "Roundhouse Camden" },
                    { new Guid("b19f1289-0ca8-4fa2-8172-95e2e2a637a3"), "travel", "London", new DateTime(2025, 2, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7678), "Activity 2 months ago", "Future Activity 7", "Somewhere on the Thames" },
                    { new Guid("bab38014-9437-49f8-ad16-bb5d97d9407d"), "music", "London", new DateTime(2024, 9, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7651), "Activity 2 months in future", "Future Activity 2", "O2 Arena" },
                    { new Guid("e13c26de-fe4d-484c-8bc2-4dc38fbcff17"), "film", "London", new DateTime(2025, 3, 16, 18, 20, 43, 740, DateTimeKind.Utc).AddTicks(7681), "Activity 8 months in future", "Future Activity 8", "Cinema" }
                });

            migrationBuilder.InsertData(
                table: "Cookies",
                columns: new[] { "Id", "CookieImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("4fc35fc3-caed-4991-8b1b-296bfcf829a5"), "https://en.wikipedia.org/wiki/Fortune_cookie#/media/File:Fortune_cookies.jpg", "Fortune cookie" },
                    { new Guid("c2bdeded-2a11-410a-89d1-03cca513302d"), "https://hips.hearstapps.com/hmg-prod/images/macaroon-vs-macaron-1676039139.jpeg", "Macaroon" },
                    { new Guid("ef8b195c-119c-440c-aa2a-3e1b6ea6cdae"), "https://www.shugarysweets.com/wp-content/uploads/2020/05/chocolate-chip-cookies-recipe.jpg", "Chocolate chip" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Id",
                keyValue: new Guid("4fc35fc3-caed-4991-8b1b-296bfcf829a5"));

            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Id",
                keyValue: new Guid("c2bdeded-2a11-410a-89d1-03cca513302d"));

            migrationBuilder.DeleteData(
                table: "Cookies",
                keyColumn: "Id",
                keyValue: new Guid("ef8b195c-119c-440c-aa2a-3e1b6ea6cdae"));

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
    }
}
