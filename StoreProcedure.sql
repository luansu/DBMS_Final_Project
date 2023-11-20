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
go
-------
create or alter proc Insert_CHINHANH @maChiNhanh nvarchar(20), @tenChiNhanh nvarchar(50), @diaChi nvarchar(255)
as 
	insert into CHINHANH (maChiNhanh, tenChiNhanh, diaChi) values (@maChiNhanh, @tenChiNhanh, @diaChi)
go
-----
create or alter proc Update_CHINHANH @tenChiNhanh nvarchar(50), @diaChi nvarchar(255), @maChiNhanh nvarchar(20)
as 
	update CHINHANH set tenChiNhanh = @tenChiNhanh, diaChi = @diaChi where maChiNhanh = @maChiNhanh
go
------
create or alter proc Delete_CHINHANH @maChiNhanh nvarchar(20)
as
	delete CHINHANH where maChiNhanh = @maChiNhanh
go 

--------------------------------------
------*CHITIETHOADONPHUTUNG
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

-------------------------------------------------------------------
create or alter proc Update_CHITIETHOADONPHUTUNG @maChiTietHoaDonPhuTung nvarchar(20), @maHoaDon nvarchar(20), @maPhuTung nvarchar(20), @soTienDaTra float
as 
	update CHITIETHOADONPHUTUNG set soTienDaTra = @soTienDaTra, maHoaDon = @maHoaDon, maPhuTung = @maPhuTung where maChiTietHoaDonPhuTung = @maChiTietHoaDonPhuTung
go 
-------------------------------------------------------------------
create or alter proc Delete_CHITIETHOADONPHUTUNG @maChiTietHoaDonPhuTung nvarchar(20)
as
	delete CHITIETHOADONPHUTUNG where maChiTietHoaDonPhuTung = @maChiTietHoaDonPhuTung


----* Chi tiết hóa đơn xe
go
create or alter proc List_CHITIETHOADONXE
as 
	select * from CHITIETHOADONXE

go
-------------------------------------------------------------------
create or alter proc Insert_CHITIETHOADONXE  @maHoaDon nvarchar(20), @maXe nvarchar(20), @ngayNhanXe nvarchar(50), @soTienDaTra money, @phiDangKyBienSo money  ,@phiDangKiem money , @phiTruocBa money, @phiBaoHiemTrachNhiemDanSu money, @phiSuDungDuongBo money
as 
	insert into CHITIETHOADONXE (maHoaDon, maXe, ngayNhanXe, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo)
	values (@maHoaDon, @maXe, @ngayNhanXe, @soTienDaTra, @phiDangKyBienSo, @phiDangKiem, @phiTruocBa, @phiBaoHiemTrachNhiemDanSu, @phiSuDungDuongBo)

exec Insert_CHITIETHOADONXE @maHoaDon , @maXe , @ngayNhanXe , @soTienDaTra, @phiDangKyBienSo, @phiDangKiem, @phiTruocBa, @phiBaoHiemTrachNhiemDanSu, @phiSuDungDuongBo
go
-------------------------------------------------------------------
create or alter proc Update_CHITIETHOADONXE @maChiTietHoaDonXe nvarchar(20), @maHoaDon nvarchar(20), @maXe nvarchar(20),  @ngayNhanXe nvarchar(50),   @soTienDaTra money, @phiDangKyBienSo money, @phiDangKiem money, @phiTruocBa money, @phiBaoHiemTrachNhiemDanSu money, @phiSuDungDuongBo money
as 
	update CHITIETHOADONXE set maHoaDon = @maHoaDon, maXe = @maXe, ngayNhanXe = @ngayNhanXe, soTienDaTra = @soTienDaTra, phiDangKyBienSo = @phiDangKyBienSo, phiDangKiem = @phiDangKiem, phiTruocBa = @phiTruocBa, phiBaoHiemTrachNhiemDanSu = @phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo = @phiSuDungDuongBo where maChiTietHoaDonXe = @maChiTietHoaDonXe

-------------------------------------------------------------------
go
create or alter proc Delete_CHITIETHOADONXE @maChiTietHoaDonXe nvarchar(20)
as
	delete CHITIETHOADONXE where maChiTietHoaDonXe = @maChiTietHoaDonXe

