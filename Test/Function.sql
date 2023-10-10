use QUANLYXEHOI
go
CREATE FUNCTION fn_MaNhanVienTuDong()-- hàm sinh mã nhân viên tự động
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @NextID NVARCHAR(50), @LastID INT
	SELECT	@LastID = ISNULL(MAX(CAST(SUBSTRING(MaNV, 4,LEN(MaNV)-2) AS INT)),0 )FROM NHANVIEN -- lấy số nhân viên có mã số cao nhất
	IF @LastID <= 99999
        SET @NextID = 'NV' + RIGHT('_00' + CAST(ISNULL(@LastID, 0) + 1 AS NVARCHAR), 5)
    ELSE
        SET @NextID = 'NV' + CAST(ISNULL(@LastID, 0) + 1 AS NVARCHAR)
	RETURN @NextID
END
go

ALTER TABLE NHANVIEN -- mỗi khi thêm hoá đơn mã sẽ được tạo tự động
ADD CONSTRAINT constr_MaNV
Default dbo.fn_MaNhanVienTuDong() for MaNV
go

EXEC sp_ThemNhanVien
@TenNV = N'Nguyễn Xuân Thể',
@NgaySinh = '10-08-2003',
@DiaChi = 'KH',
@SDT = N'1234567890',
@GioiTinh = N'Nam',
@CCCD = N'123456789012',
@ChucVu = N'Lao công',
@MaCN = 'CN_005',
@Luong = 1000000

select * from NHANVIEN

CREATE PROCEDURE [dbo].[sp_ThemNhanVien](
    @TenNV nvarchar(50),
    @NgaySinh date,
    @DiaChi nvarchar(50),
    @SoDT nvarchar(20),
    @GioiTinh nvarchar(5),
    @CCCD nvarchar(20),
    @ChucVu nvarchar(50),
    @MaCN nvarchar(50),
    @Luong MONEY)
AS
BEGIN
   BEGIN TRY
		-- Thêm nhân viên mới vào bảng Nhan_Vien
		INSERT INTO NHANVIEN (TenNV, NgaySinh, DiaChi, SoDT, GioiTinh, CCCD, ChucVu, MaCN, Luong)
		VALUES (@TenNV, @NgaySinh, @DiaChi, @SoDT, @GioiTinh, @CCCD, @ChucVu, @MaCN, @Luong);
   END TRY
   BEGIN CATCH
		DECLARE @errorMessage NVARCHAR(4000)
		SET @errorMessage = ERROR_MESSAGE()
		IF @errorMessage LIKE '%CK__Nhan_Vien__SDT__2A164134%'
			RAISERROR(N'SĐT phải có 10 chữ số', 16, 1)
		ELSE IF @errorMessage LIKE '%CK__Nhan_Vien__CCCD__75A278F5%'
			RAISERROR(N'CCCD phải có 12 chữ số', 16, 1)
		ELSE IF @errorMessage LIKE 'UQ__NHANVIEN__A955A0AA4C05A5A1'
			RAISERROR(N'CCCD bị trùng với nhân viên khác', 16, 1)
		ELSE IF @errorMessage LIKE '%UQ__Nhan_Vie__CA1930A59E569782%'
			RAISERROR(N'SĐT bị trùng với nhân viên khác', 16, 1)
		ELSE IF @errorMessage LIKE '%CK__Nhan_Vien__SDT__2EDAF651%'
			RAISERROR(N'SĐT chỉ được phép chứa các chữ số', 16, 1)
		ELSE IF @errorMessage LIKE '%CK__Nhan_Vien__CCCD__2FCF1A8A%'
			RAISERROR(N'CCCD chỉ được phép chứa các chữ số', 16, 1)
		ELSE IF @errorMessage LIKE '%constr_chk_QuanLyChiNhanh%'
			RAISERROR(N'Một chi nhánh không thể có tận 2 quản lý', 16, 1)
	END CATCH
END;
GO

insert into NHANVIEN values(dbo.fn_MaNhanVienTuDong(),N'Luaan Su', '2003-02-27', N'QL 51, Đất Mới, Long Phước, Long Thành, Đồng Nai', N'0987685789', N'Nữ', N'098123131023', N'Nhân viên kho', 'CN_005', 1, 9000000)



EXEC sp_ThemNhanVien
@TenNV = N'Nguyễn Xuân Thể',
@NgaySinh = '10-08-2003',
@DiaChi = 'KH',
@SDT = N'127890',
@GioiTinh = N'Nam',
@CCCD = N'123456789012',
@ChucVu = N'Lao công',
@MaCN = 'CN_005',
@Luong = 1000000

CREATE FUNCTION [dbo].[fn_TimKhachHangTheoGioiTinh]
(
    @GioiTinh nvarchar(5)
)
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM NHANVIEN
    WHERE GioiTinh = @GioiTinh
)
GO

ALTER TABLE NHANVIEN -- mỗi khi thêm hoá đơn mã sẽ được tạo tự động
ADD CONSTRAINT constr_MaNV
Default dbo.fn_MaNhanVienTuDong() for MaNV
go

select * from fn_TimKhachHangTheoGioiTinh(N'Nữ')
