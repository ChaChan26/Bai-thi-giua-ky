using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using QuanLySanPham.DAL.Entities;

namespace QuanLySanPham.DAL
{
    public class SanPhamRepository
    {
        public void InitializeDatabase()
        {
            using (SanPhamDbContext db = new SanPhamDbContext())
            {
                db.Database.Migrate();
            }
        }

        public List<LoaiSanPham> GetLoaiSanPhams()
        {
            using (SanPhamDbContext db = new SanPhamDbContext())
            {
                return db.LoaiSanPhams.AsNoTracking().OrderBy(loai => loai.TenLoai).ToList();
            }
        }

        public List<SanPham> GetAll()
        {
            using (SanPhamDbContext db = new SanPhamDbContext())
            {
                return db.SanPhams.AsNoTracking()
                    .Include(sanPham => sanPham.LoaiSanPham)
                    .OrderBy(sanPham => sanPham.MaSP)
                    .ToList();
            }
        }

        public bool ContainsMaSP(string maSP)
        {
            using (SanPhamDbContext db = new SanPhamDbContext())
            {
                return db.SanPhams.Any(sanPham => sanPham.MaSP == maSP);
            }
        }

        public bool ContainsMaLoai(string maLoai)
        {
            using (SanPhamDbContext db = new SanPhamDbContext())
            {
                return db.LoaiSanPhams.Any(loai => loai.MaLoai == maLoai);
            }
        }

        public void Add(SanPham sanPham)
        {
            using (SanPhamDbContext db = new SanPhamDbContext())
            {
                db.SanPhams.Add(sanPham);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException ex) when (ex.InnerException is MySqlException { ErrorCode: MySqlErrorCode.DuplicateKeyEntry })
                {
                    throw new InvalidOperationException($"Mã sản phẩm '{sanPham.MaSP}' đã tồn tại.", ex);
                }
            }
        }

        public void Update(SanPham sanPham)
        {
            using (SanPhamDbContext db = new SanPhamDbContext())
            {
                SanPham hienTai = TimSanPham(db, sanPham.MaSP);
                hienTai.TenSP = sanPham.TenSP;
                hienTai.NgayNhap = sanPham.NgayNhap;
                hienTai.SoLuong = sanPham.SoLuong;
                hienTai.DonGia = sanPham.DonGia;
                hienTai.MaLoai = sanPham.MaLoai;
                db.SaveChanges();
            }
        }

        public void Delete(string maSP)
        {
            using (SanPhamDbContext db = new SanPhamDbContext())
            {
                db.SanPhams.Remove(TimSanPham(db, maSP));
                db.SaveChanges();
            }
        }

        private static SanPham TimSanPham(SanPhamDbContext db, string maSP)
        {
            return db.SanPhams.Find(maSP)
                ?? throw new InvalidOperationException($"Không tìm thấy sản phẩm có mã '{maSP}'.");
        }
    }
}
