using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanySite.Migrations
{
    public partial class _TableFeedBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeWord",
                table: "ServiceItems");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ServiceItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "0ee1a2d6-5b20-4321-8b4a-146f6e5435c5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "UserName" },
                values: new object[] { "cf8dfbf9-5f31-4251-a8f9-4b545bae7251", "admin@email.com", "admin@EMAIL.COM", "AQAAAAEAACcQAAAAELYTuENmHCf9b+fOz7cqnQqJ7dAAQUgw81eOS9Ddd5638Oo0rNPEJzSsCIlWpBi+nA==", "admin" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 22, 2, 32, 57, 886, DateTimeKind.Utc).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 22, 2, 32, 57, 886, DateTimeKind.Utc).AddTicks(7397));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 22, 2, 32, 57, 886, DateTimeKind.Utc).AddTicks(9592));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ServiceItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CodeWord",
                table: "ServiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "5e6b99ad-1113-4fb9-a519-7f012eb03215");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "UserName" },
                values: new object[] { "61bdb4fc-8c87-400c-b8ea-dd2ccf6bc9af", "CompanyName@gmail.com", "CompanyName@gmail.com", "AQAAAAEAACcQAAAAEAFmUT5OWKHK7FD8juOrZucl8h5qz/Z8IXR3C2lQjdVut9f67jBK5Aa3tszrlC2lMQ==", "Admin" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 14, 22, 44, 57, 395, DateTimeKind.Utc).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 14, 22, 44, 57, 394, DateTimeKind.Utc).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2020, 10, 14, 22, 44, 57, 395, DateTimeKind.Utc).AddTicks(1185));
        }
    }
}
