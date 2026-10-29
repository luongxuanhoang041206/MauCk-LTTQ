-- =====================================================
-- SCRIPT TẠO CSDL QLNhanSu
-- Chạy trong SQL Server Management Studio
-- =====================================================

USE master;
GO

-- Tạo database nếu chưa có
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QLNhanSu')
BEGIN
    CREATE DATABASE QLNhanSu;
    PRINT N'Đã tạo database QLNhanSu';
END
GO

USE QLNhanSu;
GO

-- =====================================================
-- TẠO BẢNG PhongBan
-- =====================================================
IF OBJECT_ID('NhanVien', 'U') IS NOT NULL DROP TABLE NhanVien;
IF OBJECT_ID('PhongBan', 'U') IS NOT NULL DROP TABLE PhongBan;

CREATE TABLE PhongBan (
    MaPB    NVARCHAR(10)    NOT NULL PRIMARY KEY,
    TenPB   NVARCHAR(100)   NOT NULL
);
GO

-- =====================================================
-- TẠO BẢNG NhanVien
-- =====================================================
CREATE TABLE NhanVien (
    MaNV        NVARCHAR(10)    NOT NULL PRIMARY KEY,
    HoTen       NVARCHAR(100)   NOT NULL,
    GioiTinh    BIT             NOT NULL DEFAULT 1,  -- 1=Nam, 0=Nu
    NgaySinh    DATE            NOT NULL,
    MaPB        NVARCHAR(10)    NOT NULL,
    HeSoLuong   DECIMAL(4,2)    NOT NULL,
    NgayVaoLam  DATE            NOT NULL,
    CONSTRAINT FK_NV_PB FOREIGN KEY (MaPB) REFERENCES PhongBan(MaPB)
);
GO

-- =====================================================
-- DỮ LIỆU MẪU - PhongBan
-- =====================================================
INSERT INTO PhongBan (MaPB, TenPB) VALUES
(N'KD',  N'Kinh doanh'),
(N'KT',  N'Kế toán'),
(N'HC',  N'Hành chính'),
(N'IT',  N'Công nghệ thông tin'),
(N'NS',  N'Nhân sự');
GO

-- =====================================================
-- DỮ LIỆU MẪU - NhanVien
-- =====================================================
INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, NgaySinh, MaPB, HeSoLuong, NgayVaoLam) VALUES
(N'NV001', N'Trần Minh Đức',   1, '1990-03-12', N'KD', 3.33, '2015-07-01'),
(N'NV002', N'Lê Thu Hà',       0, '1995-11-25', N'KT', 2.67, '2019-08-15'),
(N'NV003', N'Phạm Quốc Bảo',   1, '1988-06-08', N'KT', 4.40, '2012-02-01'),
(N'NV004', N'Nguyễn Thị Lan',  0, '1997-09-19', N'KD', 2.34, '2021-03-10'),
(N'NV005', N'Đỗ Văn Hùng',     1, '1985-10-30', N'HC', 3.66, '2010-05-20'),
(N'NV006', N'Vũ Thị Hồng',     0, '1992-04-14', N'KD', 3.00, '2017-01-03'),
(N'NV007', N'Hoàng Gia Huy',   1, '1999-12-05', N'KT', 2.34, '2023-04-04'),
(N'NV008', N'Nguyễn Văn An',   1, '1993-07-22', N'IT', 4.00, '2018-06-01');
GO

-- Kiểm tra
SELECT nv.*, pb.TenPB, nv.HeSoLuong * 2340000 AS Luong
FROM NhanVien nv JOIN PhongBan pb ON nv.MaPB = pb.MaPB
ORDER BY nv.MaNV;
GO

PRINT N'Tạo CSDL QLNhanSu thành công!';