--* Chi tiết phiếu bảo dương
go
create or alter proc List_CHITIETPHIEUBAODUONG
as 
	select * from CHITIETPHIEUBAODUONG

exec list_CHITIETPHIEUBAODUONG
go
-------------------------------------------------------------------
create or alter proc Insert_CHITIETPHIEUBAODUONG @maBaoDuong nvarchar(20), @maPhieuBaoDuong nvarchar(20), @thanhTien float
as 
	insert into CHITIETPHIEUBAODUONG (maBaoDuong, maPhieuBaoDuong, thanhTien) values (@maBaoDuong, @maPhieuBaoDuong, @thanhTien)

exec Insert_CHITIETPHIEUBAODUONG @maBaoDuong , @maPhieuBaoDuong , @thanhTien 
-------------------------------------------------------------------
go
create or alter proc Update_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong nvarchar(20), @maBaoDuong nvarchar(20), @maPhieuBaoDuong nvarchar(20), @thanhTien float
as
	update CHITIETPHIEUBAODUONG set maBaoDuong = @maBaoDuong, maPhieuBaoDuong = @maPhieuBaoDuong, thanhTien = @thanhTien where maChiTietPhieuBaoDuong = @maChiTietPhieuBaoDuong

exec Update_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong , @maBaoDuong , @maPhieuBaoDuong , @thanhTien 
go
-------------------------------------------------------------------
create or alter proc Delete_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong nvarchar(20)
as
	delete CHITIETPHIEUBAODUONG where maChiTietPhieuBaoDuong = @maChiTietPhieuBaoDuong

exec Delete_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong 

--* Chi tiet phieu nhap phu tung
go
create or alter proc List_CHITIETPHIEUNHAPPHUTUNG
as 
	select * from CHITIETPHIEUNHAPPHUTUNG

exec list_CHITIETPHIEUNHAPPHUTUNG
go
-------------------------------------------------------------------
create or alter proc Insert_CHITIETPHIEUNHAPPHUTUNG @maPhuTung nvarchar(20), @maPhieuNhap nvarchar(20), @giaNhap float, @soLuong int
as 
	insert into CHITIETPHIEUNHAPPHUTUNG (maPhuTung, maPhieuNhap, giaNhap, soLuong) values (@maPhuTung, @maPhieuNhap, @giaNhap, @soLuong)

  
go
-------------------------------------------------------------------
create or alter proc Update_CHITIETPHIEUNHAPPHUTUNG @maChiTietPhieuNhapPhuTung nvarchar(20), @maPhuTung nvarchar(20), @maPhieuNhap nvarchar(20), @giaNhap float, @soLuong int
as
	update CHITIETPHIEUNHAPPHUTUNG set maPhuTung = @maPhuTung, maPhieuNhap = @maPhieuNhap, giaNhap = @giaNhap, soLuong = @soLuong where maChiTietPhieuNhapPhuTung = @maChiTietPhieuNhapPhuTung

begin tran
	exec Update_CHITIETPHIEUNHAPPHUTUNG 'CTPNPT010' , 'PT010' , 'PN010' , 1 , 1 
	select * from CHITIETPHIEUNHAPPHUTUNG
rollback
go
-------------------------------------------------------------------
create or alter proc Delete_CHITIETPHIEUNHAPPHUTUNG  @maChiTietPhieuNhapPhuTung nvarchar(20)
as
	delete CHITIETPHIEUNHAPPHUTUNG where maChiTietPhieuNhapPhuTung =  @maChiTietPhieuNhapPhuTung

exec Delete_CHITIETPHIEUNHAPPHUTUNG  @maChiTietPhieuNhapPhuTung 

--* Chi tiet phieu nhap xe
go
create or alter proc List_CHITIETPHIEUNHAPXE
as 
	select * from CHITIETPHIEUNHAPXE

exec list_CHITIETPHIEUNHAPXE
go
-------------------------------------------------------------------
create or alter proc Insert_CHITIETPHIEUNHAPXE @maLoXe  nvarchar(20), @maPhieuNhap nvarchar(20), @giaNhap float, @soLuong int
as 
	insert into CHITIETPHIEUNHAPXE (maLoXe, maPhieuNhap, giaNhap, soLuong) values (@maLoXe, @maPhieuNhap, @giaNhap, @soLuong)

