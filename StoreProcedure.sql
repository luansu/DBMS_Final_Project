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

