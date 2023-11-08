use DBMS_DOAN_QUANLYCUAHANGXE
go
-------------------------------------------------------------------------
-- Function tự động sinh mã bảo dưỡng
create or alter function fn_SinhMaBaoDuong()
returns nvarchar(20)
as
begin
	declare @nextID nvarchar(20), @lastID nvarchar(20)
	select @lastID = ISNULL(MAX(CAST(SUBSTRING(maBaoDuong, 5, LEN(maBaoDuong) - 4) as int)) , 0) 
	from DICHVUBAODUONG

	if (@lastID < 999)
		set @nextID = 'DVBD' + RIGHT('000' + CAST(ISNULL(@lastID, 0) + 1 as nvarchar), 3)
	else
		set @nextID = 'DVBD' + CAST(ISNULL(@lastID, 0) + 1 as nvarchar)
	return @nextID
end
go
-- Add Contraint cho mã bảo dưỡng
alter table DICHVUBAODUONG add constraint constr_MaBaoDuong
default dbo.fn_SinhMaBaoDuong() for maBaoDuong
go
--alter table DICHVUBAODUONG drop constraint constr_MaBaoDuong
begin tran
	insert into DICHVUBAODUONG(tenBaoDuong, loaiBaoDuong, phiBaoDuong)
	values ('a', 'a', 1)
	select * from DICHVUBAODUONG
rollback
select * from DICHVUBAODUONG
go
-------------------------------------------------------------------------------------------------
-- Function tự động sinh Phiếu bảo dưỡng
create or alter function fn_SinhMaPhieuBaoDuong()
returns nvarchar(20)
as
begin
	declare @NextID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maPhieuBaoDuong, 4, LEN(maPhieuBaoDuong) - 3) as int)), 0)
	from PHIEUBAODUONG

	if (@LastID < 999)
		set @NextID = 'PBD' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	else
		set @NextID = 'PBD' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	return @NextID
end
go
-- add contraint
alter table PHIEUBAODUONG add constraint contr_MaPhieuBaoDuong
default dbo.fn_SinhMaPhieuBaoDuong() for maPhieuBaoDuong
begin tran
	insert into PHIEUBAODUONG(ngayLapPhieu, tongTien, maKhachHang, maNhanVienThucHien)
	values('2003-08-10', 1111, 'KH003', 'NVHCM001')

	update PHIEUBAODUONG set ngayLapPhieu = '{}', tongTien = 2, maKhachHang = '{}', maNhanVienThucHien = '{}'
	where maPhieuBaoDuong = '{}'
	select * from PHIEUBAODUONG
rollback
go
-------------------------------------------------------------------------------------------------
-- Function tự động sinh mã chi tiết PBD
create or alter function fn_SinhMaChiTietPhieuBaoDuong()
returns nvarchar(20)
as
begin	
	declare @NextID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maChiTietPhieuBaoDuong, 6, LEN(maChiTietPhieuBaoDuong) - 5) as int)), 0)
	from CHITIETPHIEUBAODUONG

	if (@LastID < 999)
		set @NextID = 'CTPBD' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	else
		set @NextID = 'CTPBD' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	return @NextID
end
go
-- add constraint
alter table CHITIETPHIEUBAODUONG add constraint contr_MaChiTietPBD
default dbo.fn_SinhMaChiTietPhieuBaoDuong() for maChiTietPhieuBaoDuong
begin tran
	insert into CHITIETPHIEUBAODUONG(maBaoDuong, maPhieuBaoDuong, thanhTien)
	values('DVBD001', 'PBD001', 20000)

	select * from CHITIETPHIEUBAODUONG
rollback
go
-------------------------------------------------------------------------------------------------
-- Function tự động sinh mã Hợp đồng bảo hành
create or alter function fn_SinhMaHopDongBaoHanh()
returns nvarchar(20)
as
begin	
	declare @NextID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maHopDongBaoHanh, 5, LEN(maHopDongBaoHanh) - 4) as int)), 0)
	from HOPDONGBAOHANH

	if (@LastID < 999)
		set @NextID = 'HDBH' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	else
		set @NextID = 'HDBH' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	return @NextID
