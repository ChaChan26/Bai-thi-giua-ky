using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLySanPham.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenLoai = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.MaLoai);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenSP = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayNhap = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaLoai = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LoaiSanPham",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "LoaiSanPham",
                columns: new[] { "MaLoai", "TenLoai" },
                values: new object[,]
                {
                    { "MH", "Màn hình" },
                    { "MT", "Máy tính" },
                    { "PK", "Phụ kiện" }
                });

            migrationBuilder.InsertData(
                table: "SanPham",
                columns: new[] { "MaSP", "DonGia", "MaLoai", "NgayNhap", "SoLuong", "TenSP" },
                values: new object[,]
                {
                    { "SP001", 15500000m, "MT", new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Laptop Dell Inspiron 15" },
                    { "SP002", 450000m, "PK", new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Chuột không dây Logitech M331" },
                    { "SP003", 1980000m, "PK", new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Bàn phím cơ Razer BlackWidow" },
                    { "SP004", 2650000m, "MH", new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Màn hình LG 24MP400 24\"" },
                    { "SP005", 1150000m, "PK", new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Tai nghe Sony WH-CH510" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaLoai",
                table: "SanPham",
                column: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");
        }
    }
}
