using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QuanLySanPham.DAL;
using QuanLySanPham.DAL.Entities;

namespace QuanLySanPham.BUS
{
    public class SanPhamBusiness
    {
        private readonly SanPhamRepository repository = new SanPhamRepository();

        public void InitializeDatabase()
        {
            repository.InitializeDatabase();
        }

        public List<LoaiSanPham> GetLoaiSanPhams()
        {
            return repository.GetLoaiSanPhams();
        }

        public List<SanPham> GetAll()
        {
            return repository.GetAll();
        }

        public List<ValidationResult> KiemTraHopLe(SanPham sanPham)
        {
            sanPham.MaSP = sanPham.MaSP?.Trim() ?? string.Empty;
            sanPham.TenSP = sanPham.TenSP?.Trim() ?? string.Empty;
            sanPham.MaLoai = sanPham.MaLoai?.Trim() ?? string.Empty;

            List<ValidationResult> danhSachLoi = new List<ValidationResult>();
            Validator.TryValidateObject(sanPham, new ValidationContext(sanPham), danhSachLoi, validateAllProperties: true);
            if (sanPham.NgayNhap.Date > DateTime.Today)
            {
                danhSachLoi.Add(new ValidationResult("Ngày nhập không được lớn hơn ngày hiện tại.", new[] { nameof(SanPham.NgayNhap) }));
            }

            if (decimal.Round(sanPham.DonGia, 2) != sanPham.DonGia)
            {
                danhSachLoi.Add(new ValidationResult("Đơn giá chỉ được có tối đa 2 chữ số thập phân.", new[] { nameof(SanPham.DonGia) }));
            }

            return danhSachLoi;
        }

        public void Add(SanPham sanPham)
        {
            KiemTraTruocKhiLuu(sanPham);
            if (repository.ContainsMaSP(sanPham.MaSP))
            {
                throw new InvalidOperationException($"Mã sản phẩm '{sanPham.MaSP}' đã tồn tại.");
            }

            repository.Add(sanPham);
        }

        public void Update(SanPham sanPham, string maSPBanDau)
        {
            KiemTraTruocKhiLuu(sanPham);
            if (!string.Equals(sanPham.MaSP, maSPBanDau, StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Không được đổi mã sản phẩm khi sửa.");
            }

            repository.Update(sanPham);
        }

        public void Delete(string maSP)
        {
            repository.Delete(maSP);
        }

        private void KiemTraTruocKhiLuu(SanPham sanPham)
        {
            List<ValidationResult> danhSachLoi = KiemTraHopLe(sanPham);
            if (danhSachLoi.Count > 0)
            {
                throw new ValidationException(string.Join(" ", danhSachLoi.Select(loi => loi.ErrorMessage)));
            }

            if (!repository.ContainsMaLoai(sanPham.MaLoai))
            {
                throw new ValidationException("Loại sản phẩm đã chọn không tồn tại.");
            }
        }
    }
}
