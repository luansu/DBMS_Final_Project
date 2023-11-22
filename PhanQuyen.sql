use DBMS_DOAN_QUANLYCUAHANGXE
go
create role r_seller;
create role r_maintaince;

--ROLE SELLER
-- table NHANVIEN
grant select on NHANVIEN to r_seller;
grant exec on dbo.List_NHANVIEN to r_seller;

-- table KHACHHANG
grant select on KHACHHANG to r_seller;
grant exec on dbo.List_KHACHHANG to r_seller;

--table PHIEUNHAP
grant select on PHIEUNHAP to r_seller;
grant exec on dbo.List_PHIEUNHAP to r_seller;
grant exec on dbo.Insert_PHIEUNHAP to r_seller;
grant exec on dbo.Update_PHIEUNHAP to r_seller;

--table CHITIETPHIEUNHAPPHUTUNG
grant select on CHITIETPHIEUNHAPPHUTUNG to r_seller;
grant exec on dbo.List_CHITIETPHIEUNHAPPHUTUNG to r_seller;
grant exec on dbo.Insert_CHITIETPHIEUNHAPPHUTUNG to r_seller;
grant exec on dbo.Update_CHITIETPHIEUNHAPPHUTUNG to r_seller;

--table CHITIETPHIEUNHAPXE
grant select on CHITIETPHIEUNHAPXE to r_seller;
grant exec on dbo.List_CHITIETPHIEUNHAPXE to r_seller;
grant exec on dbo.Insert_CHITIETPHIEUNHAPXE to r_seller;
grant exec on dbo.Update_CHITIETPHIEUNHAPXE to r_seller;

--table HOADON
grant select on HOADON to r_seller;
grant exec on List_HOADON to r_seller;
grant exec on dbo.Insert_HOADON to r_seller;
grant exec on dbo.Update_HOADON to r_seller;

--table CHITIETHOADONXE
grant select on CHITIETHOADONXE to r_seller;
grant exec on dbo.List_CHITIETHOADONXE to r_seller;
grant exec on dbo.Insert_CHITIETHOADONXE to r_seller;
grant exec on dbo.Update_CHITIETHOADONXE to r_seller;

--table CHITIETHOADONPHUTUNG
grant select on CHITIETHOADONPHUTUNG to r_seller;
grant exec on dbo.List_CHITIETHOADONPHUTUNG to r_seller;
grant exec on dbo.Insert_CHITIETHOADONPHUTUNG to r_seller;
grant exec on dbo.Update_CHITIETHOADONPHUTUNG to r_seller;

--table CHI NHANH
grant exec on dbo.List_CHINHANH to r_seller;

-- table NHACUNGCAP
grant exec on dbo.List_NHACUNGCAP to r_seller;

--table LOXE, PHUTUNG
grant select on LOXE to r_seller
grant select on XE to r_seller
grant exec on List_PHUTUNG to r_seller

--table TAIKHOAN
grant select on TAIKHOAN to r_seller

--ROLE MAINTAINCE
--table PHUTUNG
grant select on PHUTUNG to r_maintaince;
grant exec on dbo.Insert_PHUTUNG to r_maintaince;
grant exec on dbo.Update_PHUTUNG to r_maintaince;

--table DICHVUBAODUONG
grant select on DICHVUBAODUONG to r_maintaince;
grant exec on dbo.Insert_DICHVUBAODUONG to r_maintaince;
grant exec on dbo.Update_DICHVUBAODUONG to r_maintaince;

--table PHIEUBAODUONG
grant select on PHIEUBAODUONG to r_maintaince;
grant exec on dbo.Insert_PHIEUBAODUONG to r_maintaince;
grant exec on dbo.Update_PHIEUBAODUONG to r_maintaince;

--table CHITIETPHIEUBAODUONG
grant select on CHITIETPHIEUBAODUONG to r_maintaince;
grant exec on dbo.Insert_CHITIETPHIEUBAODUONG to r_maintaince;
grant exec on dbo.Update_CHITIETPHIEUBAODUONG to r_maintaince;

--table PHIEUBAOHANH
grant select on PHIEUBAOHANH to r_maintaince;
grant exec on dbo.Insert_PHIEUBAOHANH to r_maintaince;
grant exec on dbo.Update_PHIEUBAOHANH to r_maintaince;

--table HOPDONGBAOHANH
grant select on HOPDONGBAOHANH to r_maintaince;
grant exec on dbo.Insert_HOPDONGBAOHANH to r_maintaince;
grant exec on dbo.Update_HOPDONGBAOHANH to r_maintaince;

--table TAIKHOAN

grant select on TAIKHOAN to r_maintaince

go
CREATE OR ALTER TRIGGER trg_ThemTaiKhoan
ON NHANVIEN
AFTER INSERT
AS
BEGIN
    DECLARE @taiKhoan NVARCHAR(20), @chucVu NVARCHAR(50), @soDienThoai nvarchar(20)
    
    SELECT @taiKhoan = maNhanVien, @chucVu = chucVu, @soDienThoai = soDienThoai FROM inserted
    SET @soDienThoai = ISNULL(@soDienThoai, '1')

    INSERT INTO TAIKHOAN VALUES (@taiKhoan, @soDienThoai, @taiKhoan)
    
    EXEC('CREATE LOGIN [' + @taiKhoan + '] WITH PASSWORD = ''' + @soDienThoai +''',
	DEFAULT_DATABASE = [DBMS_DOAN_QUANLYCUAHANGXE], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF')
    EXEC('CREATE USER ' + @taiKhoan + ' FOR LOGIN ' + @taiKhoan)
    
    IF @chucVu = N'Quản lý'
    BEGIN
        EXEC('USE DBMS_DOAN_QUANLYCUAHANGXE;
				ALTER SERVER ROLE sysadmin ADD MEMBER ' + @taiKhoan)
    END
	ELSE IF @chucVu like N'%bán%' or @chucVu like N'%thu%'
	BEGIN 
		EXEC('USE DBMS_DOAN_QUANLYCUAHANGXE;
              EXEC sp_addrolemember r_seller, ' + @taiKhoan)
	END
	ELSE IF @chucVu like N'%bảo%'
	BEGIN 
		EXEC('USE DBMS_DOAN_QUANLYCUAHANGXE;
              EXEC sp_addrolemember r_maintaince, ' + @taiKhoan)
	END 
END
go

-- Trigger xóa nhân viên xóa luôn tài khoản
CREATE OR ALTER TRIGGER trg_xoaTaiKhoan
ON NHANVIEN
AFTER delete
AS
BEGIN
    DECLARE @taiKhoan NVARCHAR(20)
    
    SELECT @taiKhoan = maNhanVien FROM deleted
	DELETE TAIKHOAN WHERE @taiKhoan = maNhanVien

	EXEC('DROP LOGIN ' + @taiKhoan)
	EXEC('DROP USER ' + @taiKhoan)
END
go
SELECT * FROM NHANVIEN WHERE maChiNhanh = 'CNHN'
go
-- Thêm dữ liệu cho bảng NHÂN VIÊN
begin tran
	INSERT INTO NHANVIEN (hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, maChiNhanh, hinhAnh)
	VALUES (N'Nguyễn Văn aaaa', '123456283333', '1990-01-15', N'Nam', 
	N'123 Đường Lê Lợi, Hà Nội', '0793988509', N'Quản lý', 'CNHN', '')

	SELECT * FROM NHANVIEN WHERE maChiNhanh = 'CNHN'
rollback

update NHANVIEN set chucVu = N'Nhân viên thu ngân' where maNhanVien = 'NVHN001'