namespace MauLTTQCK
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpThongTin   = new System.Windows.Forms.GroupBox();
            this.lblMaNV       = new System.Windows.Forms.Label();
            this.lblHoTen      = new System.Windows.Forms.Label();
            this.lblGioiTinh   = new System.Windows.Forms.Label();
            this.lblNgaySinh   = new System.Windows.Forms.Label();
            this.lblPhongBan   = new System.Windows.Forms.Label();
            this.lblHeSoLuong  = new System.Windows.Forms.Label();
            this.lblNgayVaoLam = new System.Windows.Forms.Label();
            this.txtMaNV       = new System.Windows.Forms.TextBox();
            this.txtHoTen      = new System.Windows.Forms.TextBox();
            this.txtHeSoLuong  = new System.Windows.Forms.TextBox();
            this.rdoNam        = new System.Windows.Forms.RadioButton();
            this.rdoNu         = new System.Windows.Forms.RadioButton();
            this.dtpNgaySinh   = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayVaoLam = new System.Windows.Forms.DateTimePicker();
            this.cboPhongBan   = new System.Windows.Forms.ComboBox();
            this.btnThem       = new System.Windows.Forms.Button();
            this.btnSua        = new System.Windows.Forms.Button();
            this.btnXoa        = new System.Windows.Forms.Button();
            this.btnLamMoi     = new System.Windows.Forms.Button();
            this.btnThongKe    = new System.Windows.Forms.Button();
            this.btnThoat      = new System.Windows.Forms.Button();
            this.grpDanhSach   = new System.Windows.Forms.GroupBox();
            this.dgvNhanVien   = new System.Windows.Forms.DataGridView();

            this.grpThongTin.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();

            // ── grpThongTin ────────────────────────────────────────────
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name     = "grpThongTin";
            this.grpThongTin.Size     = new System.Drawing.Size(870, 200);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop  = false;
            this.grpThongTin.Text     = "Thông tin nhân viên";
            this.grpThongTin.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaNV, this.lblHoTen, this.lblGioiTinh, this.lblNgaySinh,
                this.lblPhongBan, this.lblHeSoLuong, this.lblNgayVaoLam,
                this.txtMaNV, this.txtHoTen, this.txtHeSoLuong,
                this.rdoNam, this.rdoNu, this.dtpNgaySinh, this.dtpNgayVaoLam,
                this.cboPhongBan,
                this.btnThem, this.btnSua, this.btnXoa, this.btnLamMoi,
                this.btnThongKe, this.btnThoat
            });

            // ── Labels (cột trái) ──────────────────────────────────────
            this.lblMaNV.AutoSize  = true;
            this.lblMaNV.Location  = new System.Drawing.Point(20, 35);
            this.lblMaNV.Text      = "Mã NV";

            this.lblHoTen.AutoSize  = true;
            this.lblHoTen.Location  = new System.Drawing.Point(20, 65);
            this.lblHoTen.Text      = "Họ tên";

            this.lblGioiTinh.AutoSize  = true;
            this.lblGioiTinh.Location  = new System.Drawing.Point(20, 95);
            this.lblGioiTinh.Text      = "Giới tính";

            this.lblNgaySinh.AutoSize  = true;
            this.lblNgaySinh.Location  = new System.Drawing.Point(20, 125);
            this.lblNgaySinh.Text      = "Ngày sinh";

            // ── Labels (cột phải) ──────────────────────────────────────
            this.lblPhongBan.AutoSize  = true;
            this.lblPhongBan.Location  = new System.Drawing.Point(460, 35);
            this.lblPhongBan.Text      = "Phòng ban";

            this.lblHeSoLuong.AutoSize  = true;
            this.lblHeSoLuong.Location  = new System.Drawing.Point(460, 65);
            this.lblHeSoLuong.Text      = "Hệ số lương";

            this.lblNgayVaoLam.AutoSize  = true;
            this.lblNgayVaoLam.Location  = new System.Drawing.Point(460, 95);
            this.lblNgayVaoLam.Text      = "Ngày vào làm";

            // ── txtMaNV ────────────────────────────────────────────────
            this.txtMaNV.Location   = new System.Drawing.Point(120, 30);
            this.txtMaNV.Name       = "txtMaNV";
            this.txtMaNV.Size       = new System.Drawing.Size(120, 22);
            this.txtMaNV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaNV.TabIndex   = 1;

            // ── txtHoTen ──────────────────────────────────────────────
            this.txtHoTen.Location  = new System.Drawing.Point(120, 60);
            this.txtHoTen.Name      = "txtHoTen";
            this.txtHoTen.Size      = new System.Drawing.Size(280, 22);
            this.txtHoTen.TabIndex  = 2;

            // ── rdoNam / rdoNu ─────────────────────────────────────────
            this.rdoNam.AutoSize  = true;
            this.rdoNam.Location  = new System.Drawing.Point(120, 93);
            this.rdoNam.Name      = "rdoNam";
            this.rdoNam.Text      = "Nam";
            this.rdoNam.TabIndex  = 3;

            this.rdoNu.AutoSize   = true;
            this.rdoNu.Location   = new System.Drawing.Point(200, 93);
            this.rdoNu.Name       = "rdoNu";
            this.rdoNu.Text       = "Nữ";
            this.rdoNu.TabIndex   = 4;

            // ── dtpNgaySinh ────────────────────────────────────────────
            this.dtpNgaySinh.Location     = new System.Drawing.Point(120, 120);
            this.dtpNgaySinh.Name         = "dtpNgaySinh";
            this.dtpNgaySinh.Format       = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Size         = new System.Drawing.Size(150, 22);
            this.dtpNgaySinh.TabIndex     = 5;

            // ── cboPhongBan ────────────────────────────────────────────
            this.cboPhongBan.DropDownStyle      = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongBan.FormattingEnabled  = true;
            this.cboPhongBan.Location           = new System.Drawing.Point(570, 30);
            this.cboPhongBan.Name               = "cboPhongBan";
            this.cboPhongBan.Size               = new System.Drawing.Size(240, 24);
            this.cboPhongBan.TabIndex           = 6;

            // ── txtHeSoLuong ───────────────────────────────────────────
            this.txtHeSoLuong.Location  = new System.Drawing.Point(570, 60);
            this.txtHeSoLuong.Name      = "txtHeSoLuong";
            this.txtHeSoLuong.Size      = new System.Drawing.Size(120, 22);
            this.txtHeSoLuong.TabIndex  = 7;

            // ── dtpNgayVaoLam ──────────────────────────────────────────
            this.dtpNgayVaoLam.Location     = new System.Drawing.Point(570, 90);
            this.dtpNgayVaoLam.Name         = "dtpNgayVaoLam";
            this.dtpNgayVaoLam.Format       = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayVaoLam.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayVaoLam.Size         = new System.Drawing.Size(150, 22);
            this.dtpNgayVaoLam.TabIndex     = 8;

            // ── Buttons ────────────────────────────────────────────────
            this.btnThem.Location = new System.Drawing.Point(50,  160);
            this.btnThem.Name     = "btnThem";
            this.btnThem.Size     = new System.Drawing.Size(85, 26);
            this.btnThem.Text     = "&Thêm";
            this.btnThem.TabIndex = 9;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click   += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location  = new System.Drawing.Point(155, 160);
            this.btnSua.Name      = "btnSua";
            this.btnSua.Size      = new System.Drawing.Size(85, 26);
            this.btnSua.Text      = "&Sửa";
            this.btnSua.TabIndex  = 10;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click    += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location  = new System.Drawing.Point(260, 160);
            this.btnXoa.Name      = "btnXoa";
            this.btnXoa.Size      = new System.Drawing.Size(85, 26);
            this.btnXoa.Text      = "&Xóa";
            this.btnXoa.TabIndex  = 11;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click    += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Location = new System.Drawing.Point(365, 160);
            this.btnLamMoi.Name     = "btnLamMoi";
            this.btnLamMoi.Size     = new System.Drawing.Size(85, 26);
            this.btnLamMoi.Text     = "&Làm mới";
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click   += new System.EventHandler(this.btnLamMoi_Click);

            this.btnThongKe.Location = new System.Drawing.Point(580, 160);
            this.btnThongKe.Name     = "btnThongKe";
            this.btnThongKe.Size     = new System.Drawing.Size(95, 26);
            this.btnThongKe.Text     = "Thống &kê";
            this.btnThongKe.TabIndex = 13;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click   += new System.EventHandler(this.btnThongKe_Click);

            this.btnThoat.Location = new System.Drawing.Point(720, 160);
            this.btnThoat.Name     = "btnThoat";
            this.btnThoat.Size     = new System.Drawing.Size(85, 26);
            this.btnThoat.Text     = "T&hoát";
            this.btnThoat.TabIndex = 14;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click   += new System.EventHandler(this.btnThoat_Click);

            // ── grpDanhSach ────────────────────────────────────────────
            this.grpDanhSach.Location = new System.Drawing.Point(12, 222);
            this.grpDanhSach.Name     = "grpDanhSach";
            this.grpDanhSach.Size     = new System.Drawing.Size(870, 260);
            this.grpDanhSach.TabIndex = 1;
            this.grpDanhSach.TabStop  = false;
            this.grpDanhSach.Text     = "Danh sách nhân viên";
            this.grpDanhSach.Controls.Add(this.dgvNhanVien);

            // ── dgvNhanVien ────────────────────────────────────────────
            this.dgvNhanVien.AllowUserToAddRows          = false;
            this.dgvNhanVien.AllowUserToDeleteRows       = false;
            this.dgvNhanVien.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location                    = new System.Drawing.Point(6, 22);
            this.dgvNhanVien.MultiSelect                 = false;
            this.dgvNhanVien.Name                        = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly                    = true;
            this.dgvNhanVien.RowHeadersWidth             = 51;
            this.dgvNhanVien.RowTemplate.Height          = 24;
            this.dgvNhanVien.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size                        = new System.Drawing.Size(858, 232);
            this.dgvNhanVien.TabIndex                    = 0;
            this.dgvNhanVien.CellClick                  += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);

            // ── Form1 ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(894, 496);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.grpDanhSach);
            this.Name            = "Form1";
            this.Text            = "frmQuanLyNhanVien - QUẢN LÝ NHÂN VIÊN";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyPreview      = true;
            this.Load           += new System.EventHandler(this.Form1_Load);

            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox   grpThongTin;
        private System.Windows.Forms.GroupBox   grpDanhSach;
        private System.Windows.Forms.Label      lblMaNV;
        private System.Windows.Forms.Label      lblHoTen;
        private System.Windows.Forms.Label      lblGioiTinh;
        private System.Windows.Forms.Label      lblNgaySinh;
        private System.Windows.Forms.Label      lblPhongBan;
        private System.Windows.Forms.Label      lblHeSoLuong;
        private System.Windows.Forms.Label      lblNgayVaoLam;
        private System.Windows.Forms.TextBox    txtMaNV;
        private System.Windows.Forms.TextBox    txtHoTen;
        private System.Windows.Forms.TextBox    txtHeSoLuong;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;
        private System.Windows.Forms.ComboBox   cboPhongBan;
        private System.Windows.Forms.Button     btnThem;
        private System.Windows.Forms.Button     btnSua;
        private System.Windows.Forms.Button     btnXoa;
        private System.Windows.Forms.Button     btnLamMoi;
        private System.Windows.Forms.Button     btnThongKe;
        private System.Windows.Forms.Button     btnThoat;
        private System.Windows.Forms.DataGridView dgvNhanVien;
    }
}
