--drop database DBMS_DOAN_QUANLYCUAHANGXE
create database DBMS_DOAN_QUANLYCUAHANGXE
go
use DBMS_DOAN_QUANLYCUAHANGXE
go

-- Tạo bảng chi nhánh
create table CHINHANH(
	maChiNhanh nvarchar(20) primary key,
	tenChiNhanh nvarchar(50) not null,
	diaChi nvarchar(255) not null,
)
go

-- Tạo bảng nhân viên 
-- => Trigger kiểm tra NHÂN VIÊN: CCCD là số, >=18 tuổi
create table NHANVIEN( 
	maNhanVien nvarchar(20) primary key,
	hoTenNhanVien nvarchar(50) not null,
	CCCD nvarchar(20) check (len(CCCD) = 12) unique,
	ngaySinh date check (DateDiff(year, ngaySinh, GetDate()) >= 18),
	gioiTinh nvarchar(5),
	diaChi nvarchar(255),
	soDienThoai nvarchar(20) check (len(soDienThoai) = 10 or len(soDienThoai) = 11) unique,
	chucVu nvarchar(50),
	tinhTrangLamViec bit default 1,
	maChiNhanh nvarchar(20),
	hinhAnh nvarchar(200)
	foreign key (maChiNhanh) references CHINHANH(maChiNhanh)
)
go

-- Tạo bảng Tài khoản
create table TAIKHOAN(
	tenDangNhap nvarchar(20) primary key,	
	matKhau nvarchar(50) not null,
	chucVu nvarchar(50),
	maNhanVien nvarchar(20),
	foreign key (maNhanVien) references NHANVIEN(maNhanVien)
	on delete cascade -- Nhân viên xóa thì tải khoản cũng sẽ xóa
	on update cascade -- Nhân viên đổi mã thì tài khoản cũng đổi theo
)
go

-- Tạo bảng NHÀ CUNG CẤP
create table NHACUNGCAP(
	maNhaCungCap nvarchar(20) primary key,
	tenNhaCungCap nvarchar(50) not null,
	diaChi nvarchar(255) not null,
	soDienThoai nvarchar(20) check (len(soDienThoai) = 10 or len(soDienThoai) = 11),
)
go

-- Tạo bảng LÔ XE
create table LOXE(
	maLoXe nvarchar(20) primary key,
	tenXe nvarchar(50), 
	mauSac nvarchar(20), 
	giaBan money check (giaBan > 0), 
	soChoNgoi integer check (soChoNgoi >= 2) default 4, 
	xuatXu nvarchar(50), 
	hangXe nvarchar(50), 
	loaiXe nvarchar(50), 
	phienBanXe nvarchar(50),
	tocDoToiDa integer check (tocDoToiDa > 0), 
	trongLuong integer check (trongLuong > 0),
	trongTai integer check (trongTai > 0),
	canhBaoPhuongTien nvarchar(50), 
	canhBaoDiemMu nvarchar(50), 
	tuiKhi nvarchar(50), 
	mocGheAnToan nvarchar(50), 
	camBienLui nvarchar(50), 
	cameraLui nvarchar(50), 
	phanhSau nvarchar(50), 
	phanhTruoc nvarchar(50), 
	boTruyenLuc nvarchar(50), 
	boDieuKhien nvarchar(50), 
	loaiNhienLieu nvarchar(50), 
	congSuatDongCo integer check (congSuatDongCo > 0), 
	dungTichDongCo integer check (dungTichDongCo > 0), 
	loaiDongCo nvarchar(50), 
	momenXoan integer check (momenXoan > 0), 
	khoanSangGam integer check (khoanSangGam > 0), 
	chieuDaiCoSo integer check (chieuDaiCoSo > 0), 
	chieuDai integer check (chieuDai > 0), 
	chieuRong integer check (chieuRong > 0), 
	chieuCao integer check (chieuCao > 0), 
	banKinhQuayVong integer check (banKinhQuayVong > 0),
	hinhAnh nvarchar(200)
)

-- Tạo bảng XE
CREATE TABLE XE(
	maXe nvarchar(20) primary key, 
	maLoXe nvarchar(20)
	foreign key (maLoXe) references LOXE(maLoXe)
)
go

-- Tạo bảng PHỤ TÙNG
CREATE TABLE PHUTUNG(
	maPhuTung nvarchar(20) primary key, 
	loaiPhuTung nvarchar(50), 
	tenPhuTung nvarchar(50), 
	thuongHieu nvarchar(50),
	xuatXu nvarchar(50), 
	giaBan money check (giaBan > 0), 
	chatLuong nvarchar(50),
	hinhAnh nvarchar(200)
)
go

-- Tạo bảng PHIẾU NHẬP
create table PHIEUNHAP(
	maPhieuNhap nvarchar(20) primary key,
	ngayNhap date default GETDATE(),
	maNhaCungCap nvarchar(20),
	maChiNhanh nvarchar(20),
	foreign key (maNhaCungCap) references NHACUNGCAP(maNhaCungCap),
	foreign key (maChiNhanh) references CHINHANH(maChiNhanh)
)
go

-- Tạo bảng CHI TIẾT PHIẾU NHẬP XE
create table CHITIETPHIEUNHAPXE(
	maChiTietPhieuNhapXe nvarchar(20) primary key,
	maXe nvarchar(20),
	maPhieuNhap nvarchar(20),
	giaNhap money check (giaNhap > 0),
	soLuong integer check(soLuong > 0),
	foreign key (maXe) references XE(maXe),
	foreign key (maPhieuNhap) references PHIEUNHAP(maPhieuNhap)
)
go