go
-------------------------------------------------------------------
create or alter proc Update_CHITIETPHIEUNHAPXE  @maChiTietPhieuNhapXe nvarchar(20), @maLoXe nvarchar(20), @maPhieuNhap nvarchar(20), @giaNhap float, @soLuong int
as
	update CHITIETPHIEUNHAPXE set maLoXe = @maLoXe, maPhieuNhap = @maPhieuNhap, giaNhap = @giaNhap, soLuong = @soLuong where maChiTietPhieuNhapXe = @maChiTietPhieuNhapXe

exec Update_CHITIETPHIEUNHAPXE @maChiTietPhieuNhapXe , @maLoXe , @maPhieuNhap , @giaNhap , @soLuong 
go
-------------------------------------------------------------------
create or alter proc Delete_CHITIETPHIEUNHAPXE  @maChiTietPhieuNhapXe nvarchar(20)
as
	delete CHITIETPHIEUNHAPXE where maChiTietPhieuNhapXe =  @maChiTietPhieuNhapXe

exec Delete_CHITIETPHIEUNHAPXE @maChiTietPhieuNhapXe 

----* Dich vu bao duong
go
create or alter proc List_DICHVUBAODUONG
as 
	select * from DICHVUBAODUONG

exec list_DICHVUBAODUONG
go
-------------------------------------------------------------------
create or alter proc Insert_DICHVUBAODUONG @tenBaoDuong nvarchar(50), @loaiBaoDuong nvarchar(50), @phiBaoDuong float
as 
	insert into DICHVUBAODUONG (tenBaoDuong, loaiBaoDuong, phiBaoDuong) values (@tenBaoDuong, @loaiBaoDuong, @phiBaoDuong)

exec Insert_DICHVUBAODUONG @tenBaoDuong , @loaiBaoDuong , @phiBaoDuong 
go
-------------------------------------------------------------------
create or alter proc Update_DICHVUBAODUONG @maBaoDuong nvarchar(20), @tenBaoDuong nvarchar(50), @loaiBaoDuong nvarchar(50), @phiBaoDuong float
as
	update DICHVUBAODUONG set tenBaoDuong = @tenBaoDuong, loaiBaoDuong = @loaiBaoDuong, phiBaoDuong = @phiBaoDuong, maBaoDuong = @maBaoDuong

exec Update_DICHVUBAODUONG @maBaoDuong , @tenBaoDuong , @loaiBaoDuong , @phiBaoDuong 
go
-------------------------------------------------------------------
create or alter proc Delete_DICHVUBAODUONG  @maBaoDuong nvarchar(20)
as
	delete DICHVUBAODUONG where maBaoDuong =  @maBaoDuong

exec Delete_DICHVUBAODUONG @maBaoDuong


----* Hoa Don
go
create or alter proc List_HOADON
as 
	select * from HOADON

exec list_HOADON
go
-------------------------------------------------------------------
create or alter proc Insert_HOADON @ngayLapHoaDon date, @tongTien float, @tinhTrang nvarchar(50), @maKhachHang nvarchar(20), @maNhanVienThucHien nvarchar(20)
as 
	insert into HOADON (ngayLapHoaDon, tongTien, tinhTrang, maKhachHang, maNhanVienThucHien) values (@ngayLapHoaDon, @tongTien, @tinhTrang, @maKhachHang, @maNhanVienThucHien)

go
-------------------------------------------------------------------
create or alter proc Update_HOADON @maHoaDon nvarchar(20), @ngayLapHoaDon date, @tongTien float, @tinhTrang nvarchar(50), @maKhachHang nvarchar(20), @maNhanVienThucHien nvarchar(20)
as
	update HOADON set ngayLapHoaDon = @ngayLapHoaDon, tongTien = @tongTien, tinhTrang = @tinhTrang, maKhachHang = @maKhachHang,  maNhanVienThucHien = @maNhanVienThucHien where  maHoaDon =  @maHoaDon

go
-------------------------------------------------------------------
create or alter proc Delete_HOADON  @maHoaDon nvarchar(20)
as
	delete HOADON where maHoaDon =  @maHoaDon

