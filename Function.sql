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
--Xem danh sach xe co xuat xu Nhat Ban
create or alter view v_XeXuatXuNhatBan as
select maXe, tenXe, giaBan, soChoNgoi,loaiXe, loaiDongCo, loaiNhienLieu
from Xe where xuatXu = 'Nhật Bản'

select * from v_XeXuatXuNhatBan

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

-- Tạo TRIGGER khi thêm nhân viên thì tài khoản tự động thêm
create or alter trigger trg_ThemTaiKhoan
on NHANVIEN
for insert
as
begin
	declare @taiKhoan nvarchar(20), @chucVu nvarchar(50)
	select @taiKhoan = maNhanVien, @chucVu = chucVu from inserted
	insert into TAIKHOAN values (@taiKhoan, '1', @chucVu)
end
go

-- Test
begin tran
	INSERT INTO CHINHANH (maChiNhanh, tenChiNhanh, diaChi)
	VALUES ('CN001', N'Chi nhánh A', N'123 Đường A, Quận 1, TP.HCM')
	INSERT INTO NHANVIEN (maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, maChiNhanh)
	VALUES ('NV001', N'Nguyễn Văn A', '123456789012', '1990-05-15', N'Nam', N'123 Đường X, Quận Y, TP.HCM', '0123456789', N'Quản lý', 'CN001')
	select * from TaiKhoan
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
	set tenDangNhap = @taiKhoanMoi
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

--