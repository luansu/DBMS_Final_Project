use DBMS_DOAN_QUANLYCUAHANGXE
go

----------------------------------------------------------------
CREATE or ALTER TRIGGER tg_ThayDoiTrangThaiHoaDon on CHITIETHOADONXE 
for update, insert as
BEGIN
	DECLARE @soTienDaTra money, @maHoaDon nvarchar(20), @tongTien money
	SELECT @soTienDaTra = ins.soTienDaTra, @maHoaDon = ins.maHoaDon 	FROM inserted as ins
	SElECT @tongTien = hd.tongTien 						
	FROM HOADON as hd 								
	WHERE hd.maHoaDon = @maHoaDon
	IF @tongTien <= @soTienDaTra
	BEGIN 
		UPDATE HOADON 
		SET tinhTrang = N'Đã Thanh Toán'
		WHERE maHoaDon = @maHoaDon
	END
END
go
--------------------------------------------------------------------------------
-- Trigger khi nhập xe về thì mã xe tự động tạo theo mã lô xe
create or alter trigger trg_SinhMaXeKhiNhapXe
on CHITIETPHIEUNHAPXE
after insert
as
begin
	declare @maLoXe nvarchar(20), @soLuong nvarchar(20)
	-- Lấy xe mã Lô xe và số lượng từ inserted (CTPN Xe)
	select @maLoXe = maLoXe, @soLuong = soLuong from inserted
		-- Nếu đã nhập mã lô xe này
	if (@maLoXe in (select maLoXe from XE))
	begin
		declare @i int = @soLuong
		while @i > 0 -- Bắt đầu thực hiện cho tới khi hết số lượng
		begin
				-- Khởi tạo giá trị LastID = Mã xe cuối cùng trong LoXe vừa insert
			declare @NewId nvarchar(20), @LastID nvarchar(20)
			select @LastID = ISNULL(MAX(CAST(SUBSTRING(maXe, 11, LEN(maXe) - 10) as int)), 0)
			from XE where maLoXe = @maLoXe

			if (@LastID < 999)
			begin
				set @NewId = @maLoXe + '_XE' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
			end
			else
			begin
				set @NewId = @maLoXe + '_XE' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
			end

			insert into XE values (@NewId, @maLoXe)
			set @i = @i - 1
		end	
	end

	else -- Xe có mã này chưa được nhập lần nào
	begin
		declare @y int = @soLuong, @ID int = 1
		while @y > 0 -- Bắt đầu thực hiện cho tới khi hết số lượng
		begin
			if (@ID < 999)
			begin
				set @NewId = @maLoXe + '_XE' + RIGHT('000' + CAST(@ID as nvarchar), 3)
			end
			else
			begin
				set @NewId = @maLoXe + '_XE' + CAST(@ID as nvarchar)
			end

			insert into XE values (@NewId, @maLoXe)
			set @y = @y - 1
			set @ID = @ID + 1
		end
	end
end
go
-- TEST
begin tran
	insert into CHITIETPHIEUNHAPXE(maChiTietPhieuNhapXe, maLoXe, maPhieuNhap, giaNhap, soLuong)
	values ('CTPNX111', 'LOXE009', 'PN004', 200000000, 20)

	select * from CHITIETPHIEUNHAPXE
	select * from XE
rollback
go
--------------------------------------------------------------------------------
--Trigger khi nhập hàng về chi nhánh thì sẽ cập nhật vào kho
---------- Cập nhật kho xe
create or alter trigger trg_CapNhatKhoXeKhiNhapHang
on CHITIETPHIEUNHAPXE
after insert 
as
begin
	declare @maChiNhanh nvarchar(20), @maLoXe nvarchar(20), @soLuong int
	select @maChiNhanh = maChiNhanh, @maLoXe = maLoXe, @soLuong = soLuong
	from PHIEUNHAP PN
	inner join inserted
	on PN.maPhieuNhap = inserted.maPhieuNhap

	if ( (@maChiNhanh in (select maChiNhanh from KHOXE)) and (@maLoXe in (select maLoXe from KHOXE)) )
	begin
		Update KHOXE
		set soLuongXeCon = soLuongXeCon + @soLuong
		where maChiNhanh = @maChiNhanh and maLoXe = @maLoXe
	end
	else
	begin
		insert into KHOXE(maChiNhanh, maLoXe, soLuongXeCon)
		values(@maChiNhanh, @maLoXe, @soLuong)
	end 