exec Delete_HOADON @maHoaDon 

--* HOPDongBaoHanh
go
create or alter proc List_HOPDONGBAOHANH
as 
	select * from HOPDONGBAOHANH

exec list_HOPDONGBAOHANH
go
-------------------------------------------------------------------
create or alter proc Insert_HOPDONGBAOHANH @maHopDongBaoHanh nvarchar(20), @maXe nvarchar(20), @maKhachHang nvarchar(20), @ngayKyBaoHanh date, @thoiHanBaoHanh date, @tinhTrang nvarchar(20)
as 
	insert into HOPDONGBAOHANH (maHopDongBaoHanh, maXe, maKhachHang, ngayKyBaoHanh, thoiHanBaoHanh, tinhTrang) values (@maHopDongBaoHanh, @maXe, @maKhachHang, @ngayKyBaoHanh, @thoiHanBaoHanh, @tinhTrang)

exec Insert_HOPDONGBAOHANH @maHopDongBaoHanh '', @maXe '', @maKhachHang'', @ngayKyBaoHanh, @thoiHanBaoHanh, @tinhTrang ''
go
-------------------------------------------------------------------
create or alter proc Update_HOPDONGBAOHANH  @maXe nvarchar(20), @maKhachHang nvarchar(20), @ngayKyBaoHanh date, @thoiHanBaoHanh date, @tinhTrang nvarchar(20), @maHopDongBaoHanh nvarchar(20)
as
	update HOPDONGBAOHANH set maXe = @maXe, maKhachHang = @maKhachHang, ngayKyBaoHanh = @ngayKyBaoHanh, thoiHanBaoHanh = @thoiHanBaoHanh,  tinhTrang = @tinhTrang where  maHopDongBaoHanh =  @maHopDongBaoHanh

exec Update_HOPDONGBAOHANH @maXe '', @maKhachHang'' ,@ngayKyBaoHanh , @thoiHanBaoHanh , @tinhTrang '', @maHopDongBaoHanh''
go
-------------------------------------------------------------------
create or alter proc Delete_HOPDONGBAOHANH  @maHopDongBaoHanh nvarchar(20)
as
	delete HOPDONGBAOHANH where maHopDongBaoHanh =  @maHopDongBaoHanh

exec Delete_HOPDONGBAOHANH @maHopDongBaoHanh ''
go
--- KHACH HANG
create or alter proc List_KhachHang
as
	select * from KHACHHANG
exec List_KhachHang


go
create or alter proc Insert_KhachHang @hoTenKhachHang nvarchar(50), @ngaySinh date, @gioiTinh nvarchar(5), @CCCD nvarchar(20), @diaChi nvarchar(255), @soDienThoai nvarchar(20)
as
	insert into KHACHHANG(hoTenKhachHang, ngaySinh, gioiTinh, CCCD, diaChi, soDienThoai) values (@hoTenKhachHang, @ngaySinh, @gioiTinh, @CCCD, @diaChi, @soDienThoai)

exec Insert_KhachHang @hoTenKhachHang , @ngaySinh , @gioiTinh , @CCCD , @diaChi , @soDienThoai

go
create or alter proc Update_KhachHang @maKhachHang nvarchar(20), @hoTenKhachHang nvarchar(50), @ngaySinh date, @gioiTinh nvarchar(5), @CCCD nvarchar(20), @diaChi nvarchar(255), @soDienThoai nvarchar(20)
as
	Update KHACHHANG set hoTenKhachHang = @hoTenKhachHang, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, CCCD = @CCCD, diaChi = @diaChi, soDienThoai = @soDienThoai where maKhachHang = @maKhachHang

exec Update_KhachHang @maKhachHang , @hoTenKhachHang , @ngaySinh , @gioiTinh , @CCCD , @diaChi , @soDienThoai

go
create or alter proc Delete_KhachHang @maKhachHang nvarchar(20)
as
	delete KHACHHANG where maKhachHang = @maKhachHang
exec Delete_KhachHang @maKhachHang
go
--- Nha Cung cap
create or alter proc List_NhaCungCap
as
	select * from NHACUNGCAP
exec List_NhaCungCap

