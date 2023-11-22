﻿use DBMS_DOAN_QUANLYCUAHANGXE
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
--------------------------------------------------------------------------------------------------
-- Function sinh mã phụ tùng
go
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

--select dbo.fn_TongSoTienCanThanhToan('KH001', 'LOXE001_XE001') as N'Tổng tiền'
go

-- Lấy danh sách nhân viên theo chi nhánh
create OR alter function fn_LayDanhSachNhanVienTheoChiNhanh
(@MaChiNhanh nvarchar(20))
returns table
as
return (
    select * from NHANVIEN nv
    where nv.maChiNhanh = @MaChiNhanh
)
go

-- Lấy danh sách hóa đơn chưa thanh toán
create or alter function fn_LayDanhSachHoaDonChuaThanhToan()
returns table
as
return(
	select * from HOADON hd
	where hd.tinhTrang != N'Đã thanh toán'
)
go
-- Thống kê tiền nhập xe theo chi nhánh 
create or alter function fn_ThongKeTienNhapXeTheoChiNhanh
(@MaChiNhanh nvarchar(20))
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(ct.giaNhap * ct.soLuong) from CHITIETPHIEUNHAPXE ct, PHIEUNHAP pn where pn.maPhieuNhap = ct.maPhieuNhap and pn.maChiNhanh = @MaChiNhanh
	if @TongTien is null return 0
	return @TongTien
end
go
-- Thống kê tiền nhập xe trên toàn chi nhánh
create or alter function fn_ThongKeTienNhapXeToanChiNhanh()
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(ct.giaNhap * ct.soLuong) from CHITIETPHIEUNHAPXE ct
	if @TongTien is null return 0
	return @TongTien
end
go
-- Thống kê tiền nhập phụ tùng theo chi nhánh
create or alter function fn_ThongKeTienNhapPhuTungTheoChiNhanh

(@MaChiNhanh nvarchar(20))
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(ct.giaNhap * ct.soLuong) from CHITIETPHIEUNHAPPHUTUNG ct, PHIEUNHAP pn where pn.maPhieuNhap = ct.maPhieuNhap and pn.maChiNhanh = @MaChiNhanh
	if @TongTien is null return 0
	return @TongTien
end
go
-- Thống kê tiền nhập phụ tùng toàn chi nhánh
create or alter function fn_ThongKeTienNhapPhuTungToanChiNhanh()
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(ct.giaNhap * ct.soLuong) from CHITIETPHIEUNHAPPHUTUNG ct
	if @TongTien is null return 0
	return @TongTien
end
go
-- Doanh thu bán xe theo chi nhánh
create or alter function fn_DoanhThuBanXeTheoChiNhanh
(@MaChiNhanh nvarchar(20))
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(ct.soTienDaTra) 
	from CHITIETHOADONXE ct, HOADON hd, NHANVIEN nv
	where ct.maHoaDon = hd.maHoaDon and hd.maNhanVienThucHien = nv.maNhanVien and nv.maChiNhanh = @MaChiNhanh										
	if @TongTien is null return 0
	return @TongTien
end
go
-- Doanh thu bán xe trên toàn chi nhánh
create or alter function fn_DoanhThuBanXeToanChiNhanh()
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(ct.soTienDaTra) 
	from CHITIETHOADONXE ct, HOADON hd
	where ct.maHoaDon = hd.maHoaDon									
	if @TongTien is null return 0
	return @TongTien
end
go
-- Doanh thu bán phụ tùng theo chi nhánh
create or alter function fn_DoanhThuBanPhuTungTheoChiNhanh
(@MaChiNhanh nvarchar(20))
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(ct.soTienDaTra) 
	from CHITIETHOADONPhuTung ct, HOADON hd, NHANVIEN nv
	where ct.maHoaDon = hd.maHoaDon and hd.maNhanVienThucHien = nv.maNhanVien and nv.maChiNhanh = @MaChiNhanh										
	if @TongTien is null return 0
	return @TongTien
end
go
-- Doanh thu bán phụ tùng trên toàn chi nhánh
create or alter function fn_DoanhThuBanPhuTungToanChiNhanh()
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(ct.soTienDaTra) 
	from CHITIETHOADONPHUTUNG ct, HOADON hd
	where ct.maHoaDon = hd.maHoaDon									
	if @TongTien is null return 0
	return @TongTien
end
go
-- Lợi nhuận theo chi nhánh
create or alter function fn_LoiNhuanTheoChiNhanh
(@MaChiNhanh nvarchar(20))
returns money
as
begin
	return dbo.fn_DoanhThuBanPhuTungTheoChiNhanh(@MaChiNhanh) + dbo.fn_DoanhThuBanXeTheoChiNhanh(@MaChiNhanh) - dbo.fn_ThongKeTienNhapPhuTungTheoChiNhanh(@MaChiNhanh) - dbo.fn_ThongKeTienNhapXeTheoChiNhanh(@MaChiNhanh)
end
go
-- Lợi nhuận trên toàn chi nhánh
create or alter function fn_LoiNhuanToanChiNhanh()
returns money
as
begin
return dbo.fn_DoanhThuBanPhuTungToanChiNhanh() + dbo.fn_DoanhThuBanXeToanChiNhanh() - dbo.fn_ThongKeTienNhapPhuTungToanChiNhanh() - dbo.fn_ThongKeTienNhapXeToanChiNhanh()
end
go

-- Tổng tiền chưa thanh toán xe theo chi nhánh

create or alter function fn_TongTienChuaThanhToanXeTheoChiNhanh
(@maChiNhanh nvarchar(20))
returns money 
as
begin
	declare @TongTien money
	select @TongTien = sum(hd.tongTien - ct.soTienDaTra) 
	from CHITIETHOADONXE ct, HOADON hd, NHANVIEN nv
	where ct.maHoaDon = hd.maHoaDon and hd.maNhanVienThucHien = nv.maNhanVien and nv.maChiNhanh = @MaChiNhanh										
	if @TongTien is null return 0
	return @TongTien
end
go

-- Tổng tiền chưa thanh toán xe toàn chi nhánh
create or alter function fn_TongTienChuaThanhToanXeToanChiNhanh()
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(hd.tongTien - ct.soTienDaTra) 
	from CHITIETHOADONXE ct, HOADON hd
	where ct.maHoaDon = hd.maHoaDon									
	if @TongTien is null return 0
	return @TongTien
end
go

-- Tổng tiền chưa thanh toán phụ tùng theo chi nhánh

create or alter function fn_TongTienChuaThanhToanXeTheoChiNhanh
(@maChiNhanh nvarchar(20))
returns money 
as
begin
	declare @TongTien money
	select @TongTien = sum(hd.tongTien - ct.soTienDaTra) 
	from CHITIETHOADONPHUTUNG ct, HOADON hd, NHANVIEN nv
	where ct.maHoaDon = hd.maHoaDon and hd.maNhanVienThucHien = nv.maNhanVien and nv.maChiNhanh = @MaChiNhanh										
	if @TongTien is null return 0
	return @TongTien
end
go

-- Tổng tiền chưa thanh toán phụ tùng toàn chi nhánh
create or alter function fn_TongTienChuaThanhToanXeToanChiNhanh()
returns money
as
begin
	declare @TongTien money
	select @TongTien = sum(hd.tongTien - ct.soTienDaTra) 
	from CHITIETHOADONPHUTUNG ct, HOADON hd
	where ct.maHoaDon = hd.maHoaDon									
	if @TongTien is null return 0
	return @TongTien
end
go




