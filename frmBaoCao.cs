using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace MauLTTQCK
{
    public sealed class frmBaoCao : Form
    {
        private readonly DataTable _data;
        private readonly string _phongBan;
        private readonly string _gioiTinh;
        private readonly ReportViewer _viewer;

        public frmBaoCao(DataTable data, string phongBan, string gioiTinh)
        {
            if (data == null) throw new ArgumentNullException("data");
            _data = data;
            _phongBan = phongBan;
            _gioiTinh = gioiTinh;

            Text = "Báo cáo lương nhân viên";
            StartPosition = FormStartPosition.CenterParent;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(900, 600);

            _viewer = new ReportViewer { Dock = DockStyle.Fill, ProcessingMode = ProcessingMode.Local };
            Controls.Add(_viewer);
            Load += frmBaoCao_Load;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            try
            {
                ValidateReportData();

                Assembly asm = Assembly.GetExecutingAssembly();
                using (Stream stream = asm.GetManifestResourceStream("MauLTTQCK.rptNhanVien.rdlc"))
                {
                    if (stream == null)
                        throw new FileNotFoundException("Không tìm thấy tài nguyên RDLC MauLTTQCK.rptNhanVien.rdlc.");

                    _viewer.LocalReport.LoadReportDefinition(stream);
                }

                _viewer.LocalReport.DataSources.Clear();
                _viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetNhanVien", _data));
                _viewer.LocalReport.SetParameters(new[]
                {
                    new ReportParameter("FilterPhongBan", _phongBan),
                    new ReportParameter("FilterGioiTinh", _gioiTinh),
                    new ReportParameter("NgayLap", DateTime.Now.ToString("dd/MM/yyyy"))
                });
                _viewer.SetDisplayMode(DisplayMode.PrintLayout);
                _viewer.ZoomMode = ZoomMode.PageWidth;
                _viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể hiển thị báo cáo RDLC.\n\n" + GetExceptionDetails(ex),
                    "Lỗi báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void ValidateReportData()
        {
            string[] requiredColumns =
            {
                "MaNV", "HoTen", "GioiTinh", "NgaySinh", "PhongBan",
                "HeSoLuong", "NgayVaoLam", "Luong"
            };

            foreach (string column in requiredColumns)
            {
                if (!_data.Columns.Contains(column))
                    throw new InvalidOperationException(
                        "DataTable báo cáo thiếu cột '" + column + "'.");
            }
        }

        private static string GetExceptionDetails(Exception exception)
        {
            StringBuilder details = new StringBuilder();
            int level = 0;

            while (exception != null)
            {
                if (level > 0)
                    details.AppendLine().AppendLine("InnerException:");

                details.Append(exception.Message);
                exception = exception.InnerException;
                level++;
            }

            return details.ToString();
        }
    }
}
