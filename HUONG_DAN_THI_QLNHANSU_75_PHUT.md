# Hướng dẫn làm bài Quản lý nhân sự trong 75 phút

## 1. Project hiện tại có ADO.NET không?

Có. Project dùng ADO.NET trực tiếp qua `System.Data.SqlClient`: lớp `DBConnection` mở `SqlConnection`, tạo `SqlCommand`, lấy dữ liệu bằng `SqlDataAdapter`/`DataTable`, và ghi dữ liệu bằng `ExecuteNonQuery`. Chuỗi kết nối nằm trong `App.config` (connection string `QLNhanSu`). Đây không phải Entity Framework.

Project đã có `Form1`, `Form2`, `DBConnection.cs`, script tạo CSDL `QLNhanSu_CreateDB.sql`, và tham chiếu các DLL của ReportViewer. Nhưng chưa thấy tệp `.rdlc`; gói ReportViewer được cài **không có nghĩa báo cáo RDLC đã được tạo**. Trước khi thi, xác nhận tên SQL instance trong `App.config`, chạy script tạo DB và thử mở ứng dụng.

## 2. Chia 75 phút

| Phút | Việc cần làm | Mục tiêu |
|---|---|---|
| 0–7 | Đọc đề, xác định controls/tên bảng, chạy script và sửa connection string | Kết nối DB thành công |
| 7–28 | Form 1: nạp phòng ban, danh sách nhân viên, chọn dòng đổ lên controls | CRUD cơ bản hiển thị được |
| 28–42 | Thêm/Sửa/Xóa/Làm mới + kiểm tra dữ liệu và phím tắt | Hoàn thiện điểm Form 1 |
| 42–55 | Form 2: lọc phòng ban/giới tính, tìm kiếm, thống kê, nút đóng | Có kết quả đúng và thống kê |
| 55–68 | Báo cáo RDLC, truyền dữ liệu đã lọc, preview | Có báo cáo đúng bộ lọc |
| 68–75 | Chạy thử các luồng, sửa lỗi, kiểm tra tên và lưu | Không để lỗi hiển thị/khởi động |

Nếu thời gian hụt, ưu tiên: **kết nối + GridView → chọn dòng → thêm/sửa/xóa → lọc và thống kê → report → trang trí**. Giao diện gần hình mẫu là đủ; đừng căn chỉnh pixel trước khi các nút chạy.

## 3. Mẹo tăng tốc khi dựng WinForms

- Kéo thả controls trước, đổi `Name` ngay trong Properties: `txtMaNV`, `txtHoTen`, `rdoNam`, `rdoNu`, `dtpNgaySinh`, `cboPhongBan`, `txtHeSoLuong`, `dtpNgayVaoLam`, `dgvNhanVien`; Form 2 dùng `cboPBLoc`, `cboGioiTinh`, `dgvKetQua`, `btnTimKiem`, `btnXuatBaoCao`.
- Dùng `GroupBox`/`Label`/`DataGridView` mặc định, `Dock=Fill` cho lưới. `AutoSizeColumnsMode=Fill`, `ReadOnly=true`, `SelectionMode=FullRowSelect`, `MultiSelect=false`, `AllowUserToAddRows=false` giúp lưới gọn và tránh sửa trực tiếp ngoài ý muốn.
- Tạo một hàm `LoadNhanVien()` và gọi lại sau mọi thao tác thay đổi dữ liệu. Tạo `LoadPhongBan()` để nạp ComboBox một lần. Tránh chép cùng câu SELECT vào nhiều event.
- Đặt phím tắt qua dấu `&` trong Text: `&Thêm`, `&Sửa`, `&Xóa`, `Làm &mới`, `Thốn&g kê`, `T&hoát`, `Tìm &kiếm`, `&Xuất báo cáo`, `&Đóng`. Kiểm tra `UseMnemonic` (mặc định true) và tránh trùng ký tự tắt.
- Gắn event bằng double-click control trong Designer hoặc tab Events; đừng tự gắn lặp event trong Designer lẫn constructor.
- Dùng `using` cho kết nối/lệnh, SQL parameter (`@MaNV`) cho mọi giá trị nhập; không nối chuỗi SQL bằng nội dung TextBox.

## 4. CSDL và truy vấn cốt lõi

Quan hệ: `PhongBan(MaPB, TenPB)` 1—n `NhanVien(MaNV, HoTen, GioiTinh, NgaySinh, MaPB, HeSoLuong, NgayVaoLam)`. Mức lương theo đề: `HeSoLuong * 2340000`. `GioiTinh` là `bit` (1 nam, 0 nữ). SELECT cho lưới nên JOIN tên phòng ban:

