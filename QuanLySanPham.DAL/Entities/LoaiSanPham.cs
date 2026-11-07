using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySanPham.DAL.Entities
{
    [Table("LoaiSanPham")]
    public class LoaiSanPham
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string MaLoai { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string TenLoai { get; set; } = string.Empty;

        public ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}
