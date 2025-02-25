using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "ODgfjsVRNG8C1ga0SWmuCA==:wTlq+7H0TP1r5zDZB4w+Y/UzgD6n/6QYvPQdx/qkb84=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "uw7u2ftduJIFMPShQkyDig==:trOGuvZ0TJ0UoHd4VQmMw3WcBVHVx/DVjLBfeCYdx10=");
        }
    }
}
