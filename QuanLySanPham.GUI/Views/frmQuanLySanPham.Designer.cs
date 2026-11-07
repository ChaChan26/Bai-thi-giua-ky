namespace QuanLySanPham.GUI.Views
{
    partial class frmQuanLySanPham
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblHeaderTitle = new Label();
            grpThongTin = new GroupBox();
            pnlChucNang = new Panel();
            grpDanhSach = new GroupBox();
            lblLoaiSP = new Label();
            cboLoaiSP = new ComboBox();
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblNgayNhap = new Label();
            dtpNgayNhap = new DateTimePicker();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            lblDonGia = new Label();
            txtDonGia = new TextBox();
            btnLamMoi = new Button();
            btnNhap = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            dgvSanPham = new DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colNgayNhap = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colLoaiSP = new DataGridViewTextBoxColumn();
            lblThongBao = new Label();
            errorProvider = new ErrorProvider(components);
            SuspendLayout();

            // lblHeaderTitle
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Text = "QUẢN LÝ SẢN PHẨM";
            lblHeaderTitle.Location = new Point(16, 12);
            lblHeaderTitle.Size = new Size(1068, 49);
            lblHeaderTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeaderTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.FromArgb(27, 43, 56);
            lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;

            // grpThongTin
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Text = "Thông tin sản phẩm";
            grpThongTin.Location = new Point(16, 74);
            grpThongTin.Size = new Size(882, 207);
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.TabIndex = 0;

            // pnlChucNang
            pnlChucNang.Name = "pnlChucNang";
            pnlChucNang.Location = new Point(918, 77);
            pnlChucNang.Size = new Size(166, 201);
            pnlChucNang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlChucNang.TabIndex = 1;

            // grpDanhSach
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Text = "Danh sách sản phẩm";
            grpDanhSach.Location = new Point(16, 298);
            grpDanhSach.Size = new Size(1068, 317);
            grpDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDanhSach.TabIndex = 2;

            // lblLoaiSP
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Text = "Loại sản phẩm:";
            lblLoaiSP.Location = new Point(16, 46);
            lblLoaiSP.AutoSize = true;

            // cboLoaiSP
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Location = new Point(152, 42);
            cboLoaiSP.Size = new Size(267, 29);
            cboLoaiSP.TabIndex = 2;
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;

            grpThongTin.Controls.Add(lblLoaiSP);
            grpThongTin.Controls.Add(cboLoaiSP);

            // lblMaSP
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Text = "Mã sản phẩm:";
            lblMaSP.Location = new Point(16, 99);
            lblMaSP.AutoSize = true;

            // txtMaSP
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Location = new Point(152, 95);
            txtMaSP.Size = new Size(267, 29);
            txtMaSP.TabIndex = 0;
            txtMaSP.MaxLength = 20;

            grpThongTin.Controls.Add(lblMaSP);
            grpThongTin.Controls.Add(txtMaSP);

            // lblTenSP
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Text = "Tên sản phẩm:";
            lblTenSP.Location = new Point(16, 152);
            lblTenSP.AutoSize = true;

            // txtTenSP
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Location = new Point(152, 148);
            txtTenSP.Size = new Size(267, 29);
            txtTenSP.TabIndex = 1;
            txtTenSP.MaxLength = 150;

            grpThongTin.Controls.Add(lblTenSP);
            grpThongTin.Controls.Add(txtTenSP);

            // lblNgayNhap
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Text = "Ngày nhập:";
            lblNgayNhap.Location = new Point(458, 46);
            lblNgayNhap.AutoSize = true;

            // dtpNgayNhap
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Location = new Point(557, 42);
            dtpNgayNhap.Size = new Size(297, 29);
            dtpNgayNhap.TabIndex = 3;
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.CustomFormat = "dd'/'MM'/'yyyy";

            grpThongTin.Controls.Add(lblNgayNhap);
            grpThongTin.Controls.Add(dtpNgayNhap);

            // lblSoLuong
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Text = "Số lượng:";
            lblSoLuong.Location = new Point(458, 99);
            lblSoLuong.AutoSize = true;

            // txtSoLuong
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Location = new Point(557, 95);
            txtSoLuong.Size = new Size(297, 29);
            txtSoLuong.TabIndex = 4;

            grpThongTin.Controls.Add(lblSoLuong);
            grpThongTin.Controls.Add(txtSoLuong);

            // lblDonGia
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Text = "Đơn giá:";
            lblDonGia.Location = new Point(458, 152);
            lblDonGia.AutoSize = true;

            // txtDonGia
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Location = new Point(557, 148);
            txtDonGia.Size = new Size(297, 29);
            txtDonGia.TabIndex = 5;

            grpThongTin.Controls.Add(lblDonGia);
            grpThongTin.Controls.Add(txtDonGia);

            // btnLamMoi
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Text = "Mới";
            btnLamMoi.Location = new Point(0, 0);
            btnLamMoi.Size = new Size(166, 37);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.UseVisualStyleBackColor = true;

            btnLamMoi.Click += btnLamMoi_Click;
            pnlChucNang.Controls.Add(btnLamMoi);

            // btnNhap
            btnNhap.Name = "btnNhap";
            btnNhap.Text = "Nhập";
            btnNhap.Location = new Point(0, 41);
            btnNhap.Size = new Size(166, 37);
            btnNhap.TabIndex = 1;
            btnNhap.UseVisualStyleBackColor = true;

            btnNhap.Click += btnNhap_Click;
            pnlChucNang.Controls.Add(btnNhap);

            // btnSua
            btnSua.Name = "btnSua";
            btnSua.Text = "Sửa";
            btnSua.Location = new Point(0, 82);
            btnSua.Size = new Size(166, 37);
            btnSua.TabIndex = 2;
            btnSua.UseVisualStyleBackColor = true;

            btnSua.Click += btnSua_Click;
            pnlChucNang.Controls.Add(btnSua);

            // btnXoa
            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(0, 123);
            btnXoa.Size = new Size(166, 37);
            btnXoa.TabIndex = 3;
            btnXoa.UseVisualStyleBackColor = true;

            btnXoa.Click += btnXoa_Click;
            pnlChucNang.Controls.Add(btnXoa);

            // btnThoat
            btnThoat.Name = "btnThoat";
            btnThoat.Text = "Thoát";
            btnThoat.Location = new Point(0, 164);
            btnThoat.Size = new Size(166, 37);
            btnThoat.TabIndex = 4;
            btnThoat.UseVisualStyleBackColor = true;

            btnThoat.Click += btnThoat_Click;
            pnlChucNang.Controls.Add(btnThoat);

            // dgvSanPham
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.Location = new Point(10, 25);
            dgvSanPham.Size = new Size(1048, 281);
            dgvSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.MultiSelect = false;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.RowHeadersWidth = 30;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.BackgroundColor = Color.FromArgb(228, 237, 229);
            dgvSanPham.TabIndex = 0;

            dgvSanPham.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 248);
            dgvSanPham.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.RowTemplate.Height = 29;

            // colMaSP
            colMaSP.Name = "colMaSP";
            colMaSP.HeaderText = "Mã SP";
            colMaSP.FillWeight = 72;

            // colTenSP
            colTenSP.Name = "colTenSP";
            colTenSP.HeaderText = "Tên sản phẩm";
            colTenSP.FillWeight = 185;

            // colNgayNhap
            colNgayNhap.Name = "colNgayNhap";
            colNgayNhap.HeaderText = "Ngày nhập";
            colNgayNhap.FillWeight = 105;

            // colSoLuong
            colSoLuong.Name = "colSoLuong";
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.FillWeight = 75;

            // colDonGia
            colDonGia.Name = "colDonGia";
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.FillWeight = 100;

            // colLoaiSP
            colLoaiSP.Name = "colLoaiSP";
            colLoaiSP.HeaderText = "Loại sản phẩm";
            colLoaiSP.FillWeight = 132;

            colNgayNhap.DefaultCellStyle.Format = "dd'/'MM'/'yyyy";
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDonGia.DefaultCellStyle.Format = "#,##0.##";
            colDonGia.DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colNgayNhap, colSoLuong, colDonGia, colLoaiSP });
            dgvSanPham.SelectionChanged += dgvSanPham_SelectionChanged;
            grpDanhSach.Controls.Add(dgvSanPham);

            // lblThongBao
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Location = new Point(16, 623);
            lblThongBao.Size = new Size(1068, 46);
            lblThongBao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 10F);
            BackColor = SystemColors.Control;
            ClientSize = new Size(1100, 679);
            MinimumSize = new Size(1116, 718);
            StartPosition = FormStartPosition.CenterScreen;
            Name = "frmQuanLySanPham";
            AcceptButton = btnNhap;
            CancelButton = btnThoat;
            btnThoat.DialogResult = DialogResult.None;
            Controls.Add(lblHeaderTitle);
            Controls.Add(grpThongTin);
            Controls.Add(pnlChucNang);
            Controls.Add(grpDanhSach);
            Controls.Add(lblThongBao);
            Load += frmQuanLySanPham_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeaderTitle;
        private GroupBox grpThongTin;
        private Panel pnlChucNang;
        private GroupBox grpDanhSach;
        private Label lblLoaiSP;
        private ComboBox cboLoaiSP;
        private Label lblMaSP;
        private TextBox txtMaSP;
        private Label lblTenSP;
        private TextBox txtTenSP;
        private Label lblNgayNhap;
        private DateTimePicker dtpNgayNhap;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
        private Label lblDonGia;
        private TextBox txtDonGia;
        private Button btnLamMoi;
        private Button btnNhap;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private DataGridView dgvSanPham;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colNgayNhap;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colLoaiSP;
        private Label lblThongBao;
        private ErrorProvider errorProvider;
    }
}