end
go
--Test
begin tran
	insert into PHIEUNHAP(maPhieuNhap, maChiNhanh, maNhaCungCap)
	values ('PN100', 'CNHN', 'NCC-XE001')
	insert into CHITIETPHIEUNHAPXE(maChiTietPhieuNhapXe, maLoXe, maPhieuNhap, giaNhap, soLuong)
	values ('CTPNXE100','LOXE001','PN001', 100000000, 10)
	select * from KHOXE
rollback
go
---------- Cập nhật kho phụ tùng
create or alter trigger trg_CapNhatKhoPhuTungKhiNhapHang
on CHITIETPHIEUNHAPPHUTUNG
after insert
as
begin
	declare @maChiNhanh nvarchar(20), @maPhuTung nvarchar(20), @soLuong int
	select @maChiNhanh = maChiNhanh, @maPhuTung = maPhuTung, @soLuong = soLuong
	from PHIEUNHAP PN
	inner join inserted on PN.maPhieuNhap = inserted.maPhieuNhap
	if ( (@maChiNhanh in (select maChiNhanh from KHOPHUTUNG)) and (@maPhuTung in (select maPhuTung from KHOPHUTUNG)) )
	begin
		update KHOPHUTUNG
		set soLuongPhuTungCon = soLuongPhuTungCon + @soLuong
		where maChiNhanh = @maChiNhanh and maPhuTung = @maPhuTung
	end
	else
	begin
		insert into KHOPHUTUNG(maChiNhanh, maPhuTung, soLuongPhuTungCon)
		values(@maChiNhanh, @maPhuTung, @soLuong)
	end
end
go
--Test
begin tran
	insert into PHIEUNHAP(maPhieuNhap, maChiNhanh, maNhaCungCap)
	values ('PN100', 'CNHN', 'NCC-PT001')
	insert into CHITIETPHIEUNHAPPHUTUNG(maChiTietPhieuNhapPhuTung, maPhuTung, maPhieuNhap, giaNhap, soLuong)
	values ('CTPNXE100','PT001','PN001', 100000000, 10)
	select * from KHOPHUTUNG
rollback
--------------------------------------------------------------------------------
-- TRIGGER khi xuất hóa đơn mặt hàng cho khách hàng thì sẽ cập nhật lại số lượng hàng trong kho
-- Hóa đơn xe
--create or alter trigger trg_CapNhatKhoXeKhiBan 


--------------------------------------------------------------------------------
-- TRIGGER tự động sinh mã nhân viên
go
CREATE or Alter trigger tg_ThemNhanVien on NHANVIEN
instead of insert
as
BEGIN
	declare @hoTenNhanVien nvarchar(50), @CCCD nvarchar(20), @ngaySinh date, @gioiTinh nvarchar(5), @diaChi nvarchar(255), @soDienThoai nvarchar(20), @chucVu  nvarchar(50), @maChiNhanh nvarchar(20), @hinhAnh nvarchar(200)
	select @hoTenNhanVien = nv.hoTenNhanVien, @CCCD = nv.CCCD, @ngaySinh = nv.ngaySinh, @gioiTinh = nv.gioiTinh, @diaChi = nv.diaChi, @soDienThoai = nv.soDienThoai, @chucVu = nv.chucVu, @maChiNhanh = nv.maChiNhanh, @hinhAnh = nv.hinhAnh
	from inserted as nv
	print (dbo.fn_TaoMaNhanVien(@maChiNhanh))
	insert into NHANVIEN(maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, maChiNhanh, hinhAnh) Values(dbo.fn_TaoMaNhanVien(@maChiNhanh), @hoTenNhanVien , @CCCD , @ngaySinh, @gioiTinh, @diaChi , @soDienThoai, @chucVu, @maChiNhanh, @hinhAnh)
	print 111