go
create or alter proc Insert_NhaCungCap @maNhaCungCap nvarchar(20), @tenNhaCungCap nvarchar(50), @diaChi nvarchar(255), @soDienThoai nvarchar(20)
as
	insert into NHACUNGCAP(maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai) values(@maNhaCungCap,  @tenNhaCungCap, @diaChi, @soDienThoai)

exec Insert_NhaCungCap @maNhaCungCap , @tenNhaCungCap , @diaChi , @soDienThoai

go
create or alter proc Update_NhaCungCap @maNhaCungCap nvarchar(20), @tenNhaCungCap nvarchar(50), @diaChi nvarchar(255), @soDienThoai nvarchar(20)
as
	Update NHACUNGCAP set tenNhaCungCap = @tenNhaCungCap, diaChi = @diaChi, soDienThoai = @soDienThoai where maNhaCungCap = @maNhaCungCap

exec Update_NhaCungCap @maNhaCungCap , @tenNhaCungCap , @diaChi , @soDienThoai

go
create or alter proc Delete_NhaCungCap @maNhaCungCap nvarchar(20)
as
	delete NHACUNGCAP where maNhaCungCap = @maNhaCungCap
exec Delete_NhaCungCap @maNhaCungCap 

---Phieu nhap
go
create or alter proc List_PhieuNhap
as
	select * from PHIEUNHAP
exec List_PhieuNhap

go
create or alter proc Insert_PhieuNhap @ngayNhap date, @maChiNhanh nvarchar(20), @maNhaCungCap nvarchar(20)
as
	insert into PHIEUNHAP(ngayNhap, maChiNhanh, maNhaCungCap) values(@ngayNhap, @maChiNhanh, @maNhaCungCap)

exec Insert_PhieuNhap @ngayNhap , @maChiNhanh , @maNhaCungCap 


go
create or alter proc Update_PhieuNhap @maPhieuNhap nvarchar(20), @ngayNhap date, @maChiNhanh nvarchar(20), @maNhaCungCap nvarchar(20)
as
	update PHIEUNHAP set ngayNhap = @ngayNhap, maChiNhanh = @maChiNhanh, maNhaCungCap = @maNhaCungCap where maPhieuNhap = @maPhieuNhap

exec Update_PhieuNhap @maPhieuNhap , @ngayNhap , @maChiNhanh , @maNhaCungCap 


go
create or alter proc Delete_PhieuNhap @maPhieuNhap nvarchar(20)
as
	delete PHIEUNHAP where maPhieuNhap = @maPhieuNhap

exec Delete_PhieuNhap @maPhieuNhap 
go
-- Phu tung
create or alter proc List_PhuTung
as
	select * from PHUTUNG
exec List_PhuTung

go
create or alter proc Insert_PhuTung @loaiPhuTung nvarchar(50), @tenPhuTung nvarchar(50), @thuongHieu nvarchar(50), @xuatXu nvarchar(50), @giaBan float, @chatLuong nvarchar(50), @hinhAnh nvarchar(200)
as
	insert into PHUTUNG(loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh) values (@loaiPhuTung, @tenPhuTung, @thuongHieu, @xuatXu, @giaBan, @chatLuong, @hinhAnh)

exec Insert_PhuTung @loaiPhuTung , @tenPhuTung , @thuongHieu , @xuatXu , @giaBan , @chatLuong , @hinhAnh 


go
create or alter proc Update_PhuTung @maPhuTung nvarchar(20), @loaiPhuTung nvarchar(50), @tenPhuTung nvarchar(50), @thuongHieu nvarchar(50), @xuatXu nvarchar(50), @giaBan float, @chatLuong nvarchar(50), @hinhAnh nvarchar(200)
as
	Update PHUTUNG set loaiPhuTung = @loaiPhuTung, tenPhuTung = @tenPhuTung, thuongHieu = @thuongHieu, xuatXu = @xuatXu, giaBan = @giaBan, chatLuong = @chatLuong, hinhAnh = @hinhAnh where maPhuTung = @maPhuTung

exec Update_PhuTung @maPhuTung , @loaiPhuTung , @tenPhuTung , @thuongHieu , @xuatXu , @giaBan , @chatLuong , @hinhAnh 

