﻿--Xem danh sách nhan viên còn làm việc
use DBMS_DOAN_QUANLYCUAHANGXE
go
CREATE VIEW v_DSNhanVienConLamViec as
SELECT hotenNhanVien, CCCD, ngaySinh, gioiTinh, soDienThoai
FROM NHANVIEN as nv
WHERE nv.tinhTrangLamViec = 1
go 
--Xem danh sách chi nhánh
CREATE VIEW v_DSChiNhanh as
SELECT * 
FROM CHINHANH
go
--Xen danh sách nhà cung cấp
CREATE VIEW v_DSNhaCungCap as
SELECT *
FROM NHACUNGCAP
go
--Xem danh sách Xe
CREATE VIEW v_DSXeConTrongKho as
SELECT maXe, tenXe, mauSac, soChoNgoi, xuatXu, hangXe, loaiXe, phienBanXe, pn.soLuong
FROM XE, PHIEUNHAP as pn
WHERE pn.soLuong > 0
go

--View xem số xe đã bán theo chi nhánh
CREATE or ALTER VIEW v_SoXeDaBan as
SELECT cn.maChiNhanh, cn.maXe, CASE WHEN hd.daBan IS NULL 
										THEN 0 
									ELSE hd.daBan END AS daBan
FROM (SELECT distinct cn.maChiNhanh, x.maXe
		FROM CHINHANH as cn, PHIEUNHAP as pn, CHITIETPHIEUNHAPXE as pnx, XE as x
		WHERE cn.maChiNhanh = pn.maChiNhanh and pn.maPhieuNhap = pnx.maPhieuNhap and pnx.maXe = x.maXe) as cn LEFT OUTER JOIN (SELECT cn.maChiNhanh, hdx.maXe, count(*) daBan
																																FROM NHANVIEN as nv, CHINHANH as cn, HOADON as hd, CHITIETHOADONXE as hdx 
																																WHERE nv.maChiNhanh = cn.maChiNhanh and hd.maNhanVienThucHien = nv.maNhanVien and hd.maHoaDon = hdx.maHoaDon 
																																GROUP BY cn.maChiNhanh, hdx.maXe) as hd 
on hd.maChiNhanh = cn.maChiNhanh and hd.maXe = cn.maXe
go

select * from v_SoXeDaBan

--Xem danh sach xe theo từng chi nhánh
CREATE or AlTER VIEW v_KhoXeTheoChiNhanh as
SELECT distinct cn.maChiNhanh, cn.maXe, (cn.soLuong - hd.daBan) as Conlai
FROM (SELECT pn.maChiNhanh, ctpn.maXe, sum(ctpn.soLuong) as soLuong 
FROM PHIEUNHAP as pn, CHITIETPHIEUNHAPXE as ctpn
WHERE pn.maPhieuNhap = ctpn.maPhieuNhap
GROUP BY pn.maChiNhanh, ctpn.maXe) as cn, v_SoXeDaBan as hd
WHERE cn.maChiNhanh = hd.maChiNhanh and cn.maXe = hd.maXe

select * from v_KhoXeTheoChiNhanh

--Xem danh sach nhan vien co chuc vu la quan ly
CREATE or alter VIEW v_NhanVienQuanLy as
select nv.maNhanVien, nv.hoTenNhanVien, nv.soDienThoai, cn.maChiNhanh, cn.tenChiNhanh
from NHANVIEN as nv, CHINHANH as cn
where nv.maChiNhanh = cn.maChiNhanh and nv.chucVu = 'Quản lý'



delete NhanVien where maChiNhanh = 'CNHN'
delete Chinhanh where maChinhanh = 'CNHN'

select * from v_NhanVienQuanLy
--Xem danh sach xe co xuat xu Nhat Ban
create or alter view v_XeXuatXuNhatBan as
select maXe, tenXe, giaBan, soChoNgoi,loaiXe, loaiDongCo, loaiNhienLieu
from Xe where xuatXu = 'Nhật Bản'

select * from v_XeXuatXuNhatBan

go
-- Tạo TRIGGER khi thêm nhân viên thì tài khoản tự động thêm
-- Set Tên đăng nhập mặc định là mã nhân viên
create or alter trigger trg_ThemTaiKhoan
on NHANVIEN
for insert
as
begin
	declare @taiKhoan nvarchar(20), @chucVu nvarchar(50)
	select @taiKhoan = maNhanVien, @chucVu = chucVu from inserted
	insert into TAIKHOAN values (@taiKhoan, '1', @chucVu, @taiKhoan)
end
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