-- Tạo bảng CHI TIẾT PHIẾU NHẬP PHỤ TÙNG
create table CHITIETPHIEUNHAPPHUTUNG(
	maChiTietPhieuNhapPhuTung nvarchar(20) primary key,
	maPhuTung nvarchar(20),
	maPhieuNhap nvarchar(20),
	giaNhap money check (giaNhap > 0),
	soLuong integer check(soLuong > 0),
	foreign key (maPhuTung) references PHUTUNG(maPhuTung),
	foreign key (maPhieuNhap) references PHIEUNHAP(maPhieuNhap)
)
go

-- Tạo bảng KHÁCH HÀNG
CREATE TABLE KHACHHANG(
	maKhachHang nvarchar(20) primary key,
	hoTenKhachHang nvarchar(50) not null, 
	ngaySinh date check (DateDiff(year, ngaySinh, GetDate()) >= 18), 
	gioiTinh nvarchar(5), 
	CCCD nvarchar(20) check (len(CCCD) = 12) unique, 
	diaChi nvarchar(255), 
	soDienThoai nvarchar(20) check (len(soDienThoai) = 10 or len(soDienThoai) = 11) unique,
)
go

-- Tạo bảng hóa đơn
create table HOADON(
	maHoaDon nvarchar(20) primary key,
	ngayLapHoaDon nvarchar(50) default GETDATE(),
	tongTien money check (tongTien > 0),
	tinhTrang nvarchar(50) Check (tinhTrang = N'Chưa thanh toán' or tinhTrang = N'Đã thanh toán') default N'Chưa thanh toán',
	maKhachHang nvarchar(20), 
	maNhanVienThucHien nvarchar(20)
	foreign key (maKhachHang) references KHACHHANG(maKhachHang),
	foreign key (maNhanVienThucHien) references NHANVIEN(maNhanVien)
)
go

-- Tạo bảng CHI TIẾT HÓA ĐƠN XE
create table CHITIETHOADONXE(
	maChiTietHoaDonXe nvarchar(20) primary key,
	maHoaDon nvarchar(20), 
	maXe nvarchar(20),
	ngayNhanXe nvarchar(50),
	soTienDaTra money check (soTienDaTra >= 0),
	phiDangKyBienSo money check (phiDangKyBienSo >= 0),
	phiDangKiem money check (phiDangKiem >= 0),
	phiTruocBa money check (phiTruocBa >= 0),
	phiBaoHiemTrachNhiemDanSu money check (phiBaoHiemTrachNhiemDanSu >= 0),
	phiSuDungDuongBo money check (phiSuDungDuongBo >= 0),
	foreign key (maHoaDon) references HOADON(maHoaDon),
	foreign key (maXe) references XE(maXe)
)
go

--Tạo bảng CHI TIẾT HÓA ĐƠN PHỤ TÙNG
create table CHITIETHOADONPHUTUNG(
	maChiTietHoaDonPhuTung nvarchar(20) primary key,
	soTienDaTra money check (soTienDaTra >= 0),
	maHoaDon nvarchar(20), 
	maPhuTung nvarchar(20),
	foreign key (maHoaDon) references HOADON(maHoaDon),
	foreign key (maPhuTung) references PHUTUNG(maPhuTung)
)
go

-- Tạo bảng HỢP ĐỒNG BẢO HÀNH
CREATE TABLE HOPDONGBAOHANH(
	maHopDongBaoHanh nvarchar(20) primary key, 
	maXe nvarchar(20),
	maKhachHang nvarchar(20),
	ngayKyBaoHanh date, 
	thoiHanBaoHanh date, 
	tinhTrang nvarchar(20) check (tinhTrang = N'Còn bảo hành' or tinhTrang = N'Hết hạn'),
	foreign key (maXe) references XE(maXe),
	foreign key (maKhachHang) references KHACHHANG(maKhachHang)
)
go

-- Tạo bảng PHIẾU BẢO HÀNH
CREATE TABLE PHIEUBAOHANH(
	maPhieuBaoHanh nvarchar(20) primary key, 
	maHopDongBaoHanh nvarchar(20),
	maNhanVienThucHien nvarchar(20),
	ngayNhanXe date,
	ngayTraXe date,
	ngayLapPhieu date,
	foreign key (maHopDongBaoHanh) references HOPDONGBAOHANH(maHopDongBaoHanh),
	foreign key (maNhanVienThucHien) references NHANVIEN(maNhanVien)
)
go

-- Tạo bảng DỊCH VỤ BẢO DƯỠNG
CREATE TABLE DICHVUBAODUONG(
	maBaoDuong nvarchar(20) primary key, 
	tenBaoDuong nvarchar(50) not null, 
	loaiBaoDuong nvarchar(50) not null,
	phiBaoDuong money check (phiBaoDuong >= 0),
)
go

-- Tạo bảng PHIẾU BẢO DƯỠNG
CREATE TABLE PHIEUBAODUONG(
	maPhieuBaoDuong nvarchar(20) primary key, 
	ngayLapPhieu date default GetDate(), 
	tongTien money check (tongTien >= 0),
	maKhachHang nvarchar(20), 
	maNhanVienThucHien nvarchar(20), 
	foreign key (maKhachHang) references KHACHHANG(maKhachHang),
	foreign key (maNhanVienThucHien) references NHANVIEN(maNhanVien)
)
go

-- Tạo bảng HÓA ĐƠN BẢO DƯỠNG
create table CHITIETPHIEUBAODUONG(
	maChiTietPhieuBaoDuong nvarchar(20) primary key,
	maBaoDuong nvarchar(20),
	maPhieuBaoDuong nvarchar(20),
	thanhTien money check (thanhTien >= 0),
	foreign key (maBaoDuong) references DICHVUBAODUONG(maBaoDuong),
	foreign key (maPhieuBaoDuong) references PHIEUBAODUONG(maPhieuBaoDuong)
)
go








