using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySanPham.DAL.Entities
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [Required(ErrorMessage = "Vui lòng nhập mã sản phẩm.")]
        [StringLength(20, ErrorMessage = "Mã sản phẩm tối đa 20 ký tự.")]
        public string MaSP { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        [StringLength(150, ErrorMessage = "Tên sản phẩm tối đa 150 ký tự.")]
        public string TenSP { get; set; } = string.Empty;

        public DateTime NgayNhap { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải là số nguyên lớn hơn 0.")]
        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0.01", "9999999999999999.99", ParseLimitsInInvariantCulture = true,
            ErrorMessage = "Đơn giá phải lớn hơn 0 và nằm trong giới hạn decimal(18,2).")]
        public decimal DonGia { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại sản phẩm.")]
        [StringLength(10, ErrorMessage = "Mã loại sản phẩm tối đa 10 ký tự.")]
        public string MaLoai { get; set; } = string.Empty;

        [ForeignKey(nameof(MaLoai))]
        public LoaiSanPham LoaiSanPham { get; set; } = null!;
    }
}
