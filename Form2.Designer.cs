namespace MauLTTQCK
{
    partial class Form2
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
            this.grpDieuKien  = new System.Windows.Forms.GroupBox();
            this.lblPhongBan  = new System.Windows.Forms.Label();
            this.lblGioiTinh  = new System.Windows.Forms.Label();
            this.cboPhongBan  = new System.Windows.Forms.ComboBox();
            this.cboGioiTinh  = new System.Windows.Forms.ComboBox();
            this.btnTimKiem   = new System.Windows.Forms.Button();
            this.btnXuatBaoCao = new System.Windows.Forms.Button();
            this.btnDong      = new System.Windows.Forms.Button();
            this.grpKetQua    = new System.Windows.Forms.GroupBox();
            this.dgvKetQua    = new System.Windows.Forms.DataGridView();
            this.grpThongKe   = new System.Windows.Forms.GroupBox();
            this.lblLbSoNV    = new System.Windows.Forms.Label();
            this.lblSoNhanVien = new System.Windows.Forms.Label();
            this.lblLbTongLuong = new System.Windows.Forms.Label();
            this.lblTongLuong  = new System.Windows.Forms.Label();
            this.lblLbHeSoCaoNhat = new System.Windows.Forms.Label();
            this.lblHeSoCaoNhat   = new System.Windows.Forms.Label();

            this.grpDieuKien.SuspendLayout();
            this.grpKetQua.SuspendLayout();
            this.grpThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();

            // ── grpDieuKien ───────────────────────────────────────────
            this.grpDieuKien.Location = new System.Drawing.Point(12, 12);
            this.grpDieuKien.Name     = "grpDieuKien";
            this.grpDieuKien.Size     = new System.Drawing.Size(860, 70);
            this.grpDieuKien.TabIndex = 0;
            this.grpDieuKien.TabStop  = false;
            this.grpDieuKien.Text     = "Điều kiện tìm kiếm";
            this.grpDieuKien.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPhongBan, this.cboPhongBan,
                this.lblGioiTinh, this.cboGioiTinh,
                this.btnTimKiem, this.btnXuatBaoCao, this.btnDong
            });

            // lblPhongBan
            this.lblPhongBan.AutoSize = true;
            this.lblPhongBan.Location = new System.Drawing.Point(15, 30);
            this.lblPhongBan.Text     = "Phòng ban";

            // cboPhongBan
            this.cboPhongBan.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongBan.FormattingEnabled = true;
            this.cboPhongBan.Location          = new System.Drawing.Point(90, 26);
            this.cboPhongBan.Name              = "cboPhongBan";
            this.cboPhongBan.Size              = new System.Drawing.Size(160, 24);
            this.cboPhongBan.TabIndex          = 1;

            // lblGioiTinh
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(270, 30);
            this.lblGioiTinh.Text     = "Giới tính";

            // cboGioiTinh
            this.cboGioiTinh.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Location          = new System.Drawing.Point(335, 26);
            this.cboGioiTinh.Name              = "cboGioiTinh";
            this.cboGioiTinh.Size              = new System.Drawing.Size(120, 24);
            this.cboGioiTinh.TabIndex          = 2;

            // btnTimKiem
            this.btnTimKiem.Location = new System.Drawing.Point(490, 25);
            this.btnTimKiem.Name     = "btnTimKiem";
            this.btnTimKiem.Size     = new System.Drawing.Size(100, 26);
            this.btnTimKiem.Text     = "&Tìm kiếm";
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click   += new System.EventHandler(this.btnTimKiem_Click);

            // btnXuatBaoCao
            this.btnXuatBaoCao.Location = new System.Drawing.Point(605, 25);
            this.btnXuatBaoCao.Name     = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size     = new System.Drawing.Size(110, 26);
            this.btnXuatBaoCao.Text     = "&Xuất báo cáo";
            this.btnXuatBaoCao.TabIndex = 4;
            this.btnXuatBaoCao.UseVisualStyleBackColor = true;
            this.btnXuatBaoCao.Click   += new System.EventHandler(this.btnXuatBaoCao_Click);

            // btnDong
            this.btnDong.Location = new System.Drawing.Point(738, 25);
            this.btnDong.Name     = "btnDong";
            this.btnDong.Size     = new System.Drawing.Size(90, 26);
            this.btnDong.Text     = "&Đóng";
            this.btnDong.TabIndex = 5;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click   += new System.EventHandler(this.btnDong_Click);

            // ── grpKetQua ─────────────────────────────────────────────
            this.grpKetQua.Location = new System.Drawing.Point(12, 90);
            this.grpKetQua.Name     = "grpKetQua";
            this.grpKetQua.Size     = new System.Drawing.Size(860, 280);
            this.grpKetQua.TabIndex = 1;
            this.grpKetQua.TabStop  = false;
            this.grpKetQua.Text     = "Kết quả";
            this.grpKetQua.Controls.Add(this.dgvKetQua);

            // dgvKetQua
            this.dgvKetQua.AllowUserToAddRows          = false;
            this.dgvKetQua.AllowUserToDeleteRows       = false;
            this.dgvKetQua.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location                    = new System.Drawing.Point(6, 22);
            this.dgvKetQua.MultiSelect                 = false;
            this.dgvKetQua.Name                        = "dgvKetQua";
            this.dgvKetQua.ReadOnly                    = true;
            this.dgvKetQua.RowHeadersWidth             = 51;
            this.dgvKetQua.RowTemplate.Height          = 24;
            this.dgvKetQua.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size                        = new System.Drawing.Size(848, 252);
            this.dgvKetQua.TabIndex                    = 0;

            // ── grpThongKe ────────────────────────────────────────────
            this.grpThongKe.Location = new System.Drawing.Point(12, 380);
            this.grpThongKe.Name     = "grpThongKe";
            this.grpThongKe.Size     = new System.Drawing.Size(860, 80);
            this.grpThongKe.TabIndex = 2;
            this.grpThongKe.TabStop  = false;
            this.grpThongKe.Text     = "Thống kê";
            this.grpThongKe.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblLbSoNV, this.lblSoNhanVien,
                this.lblLbTongLuong, this.lblTongLuong,
                this.lblLbHeSoCaoNhat, this.lblHeSoCaoNhat
            });

            // Row 1: Số nhân viên
            this.lblLbSoNV.AutoSize  = true;
            this.lblLbSoNV.Location  = new System.Drawing.Point(20, 28);
            this.lblLbSoNV.Text      = "Số nhân viên:";
            this.lblLbSoNV.Font      = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);

            this.lblSoNhanVien.AutoSize  = true;
            this.lblSoNhanVien.Location  = new System.Drawing.Point(110, 28);
            this.lblSoNhanVien.Text      = "0";
            this.lblSoNhanVien.ForeColor = System.Drawing.Color.Blue;
            this.lblSoNhanVien.Font      = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);

            // Tổng lương (giữa)
            this.lblLbTongLuong.AutoSize  = true;
            this.lblLbTongLuong.Location  = new System.Drawing.Point(280, 28);
            this.lblLbTongLuong.Text      = "Tổng lương:";
            this.lblLbTongLuong.Font      = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);

            this.lblTongLuong.AutoSize  = true;
            this.lblTongLuong.Location  = new System.Drawing.Point(370, 28);
            this.lblTongLuong.Text      = "0";
            this.lblTongLuong.ForeColor = System.Drawing.Color.Blue;
            this.lblTongLuong.Font      = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);

            // Row 2: Hệ số lương cao nhất
            this.lblLbHeSoCaoNhat.AutoSize  = true;
            this.lblLbHeSoCaoNhat.Location  = new System.Drawing.Point(20, 52);
            this.lblLbHeSoCaoNhat.Text      = "Hệ số lương cao nhất:";
            this.lblLbHeSoCaoNhat.Font      = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);

            this.lblHeSoCaoNhat.AutoSize  = true;
            this.lblHeSoCaoNhat.Location  = new System.Drawing.Point(165, 52);
            this.lblHeSoCaoNhat.Text      = "0";
            this.lblHeSoCaoNhat.ForeColor = System.Drawing.Color.Blue;
            this.lblHeSoCaoNhat.Font      = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);

            // ── Form2 ─────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(884, 474);
            this.Controls.Add(this.grpDieuKien);
            this.Controls.Add(this.grpKetQua);
            this.Controls.Add(this.grpThongKe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "Form2";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "frmThongKe - TÌM KIẾM VÀ THỐNG KÊ";
            this.Load           += new System.EventHandler(this.Form2_Load);

            this.grpDieuKien.ResumeLayout(false);
            this.grpDieuKien.PerformLayout();
            this.grpKetQua.ResumeLayout(false);
            this.grpThongKe.ResumeLayout(false);
            this.grpThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox   grpDieuKien;
        private System.Windows.Forms.Label      lblPhongBan;
        private System.Windows.Forms.Label      lblGioiTinh;
        private System.Windows.Forms.ComboBox   cboPhongBan;
        private System.Windows.Forms.ComboBox   cboGioiTinh;
        private System.Windows.Forms.Button     btnTimKiem;
        private System.Windows.Forms.Button     btnXuatBaoCao;
        private System.Windows.Forms.Button     btnDong;
        private System.Windows.Forms.GroupBox   grpKetQua;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.GroupBox   grpThongKe;
        private System.Windows.Forms.Label      lblLbSoNV;
        private System.Windows.Forms.Label      lblSoNhanVien;
        private System.Windows.Forms.Label      lblLbTongLuong;
        private System.Windows.Forms.Label      lblTongLuong;
        private System.Windows.Forms.Label      lblLbHeSoCaoNhat;
        private System.Windows.Forms.Label      lblHeSoCaoNhat;
    }
}
