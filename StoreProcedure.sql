use DBMS_DOAN_QUANLYCUAHANGXE
go

--Xem danh sách thông tin xe theo lô
create or alter proc sp_ThongTinXeTheoLo
@maLoXe nvarchar(20)
as
begin
	select maXe, L.maLoXe, tenXe, mauSac, giaBan, soChoNgoi, xuatXu, hangXe, loaiXe, phienBanXe,
	tocDoToiDa, trongLuong,trongTai,loaiNhienLieu, congSuatDongCo, dungTichDongCo, loaiDongCo, 
	khoangSangGam, chieuDaiCoSo, chieuDai, chieuRong, chieuCao, banKinhQuayVong, hinhAnh
	from LOXE L inner join XE X
	on L.maLoXe = X.maLoXe
	where L.maLoXe = @maLoXe
end
go

exec sp_ThongTinXeTheoLo @maLoXe = 'LOXE002'
go
	

-- Xem thông tin khách hàng
create or alter proc sp_ThongTinKhachHang
as
	select * from KHACHHANG

exec sp_ThongTinKhachHang
go

-- Liệt kê các lô xe xuất xứ theo tên quốc gia
create or alter proc sp_LoXeTheoXuatXu @xuatXu nvarchar(50)
as
begin
	select * from LOXE where xuatXu = @xuatXu
end
go

--Liệt kê thông tin nhân viên theo chi nhánh
create or alter proc sp_LietKeNhanVienTheoChiNhanh
@maChiNhanh nvarchar(20)
as
begin
	select * from NHANVIEN where maChiNhanh = @maChiNhanh
end
go
exec sp_LietKeNhanVienTheoChiNhanh @maChiNhanh = 'CNHN'
-----
select PN.maPhieuNhap, maChiNhanh, maLoXe, soLuong
from PHIEUNHAP PN
inner join CHITIETPHIEUNHAPXE CTPNX
on PN.maPhieuNhap = CTPNX.maPhieuNhap

go



-----------------------------------------
--* CHINHANH
go
create or alter proc List_CHINHANH
as 
	select * from CHINHANH

exec list_ChiNhanh
go
-------------------------------------------------------------------
create or alter proc Insert_CHINHANH @maChiNhanh nvarchar(20), @tenChiNhanh nvarchar(50), @diaChi nvarchar(255)
as 
	insert into CHINHANH (maChiNhanh, tenChiNhanh, diaChi) values (@maChiNhanh, @tenChiNhanh, @diaChi)

begin tran
	exec Insert_CHINHANH @maChiNhanh, @tenChiNhanh,  @diaChi
	select * from CHINHANH
rollback
go
-------------------------------------------------------------------
create or alter proc Update_CHINHANH @tenChiNhanh nvarchar(50), @diaChi nvarchar(255), @maChiNhanh nvarchar(20)
as 
	update CHINHANH set tenChiNhanh = @tenChiNhanh, diaChi = @diaChi where maChiNhanh = @maChiNhanh

exec Update_CHINHANH @tenChiNhanh , @diaChi , @maChiNhanh 
go
-------------------------------------------------------------------
create or alter proc Delete_CHINHANH @maChiNhanh nvarchar(20)
as
	delete CHINHANH where maChiNhanh = @maChiNhanh
go
exec Delete_CHINHANH @maChiNhanh 

--------------------------------------
----------------------------*CHITIETHOADONPHUTUNG
go
create or alter proc List_CHITIETHOADONPHUTUNG
as 
	select * from CHITIETHOADONPHUTUNG

exec List_CHITIETHOADONPHUTUNG
go
-------------------------------------------------------------------
create or alter proc Insert_CHITIETHOADONPHUTUNG @maHoaDon nvarchar(20), @maPhuTung nvarchar(20), @soTienDaTra float
as 
	insert into CHITIETHOADONPHUTUNG (maHoaDon, maPhuTung, soTienDaTra) values (@maHoaDon, @maPhuTung, @soTienDaTra)