end
go
-- add constraint
alter table HOPDONGBAOHANH add constraint contr_MaHopDongBaoHanh
default dbo.fn_SinhMaHopDongBaoHanh() for maHopDongBaoHanh
begin tran
	insert into HOPDONGBAOHANH(maXe, maKhachHang, ngayKyBaoHanh, thoiHanBaoHanh)
	values('LOXE001_XE001', 'KH001', '2003-08-09', '2003-08-10')

	select * from HOPDONGBAOHANH
rollback
go
-------------------------------------------------------------------------------------------------
-- Function tự động sinh mã Phiếu bảo hành
create or alter function fn_SinhMaPhieuBaoHanh()
returns nvarchar(20)
as
begin	
	declare @NextID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maPhieuBaoHanh, 4, LEN(maPhieuBaoHanh) - 3) as int)), 0)
	from PHIEUBAOHANH

	if (@LastID < 999)
		set @NextID = 'PBH' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	else
		set @NextID = 'PBH' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	return @NextID
end
go
-- add constraint
alter table PHIEUBAOHANH add constraint contr_MaPhieuBaoHanh
default dbo.fn_SinhMaPhieuBaoHanh() for maPhieuBaoHanh

-------------------------------------------------------------------------------------------------
-- Function tự động sinh mã khách hàng
go
create or alter function fn_SinhMaKhachHang()
returns nvarchar(20)
as
begin
	declare @NextID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maKhachHang, 3, LEN(maKhachHang) - 2) as int)), 0)
	from KHACHHANG

	if (@LastID < 999)
		set @NextID = 'KH' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	else
		set @NextID = 'KH' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	return @NextID
end
go
-- Add Constraint cho mã Khách hàng
alter table KHACHHANG add constraint contr_MaKhachHang
default dbo.fn_SinhMaKhachHang() for maKhachHang
--
begin tran
	insert into KHACHHANG(hoTenKhachHang, ngaySinh, diaChi, gioiTinh, CCCD, soDienThoai)
	values ('a', '', 'a', 'Nam', '111111111111', '1111111111')
	select * from KHACHHANG
rollback
go
--------------------------------------------------------------------------------------------------
--Function tự động sinh mã phiếu nhập
create or alter function fn_SinhMaPhieuNhap()
returns nvarchar(20)
as
begin
	declare @NewId nvarchar(20), @LastId nvarchar(20)
	select @LastId = ISNULL(MAX(CAST(SUBSTRING(maPhieuNhap, 3, LEN(maPhieuNhap) - 2) as int)), 0)
	from PHIEUNHAP
	if (@LastId < 999)
	begin
		set @NewId = 'PN' + RIGHT('000' + CAST(ISNULL(@LastId, 0) + 1 as nvarchar), 3)
	end
	else
	begin
		set @NewId = 'PN' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	end
	return @NewID
end
go
-- Add constraint 
alter table PHIEUNHAP add constraint contr_SinhMaPhieuNhap
default dbo.fn_SinhMaPhieuNhap() for maPhieuNhap
go
--
begin tran
	insert into PHIEUNHAP(ngayNhap, maNhaCungCap, maChiNhanh)
	values ('2003-08-10', 'NCC-XE001', 'CNHN')

	select * from PHIEUNHAP
rollback
go
--------------------------------------------------------------------------------------------------
-- Function tự sinh mã chi tiết phiếu nhập xe
create or alter function fn_SinhMaChiTietPhieuNhapXe()
returns nvarchar(20)
as
begin
	declare @NextId nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maChiTietPhieuNhapXe, 6, LEN(maChiTietPhieuNhapXe) - 5) as int)), 0)
	from CHITIETPHIEUNHAPXE
	
	if (@LastID < 999)
	begin
		set @NextId = 'CTPNX' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	end
	else
	begin
		set @NextId = 'CTPNX' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	end
	return @NextId
end
go
-- Add constraint
alter table CHITIETPHIEUNHAPXE add constraint contr_SinhMaChiTietPhieuNhapXe
default dbo.fn_SinhMaChiTietPhieuNhapXe() for maChiTietPhieuNhapXe
begin tran
	insert into CHITIETPHIEUNHAPXE(maLoXe, maPhieuNhap, giaNhap, soLuong)
	values('LOXE001', 'PN001', 11111, 111)

	select * from CHITIETPHIEUNHAPXE