```sql
SELECT nv.MaNV, nv.HoTen,
       CASE WHEN nv.GioiTinh=1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
       nv.NgaySinh, pb.TenPB AS PhongBan, nv.MaPB, nv.HeSoLuong,
       nv.NgayVaoLam, nv.HeSoLuong * 2340000 AS Luong
FROM NhanVien nv JOIN PhongBan pb ON pb.MaPB=nv.MaPB
ORDER BY nv.MaNV;
```

Đừng quên `N` trước chuỗi tiếng Việt trong SQL viết tay. Dùng `AddWithValue` cho bài thi ngắn hoặc khai báo kiểu rõ ràng bằng `SqlParameter`; luôn parameter hóa giá trị thay vì nối chuỗi. Kiểm tra mã trùng trước INSERT hoặc bắt lỗi khóa chính và báo dễ hiểu.

## 5. Form 1 — danh sách và CRUD

### Khi mở form

1. `LoadPhongBan()`: lấy `MaPB, TenPB` vào ComboBox, đặt `DisplayMember="TenPB"`, `ValueMember="MaPB"`.
2. `LoadNhanVien()`: chạy SELECT JOIN ở trên, gán `dgvNhanVien.DataSource`.
3. Nếu lưới có dữ liệu, chọn dòng đầu; nếu rỗng, xóa trắng controls.

### Chọn dòng

Trong `dgvNhanVien_SelectionChanged`, nếu `CurrentRow` không null thì đưa từng giá trị lên controls. Có `MaPB` trong SELECT, ẩn cột này, rồi gán `cboPhongBan.SelectedValue`. Chuyển `GioiTinh` về radio tương ứng. Tránh đọc `SelectedRows[0]` khi chưa có dòng chọn.

### Thêm (Alt+T)

- Validate: mã/tên không rỗng; mã chưa tồn tại; hệ số là số và trong khoảng `2.34–8.00`; ngày vào làm không trước ngày sinh; ngày sinh đủ 18 tuổi; ComboBox đã chọn phòng ban.
- Ngày sinh: `DateTime.Today.AddYears(-18)` là mốc sinh muộn nhất để đủ 18 tuổi.
- INSERT với parameter cho đủ 7 cột. Nếu thành công: báo ngắn, gọi `LoadNhanVien()`, chọn lại bản ghi vừa thêm.

### Sửa (Alt+S)

- Yêu cầu chọn nhân viên; validate như Thêm nhưng không kiểm tra mã trùng với chính dòng đó.
- UPDATE theo `WHERE MaNV=@MaNV`; mã nhân viên thường giữ nguyên.
- Nếu `ExecuteNonQuery()` trả 0, báo bản ghi không còn tồn tại; nếu 1 thì nạp lại.

### Xóa (Alt+X)

- Lấy mã từ dòng đang chọn, hỏi `MessageBox.Show(..., MessageBoxButtons.YesNo, MessageBoxIcon.Question)`; chỉ xóa nếu Yes.
- DELETE có parameter và nạp lại lưới.

### Làm mới / thoát

- Làm mới: xóa trắng/đặt lại controls và nạp lại lưới theo yêu cầu.
- Thoát: hỏi Yes/No đúng đề rồi mới `Close()`.

## 6. Form 2 — lọc và thống kê

- Khi mở, ComboBox phòng ban có item đầu `Tất cả`; giới tính có `Tất cả`, `Nam`, `Nữ`. Có thể dùng `MaPB=null` cho “Tất cả”.
- Nút Tìm kiếm lọc theo cả hai tiêu chí (AND). SQL dạng `(@MaPB IS NULL OR nv.MaPB=@MaPB) AND (@GT IS NULL OR nv.GioiTinh=@GT)`; truyền tham số nullable.
- Nếu `DataTable.Rows.Count == 0`, báo “Không tìm thấy dữ liệu phù hợp”, gán lưới rỗng và reset các chỉ số để không giữ số liệu cũ.
- Thống kê trên đúng tập kết quả: số nhân viên=`Rows.Count`; tổng lương cộng cột `Luong`; hệ số lớn nhất lấy max `HeSoLuong`. Dùng `DataTable.Compute("SUM(Luong)", "")` / `MAX(HeSoLuong)` hoặc LINQ; xử lý bảng rỗng trước.
- Nút Đóng đóng Form 2. Form 1 mở Form 2 bằng `using (var f = new Form2()) f.ShowDialog(this);`.

## 7. Báo cáo RDLC — lộ trình tối thiểu

Đề yêu cầu **RDLC/ReportViewer** và báo cáo phải nhận điều kiện lọc Form 2. RDLC là báo cáo local: truy vấn ADO.NET tạo `DataTable`, ReportViewer nhận nó qua `ReportDataSource`; không cần Report Server.

