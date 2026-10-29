using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MauLTTQCK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPhongBan();
            LoadNhanVien();
            LamMoi();
        }
        private void LoadPhongBan()
        {
            string sql = "SELECT MaPB, TenPB FROM PhongBan ORDER BY TenPB";
            DataTable dt = DBConnection.GetDataTable(sql);

            cboPhongBan.DataSource    = dt;
            cboPhongBan.DisplayMember = "TenPB";
            cboPhongBan.ValueMember   = "MaPB";
        }

        private void LoadNhanVien()
        {
            string sql = @"
                SELECT  nv.MaNV,
                        nv.HoTen,
                        CASE WHEN nv.GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
                        CONVERT(varchar,nv.NgaySinh,103)   AS NgaySinh,
                        pb.TenPB                            AS PhongBan,
                        nv.HeSoLuong,
                        CONVERT(varchar,nv.NgayVaoLam,103) AS NgayVaoLam,
                        nv.HeSoLuong * 2340000              AS Luong
                FROM  NhanVien nv
                INNER JOIN PhongBan pb ON nv.MaPB = pb.MaPB
                ORDER BY nv.MaNV";

            DataTable dt = DBConnection.GetDataTable(sql);
            dgvNhanVien.DataSource = dt;
            DinhDangDgv();
        }

        private void DinhDangDgv()
        {
            if (dgvNhanVien.Columns.Count == 0) return;

            dgvNhanVien.Columns["MaNV"].HeaderText       = "Mã NV";
            dgvNhanVien.Columns["HoTen"].HeaderText      = "Họ tên";
            dgvNhanVien.Columns["GioiTinh"].HeaderText   = "Giới tính";
            dgvNhanVien.Columns["NgaySinh"].HeaderText   = "Ngày sinh";
            dgvNhanVien.Columns["PhongBan"].HeaderText   = "Phòng ban";
            dgvNhanVien.Columns["HeSoLuong"].HeaderText  = "Hệ số lương";
            dgvNhanVien.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
            dgvNhanVien.Columns["Luong"].HeaderText      = "Lương";

            dgvNhanVien.Columns["HeSoLuong"].DefaultCellStyle.Format = "0.00";
            dgvNhanVien.Columns["Luong"].DefaultCellStyle.Format     = "#,##0";
            dgvNhanVien.Columns["Luong"].DefaultCellStyle.Alignment  =
                DataGridViewContentAlignment.MiddleRight;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

            txtMaNV.Text      = row.Cells["MaNV"].Value?.ToString();
            txtHoTen.Text     = row.Cells["HoTen"].Value?.ToString();
            txtHeSoLuong.Text = row.Cells["HeSoLuong"].Value?.ToString();

            rdoNam.Checked = row.Cells["GioiTinh"].Value?.ToString() == "Nam";
            rdoNu.Checked  = !rdoNam.Checked;

            if (DateTime.TryParseExact(row.Cells["NgaySinh"].Value?.ToString(),
                "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ns))
                dtpNgaySinh.Value = ns;

            if (DateTime.TryParseExact(row.Cells["NgayVaoLam"].Value?.ToString(),
                "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime nvl))
                dtpNgayVaoLam.Value = nvl;

            string tenPB = row.Cells["PhongBan"].Value?.ToString();
            foreach (DataRowView item in cboPhongBan.Items)
            {
                if (item["TenPB"].ToString() == tenPB)
                {
                    cboPhongBan.SelectedItem = item;
                    break;
                }
            }
            txtMaNV.ReadOnly = true;
        }

        private bool KiemTraDuLieu(bool kiemTraTrungMa = true)
        {
            string maNV = txtMaNV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Mã NV không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return false;
            }
            if (!Regex.IsMatch(maNV, @"^NV\d{3,}$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Mã NV phải có dạng 'NV' + ít nhất 3 chữ số (VD: NV001, NV008).",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return false;
            }
            if (kiemTraTrungMa)
            {
                string sqlCheck = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
                DataTable dt = DBConnection.GetDataTable(sqlCheck,
                    new SqlParameter[] { new SqlParameter("@MaNV", maNV) });
                if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    MessageBox.Show($"Mã NV '{maNV}' đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNV.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (!decimal.TryParse(txtHeSoLuong.Text.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal hsl)
                || hsl < 2.34m || hsl > 8.00m)
            {
                MessageBox.Show("Hệ số lương phải là số trong khoảng 2.34 – 8.00!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeSoLuong.Focus();
                return false;
            }
            if (dtpNgaySinh.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpNgayVaoLam.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày vào làm không được lớn hơn ngày hiện tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private decimal ParseHeSo()
        {
            decimal.TryParse(txtHeSoLuong.Text.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal v);
            return v;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu(kiemTraTrungMa: true)) return;

            string sql = @"
                INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, NgaySinh, MaPB, HeSoLuong, NgayVaoLam)
                VALUES (@MaNV, @HoTen, @GioiTinh, @NgaySinh, @MaPB, @HeSoLuong, @NgayVaoLam)";

            var prms = new SqlParameter[]
            {
                new SqlParameter("@MaNV",       txtMaNV.Text.Trim().ToUpper()),
                new SqlParameter("@HoTen",      txtHoTen.Text.Trim()),
                new SqlParameter("@GioiTinh",   rdoNam.Checked),
                new SqlParameter("@NgaySinh",   dtpNgaySinh.Value.Date),
                new SqlParameter("@MaPB",       cboPhongBan.SelectedValue),
                new SqlParameter("@HeSoLuong",  ParseHeSo()),
                new SqlParameter("@NgayVaoLam", dtpNgayVaoLam.Value.Date)
            };

            try
            {
                DBConnection.ExecuteNonQuery(sql, prms);
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhanVien();
                LamMoi();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    MessageBox.Show("Mã NV đã tồn tại trong CSDL!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Lỗi cụ thể: " + ex.Message, "Lỗi SQL",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Hãy chọn một dòng trên danh sách để sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraDuLieu(kiemTraTrungMa: false)) return;

            string sql = @"
                UPDATE NhanVien
                SET HoTen      = @HoTen,
                    GioiTinh   = @GioiTinh,
                    NgaySinh   = @NgaySinh,
                    MaPB       = @MaPB,
                    HeSoLuong  = @HeSoLuong,
                    NgayVaoLam = @NgayVaoLam
                WHERE MaNV = @MaNV";

            var prms = new SqlParameter[]
            {
                new SqlParameter("@MaNV",       txtMaNV.Text.Trim()),
                new SqlParameter("@HoTen",      txtHoTen.Text.Trim()),
                new SqlParameter("@GioiTinh",   rdoNam.Checked),
                new SqlParameter("@NgaySinh",   dtpNgaySinh.Value.Date),
                new SqlParameter("@MaPB",       cboPhongBan.SelectedValue),
                new SqlParameter("@HeSoLuong",  ParseHeSo()),
                new SqlParameter("@NgayVaoLam", dtpNgayVaoLam.Value.Date)
            };

            int rows = DBConnection.ExecuteNonQuery(sql, prms);
            if (rows > 0)
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Không tìm thấy nhân viên để cập nhật!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadNhanVien();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Hãy chọn một dòng trên danh sách để xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = txtMaNV.Text.Trim();
            DialogResult res = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhân viên {maNV} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res != DialogResult.Yes) return;

            string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
            var prms   = new SqlParameter[] { new SqlParameter("@MaNV", maNV) };

            DBConnection.ExecuteNonQuery(sql, prms);
            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNhanVien();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtHeSoLuong.Clear();

            rdoNam.Checked = true;

            dtpNgaySinh.Value   = new DateTime(2000, 1, 1);
            dtpNgayVaoLam.Value = DateTime.Today;

            if (cboPhongBan.Items.Count > 0)
                cboPhongBan.SelectedIndex = 0;

            txtMaNV.Focus();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            using (Form2 f2 = new Form2())
            {
                f2.ShowDialog(this);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
                Application.Exit();
        }
    }
}
