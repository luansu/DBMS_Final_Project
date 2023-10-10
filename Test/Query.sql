use QUANLYXEHOI
go

insert into MATHANG(MaMH, TenMH, HangSX, GiaNhap, DonGia)
values ('MH_001', N'Wave', N'Honda', 5000000, 11000000),
		('MH_002', N'Lốp xe', N'Suzuki', 500000, 20000000),
		('MH_003', N'Lamborghini Urus', N'Lamborghini', 5000000, 11000000),
		('MH_004', N'Bugi NGK', N'Honda', 625000, 750000),
		('MH_005', N'Vision', N'Honda', 32000000, 35000000),
		('MH_006', N'Bugi Cisco', N'Honda', 5000000, 10000000)

insert into PHUTUNG(MaPT, LoaiPT, ChatLuong) 
values ('MH_002', N'Lốp', N'Tốt'),
		('MH_004', N'Linh kiện', N'Siêu bền'),
		('MH_006', N'Linh kiện', N'Chịu nhiệt tốt')

insert into XE (MaXe, MauSac, KhoiLuong, DungTichXe, LoaiDongCo, CongSuatToiDa)
values ('MH_003', N'Đỏ', N'2197', N'1596 Lít', N'V8 3.9L', N'650 HP'),
		('MH_001', N'Đen', N'150', N'300 Lít', N'V8 1.9L', N'200 HP'),
		('MH_005', N'Đỏ', N'239', N'350 Lít', N'V9 2.9L', N'300 HP')

insert into NHACUNGCAP(MaNCC, TenNCC, DiaChi, SDT)
values ('NCC_01', N'DaThung', N'Số 1 Võ Văn Ngân - Linh Chiểu - Thủ Đức - Tp.HCM', N'0912345678'),
		('NCC_02', N'XuanThe', N'71 Tân Lập 1 - Hiệp Phú - Thủ Đức - Tp.HCM', N'0912345678'),
		('NCC_03', N'LuanSu', N'484A Lê Văn Việt - Hiệp Phú - Thủ Đức - Tp.HCM', N'0912345678'),
		('NCC_04', N'VietKhoa', N'365A Lê Văn Chí - Linh Chiểu - Thủ Đức - Tp.HCM', N'0912345678')

insert into KHACHHANG (MaKH, TenKH, SoDT, GioiTinh, CCCD, DiaChi)
values ('KH_001', N'Lament_H', '0987654321', N'Nữ', '098765123543', N'309/45 Võ Văn Ngân - Linh Chiểu - Thủ Đức'),
		('KH_002', N'K3 NoPro', '0123456789', N'Nam', '098745361234', N'483 Lê Văn Việt - Hiệp Phú - Thủ Đức')

insert into CHINHANH(MaCN, TenCN, DiaChi)
values ('CN_001', N'ISUZU Việt Nam - Viet Nam Auto', N'916 Quang Trung, Phường 8, Quận Gò Vấp, Tp. Hồ Chí Minh'),
		('CN_002', N'Công Ty TNHH Ô Tô ISUZU Đạt Tấn Phát', N'Số 795, KP. 4, Xa lộ Hà Nội, P. Long Bình, TP. Biên Hòa, Đồng Nai'),
		('CN_003', N'KMC - Công Ty TNHH Khang Minh', N'KM 9, Cao Tốc Bắc Thăng Long, Nội Bài, Mê Linh, Hà Nội'),
		('CN_004', N'CN Lái Thiêu - Công Ty TNHH Cơ Khí Ô Tô Lê Anh', N'KP. Hòa Long, P. Lái Thiêu, TX. Thuận An, Bình Dương'),
		('CN_005', N'Công Ty TNHH MTV Kinh Doanh Ô Tô Thăng Long', N'Số 105 Láng Hạ, P. Láng Hạ, Q. Đống Đa, Hà Nội'),
		('CN_006', N'Công Ty TNHH Việt Nam SUZUKI', N'Đường Số 2, KCN Long Bình, P. Long Bình, TP. Biên Hòa, Đồng Nai'),
		('CN_007', N'Công Ty CP Ô Tô Đô Thành', N'QL 51, ấp Đất Mới, Long Phước, Long Thành, Đồng Nai'),
		('CN_008', N'Công Ty TNHH Mercedes- Benz Việt Nam', N'Số 693, Đường Quang Trung, P. 8, Q. Gò Vấp, Tp. Hồ Chí Minh (TPHCM)'),
		('CN_009', N'Công Ty TNHH Ô Tô Mitsubishi Việt Nam', N'Tầng 6, Tòa Nhà Pearl Plaza, 561A Điện Biên Phủ, Q. Bình Thạnh, TPHCM'),
		('CN_010', N'Toyota Thăng Long', N'316 Cầu Giấy, P. Dịch Vọng, Q. Cầu Giấy, Hà Nội')

