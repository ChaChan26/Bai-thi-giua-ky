using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using QuanLySanPham.BUS;
using QuanLySanPham.DAL.Entities;

namespace QuanLySanPham.GUI.Views
{
    public partial class frmQuanLySanPham : Form
    {
        private static readonly CultureInfo VanHoaNhapLieu = CultureInfo.GetCultureInfo("vi-VN");
        private readonly SanPhamBusiness sanPhamBusiness = new SanPhamBusiness();
        private bool daKetNoiCSDL;
        private bool dangCapNhatBang;
        private SanPham? sanPhamDangChon;

        public frmQuanLySanPham()
        {
            InitializeComponent();
            Text = $"Quản lý sản phẩm – {ConfigurationManager.AppSettings["MaSinhVien"] ?? "Mã sinh viên"} – {ConfigurationManager.AppSettings["HoTenSinhVien"] ?? "Họ tên sinh viên"}";
            LamMoiForm();
        }

        private void frmQuanLySanPham_Load(object? sender, EventArgs e)
        {
            try
            {
                sanPhamBusiness.InitializeDatabase();
                cboLoaiSP.DisplayMember = nameof(LoaiSanPham.TenLoai);
                cboLoaiSP.Items.AddRange(sanPhamBusiness.GetLoaiSanPhams().ToArray());
                LoadDanhSachSanPham();
                daKetNoiCSDL = true;
                HienThiThongBao("Đã tải dữ liệu.");
            }
            catch (Exception ex)
            {
                HienThiThongBao("Không tải được dữ liệu. Kiểm tra App.config và MySQL. " + ex.Message, loi: true);
            }
            finally
            {
                LamMoiForm();
                BeginInvoke(new Action(() => txtMaSP.Focus()));
            }
        }

        private void LoadDanhSachSanPham()
        {
            List<SanPham> danhSach = sanPhamBusiness.GetAll();
            dangCapNhatBang = true;
            try
            {
                dgvSanPham.Rows.Clear();
                foreach (SanPham sanPham in danhSach)
                {
                    int index = dgvSanPham.Rows.Add(sanPham.MaSP, sanPham.TenSP, sanPham.NgayNhap,
                        sanPham.SoLuong, sanPham.DonGia, sanPham.LoaiSanPham.TenLoai);
                    dgvSanPham.Rows[index].Tag = sanPham;
                }

                dgvSanPham.CurrentCell = null;
                dgvSanPham.ClearSelection();
            }
            finally
            {
                dangCapNhatBang = false;
            }
        }

        private void LamMoiForm()
        {
            sanPhamDangChon = null;
            errorProvider.Clear();
            txtMaSP.Clear();
            txtMaSP.ReadOnly = false;
            txtTenSP.Clear();
            dtpNgayNhap.Value = DateTime.Today;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            cboLoaiSP.SelectedIndex = -1;

            dangCapNhatBang = true;
            dgvSanPham.CurrentCell = null;
            dgvSanPham.ClearSelection();
            dangCapNhatBang = false;

            btnNhap.Enabled = daKetNoiCSDL;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaSP.Focus();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            LamMoiForm();
            if (daKetNoiCSDL)
            {
                HienThiThongBao("Sẵn sàng nhập sản phẩm mới.");
            }
        }

        private void dgvSanPham_SelectionChanged(object? sender, EventArgs e)
        {
            if (dangCapNhatBang || !daKetNoiCSDL || dgvSanPham.SelectedRows.Count == 0 ||
                dgvSanPham.SelectedRows[0].Tag is not SanPham sanPham)
            {
                return;
            }

            sanPhamDangChon = sanPham;
            errorProvider.Clear();
            txtMaSP.Text = sanPham.MaSP;
            txtMaSP.ReadOnly = true;
            txtTenSP.Text = sanPham.TenSP;
            cboLoaiSP.SelectedItem = cboLoaiSP.Items.Cast<LoaiSanPham>()
                .FirstOrDefault(loai => loai.MaLoai == sanPham.MaLoai);
            dtpNgayNhap.Value = sanPham.NgayNhap;
            txtSoLuong.Text = sanPham.SoLuong.ToString(VanHoaNhapLieu);
            txtDonGia.Text = sanPham.DonGia.ToString("0.##", VanHoaNhapLieu);
            btnNhap.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            HienThiThongBao("Đang chọn sản phẩm " + sanPham.MaSP + ".");
        }