END
--------------------------------------------------------------------------------
-- Tạo TRIGGER khi thêm nhân viên thì tài khoản tự động thêm
-- Set Tên đăng nhập mặc định là mã nhân viên
go
CREATE OR ALTER TRIGGER trg_ThemTaiKhoan
ON NHANVIEN
AFTER INSERT
AS
BEGIN
	print 111
    DECLARE @taiKhoan NVARCHAR(20), @chucVu NVARCHAR(50)
    
    SELECT @taiKhoan = maNhanVien, @chucVu = chucVu FROM inserted
    
    INSERT INTO TAIKHOAN VALUES (@taiKhoan, '1', @chucVu, @taiKhoan)
    
    EXEC('CREATE LOGIN ' + @taiKhoan + ' WITH PASSWORD = ''1''')
    EXEC('CREATE USER ' + @taiKhoan + ' FOR LOGIN ' + @taiKhoan)
    
    IF @chucVu = N'Quản lý'
    BEGIN
        EXEC('USE DBMS_DOAN_QUANLYCUAHANGXE;
              EXEC sp_addrolemember r_admin TO ' + @taiKhoan)
    END
	ELSE IF @chucVu like N'%bán%'
	BEGIN 
		EXEC('USE DBMS_DOAN_QUANLYCUAHANGXE;
              EXEC sp_addrolemember r_seller TO ' + @taiKhoan)
	END
	ELSE IF @chucVu like N'%bảo%'
	BEGIN 
		EXEC('USE DBMS_DOAN_QUANLYCUAHANGXE;
              EXEC sp_addrolemember r_maintenace TO ' + @taiKhoan)
	END 
END

go

-- Test
begin tran
	INSERT INTO CHINHANH (maChiNhanh, tenChiNhanh, diaChi)
	VALUES ('CN001', N'Chi nhánh A', N'123 Đường A, Quận 1, TP.HCM')
	INSERT INTO NHANVIEN (hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, maChiNhanh)
	VALUES (N'Nguyễn Văn A', '123459189012', '1990-05-15', N'Nam', N'123 Đường X, Quận Y, TP.HCM', '0123456789', N'Quản lý', 'CNHCM')
	select * from TaiKhoan
	delete NHANVIEN WHERE maNhanVien = 'NVHCM008'
	select * from NHANVIEN
	select * from CHINHANH
rollback
go

-- Tạo trigger Khi sửa mã nhân viên thì tài khoản cũng sẽ cập nhật theo
create or alter trigger trg_CapNhatTaiKhoan
on NHANVIEN
for update
as
begin
	declare @taiKhoanCu nvarchar(20), @taiKhoanMoi nvarchar(20)
	set @taiKhoanMoi = (select maNhanVien from inserted)
	set @taiKhoanCu = (select maNhanVien from deleted)
	Update TAIKHOAN
	set tenDangNhap = @taiKhoanMoi, maNhanVien = @taiKhoanMoi
	where tenDangNhap = @taiKhoanCu
end
go
-- Test
begin tran
	INSERT INTO CHINHANH (maChiNhanh, tenChiNhanh, diaChi)
	VALUES ('CN001', N'Chi nhánh A', N'123 Đường A, Quận 1, TP.HCM')
	INSERT INTO NHANVIEN (maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, maChiNhanh)
	VALUES ('NV001', N'Nguyễn Văn A', '123456789012', '1990-05-15', N'Nam', N'123 Đường X, Quận Y, TP.HCM', '0123456789', N'Quản lý', 'CN001')

	select * from TaiKhoan

	update NHANVIEN
	set maNhanVien = 'NV002'
	where maNhanVien = 'NV001'

	select * from TAIKHOAN
rollback
go

-- Trigger đuổi việc nhân viên
CREATE or Alter trigger tg_XoaNhanVien on NHANVIEN
after delete
as
BEGIN
	declare @maNhanVien nvarchar(20), @taiKhoan nvarchar(20)
	select @maNhanVien = d.maNhanVien from deleted d
	select @taiKhoan = tk.tenDangNhap from TAIKHOAN tk where tk.maNhanVien = @maNhanVien
	EXEC('USE DBMS_DOAN_QUANLYCUAHANGXE;
              DROP USER ' + @taiKhoan)
END