insert into NHANVIEN(MaNV, TenNV, NgaySinh, DiaChi, SoDT, GioiTinh, CCCD, ChucVu, MaCN, TinhTrangLamViec, Luong)
values ('NV_001', N'Lan Anh', '2003-05-21', N'71 Tân Lập 1 - Hiệp Phú - Thủ Đức - Tp.HCM', '0987123456', N'Nữ', '057692831023', N'Thu ngân', 'CN_001', 1, 50000000),
		('NV_002', N'Phương Nghi', '2003-09-05', N'KP.Hòa Long, P.Lái Thiêu, TX.Thuận An, Bình Dương', '0912645737', N'Nữ', '038573652349', N'Quản Lý Nhân Viên', 'CN_002', 1, 100000000),
		('NV_003',N'Phương Ninh', '2003-01-06', N'Số 105 Láng Hạ, P. Láng Hạ, Q. Đống Đa, Hà Nội', N'0983751237', N'Nữ', N'056547891023', N'Bảo dưỡng', 'CN_003', 1, 7000000),
		('NV_004',N'ABC', '2003-02-27', N'QL 51, Đất Mới, Long Phước, Long Thành, Đồng Nai', N'0987461458', N'Nữ', N'098723431023', N'Tư vấn', 'CN_004', 1, 7000000),
		('NV_005',N'XYZ', '2003-02-27', N'QL 51, Đất Mới, Long Phước, Long Thành, Đồng Nai', N'0987645789', N'Nữ', N'098223131023', N'Nhân viên kho', 'CN_005', 1, 9000000)

insert into BAODUONG(MaBD, TenBD, PhiBD, ThongTinBD)
values ('BD_001', N'Bảo dưỡng cấp 1', '9000000', N'Thay dầu động cơ'),
		('BD_002', N'Bảo dưỡng cấp 1', '1300000', N'Kiểm tra hệ thống còi xe, đèn xe, lốp xe'),
		('BD_003', N'Bảo dưỡng cấp 2', '1500000', N'Vệ sinh lọc gió động cơ'),
		('BD_004', N'Bảo dưỡng cấp 2', '2500000', N'Kiểm tra, bảo dưỡng phanh trước/sau'),
		('BD_005', N'Bảo dưỡng cấp 3', '3000000', N'Vệ sinh bugi'),
		('BD_006', N'Bảo dưỡng cấp 3', '4000000', N'Thay lọc gió động cơ' ),
		('BD_007', N'Bảo dưỡng cấp 4', '800000', N'Thay lọc nhiên liệu' ),
		('BD_008', N'Bảo dưỡng cấp 4', '10000000', N'Thay dầu hộp số' ),
		('BD_009', N'Bảo dưỡng cấp cao', '12000000', N'Kiểm tra các dây đai trên động cơ' ),
		('BD_010', N'Bảo dưỡng cấp cao', '15000000', N'Kiểm tra điều chỉnh tốc độ không tải' )

insert into HOADON(MaHD, NgayLap, ThanhTien, MaNVThuNgan, MaKH)
values ('HD_001', '2023-09-12', 15000000, 'NV_001', 'KH_001'),
		('HD_002', '2023-09-11', 12000000, 'NV_001', 'KH_002')

insert into CHITIETHOADON(MaHD, MaMH, MaBD, SoLuong, MaNVBaoDuong)
values ('HD_001', 'MH_003', null, 1, null),
		('HD_002', null, 'BD_009', 1, 'NV_003')

insert into PHIEUNHAP(MaPN, NgayNhap, ThanhTien, MaNVKho, MaNCC)
values ('PN_001', '2003-08-10', 20000000, 'NV_005', 'NCC_01'),
		('PN_002', '2003-09-12', 15000000, 'NV_005', 'NCC_02'),
		('PN_003', '2003-09-10', 30000000, 'NV_005', 'NCC_03')

insert into CHITIETPHIEUNHAP(MaPN, MaMH, SoLuong)
values ('PN_001', 'MH_001', 10),
		('PN_001', 'MH_003', 5),
		('PN_001', 'MH_005', 7),
		('PN_002', 'MH_002', 20),
		('PN_002', 'MH_004', 15),
		('PN_002', 'MH_006', 25)

insert into KHO(MaCN, MaMH, SoLuong)
values ('CN_001', 'MH_001', 10),
		('CN_002', 'MH_002', 20),
		('CN_003', 'MH_003', 5),
		('CN_004', 'MH_004', 15),
		('CN_005', 'MH_005', 7),
		('CN_006', 'MH_006', 25)

select * from MATHANG
select * from PHUTUNG
select * from XE
select * from NHACUNGCAP
select * from KHACHHANG
select * from CHINHANH
select * from NHANVIEN
select * from BAODUONG
select * from HOADON
select * from CHITIETHOADON
select * from PHIEUNHAP
select * from CHITIETPHIEUNHAP
select * from KHO