        private SanPham? LayThongTinSanPham()
        {
            errorProvider.Clear();
            int.TryParse(txtSoLuong.Text.Trim(), NumberStyles.Integer, VanHoaNhapLieu, out int soLuong);
            decimal.TryParse(txtDonGia.Text.Trim(), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
                VanHoaNhapLieu, out decimal donGia);

            SanPham sanPham = new SanPham
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                MaLoai = (cboLoaiSP.SelectedItem as LoaiSanPham)?.MaLoai ?? string.Empty,
                NgayNhap = dtpNgayNhap.Value.Date,
                SoLuong = soLuong,
                DonGia = donGia
            };

            List<ValidationResult> danhSachLoi = sanPhamBusiness.KiemTraHopLe(sanPham);
            if (danhSachLoi.Count == 0)
            {
                return sanPham;
            }

            Dictionary<string, Control> dieuKhienTheoThuocTinh = new Dictionary<string, Control>
            {
                [nameof(SanPham.MaSP)] = txtMaSP,
                [nameof(SanPham.TenSP)] = txtTenSP,
                [nameof(SanPham.MaLoai)] = cboLoaiSP,
                [nameof(SanPham.NgayNhap)] = dtpNgayNhap,
                [nameof(SanPham.SoLuong)] = txtSoLuong,
                [nameof(SanPham.DonGia)] = txtDonGia
            };
            Control? dieuKhienDauTien = null;
            foreach (ValidationResult loi in danhSachLoi)
            {
                foreach (string thuocTinh in loi.MemberNames)
                {
                    if (dieuKhienTheoThuocTinh.TryGetValue(thuocTinh, out Control? dieuKhien))
                    {
                        errorProvider.SetError(dieuKhien, loi.ErrorMessage);
                        dieuKhienDauTien ??= dieuKhien;
                    }
                }
            }

            dieuKhienDauTien?.Focus();
            HienThiThongBao(string.Join(" ", danhSachLoi.Select(loi => loi.ErrorMessage)), loi: true);
            return null;
        }

        private void btnNhap_Click(object? sender, EventArgs e)
        {
            SanPham? sanPham = LayThongTinSanPham();
            if (sanPham != null)
            {
                LuuVaTaiLai(() => sanPhamBusiness.Add(sanPham), "nhập");
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (sanPhamDangChon is not SanPham banDau)
            {
                return;
            }

            SanPham? sanPham = LayThongTinSanPham();
            if (sanPham != null)
            {
                LuuVaTaiLai(() => sanPhamBusiness.Update(sanPham, banDau.MaSP), "sửa");
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (sanPhamDangChon is SanPham sanPham && XacNhanXoa(sanPham))
            {
                LuuVaTaiLai(() => sanPhamBusiness.Delete(sanPham.MaSP), "xóa");
            }
        }

        private void LuuVaTaiLai(Action luu, string thaoTac)
        {
            try
            {
                luu();
            }
            catch (Exception ex)
            {
                HienThiThongBao($"Không thể {thaoTac} sản phẩm. {ex.Message}", loi: true);
                return;
            }

            LamMoiForm();
            try
            {
                LoadDanhSachSanPham();
                HienThiThongBao("Đã " + thaoTac + " sản phẩm.");
            }
            catch (Exception ex)
            {
                HienThiThongBao($"Đã {thaoTac} sản phẩm nhưng chưa tải lại được danh sách. {ex.Message}", loi: true);
            }
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool XacNhanXoa(SanPham sanPham)
        {
            return MessageBox.Show(this, $"Xóa sản phẩm '{sanPham.TenSP}' (mã {sanPham.MaSP})?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        protected virtual bool XacNhanThoat()
        {
            return MessageBox.Show(this, "Bạn có muốn thoát chương trình?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = !XacNhanThoat();
            }
        }

        private void HienThiThongBao(string thongBao, bool loi = false)
        {
            lblThongBao.Text = thongBao;
            lblThongBao.ForeColor = loi ? Color.Firebrick : Color.FromArgb(30, 65, 90);
        }
    }
}
