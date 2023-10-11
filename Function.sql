--Xem danh sách nhan viên còn làm việc
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

--Xem danh sach xe theo từng chi nhánh
CREATE VIEW v_KhoXeTheoChiNhanh as
SELECT pn.maChiNhanh, ctpn.maXe, sum(ctpn.soLuong) as soLuong 
FROM PHIEUNHAP as pn, CHITIETPHIEUNHAPXE as ctpn 
WHERE pn.maPhieuNhap = ctpn.maPhieuNhap
GROUP BY pn.maChiNhanh, ctpn.maXe

select * from v_KhoXeTheoChiNhanh

--Xem danh sach nhan vien co chuc vu la quan ly
CREATE or alter VIEW v_NhanVienQuanLy as
select nv.maNhanVien, nv.hoTenNhanVien, nv.soDienThoai, cn.maChiNhanh, cn.tenChiNhanh
from NHANVIEN as nv, CHINHANH as cn
where nv.maChiNhanh = cn.maChiNhanh and nv.chucVu = 'Quản lý'

delete NhanVien where maChiNhanh = 'CNHN'
delete Chinhanh where maChinhanh = 'CNHN'

select * from v_NhanVienQuanLy
--Xem 

--TRIGGER
-- Tự động thêm tài khoản khi thêm nhân viên
create or alter trigger tg_UpdateTK on NhanVien
for insert
as
begin
	declare @tenDangNhap nvarchar(20), @chucVu nvarchar(50)
	select @tenDangNhap = maNhanVien, @chucVu = chucVu from inserted
	insert into TAIKHOAN (tenDangNhap, matKhau, chucVu) values (@tenDangNhap, '1234', @chucVu)
end


-- Tự động xóa tài khoản khi xóa nhân viên
create or alter trigger tg_DeleteTK on NhanVien
for delete
as
begin
	declare @tenDangNhap nvarchar(20), @chucVu nvarchar(50)
	select @tenDangNhap = maNhanVien, @chucVu = chucVu from deleted
	delete TAIKHOAN where TAIKHOAN.tenDangNhap = @tenDangNhap
end