go
create or alter proc Delete_PhuTung @maPhuTung nvarchar(20)
as
	delete PHUTUNG where maPhuTung = @maPhuTung
go
exec Delete_PhuTung @maPhuTung 

--

begin tran
	insert into NHANVIEN 
	(hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, 
	soDienThoai, chucVu, tinhTrangLamViec, maChiNhanh, hinhAnh) 
	values (N'{1}', '{2}', '2003-08-10', N'{4}', N'{5}', '{6}', N'{7}', 1, 'CNHN', '{10}')

	select * from NHANVIEN
rollback

--------------
-- Nhan Vien
go
create or alter proc List_TimKiemNhanVienTheoMaChiNhanh @maChiNhanh nvarchar(20)
as
	select * from NhanVien where maChiNhanh = @maChiNhanh

exec List_TimKiemNhanVienTheoMaChiNhanh @maChiNhanh

go
create or alter proc List_NhanVien 
as
	select * from NHANVIEN

exec List_NhanVien


go
create or alter proc Insert_NhanVien 
(
@hoTenNhanVien nvarchar(50), @CCCD nvarchar(20), 
@ngaySinh date, @gioiTinh nvarchar(5), @diaChi nvarchar(255), @soDienThoai nvarchar(20), 
@chucVu nvarchar(50), @tinhTrangLamViec bit, @maChiNhanh nvarchar(20), @hinhAnh nvarchar(200)
)
as
begin
	begin try
		insert into NHANVIEN 
		(hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, 
		chucVu, tinhTrangLamViec, maChiNhanh, hinhAnh) 
		values (@hoTenNhanVien, @CCCD, @ngaySinh, @gioiTinh, @diaChi, 
		@soDienThoai, @chucVu, @tinhTrangLamViec, @maChiNhanh, @hinhAnh)
	end try

	begin catch
		DECLARE @errorMessage NVARCHAR(4000)
		SET @errorMessage = ERROR_MESSAGE();
		IF @errorMessage LIKE '%contr_NHANVIEN_checkLenSDT%'
			RAISERROR(N'SĐT phải có 10 hoặc 11 chữ số', 16, 1)
		ELSE IF @errorMessage LIKE '%contr_NhanVien_checkLenCCCD%'
			RAISERROR(N'CCCD phải có 12 chữ số', 16, 1)
		ELSE IF @errorMessage LIKE '%contr_NhanVien_conflictCCCD%'
			RAISERROR(N'CCCD bị trùng với nhân viên khác', 16, 1)
		ELSE IF @errorMessage LIKE '%contr_NhanVien_conflictSDT%'
			RAISERROR(N'SĐT bị trùng với nhân viên khác', 16, 1)
	end catch

end

begin tran
--select * from NHANVIEN
exec Insert_NhanVien 'a', '111111111111', '2003-08-10', 'Nam', '', '079398850', '', 1, 'CNHN', ''
rollback