rollback
--------------------------------------------------------------------------------------------------
-- Function tự sinh mã chi tiết phiếu nhập phụ tùng
go
create or alter function fn_SinhMaChiTietPhieuNhapPhuTung()
returns nvarchar(20)
as
begin
	declare @NewID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maChiTietPhieuNhapPhuTung, 7, len(maChiTietPhieuNhapPhuTung) - 6) as int)), 0)
	from CHITIETPHIEUNHAPPHUTUNG
	if (@LastID < 999)
	begin
		set @NewID = 'CTPNPT' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	end
	else
		set @NewID = 'CTPNPT' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	return @NewID
end
go
-- Add contraint
alter table CHITIETPHIEUNHAPPHUTUNG add constraint contr_SinhMaChiTietPhieuNhapPhuTung
default dbo.fn_SinhMaChiTietPhieuNhapPhuTung() for maChiTietPhieuNhapPhuTung
go
begin tran
	insert into CHITIETPHIEUNHAPPHUTUNG(maPhuTung, maPhieuNhap, giaNhap, soLuong)
	values ('PT001', 'PN001', 20000, 10)

	select * from CHITIETPHIEUNHAPPHUTUNG
rollback
go
--------------------------------------------------------------------------------------------------
--Function sinh mã hóa đơn
create or alter function fn_SinhMaHoaDon()
returns nvarchar(20)
as
begin
	declare @NewID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maHoaDon, 3, len(maHoaDon) - 2) as int)), 0)
	from HOADON
	if (@LastID < 999)
	begin
		set @NewID = 'HD' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	end
	else
		set @NewID = 'HD' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	return @NewID
end
go
--Add constraint
alter table HOADON add constraint contr_SinhMaHoaDon
default dbo.fn_SinhMaHoaDon() for maHoaDon
go
begin tran
	insert into HOADON(ngayLapHoaDon, tongTien, tinhTrang, maKhachHang, maNhanVienThucHien)
	values('2003-08-10', 111111, N'Chưa thanh toán', 'KH001', 'NVHN001')
	select * from HOADON
rollback
go
--------------------------------------------------------------------------------------------------
-- Function tự tạo mã chi tiết hóa đơn phụ tùng
create or alter function fn_SinhMaChiTietHoaDonPhuTung()
returns nvarchar(20)
as
begin
	declare @NewID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maChiTietHoaDonPhuTung, 7, LEN(maChiTietHoaDonPhuTung) - 6) as int)), 0)
	from CHITIETHOADONPHUTUNG

	if (@LastID < 999)
	begin
		set @NewID = 'CTHDPT' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	end
	else
	begin
		set @NewID = 'CTHDPT' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	end 
	return @NewID
end
go
--Add constraint
alter table CHITIETHOADONPHUTUNG add constraint contr_SinhMaCTHDPT
default dbo.fn_SinhMaChiTietHoaDonPhuTung() for maChiTietHoaDonPhuTung
go
begin tran
	insert into CHITIETHOADONPHUTUNG(maHoaDon, maPhuTung, soTienDaTra)
	values ('HD001', 'PT001', 100000)
	select * from CHITIETHOADONPHUTUNG
rollback
go
--------------------------------------------------------------------------------------------------
-- Function sinh mã chi tiết hóa đơn xe
create or alter function fn_SinhMaCTHDXe()
returns nvarchar(20)
as
begin
	declare @NewID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maChiTietHoaDonXe, 6, LEN(maChiTietHoaDonXe) - 1) as int)), 0)
	from CHITIETHOADONXE
	if (@LastID < 999)
	begin
		set @NewID = 'CTHDX' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	end
	else
	begin
		set @NewID = 'CTHDX' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	end
	return @NewID
end
go
-- Add Constraint
alter table CHITIETHOADONXE add constraint contr_SinhMaCTHDXe
default dbo.fn_SinhMaCTHDXe() for maChiTietHoaDonXe
begin tran
	insert into CHITIETHOADONXE(maHoaDon, maXe, ngayNhanXe, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo)
	values ('HD001', 'LOXE001_XE001', '2003-08-10', 100000000, 2000000, 1000000, 1000000, 1000000, 1000000)
	select * from CHITIETHOADONXE