go
exec Insert_CHITIETHOADONPHUTUNG @maHoaDon , @maPhuTung, @soTienDaTra
-------------------------------------------------------------------
create or alter proc Update_CHITIETHOADONPHUTUNG @maHoaDon nvarchar(20), @maPhuTung nvarchar(20), @soTienDaTra money,  @maChiTietHoaDonPhuTung nvarchar(20)
as 
	update CHITIETHOADONPHUTUNG set soTienDaTra = @soTienDaTra, maHoaDon = @maHoaDon, maPhuTung = @maPhuTung where maChiTietHoaDonPhuTung = @maChiTietHoaDonPhuTung

exec Update_CHITIETHOADONPHUTUNG @soTienDaTra , @maHoaDon '', @maPhuTung '', @maChiTietHoaDonPhuTung ''
-------------------------------------------------------------------
create or alter proc Delete_CHITIETHOADONPHUTUNG @maChiTietHoaDonPhuTung nvarchar(20)
as
	delete CHITIETHOADONPHUTUNG where maChiTietHoaDonPhuTung = @maChiTietHoaDonPhuTung

exec Delete_CHITIETHOADONPHUTUNG @maChiTietHoaDonPhuTung ''

* Chi tiết hóa đơn xe

create or alter proc List_CHITIETHOADONXE
as 
	select * from CHITIETHOADONXE

exec list_CHITIETHOADONXE
-------------------------------------------------------------------
create or alter proc Insert_CHITIETHOADONXE @maChiTietHoaDonXe nvarchar(20), @maHoaDon nvarchar(20), @maXe nvarchar(20), @ngayNhanXe nvarchar(50), @soTienDaTra money, @phiDangKyBienSo money  ,@phiDangKiem money , @phiTruocBa money, @phiBaoHiemTrachNhiemDanSu money, @phiSuDungDuongBo money
as 
	insert into CHITIETHOADONXE (maChiTietHoaDonXe, maHoaDon, maXe, ngayNhanXe, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo)
	values (@maChiTietHoaDonXe, @maHoaDon, @maXe, @ngayNhanXe, @soTienDaTra, @phiDangKyBienSo, @phiDangKiem, @phiTruocBa, @phiBaoHiemTrachNhiemDanSu, @phiSuDungDuongBo)

exec Insert_CHITIETHOADONXE @maChiTietHoaDonXe '', @maHoaDon '' , @maXe '', @ngayNhanXe '', @soTienDaTra, @phiDangKyBienSo, @phiDangKiem, @phiTruocBa, @phiBaoHiemTrachNhiemDanSu, @phiSuDungDuongBo
-------------------------------------------------------------------
create or alter proc Update_CHITIETHOADONXE @maHoaDon nvarchar(20), @maXe nvarchar(20),  @ngayNhanXe nvarchar(50),   @soTienDaTra money, @phiDangKyBienSo money, @phiDangKiem money, @phiTruocBa money, @phiBaoHiemTrachNhiemDanSu money, @phiSuDungDuongBo money, @maChiTietHoaDonXe nvarchar(20)
as 
	update CHITIETHOADONXE set maHoaDon = @maHoaDon, maXe = @maXe, ngayNhanXe = @ngayNhanXe, soTienDaTra = @soTienDaTra, phiDangKyBienSo = @phiDangKyBienSo, phiDangKiem = @phiDangKiem, phiTruocBa = @phiTruocBa, phiBaoHiemTrachNhiemDanSu = @phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo = @phiSuDungDuongBo where maChiTietHoaDonXe = @maChiTietHoaDonXe

exec Update_CHITIETHOADONXE @maHoaDon , @maXe, @ngayNhanXe, @soTienDaTra, @phiDangKyBienSo, @phiDangKiem, @phiTruocBa, @phiBaoHiemTrachNhiemDanSu, @phiSuDungDuongBo, @maChiTietHoaDonXe
-------------------------------------------------------------------
create or alter proc Delete_CHITIETHOADONXE @maChiTietHoaDonXe nvarchar(20)
as
	delete CHITIETHOADONXE where maChiTietHoaDonXe = @maChiTietHoaDonXe

