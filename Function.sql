--Xem danh sách nhan viên còn làm việc
use DBMS_DOAN_QUANLYCUAHANGXE
go
CREATE VIEW v_DSNhanVienConLamViec as
SELECT hotenNhanVien, CCCD, ngaySinh, gioiTinh, soDienThoai
FROM NHANVIEN as nv
WHERE nv.tinhTrangLamViec = 1
go 

select * from v_DSNhanVienConLamViec

--Xem danh sách chi nhánh
CREATE VIEW v_DSChiNhanh as
SELECT * 
FROM CHINHANH
go

select * from v_DSChiNhanh
--Xen danh sách nhà cung cấp
CREATE VIEW v_DSNhaCungCap as
SELECT *
FROM NHACUNGCAP
go

select * from v_DSNhaCungCap

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
from Xe where xuatXu = N'Nhật Bản'

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

INSERT INTO NHANVIEN (maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, maChiNhanh, hinhAnh)
VALUES ('NVHN012', 'Nguyễn Văn An', '123456283012', '1990-01-15', N'Nam', '123 Đường Lê Lợi, Hà Nội', '0932345768', 'Quản lý', 'CNHN', ''),

select * from TAIKHOAN
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

CREATE or ALTER TRIGGER tg_ThayDoiTrangThaiHoaDon on CHITIETHOADONXE 
for update, insert as
BEGIN
	DECLARE @soTienDaTra money, @maHoaDon nvarchar(20), @tongTien money
	SELECT @soTienDaTra = ins.soTienDaTra, @maHoaDon = ins.maHoaDon FROM inserted as ins
	SElECT @tongTien = hd.tongTien FROM HOADON as hd WHERE hd.maHoaDon = @maHoaDon
	IF @tongTien <= @soTienDaTra
	BEGIN 
		UPDATE HOADON 
		SET tinhTrang = N'Đã Thanh Toán'
		WHERE maHoaDon = @maHoaDon
	END
END

select * from HOADON
select * from CHITIETHOADONXE

--Trigger Kiểm tra chi nhánh không quá 2 người quản lý
CREATE or ALTER TRIGGER tg_MotQuanLy on NHANVIEN
AFTER UPDATE, INSERT as
BEGIN 
	DECLARE @maChiNhanh nvarchar(20), @chucVu nvarchar(50), @count int, @maNhanVien nvarchar(20)
	SELECT @maChiNhanh = ins.maChiNhanh, @chucVu = ins.chucVu, @maNhanVien = ins.maNhanVien, @count = nv.soluong FROM inserted as ins, (SELECT nv.maChiNhanh, count(nv.maNhanVien) as soluong
																						FROM NHANVIEN as nv 
																						WHERE nv.chucVu = N'Quản lý' 
																						GROUP BY nv.maChiNhanh) as nv
																WHERE ins.maChiNhanh = nv.maChiNhanh
	IF @chucVu = N'Quản lý' and @count > 1
	BEGIN
		PRINT N'Không thể thêm quản lý'
		UPDATE NHANVIEN
		SET chucVu = null
		WHERE maNhanVien = @maNhanVien
	END
END

select * from NHANVIEN

-- Trigger khi nhập lô xe sẽ tự tạo maXe tương ứng
CREATE or ALTER TRIGGER tg_TaoMaXe on CHITIETPHIEUNHAPXE
AFTER INSERT as
BEGIN
	DECLARE @maLoXe nvarchar(20), @soLuong int, @maChiNhanh nvarchar(20)
	SELECT @maLoXe = ins.maLoXe, @soLuong = ins.soLuong, @maChiNhanh = pn.maChiNhanh FROM inserted as ins, PHIEUNHAP as pn
	WHERE pn.maPhieuNhap = ins.maPhieuNhap
	WHILE @soLuong > 0
	BEGIN
		DECLARE @maXe nvarchar(20)
		SET @maXe = CONCAT(@maLoXe,'_', @maChiNhanh, REPLICATE('0', 4-LEN(@soLuong)),str(@soLuong, LEN(@soLuong))) 
		INSERT INTO XE(maXe, maLoXe)
		Values (@maXe, @maLoXe)
		SET @soLuong = @soLuong - 1
	END
END

-- Test
begin tran
	INSERT INTO CHITIETPHIEUNHAPXE (maChiTietPhieuNhapXe, maLoXe, maPhieuNhap, giaNhap, soLuong)
	VALUES ('CTX006', 'LOXE001', 'PN001', 1200000, 10)
	Select * from XE
rollback
go

