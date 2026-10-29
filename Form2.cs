using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace MauLTTQCK
{
    public partial class Form2 : Form
    {
        private DataTable ketQuaHienTai;
        private string phongBanKetQua = "Tất cả";
        private string gioiTinhKetQua = "Tất cả";
     
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPhongBan();
                TimKiem(false); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể nạp danh sách phòng ban. Hãy kiểm tra kết nối SQL Server.\n\n" + ex.Message,
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void LoadPhongBan()
        {
            string sql = "SELECT MaPB, TenPB FROM PhongBan ORDER BY TenPB";
            DataTable dt = DBConnection.GetDataTable(sql);

            DataRow drAll = dt.NewRow();
            drAll["MaPB"] = "";
            drAll["TenPB"] = "Tất cả";
            dt.Rows.InsertAt(drAll, 0);

            cboPhongBan.DataSource    = dt;
            cboPhongBan.DisplayMember = "TenPB";
            cboPhongBan.ValueMember   = "MaPB";
            cboPhongBan.SelectedIndex = 0;   

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Tất cả", "Nam", "Nữ" });
            cboGioiTinh.SelectedIndex = 0;
        }

        private void TimKiem(bool thongBaoNeuRong = true)
        {
            string maPB    = cboPhongBan.SelectedValue?.ToString() ?? "";
            string gioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "Tất cả";

            string sql = @"
                SELECT  nv.MaNV,
                        nv.HoTen,
                        CASE WHEN nv.GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
                        nv.NgaySinh,
                        pb.TenPB                            AS PhongBan,
                        nv.HeSoLuong,
                        nv.NgayVaoLam,
                        nv.HeSoLuong * 2340000              AS Luong
                FROM  NhanVien nv
                INNER JOIN PhongBan pb ON nv.MaPB = pb.MaPB
                WHERE  (@MaPB = '' OR nv.MaPB = @MaPB)
                  AND  (@GioiTinh = N'Tất cả'
                        OR (nv.GioiTinh = 1 AND @GioiTinh = N'Nam')
                        OR (nv.GioiTinh = 0 AND @GioiTinh = N'Nữ'))
                ORDER BY pb.TenPB, nv.MaNV";

            var prms = new SqlParameter[]
            {
                new SqlParameter("@MaPB",     maPB),
                new SqlParameter("@GioiTinh", gioiTinh)
            };

            DataTable dt;
            try
            {
                dt = DBConnection.GetDataTable(sql, prms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tìm dữ liệu. Hãy kiểm tra kết nối SQL Server.\n\n" + ex.Message,
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ketQuaHienTai = dt;
            phongBanKetQua = cboPhongBan.Text;
            gioiTinhKetQua = cboGioiTinh.Text;
            dgvKetQua.DataSource = dt;
            DinhDangDgv();

            if (dt.Rows.Count == 0)
            {
                if (thongBaoNeuRong)
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CapNhatThongKe(dt);
        }

        private void DinhDangDgv()
        {
            if (dgvKetQua.Columns.Count == 0) return;

            dgvKetQua.Columns["MaNV"].HeaderText       = "Mã NV";
            dgvKetQua.Columns["HoTen"].HeaderText      = "Họ tên";
            dgvKetQua.Columns["GioiTinh"].HeaderText   = "Giới tính";
            dgvKetQua.Columns["NgaySinh"].HeaderText   = "Ngày sinh";
            dgvKetQua.Columns["PhongBan"].HeaderText   = "Phòng ban";
            dgvKetQua.Columns["HeSoLuong"].HeaderText  = "Hệ số lương";
            dgvKetQua.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
            dgvKetQua.Columns["Luong"].HeaderText      = "Lương";

            dgvKetQua.Columns["HeSoLuong"].DefaultCellStyle.Format    = "0.00";
            dgvKetQua.Columns["Luong"].DefaultCellStyle.Format        = "#,##0";
            dgvKetQua.Columns["Luong"].DefaultCellStyle.Alignment     =
                DataGridViewContentAlignment.MiddleRight;
            dgvKetQua.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvKetQua.Columns["NgayVaoLam"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void CapNhatThongKe(DataTable dt)
        {
            int soNV = dt.Rows.Count;
            lblSoNhanVien.Text = soNV.ToString();

            if (soNV == 0)
            {
                lblTongLuong.Text    = "0";
                lblHeSoCaoNhat.Text  = "0";
                return;
            }

            decimal tongLuong   = 0;
            decimal heCaoNhat   = 0;

            foreach (DataRow row in dt.Rows)
            {
                decimal luong = Convert.ToDecimal(row["Luong"]);
                decimal heSo  = Convert.ToDecimal(row["HeSoLuong"]);
                tongLuong  += luong;
                if (heSo > heCaoNhat) heCaoNhat = heSo;
            }

            lblTongLuong.Text   = tongLuong.ToString("#,##0");
            lblHeSoCaoNhat.Text = heCaoNhat.ToString("0.00");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (ketQuaHienTai == null || ketQuaHienTai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = ketQuaHienTai;

            string filterPhongBan = phongBanKetQua;
            string filterGioiTinh = gioiTinhKetQua;

            using (frmBaoCao frm = new frmBaoCao(dt.Copy(), filterPhongBan, filterGioiTinh))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