exec Delete_CHITIETHOADONXE @maChiTietHoaDonXe ''


* Chi tiết phiếu bảo dương

create or alter proc List_CHITIETPHIEUBAODUONG
as 
	select * from CHITIETPHIEUBAODUONG

exec list_CHITIETPHIEUBAODUONG
-------------------------------------------------------------------
create or alter proc Insert_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong nvarchar(20), @maBaoDuong nvarchar(20), @maPhieuBaoDuong nvarchar(20), @thanhTien money
as 
	insert into CHITIETPHIEUBAODUONG (maChiTietPhieuBaoDuong, maBaoDuong, maPhieuBaoDuong, thanhTien) values (@maChiTietPhieuBaoDuong, @maBaoDuong, @maPhieuBaoDuong, @thanhTien)

exec Insert_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong '', @maBaoDuong '', @maPhieuBaoDuong'', @thanhTien''
-------------------------------------------------------------------
create or alter proc Update_CHITIETPHIEUBAODUONG @maBaoDuong nvarchar(20), @maPhieuBaoDuong nvarchar(20), @thanhTien money,  @maChiTietPhieuBaoDuong nvarchar(20)
as
	update CHITIETPHIEUBAODUONG set maBaoDuong = @maBaoDuong, maPhieuBaoDuong = @maPhieuBaoDuong, thanhTien = @thanhTien where maChiTietPhieuBaoDuong = @maChiTietPhieuBaoDuong

exec Update_CHITIETPHIEUBAODUONG @maBaoDuong '', @maPhieuBaoDuong '', @thanhTien, @maChiTietPhieuBaoDuong''
-------------------------------------------------------------------
create or alter proc Delete_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong nvarchar(20)
as
	delete CHITIETPHIEUBAODUONG where maChiTietPhieuBaoDuong = @maChiTietPhieuBaoDuong

exec Delete_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong ''

* Chi tiet phieu nhap phu tung

create or alter proc List_CHITIETPHIEUNHAPPHUTUNG
as 
	select * from CHITIETPHIEUNHAPPHUTUNG

exec list_CHITIETPHIEUNHAPPHUTUNG
-------------------------------------------------------------------
create or alter proc Insert_CHITIETPHIEUNHAPPHUTUNG @maChiTietPhieuNhapPhuTung nvarchar(20), @maPhuTung nvarchar(20), @maPhieuNhap nvarchar(20), @giaNhap money, @soLuong int
as 
	insert into CHITIETPHIEUNHAPPHUTUNG (maChiTietPhieuNhapPhuTung, maPhuTung, maPhieuNhap, giaNhap, soLuong) values (@maChiTietPhieuNhapPhuTung, @maPhuTung, @maPhieuNhap, @giaNhap, @soLuong)

exec Insert_CHITIETPHIEUNHAPPHUTUNG @maChiTietPhieuNhapPhuTung '', @maPhuTung'', @maPhieuNhap '', @giaNhap, @soLuong 
-------------------------------------------------------------------
create or alter proc Update_CHITIETPHIEUNHAPPHUTUNG  @maPhuTung nvarchar(20), @maPhieuNhap nvarchar(20), @giaNhap money, @soLuong int, @maChiTietPhieuNhapPhuTung nvarchar(20)
as
	update CHITIETPHIEUNHAPPHUTUNG set maPhuTung = @maPhuTung, maPhieuNhap = @maPhieuNhap, giaNhap = @giaNhap, soLuong = @soLuong, maChiTietPhieuNhapPhuTung = @maChiTietPhieuNhapPhuTung

exec Update_CHITIETPHIEUNHAPPHUTUNG @maPhuTung '', @maPhieuNhap '', @giaNhap '', @soLuong '', @maChiTietPhieuNhapPhuTung''
-------------------------------------------------------------------
create or alter proc Delete_CHITIETPHIEUNHAPPHUTUNG  @maChiTietPhieuNhapPhuTung nvarchar(20)
as
	delete CHITIETPHIEUNHAPPHUTUNG where maChiTietPhieuNhapPhuTung =  @maChiTietPhieuNhapPhuTung