rollback
go
--------------------------------------------------------------------------------------------------
-- Function sinh mã phụ tùng
create or alter function fn_SinhMaPhuTung()
returns nvarchar(20)
as
begin
	declare @NewID nvarchar(20), @LastID nvarchar(20)
	select @LastID = ISNULL(MAX(CAST(SUBSTRING(maPhuTung, 3, LEN(maPhuTung) - 2) as int)), 0)
	from PHUTUNG

	if (@LastID < 999)
	begin
		set @NewID = 'PT' + RIGHT('000' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar), 3)
	end
	else
	begin
		set @NewID = 'PT' + CAST(ISNULL(@LastID, 0) + 1 as nvarchar)
	end
	return @NewID
end
go
--Add constraint
alter table PHUTUNG add constraint contr_SinhMaPhuTung
default dbo.fn_SinhMaPhuTung() for maPhuTung
--Test
begin tran
	insert into PHUTUNG(loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong)
	values ('', '', '', '', 10000, '')
	select * from PHUTUNG
rollback
go
--------------------------------------------------------------------------------------------------
-- Function tự động sinh mã nhân viên
create or alter function fn_TaoMaNhanVien
(@MaChiNhanh nvarchar(20))
returns nvarchar(20)
as
begin
	declare @nextID nvarchar(20), @Count int, @TienTo varchar(20), @TenChiNhanh nvarchar(50), @I int
	declare @DodaiMa int
	SET @DodaiMa = 3
	SELECT @TenChiNhanh = cn.tenChiNhanh FROM CHINHANH cn WHERE cn.maChiNhanh =  @MaChiNhanh
	SELECT @Count = count(*) FROM NHANVIEN vn WHERE vn.maChiNhanh = @MaChiNhanh
	SET @I =  charindex(' ', @TenChiNhanh)
	SET @TienTo = SUBSTRING(@TenChiNhanh, 1, 1)
	WHILE @I > 0
	BEGIN
		SET @TienTo = CONCAT(@TienTo, SUBSTRING(@TenChiNhanh, @I + 1, 1))
		SET @TenChiNhanh = SUBSTRING(@TenChiNhanh, @I + 1, len(@TenChiNhanh) -1)
		SET @I =  charindex(' ', @TenChiNhanh)
	END
	SET @nextID = CONCAT(CONCAT(CONCAT('NV', SUBSTRING(@TienTo,3, @DodaiMa)), REPLICATE('0', @DodaiMa - len(@Count))), @Count + 1)
	return @nextID
end
go

------------------------------------------------------------------
-- Function tính tổng số tiền khách hàng phải trả
-- khi thanh toán 1 chiếc xe
go
create or alter function fn_TongSoTienCanThanhToan
(@maKhachHang nvarchar(20), @maXe nvarchar(20))
returns money
as
begin
	declare @TongTien money
	declare @giaBan money, @phiDangKyBienSo money, @phiDangKiem money,
			@phiTruocBa money, @phiBaoHiemTrachNhiemDanSu money, @phiSuDungDuongBo money

	select @giaBan = giaBan, @phiDangKyBienSo = phiDangKyBienSo, @phiDangKiem = phiDangKiem, 
			@phiTruocBa = phiTruocBa, @phiBaoHiemTrachNhiemDanSu = phiBaoHiemTrachNhiemDanSu, 
			@phiSuDungDuongBo = phiSuDungDuongBo
	from
	(select KH.maKhachHang, maXe
	from KHACHHANG KH
	inner join HOADON HD on KH.maKhachHang = HD.maKhachHang
	inner join CHITIETHOADONXE CTHDX on HD.maHoaDon = CTHDX.maHoaDon) Q 
	-- lấy ra mã khách hàng và mã xe
	inner join 
		(select maXe, giaBan
		from XE inner join LOXE
		on XE.maLoXe = LOXE.maLoXe) P -- lấy ra mã xe và giá bán
		on Q.maXe = P.maXe
	inner join
		(select maXe, phiDangKyBienSo, phiDangKiem, phiTruocBa, 
				phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo 
		from CHITIETHOADONXE) K -- lấy ra mã xe và các loại phí của xe
		on P.maXe = K.maXe
	where maKhachHang = @maKhachHang and Q.maXe = @maXe

	set @TongTien = @giaBan + @phiDangKyBienSo + @phiDangKiem + @phiTruocBa 
	+ @phiBaoHiemTrachNhiemDanSu + @phiSuDungDuongBo
	return @TongTien
end
go

select dbo.fn_TongSoTienCanThanhToan('KH001', 'LOXE001_XE001') as N'Tổng tiền'
go




