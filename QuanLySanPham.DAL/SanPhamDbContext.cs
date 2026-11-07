using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using QuanLySanPham.DAL.Entities;

namespace QuanLySanPham.DAL
{
    public class SanPhamDbContext : DbContext
    {
        public DbSet<LoaiSanPham> LoaiSanPhams
        {
            get
            {
                return Set<LoaiSanPham>();
            }
        }

        public DbSet<SanPham> SanPhams
        {
            get
            {
                return Set<SanPham>();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? chuoiKetNoi = ConfigurationManager.ConnectionStrings["QuanLySanPham"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(chuoiKetNoi))
            {
                throw new ConfigurationErrorsException("Thiếu chuỗi kết nối QuanLySanPham trong App.config.");
            }

            string phienBan = ConfigurationManager.AppSettings["MySqlServerVersion"] ?? "8.4.0-mysql";
            ServerVersion serverVersion = ServerVersion.Parse(phienBan);
            optionsBuilder.UseMySql(chuoiKetNoi, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSanPham>().HasData(
                new LoaiSanPham
                {
                    MaLoai = "MT",
                    TenLoai = "Máy tính"
                },
                new LoaiSanPham
                {
                    MaLoai = "PK",
                    TenLoai = "Phụ kiện"
                },
                new LoaiSanPham
                {
                    MaLoai = "MH",
                    TenLoai = "Màn hình"
                });

            modelBuilder.Entity<SanPham>().HasData(
                new SanPham
                {
                    MaSP = "SP001",
                    TenSP = "Laptop Dell Inspiron 15",
                    NgayNhap = new DateTime(2026, 7, 1),
                    SoLuong = 10,
                    DonGia = 15500000m,
                    MaLoai = "MT"
                },
                new SanPham
                {
                    MaSP = "SP002",
                    TenSP = "Chuột không dây Logitech M331",
                    NgayNhap = new DateTime(2026, 6, 15),
                    SoLuong = 25,
                    DonGia = 450000m,
                    MaLoai = "PK"
                },
                new SanPham
                {
                    MaSP = "SP003",
                    TenSP = "Bàn phím cơ Razer BlackWidow",
                    NgayNhap = new DateTime(2026, 6, 20),
                    SoLuong = 15,
                    DonGia = 1980000m,
                    MaLoai = "PK"
                },
                new SanPham
                {
                    MaSP = "SP004",
                    TenSP = "Màn hình LG 24MP400 24\"",
                    NgayNhap = new DateTime(2026, 7, 5),
                    SoLuong = 12,
                    DonGia = 2650000m,
                    MaLoai = "MH"
                },
                new SanPham
                {
                    MaSP = "SP005",
                    TenSP = "Tai nghe Sony WH-CH510",
                    NgayNhap = new DateTime(2026, 7, 10),
                    SoLuong = 20,
                    DonGia = 1150000m,
                    MaLoai = "PK"
                });
        }
    }
}