exec Delete_CHITIETPHIEUNHAPPHUTUNG  @maChiTietPhieuNhapPhuTung ''

* Chi tiet phieu nhap phu tung

create or alter proc List_CHITIETPHIEUNHAPXE
as 
	select * from CHITIETPHIEUNHAPXE

exec list_CHITIETPHIEUNHAPXE
-------------------------------------------------------------------
create or alter proc Insert_CHITIETPHIEUNHAPXE @maChiTietPhieuNhapXe nvarchar(20), @maLoXe  nvarchar(20), @maPhieuNhap nvarchar(20), @giaNhap money, @soLuong int
as 
	insert into CHITIETPHIEUNHAPXE (maChiTietPhieuNhapXe, maLoXe, maPhieuNhap, giaNhap, soLuong) values (@maChiTietPhieuNhapXe, @maLoXe, @maPhieuNhap, @giaNhap, @soLuong)

exec Insert_CHITIETPHIEUNHAPXE @maChiTietPhieuNhapXe '', @maLoXe '', @maPhieuNhap '', @giaNhap, @soLuong 
-------------------------------------------------------------------
create or alter proc Update_CHITIETPHIEUNHAPXE  @maLoXe nvarchar(20), @maPhieuNhap nvarchar(20), @giaNhap money, @soLuong int, @maChiTietPhieuNhapXe nvarchar(20)
as
	update CHITIETPHIEUNHAPXE set maLoXe = @maLoXe, maPhieuNhap = @maPhieuNhap, giaNhap = @giaNhap, soLuong = @soLuong, maChiTietPhieuNhapXe = @maChiTietPhieuNhapXe

exec Update_CHITIETPHIEUNHAPXE @maLoXe '', @maPhieuNhap '', @giaNhap , @soLuong , @maChiTietPhieuNhapXe''
-------------------------------------------------------------------
create or alter proc Delete_CHITIETPHIEUNHAPXE  @maChiTietPhieuNhapXe nvarchar(20)
as
	delete CHITIETPHIEUNHAPXE where maChiTietPhieuNhapXe =  @maChiTietPhieuNhapXe

exec Delete_CHITIETPHIEUNHAPXE @maChiTietPhieuNhapXe ''

* Dich vu bao duong
create or alter proc List_DICHVUBAODUONG
as 
	select * from DICHVUBAODUONG

exec list_DICHVUBAODUONG
-------------------------------------------------------------------
create or alter proc Insert_DICHVUBAODUONG @maBaoDuong nvarchar(20), @tenBaoDuong nvarchar(50), @loaiBaoDuong nvarchar(50), @phiBaoDuong money
as 
	insert into DICHVUBAODUONG (maBaoDuong, tenBaoDuong, loaiBaoDuong, phiBaoDuong) values (@maBaoDuong, @tenBaoDuong, @loaiBaoDuong, @phiBaoDuong)

exec Insert_DICHVUBAODUONG @maBaoDuong '', @tenBaoDuong '', @loaiBaoDuong '', @phiBaoDuong
-------------------------------------------------------------------
create or alter proc Update_DICHVUBAODUONG  @tenBaoDuong nvarchar(50), @loaiBaoDuong nvarchar(50), @phiBaoDuong money, @maBaoDuong nvarchar(20)
as
	update DICHVUBAODUONG set tenBaoDuong = @tenBaoDuong, loaiBaoDuong = @loaiBaoDuong, phiBaoDuong = @phiBaoDuong, maBaoDuong = @maBaoDuong

exec Update_DICHVUBAODUONG @tenBaoDuong '', @loaiBaoDuong '', @phiBaoDuong , @maBaoDuong ''
-------------------------------------------------------------------
create or alter proc Delete_DICHVUBAODUONG  @maBaoDuong nvarchar(20)
as
	delete DICHVUBAODUONG where maBaoDuong =  @maBaoDuong

exec Delete_DICHVUBAODUONG @maBaoDuong ''


* Hoa Don
create or alter proc List_HOADON
as 
	select * from HOADON