create or alter proc Update_NhanVien @maNhanVien nvarchar(20), @hoTenNhanVien nvarchar(50), @CCCD nvarchar(20), @ngaySinh date, @gioiTinh nvarchar(5), @diaChi nvarchar(255, @soDienThoai nvarchar(20), @chucVu nvarchar(50), @tinhTrangLamViec bit, @maChiNhanh nvarchar(20), @hinhAnh nvarchar(200)
as
	update NHANVIEN set hoTenNhanVien = @hoTenNhanVien, CCCD = @CCCD, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, diaChi = @diaChi, soDienThoai = @soDienThoai, chucVu = @chucVu, tinhTrangLamViec = @tinhTrangLamViec, maChiNhanh = @maChiNhanh, hinhAnh = @hinhAnh where maNhanVien = @maNhanVien

exec Update_NhanVien @maNhanVien, @hoTenNhanVien, @CCCD, @ngaySinh, @gioiTinh, @diaChi, @soDienThoai, @chucVu, @tinhTrangLamViec, @maChiNhanh, @hinhAnh
go

create or alter proc Delete_NhanVien @maNhanVien nvarchar(20)
as
	delete NHANVIEN where maNhanVien = @maNhanVien

exec Delete_NhanVien @maNhanVien



create or alter proc TimKiemNhanVien @maNhanVien nvarchar(20), @hoTenNhanVien nvarchar(50), @CCCD nvarchar(20), @ngaySinh date, @gioiTinh nvarchar(5), @diaChi nvarchar(255, @soDienThoai nvarchar(20), @chucVu nvarchar(50), @tinhTrangLamViec bit, @maChiNhanh nvarchar(20), @hinhAnh nvarchar(200)
as
	select * from NHANVIEN where hoTenNhanVien like N'%{0}%' and CCCD like N'%{1}%' and diaChi like N'%{2}%' and soDienThoai like N'%{3}%' and chucVu like N'%{4}%' and maChiNhanh like N'%{5}%'

go
create or alter proc sp_TaoChiTietHoaDonPhuTung @maHoaDon nvarchar(20), @maPhuTung nvarchar(20)
as 
begin
	DECLARE @maChiTietHoaDonPhuTung NVARCHAR(20)
    DECLARE @soTienDaTra float -- Change the data type as needed

    -- Generate the maChiTietHoaDonPhuTung using the dbo.fn_SinhMaChiTietHoaDonPhuTung() function
    SET @maChiTietHoaDonPhuTung = dbo.fn_SinhMaChiTietHoaDonPhuTung()

    -- Set the value for soTienDaTra (you may want to adjust this)
    SET @soTienDaTra = 0 -- Change this value as needed
	insert into CHITIETHOADONPHUTUNG(maChiTietHoaDonPhuTung, maHoaDon, maPhuTung, soTienDaTra) values (@maChiTietHoaDonPhuTung, @maHoaDon, @maPhuTung, @soTienDaTra)
end

begin tran
	exec sp_TaoChiTietHoaDonPhuTung 'HD001', 'PT007'
	select * from CHITIETHOADONPHUTUNG
	rollback

go
create or alter proc sp_TaoChiTietHoaDonXe @maHoaDon nvarchar(20), @maXe nvarchar(20), @ngayNhanXe date
as 
begin
	
    DECLARE @soTienDaTra float
	DECLARE @phiDangKyBienSo float 
	declare @phiDangKiem float 
	declare @phiTruocBa float
	declare @phiBaoHiemTrachNhiemDanSu float
	declare @phiSuDungDuongBo float


	SET @phiTruocBa = dbo.fn_checkPhiTruocBa(@maXe)
	set @phiDangKyBienSo = dbo.fn_checkPhiCapBienSo(@maXe)
	set @phiDangKiem = 250000
	set @phiBaoHiemTrachNhiemDanSu = 437000
	set @phiSuDungDuongBo = 1430000
	set @soTienDaTra = 0


    -- Set the value for soTienDaTra (you may want to adjust this)
    SET @soTienDaTra = 0 -- Change this value as needed
	insert into CHITIETHOADONXE( maHoaDon, maXe, ngayNhanXe, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo) 
	values ( @maHoaDon, @maXe, @ngayNhanXe, @soTienDaTra, @phiDangKyBienSo, @phiDangKiem, @phiTruocBa, @phiBaoHiemTrachNhiemDanSu, @phiSuDungDuongBo)
end

begin tran
	exec sp_TaoChiTietHoaDonXe 'HD004', 'LOXE005_XE002', '2023-11-11'
	select * from CHITIETHOADONXE
	rollback

create or alter proc List_LoXe
as 
	select * from LOXE
exec List_LoXe


create or alter proc Insert_LoXe @maLoXe nvarchar(20), @tenXe nvarchar(50), @mauSac nvarchar(20), @giaBan float, @soChoNgoi int, @xuatXu nvarchar(50), @hangXe nvarchar(50), @loaiXe nvarchar(50), @phienBanXe nvarchar(50),
		@tocDoToiDa int, @trongLuong int, @trongTai int, @loaiNhienLieu nvarchar(50), @congSuatDongCo int, @dungTichDongCo int, @loaiDongCo nvarchar(50), @khoangSangGam int, @chieuDaiCoSo int, @chieuDai int, @chieuRong int, @chieuCao int, @banKinhQuayVong int, @hinhAnh nvarchar(200)
as 
	insert into LOXE (maLoXe, tenXe, mauSac, giaBan, soChoNgoi, xuatXu, hangXe, loaiXe, phienBanXe, tocDoToiDa, trongLuong, trongTai,
             loaiNhienLieu, congSuatDongCo, dungTichDongCo, loaiDongCo, khoangSangGam, chieuDaiCoSo, chieuDai, chieuRong, chieuCao, banKinhQuayVong, hinhAnh) 
			 values (@maLoXe, @tenXe, @mauSac, @giaBan, @soChoNgoi, @xuatXu, @hangXe, @loaiXe, @phienBanXe, @tocDoToiDa, @trongLuong, @trongTai,
             @loaiNhienLieu, @congSuatDongCo, @dungTichDongCo, @loaiDongCo, @khoangSangGam, @chieuDaiCoSo, @chieuDai, @chieuRong, @chieuCao, @banKinhQuayVong, @hinhAnh)

exec Insert_LoXe @maLoXe, @tenXe, @mauSac, @giaBan, @soChoNgoi, @xuatXu, @hangXe, @loaiXe, @phienBanXe, @tocDoToiDa, @trongLuong, @trongTai,
             @loaiNhienLieu, @congSuatDongCo, @dungTichDongCo, @loaiDongCo, @khoangSangGam, @chieuDaiCoSo, @chieuDai, @chieuRong, @chieuCao, @banKinhQuayVong, @hinhAnh



create or alter proc Update_LoXe @maLoXe nvarchar(20), @tenXe nvarchar(50), @mauSac nvarchar(20), @giaBan float, @soChoNgoi int, @xuatXu nvarchar(50), @hangXe nvarchar(50), @loaiXe nvarchar(50), @phienBanXe nvarchar(50),
		@tocDoToiDa int, @trongLuong int, @trongTai int, @loaiNhienLieu nvarchar(50), @congSuatDongCo int, @dungTichDongCo int, @loaiDongCo nvarchar(50), @khoangSangGam int, @chieuDaiCoSo int, @chieuDai int, @chieuRong int, @chieuCao int, @banKinhQuayVong int, @hinhAnh nvarchar(200)
as 
	update LOXE set tenXe = @tenXe, mauSac = @mauSac, giaBan = @giaBan, soChoNgoi = @soChoNgoi, xuatXu = @xuatXu, hangXe = @hangXe, loaiXe = @loaiXe, phienBanXe = @phienBanXe, tocDoToiDa = @tocDoToiDa, trongLuong = @trongLuong, trongTai = @trongTai,
            loaiNhienLieu = @loaiNhienLieu, congSuatDongCo = @congSuatDongCo, dungTichDongCo = @dungTichDongCo, loaiDongCo = @loaiDongCo, khoangSangGam = @khoangSangGam, chieuDaiCoSo = @chieuDaiCoSo, chieuDai = @chieuDai, chieuRong = @chieuRong, chieuCao = @chieuCao, banKinhQuayVong = @banKinhQuayVong, hinhAnh = @hinhAnh
			where maLoXe = @maLoXe

exec Update_LoXe @maLoXe, @tenXe, @mauSac, @giaBan, @soChoNgoi, @xuatXu, @hangXe, @loaiXe, @phienBanXe, @tocDoToiDa, @trongLuong, @trongTai,
             @loaiNhienLieu, @congSuatDongCo, @dungTichDongCo, @loaiDongCo, @khoangSangGam, @chieuDaiCoSo, @chieuDai, @chieuRong, @chieuCao, @banKinhQuayVong, @hinhAnh


create or alter proc Delete_LoXe @maLoXe nvarchar(20)
as
	delete LOXE where maLoXe = @maLoXe

-- Procedure xóa nhân viên
create or alter proc sp_XoaNhanVien @maNhanVien nvarchar(20)
as 
begin
	EXEC('USE DBMS_DOAN_QUANLYCUAHANGXE;
              EXEC sp_dropuser ' + @maNhanVien)
	EXEC('USE DBMS_DOAN_QUANLYCUAHANGXE;
              EXEC sp_droplogin ' + @maNhanVien)
	delete nhanvien where maNhanVien = @maNhanVien
	delete TAIKHOAN WHERE maNhanVien = @maNhanVien
end

create or alter proc sp_InsertNhanVien(@maNhanVien nvarchar(20), hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, maChiNhanh, hinhAnh