1. Đảm bảo Visual Studio có extension thiết kế RDLC nếu máy chưa có; project có DLL ReportViewer WinForms. Thêm Form báo cáo (`frmBaoCao`) và control ReportViewer (`rvNhanVien`).
2. Tạo `rptNhanVien.rdlc`. Tạo dataset với các trường `STT, MaNV, HoTen, NgaySinh, HeSoLuong, Luong, TenPB`. Đặt tiêu đề công ty, “BẢNG LƯƠNG NHÂN VIÊN”, ngày lập và dòng điều kiện lọc.
3. Thêm Table/Tablix; nhóm theo `TenPB`, bật group header để mỗi phòng ban có dòng tiêu đề; chi tiết có STT, mã, họ tên, ngày sinh, hệ số, lương. Cuối bảng dùng `Sum(Fields!Luong.Value)`; thêm textbox “Người lập biểu” và số trang.
4. Nút xuất báo cáo kiểm tra lưới có dòng; nếu rỗng báo “Không có dữ liệu để xuất báo cáo”. Nếu có, mở Form báo cáo và truyền chính `DataTable` đang lọc cùng chuỗi mô tả bộ lọc.
5. Trong Form báo cáo: `rvNhanVien.LocalReport.DataSources.Clear();`; thêm `new ReportDataSource("DataSetNhanVien", dataTable)` (tên phải khớp dataset trong RDLC); gán parameter nếu report có ngày lập/điều kiện; gọi `RefreshReport()`.
6. Để xuất PDF/Excel dùng toolbar Export sẵn của ReportViewer; hoặc `LocalReport.Render("PDF")` / `Render("EXCELOPENXML")` và `SaveFileDialog`. Nếu đề chấm chỉ cần xem báo cáo, ưu tiên preview chạy được.

**Mẹo thi:** báo cáo là phần tốn thời gian nhất nếu phải tạo RDLC bằng designer. Trước giờ thi hãy cài extension, thử tạo một RDLC mẫu và lưu form preview. Nếu phòng thi không có extension, làm chắc CRUD/lọc/thống kê trước; sau đó tạo report tối giản bằng ReportViewer. Gói NuGet chỉ cung cấp runtime, không chắc đã có trình thiết kế.

## 8. Lỗi hay gặp và cách gỡ nhanh

- Không kết nối được: kiểm tra `Data Source` (`localhost\\SQLEXPRESS`, `(localdb)\\MSSQLLocalDB`, hoặc instance máy thi), dịch vụ SQL Server đang chạy, DB `QLNhanSu` tồn tại; Integrated Security dùng tài khoản Windows.
- Không load được ReportViewer: xác nhận NuGet restore, reference DLL, control có trên Form, target .NET Framework khớp gói.
- ComboBox hiện mã thay vì tên: sai `DisplayMember`; chọn sai dòng: `ValueMember` chưa đặt hoặc SELECT thiếu `MaPB`.
- Lưới không cập nhật: gọi lại `LoadNhanVien()` sau `ExecuteNonQuery()`; kiểm tra `WHERE` và số dòng bị tác động.
- Sai định dạng tiền/ngày: định dạng cột DataGridView hoặc RDLC; giữ kiểu Date/Decimal trong DataTable, đừng đổi thành chuỗi trong SQL.
- Chọn dòng gây lỗi: kiểm tra `CurrentRow == null`, hàng placeholder, `DBNull.Value`, và lưới rỗng.
- Lọc không có kết quả nhưng thống kê còn số cũ: reset label trước khi cập nhật, thống kê từ DataTable vừa truy vấn.

## 9. Checklist 2 phút cuối

- [ ] Chạy được ứng dụng, chuỗi kết nối đúng instance và DB.
- [ ] Form 1 nạp đủ phòng ban/nhân viên, chọn dòng đổ dữ liệu đúng.
- [ ] Thêm sai dữ liệu bị chặn; thêm hợp lệ rồi lưới cập nhật.
- [ ] Sửa và xóa đúng dòng; xóa có Yes/No.
- [ ] Làm mới, thống kê, thoát có xác nhận.
- [ ] Form 2 có “Tất cả”, lọc AND phòng ban + giới tính, xử lý trường hợp rỗng.
- [ ] Ba thống kê đúng với tập kết quả.
- [ ] Báo cáo nhận đúng tập đã lọc; nếu rỗng thì không mở report.
- [ ] Tên dataset khớp `ReportDataSource`; preview/export hoạt động.
- [ ] Phím tắt `&` không trùng khó hiểu; lưu project và file report.

## 10. Khung tư duy thao tác

Với mỗi phần, làm đường đi dữ liệu trước: **SQL → DataTable → DataGridView → chọn dòng → controls → lệnh ghi → nạp lại**. Sau đó mới chỉnh màu, kích thước, căn lề. Với báo cáo, kiểm tra tên dataset và field trước khi chỉnh giao diện. Dùng `try/catch (Exception ex)` quanh thao tác DB để phát hiện nhanh lỗi kết nối/truy vấn.