exec list_HOADON
-------------------------------------------------------------------
create or alter proc Insert_HOADON @maHoaDon nvarchar(20), @ngayLapHoaDon nvarchar(50), @tongTien money, @tinhTrang nvarchar(50), @maKhachHang nvarchar(20), @maNhanVienThucHien nvarchar(20)
as 
	insert into HOADON (maHoaDon, ngayLapHoaDon, tongTien, tinhTrang, maKhachHang, maNhanVienThucHien) values (@maHoaDon, @ngayLapHoaDon, @tongTien, @tinhTrang, @maKhachHang, @maNhanVienThucHien)

exec Insert_HOADON @maHoaDon '', @ngayLapHoaDon '', @tongTien, @tinhTrang, @maKhachHang '', @maNhanVienThucHien ''
-------------------------------------------------------------------
create or alter proc Update_HOADON  @ngayLapHoaDon nvarchar(50), @tongTien money, @tinhTrang nvarchar(50), @maKhachHang nvarchar(20), @maNhanVienThucHien nvarchar(20), @maHoaDon nvarchar(20)
as
	update HOADON set ngayLapHoaDon = @ngayLapHoaDon, tongTien = @tongTien, tinhTrang = @tinhTrang, maKhachHang = @maKhachHang,  maNhanVienThucHien = @maNhanVienThucHien where  maHoaDon =  @maHoaDon

exec Update_HOADON @ngayLapHoaDon '', @tongTien ,@tinhTrang '', @maKhachHang'' , @maNhanVienThucHien '', @maHoaDon''
-------------------------------------------------------------------
create or alter proc Delete_HOADON  @maHoaDon nvarchar(20)
as
	delete HOADON where maHoaDon =  @maHoaDon

exec Delete_HOADON @maHoaDon ''

* HOPDongBaoHanh
create or alter proc List_HOPDONGBAOHANH
as 
	select * from HOPDONGBAOHANH

exec list_HOPDONGBAOHANH
-------------------------------------------------------------------
create or alter proc Insert_HOPDONGBAOHANH @maHopDongBaoHanh nvarchar(20), @maXe nvarchar(20), @maKhachHang nvarchar(20), @ngayKyBaoHanh date, @thoiHanBaoHanh date, @tinhTrang nvarchar(20)
as 
	insert into HOPDONGBAOHANH (maHopDongBaoHanh, maXe, maKhachHang, ngayKyBaoHanh, thoiHanBaoHanh, tinhTrang) values (@maHopDongBaoHanh, @maXe, @maKhachHang, @ngayKyBaoHanh, @thoiHanBaoHanh, @tinhTrang)

exec Insert_HOPDONGBAOHANH @maHopDongBaoHanh '', @maXe '', @maKhachHang'', @ngayKyBaoHanh, @thoiHanBaoHanh, @tinhTrang ''
-------------------------------------------------------------------
create or alter proc Update_HOPDONGBAOHANH  @maXe nvarchar(20), @maKhachHang nvarchar(20), @ngayKyBaoHanh date, @thoiHanBaoHanh date, @tinhTrang nvarchar(20), @maHopDongBaoHanh nvarchar(20)
as
	update HOPDONGBAOHANH set maXe = @maXe, maKhachHang = @maKhachHang, ngayKyBaoHanh = @ngayKyBaoHanh, thoiHanBaoHanh = @thoiHanBaoHanh,  tinhTrang = @tinhTrang where  maHopDongBaoHanh =  @maHopDongBaoHanh

exec Update_HOPDONGBAOHANH @maXe '', @maKhachHang'' ,@ngayKyBaoHanh , @thoiHanBaoHanh , @tinhTrang '', @maHopDongBaoHanh''
-------------------------------------------------------------------
create or alter proc Delete_HOPDONGBAOHANH  @maHopDongBaoHanh nvarchar(20)
as
	delete HOPDONGBAOHANH where maHopDongBaoHanh =  @maHopDongBaoHanh

exec Delete_HOPDONGBAOHANH @maHopDongBaoHanh ''



