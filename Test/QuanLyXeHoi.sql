create database QUANLYXEHOI
go
use QUANLYXEHOI
go
create table MATHANG(
	MaMH nvarchar(50) primary key,
	TenMH nvarchar(50),
	HangSX nvarchar(50),
	GiaNhap money check (GiaNhap > 0),
	DonGia money check (DonGia > 0),
);
go
create table PHUTUNG(
	MaPT nvarchar(50) primary key,
	LoaiPT nvarchar (50),
	ChatLuong nvarchar (50),
	foreign key (MaPT) references MATHANG(MaMH) on delete cascade,
);
go
create table XE(
	MaXe nvarchar(50) primary key,
	MauSac nvarchar(50),
	KhoiLuong float,
	DungTichXe nvarchar(50),
	LoaiDongCo nvarchar(50),
	CongSuatToiDa nvarchar(50),
	foreign key (MaXe) references MATHANG(MaMH) on delete cascade,
);
go
create table NHACUNGCAP(
	MaNCC nvarchar(50) primary key,
	TenNCC nvarchar(50),
	DiaChi nvarchar(50),
	SDT nvarchar(20),
);
go
create table KHACHHANG(
	MaKH nvarchar(50) primary key,
	TenKH nvarchar(50),
	SoDT nvarchar(20) unique check (len(SoDT) = 10),
	GioiTinh nvarchar(5),
	CCCD nvarchar(20) unique check (len(CCCD) = 12),
	DiaChi nvarchar(50),
);
create table CHINHANH(
	MaCN nvarchar(50) primary key,
	TenCN nvarchar(50),
	DiaChi nvarchar(100),
);
go
create table NHANVIEN(
	MaNV nvarchar(50) primary key,
	TenNV nvarchar(50),
	NgaySinh date,
	DiaChi nvarchar(50),
	SoDT nvarchar(20) unique check (len(SoDT) = 10),
	GioiTinh nvarchar(5) check (GioiTinh = N'Nam' OR GioiTinh = N'Nữ'),
	CCCD nvarchar(20) unique check (len(CCCD) = 12),
	ChucVu nvarchar(50),
	MaCN nvarchar(50),
	TinhTrangLamViec bit default 1,
	Luong money,
	foreign key (MaCN) references CHINHANH(MaCN),
);
go
create table BAODUONG(
	MaBD nvarchar(50) primary key,
	TenBD nvarchar(50),
	PhiBD money check (PhiBD > 0),
	ThongTinBD nvarchar(50),
);
go
create table HOADON(
	MaHD nvarchar(50) PRIMARY KEY,
	NgayLap date not null check (DATEDIFF(day, NgayLap, GETDATE())>=0),
	ThanhTien money default 0,
	MaNVThuNgan nvarchar(50) ,
	MaKH nvarchar(50),
    FOREIGN KEY (MaNVThuNgan) REFERENCES NHANVIEN(MaNV),
    FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)
);

go
CREATE TABLE CHITIETHOADON 
(
	MaHD nvarchar(50) not null,
	MaMH nvarchar(50) null,
	MaBD nvarchar(50) null,
	SoLuong int default 1 check(SoLuong>=0),
	MaNVBaoDuong nvarchar(50) null,
	unique (MaHD,MaMH,MaBD) ,
       FOREIGN KEY (MaHD) REFERENCES HOADON(MaHD) ON DELETE CASCADE,
       FOREIGN KEY (MaMH) REFERENCES MATHANG(MaMH),
	FOREIGN KEY (MaBD) REFERENCES BAODUONG(MaBD),
	FOREIGN KEY (MaNVBaoDuong) REFERENCES NHANVIEN(MaNV) 
);
go
CREATE TABLE PHIEUNHAP 
(
	MaPN nvarchar(50) PRIMARY KEY,
	NgayNhap date check (DATEDIFF(day, NgayNhap, GETDATE())>=0),
	ThanhTien money default 0,
	MaNVKho nvarchar(50),
	MaNCC nvarchar(50) ,
       FOREIGN KEY (MaNVKho) REFERENCES NHANVIEN(MaNV),
       FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC),
);
go
CREATE TABLE CHITIETPHIEUNHAP 
(
	MaPN nvarchar(50),
	MaMH nvarchar(50) ,
	SoLuong int check (SoLuong>=0) default 0,
	PRIMARY KEY (MaPN, MaMH),
       FOREIGN KEY (MaPN) REFERENCES PHIEUNHAP(MaPN) ON DELETE CASCADE,
       FOREIGN KEY (MaMH) REFERENCES MATHANG(MaMH),
);
go
CREATE TABLE KHO
(
	MaCN nvarchar(50),
	MaMH nvarchar(50),
	SoLuong int check (SoLuong>=0) default 0,
	PRIMARY KEY (MaCN, MaMH),
       FOREIGN KEY (MaCN) REFERENCES CHINHANH(MaCN),
       FOREIGN KEY (MaMH) REFERENCES MATHANG(MaMH)  ON DELETE CASCADE
);