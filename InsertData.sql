go
use DBMS_DOAN_QUANLYCUAHANGXE
go

-- Thêm dữ liệu cho bảng CHI NHÁNH
INSERT INTO CHINHANH (maChiNhanh, tenChiNhanh, diaChi)
VALUES ('CNHN', N'Chi nhánh Hà Nội', N'Số 25, Đường Lê Lợi, Quận Hai Bà Trưng, Hà Nội'),
       ('CNHCM', N'Chi nhánh Hồ Chí Minh', N'456 Đường B, Quận 2, TP.HCM'),
       ('CNHUE', N'Chi nhánh Huế', N'555 Đường Hà Khánh, Thành phố Huế'),
       ('CNCT', N'Chi nhánh Cần Thơ', N'222 Đường Trần Phú, Quận Ninh Kiều, Cần Thơ'),
       ('CNDN', N'Chi nhánh Đà Nẵng', N' 789 Đường 2/9, Quận Hải Châu, Đà Nẵng');
go

-- Thêm dữ liệu cho bảng NHÂN VIÊN
INSERT INTO NHANVIEN (maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, maChiNhanh, hinhAnh)
VALUES ('NVHN001', 'Nguyễn Văn An', '123456289012', '1990-01-15', N'Nam', '123 Đường Lê Lợi, Hà Nội', '0932345678', 'Quản lý', 'CNHN', ''),
       ('NVHN002', 'Trần Thị Bình', '234565890123', '1992-03-20', N'Nữ', '456 Đường Hà Trung, Hà Nội', '0982654321', 'Nhân viên kế toán', 'CNHN', ''),
       ('NVHN003', 'Lê Văn Cường', '345612901234', '1995-05-10', N'Nam', '789 Đường Lý Thường Kiệt, Hà Nội', '0911234567', 'Nhân viên IT', 'CNHN', ''),
       ('NVHN004', 'Phạm Thị Dương', '456789322345', '1988-07-05', N'Nữ', '101 Đường Trần Phú, Hà Nội', '0976543310', 'Nhân viên bán hàng', 'CNHN', ''),
       ('NVHN005', 'Hoàng Văn Em', '567890144456', '1993-09-25', N'Nam', '222 Đường Đống Đa, Hà Nội', '0932108876', 'Nhân viên kế toán', 'CNHN', ''),
       ('NVHN006', 'Nguyễn Thị Dung', '678932234567', '1997-11-30', N'Nữ', '333 Đường Nguyễn Du, Hà Nội', '0915432101', 'Nhân viên IT', 'CNHN', ''),
       ('NVHN007', 'Trần Văn Giang', '789012343278', '1994-02-14', N'Nam', '444 Đường Bà Triệu, Hà Nội', '0921498765', 'Nhân viên cơ khí', 'CNHN', ''),

	   ('NVHCM001', 'Lê Thị Hương', '123456712012', '1991-04-20', N'Nữ', '123 Đường Lê Lai, Hồ Chí Minh', '09123325678', 'Quản lý', 'CNHCM', ''),
       ('NVHCM002', 'Phạm Văn Hoàng', '234563490123', '1989-06-15', N'Nam', '456 Đường Nam Kỳ Khởi Nghĩa, Hồ Chí Minh', '0987321321', 'Nhân viên kế toán', 'CNHCM', ''),
       ('NVHCM003', 'Nguyễn Thị Khanh', '345678910234', '1990-08-10', N'Nữ', '789 Đường Võ Văn Tần, Hồ Chí Minh', '0901233567', 'Nhân viên IT', 'CNHCM', ''),
       ('NVHCM004', 'Nguyễn Minh Khánh', '456909012345', '1996-10-05', N'Nam', '101 Đường Cách Mạng Tháng Tám, Hồ Chí Minh', '0976543210', 'Nhân viên bán hàng', 'CNHCM', ''),
       ('NVHCM005', 'Lê Thị Linh', '567890893456', '1987-12-25', 'Nữ', N'222 Đường Lê Duẩn, Hồ Chí Minh', '0932109446', 'Nhân viên kế toán', 'CNHCM', ''),
       ('NVHCM006', 'Hoàng Văn Minh', '678972234567', '1992-02-10', N'Nam', '333 Đường Lý Thường Kiệt, Hồ Chí Minh', '0965452101', 'Nhân viên IT', 'CNHCM', ''),
       ('NVHCM007', 'Trần Thị Ngân', '789012323278', '1993-05-14', N'Nữ', '444 Đường Nguyễn Đình Chính, Hồ Chí Minh', '0921033765', 'Nhân viên bảo vệ', 'CNHCM', ''),

	   ('NVCT001', 'Nguyễn Thành Sơn', '123451489012', '1991-03-20', N'Nam', '123 Đường Hòa Bình, Cần Thơ', '0912343278', 'Quản lý', 'CNCT', ''),
       ('NVCT002', 'Trần Thị Phương', '234567881123', '1989-05-15', N'Nữ', '456 Đường Lê Lai, Cần Thơ', '0987654231', 'Nhân viên kế toán', 'CNCT', ''),
       ('NVCT003', 'Lê Văn Quang', '345678011234', '1990-07-10', N'Nam', '789 Đường Võ Văn Kiệt, Cần Thơ', '0901674567', 'Nhân viên IT', 'CNCT', ''),
       ('NVCT004', 'Phạm Thị Quỳnh', '456229012345', '1996-09-05', N'Nữ', '101 Đường 30/4, Cần Thơ', '0976501210', 'Nhân viên bán hàng', 'CNCT', ''),
       ('NVCT005', 'Hoàng Văn Sáng', '569990123456', '1988-11-25', N'Nam', '222 Đường Cách Mạng Tháng Tám, Cần Thơ', '0932108976', 'Nhân viên kế toán', 'CNCT', ''),
       ('NVCT006', 'Nguyễn Thị Thu', '676601234567', '1992-01-10', N'Nữ', '333 Đường Nguyễn Văn Linh, Cần Thơ', '0965434501', 'Nhân viên IT', 'CNCT', ''),
       ('NVCT007', 'Trần Văn Nam', '789099345678', '1994-04-14', N'Nam', '444 Đường 3/2, Cần Thơ', '0921198765', 'Nhân viên bảo vệ', 'CNCT', ''),

	   ('NVDN001', 'Trần Đinh Xu', '123453089012', '1991-02-15', N'Nam', '123 Đường Bạch Đằng, Đà Nẵng', '0916845678', 'Quản lý', 'CNDN', ''),
       ('NVDN002', 'Nguyễn Thị Yến', '234590810123', '1989-04-20', N'Nữ', '456 Đường Lê Duẩn, Đà Nẵng', '0982954321', 'Nhân viên kế toán', 'CNDN', ''),
       ('NVDN003', 'Phạm Văn Đồng', '345636901234', '1990-06-10', N'Nam', '789 Đường 2/9, Đà Nẵng', '0901294567', 'Nhân viên IT', 'CNDN', ''),
       ('NVDN004', 'Trần Thị Uyên', '576789012345', '1996-08-05', N'Nữ', '101 Đường Hùng Vương, Đà Nẵng', '0901543210', 'Nhân viên bán hàng', 'CNDN', ''),
       ('NVDN005', 'Lê Thị Lan', '567899123456', '1988-10-25', N'Nữ', '222 Đường Phan Đăng Lưu, Đà Nẵng', '0932148876', 'Nhân viên kế toán', 'CNDN', ''),
       ('NVDN006', 'Hoàng Văn Mạnh', '638901234567', '1992-12-10', N'Nam', '333 Đường Hồ Nghinh, Đà Nẵng', '0969132101', 'Nhân viên IT', 'CNDN', ''),
       ('NVDN007', 'Nguyễn Băng Hà', '789012345678', '1994-03-14', N'Nam', '444 Đường 3/2, Đà Nẵng', '0921092065', 'Nhân viên bảo vệ', 'CNDN', ''),

	   ('NVHUE001', 'Lê Văn Hưng', '123456789012', '1991-05-20', N'Nam', '123 Đường Nguyễn Huệ, Huế', '0332345678', 'Quản lý', 'CNHUE', ''),
       ('NVHUE002', 'Trần Thị Kim Thoa', '234567890123', '1989-07-15', N'Nữ', '456 Đường 2/9, Huế', '0987654321', 'Nhân viên kế toán', 'CNHUE', ''),
       ('NVHUE003', 'Nguyễn Văn Luyện', '345678901234', '1990-09-10', N'Nam', '789 Đường Điện Biên Phủ, Huế', '0976234567', 'Nhân viên IT', 'CNHUE', ''),
       ('NVHUE004', 'Văn Thị Mười Ngọc', '456789012345', '1996-01-22', N'Nữ', '675 Đường Nguyễn Tất Thành, Huế', '0912346729', 'Nhân viên bán hàng', 'CNHUE', ''),
	   ('NVHUE005', 'Hoàng Văn Thụ', '567890123456', '1988-01-25', N'Nam', '222 Đường Trường Chinh, Huế', '0932109776', 'Nhân viên kế toán', 'CNHUE', ''),
       ('NVHUE006', 'Lê Thị Oanh', '678901234567', '1992-03-10', N'Nữ', '333 Đường Nguyễn Tất Thành, Huế', '0966632101', 'Nhân viên IT', 'CNHUE', ''),
       ('NVHUE007', 'Nguyễn Văn Phúc', '789021345678', '1994-06-14', N'Nam', '444 Đường Đống Đa, Huế', '0921098265', 'Nhân viên bảo vệ', 'CNHUE', '');
go

-- Thêm dữ liệu cho bảng TÀI KHOẢN
INSERT INTO TAIKHOAN (tenDangNhap, matKhau, chucVu, maNhanVien)
VALUES ('1', '1', N'Quản lý', 'NVHN001'),
	   ('2', '1', N'Nhân viên', 'NVHN002'),
	   ('3', '1', N'Nhân viên', 'NVHN003'),
	   ('4', '1', N'Bán hàng', 'NVHN004'),
	   ('5', '1', N'Quản lý', 'NVHN005'),
	   ('6', '1', N'Quản lý', 'NVHN006'),
	   ('7', '1', N'Thợ cơ khí', 'NVHN007');
go
-- Thêm dữ liệu cho bảng NHÀ CUNG CẤP
INSERT INTO NHACUNGCAP (maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai)
VALUES ('NCC-XE001', N'Công ty Toyota Việt Nam', N'123 Đường X, Quận Y, TP.HCM', '0123456789'),
	   ('NCC-XE002', N'Công ty Honda Việt Nam', N'456 Đường P, Quận Q, TP.HCM', '0987654321'),
       ('NCC-XE003', N'Công ty Ford Việt Nam', N'789 Đường R, Quận S, TP.HCM', '0321654987'),
       ('NCC-XE004', N'Công ty Nissan Việt Nam', N'101 Đường T, Quận U, TP.HCM', '0765432198'),
       ('NCC-XE005', N'Công ty Hyundai Việt Nam', N'202 Đường V, Quận W, TP.HCM', '0901234567'),

	   ('NCC-PT001', N'Aisin Seiki', N'456 Đường P, Quận Q, TP.HCM', '0987654321'),
	   ('NCC-PT002', N'Bosch', N'456 Đường P, Quận Q, TP.HCM', '0987654321'),
       ('NCC-PT003', N'Delphi', N'789 Đường R, Quận S, TP.HCM', '0321654987'),
       ('NCC-PT004', N'Denso', N'101 Đường T, Quận U, TP.HCM', '0765432198'),
       ('NCC-PT005', N'Michelin', N'202 Đường V, Quận W, TP.HCM', '0901234567');
go
-- Nhập xe
INSERT INTO LOXE (maLoXe, tenXe, mauSac, giaBan, soChoNgoi, xuatXu, hangXe, loaiXe, phienBanXe, tocDoToiDa, trongLuong, 
               canhBaoPhuongTien, canhBaoDiemMu, tuiKhi, mocGheAnToan, camBienLui, cameraLui, phanhSau, phanhTruoc, 
               boTruyenLuc, boDieuKhien, loaiNhienLieu, congSuatDongCo, dungTichDongCo, loaiDongCo, momenXoan, 
               khoanSangGam, chieuDaiCoSo, chieuDai, chieuRong, chieuCao, banKinhQuayVong, hinhAnh)
VALUES ('LOXE001', 'Mazda CX-5', 'Đen', 1400000, 5, 'Nhật Bản', 'Mazda', 'SUV', 'Grand Touring', 195, 1680, 
        'Có', 'Không', 'Có', 'Không', 'Có', 'Có', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Xăng', 225, 1998, 
        '4 xi-lanh', 250, 195, 4732, 179, 72, 167, 17, ''),
		('LOXE002', 'Volkswagen Golf', 'Xám', 1250000, 5, 'Đức', 'Volkswagen', 'Hatchback', 'Highline', 180, 1450, 
        'Có', 'Không', 'Không', 'Có', 'Có', 'Không', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Xăng', 180, 1395, 
        '4 xi-lanh', 200, 175, 4255, 179, 70, 157, 16, ''),
		('LOXE003', 'Subaru Outback', 'Xanh', 1380000, 5, 'Nhật Bản', 'Subaru', 'Crossover', 'Limited', 190, 1700, 
        'Có', 'Có', 'Không', 'Có', 'Có', 'Có', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Xăng', 256, 2498, 
        '6 xi-lanh', 320, 200, 4785, 167, 72, 174, 17, ''),
		('LOXE004', 'Mercedes-Benz E-Class', 'Bạc', 1500000, 5, 'Đức', 'Mercedes-Benz', 'Sedan', 'E350', 210, 1800, 
        'Có', 'Có', 'Có', 'Có', 'Có', 'Có', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Xăng', 292, 2999, 
        '6 xi-lanh', 365, 188, 4923, 146, 73, 155, 17, ''),
		('LOXE005', 'BMW X5', 'Đen', 1600000, 5, 'Đức', 'BMW', 'SUV', 'xDrive40i', 230, 2000, 
        'Có', 'Có', 'Không', 'Có', 'Có', 'Có', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Xăng', 335, 2998, 
        '6 xi-lanh', 450, 194, 4922, 176, 79, 172, 18, ''),
		('LOXE006', 'Audi Q7', 'Trắng', 1550000, 7, 'Đức', 'Audi', 'SUV', 'Premium Plus', 240, 2100, 
        'Có', 'Có', 'Có', 'Có', 'Có', 'Có', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Xăng', 335, 2995, 
        '6 xi-lanh', 500, 200, 5052, 174, 77, 169, 19, ''),
		('LOXE007', 'Lexus RX', 'Xám', 1450000, 5, 'Nhật Bản', 'Lexus', 'SUV', 'RX350', 220, 1900, 
        'Có', 'Có', 'Không', 'Có', 'Có', 'Có', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Xăng', 295, 3456, 
        '6 xi-lanh', 365, 193, 4890, 168, 74, 171, 18, ''),
		('LOXE008', 'Volvo XC90', 'Trắng', 1700000, 7, 'Thụy Điển', 'Volvo', 'SUV', 'T8 Inscription', 250, 2150, 
        'Có', 'Có', 'Có', 'Có', 'Có', 'Có', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Xăng', 400, 1969, 
        '4 xi-lanh', 407, 194, 4950, 176, 77, 174, 19, ''),
		('LOXE009', 'Jeep Grand Cherokee', 'Đỏ', 1480000, 5, 'Mỹ', 'Jeep', 'SUV', 'Limited', 225, 2000, 
        'Có', 'Có', 'Không', 'Có', 'Có', 'Có', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Xăng', 360, 3600, 
        '6 xi-lanh', 528, 189, 4828, 180, 69, 165, 18, ''),
		('LOXE010', 'Tesla Model X', 'Trắng', 1800000, 7, 'Mỹ', 'Tesla', 'SUV', 'Long Range', 250, 2200, 
        'Có', 'Có', 'Không', 'Có', 'Có', 'Có', 'Đĩa', 'Đĩa', 'Tự động', 'Tự động', 'Điện', 670, null, 
        'Điện', 967, 198, 5036, 168, 78, 168, null, '');
go

INSERT INTO XE (maXe, maLoXe)
VALUES ('LOXE001_XE001', 'LOXE001'),
		('LOXE001_XE002', 'LOXE001'),
		('LOXE002_XE001', 'LOXE002'),
		('LOXE002_XE002', 'LOXE002'),
		('LOXE003_XE001', 'LOXE003'),
		('LOXE003_XE002', 'LOXE003'),
		('LOXE004_XE001', 'LOXE004'),
		('LOXE004_XE002', 'LOXE004'),
		('LOXE005_XE001', 'LOXE005'),
		('LOXE005_XE002', 'LOXE005')


INSERT INTO PHUTUNG (maPhuTung, loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh)
VALUES ('PT001', 'Lốp xe', 'Lốp Michelin', 'Michelin', 'Pháp', 800, 'Cao cấp', ''),
       ('PT002', 'Bình xăng', 'Bình xăng Yamaha', 'Yamaha', 'Nhật Bản', 50, 'Tiêu chuẩn', ''),
       ('PT003', 'Dầu nhớt', 'Dầu nhớt Motul', 'Motul', 'Pháp', 150, 'Cao cấp', ''),
       ('PT004', 'Đèn pha', 'Đèn pha Philips', 'Philips', 'Hà Lan', 120, 'Tiêu chuẩn', ''),
       ('PT005', 'Bánh xe', 'Bánh xe Vision', 'Vision', 'Nhật Bản', 100, 'Tiêu chuẩn', ''),
       ('PT006', 'Hộp số', 'Hộp số ZF', 'ZF', 'Đức', 300, 'Cao cấp', ''),
       ('PT007', 'Bơm xăng', 'Bơm xăng Bosch', 'Bosch', 'Đức', 80, 'Tiêu chuẩn', ''),
       ('PT008', 'Bình điện', 'Bình điện Exide', 'Exide', 'Mỹ', 70, 'Tiêu chuẩn', ''),
       ('PT009', 'Công tắc đèn', 'Công tắc đèn Denso', 'Denso', 'Nhật Bản', 20, 'Tiêu chuẩn', ''),
       ('PT010', 'Filtro lọc', 'Filtro lọc Sakura', 'Sakura', 'Nhật Bản', 40, 'Tiêu chuẩn', '');
go

INSERT INTO PHIEUNHAP (maPhieuNhap, maNhaCungCap, maChiNhanh, ngayNhap)
VALUES 
    ('PN001', 'NCC-XE001', 'CNHN', '2023-10-01'),
    ('PN002', 'NCC-XE002', 'CNHCM', '2023-10-02'),
    ('PN003', 'NCC-XE003', 'CNHN', '2023-10-03'),
    ('PN004', 'NCC-XE004', 'CNHUE', '2023-10-04'),
    ('PN005', 'NCC-XE005', 'CNDN', '2023-10-05'),

    ('PN006', 'NCC-PT001', 'CNHN', '2023-10-06'),
    ('PN007', 'NCC-PT002', 'CNHUE', '2023-10-07'),
    ('PN008', 'NCC-PT003', 'CNCT', '2023-10-08'),
    ('PN009', 'NCC-PT004', 'CNHN', '2023-10-09'),
    ('PN010', 'NCC-PT005', 'CNCT', '2023-10-10');
go

INSERT INTO CHITIETPHIEUNHAPXE (maChiTietPhieuNhapXe, maXe, maPhieuNhap, giaNhap, soLuong)
VALUES ('CTX001', 'LOXE001_XE001', 'PN001', 1200000, 5),
       ('CTX002', 'LOXE001_XE002', 'PN001', 1300000, 6),
       ('CTX003', 'LOXE002_XE001', 'PN002', 1100000, 2),
       ('CTX004', 'LOXE002_XE002', 'PN002', 1400000, 1),
       ('CTX005', 'LOXE003_XE001', 'PN003', 1250000, 6),
       ('CTX006', 'LOXE003_XE002', 'PN003', 1350000, 9),
       ('CTX007', 'LOXE004_XE001', 'PN004', 1150000, 10),
       ('CTX008', 'LOXE004_XE002', 'PN004', 1500000, 11),
       ('CTX009', 'LOXE005_XE001', 'PN005', 1280000, 13),
       ('CTX010', 'LOXE005_XE002', 'PN005', 1380000, 4);
go

INSERT INTO CHITIETPHIEUNHAPPHUTUNG (maChiTietPhieuNhapPhuTung, maPhuTung, maPhieuNhap, giaNhap ,soLuong)
VALUES ('CTPT001', 'PT001', 'PN006', 750000, 9),
       ('CTPT002', 'PT002', 'PN006', 450000, 10),
       ('CTPT003', 'PT003', 'PN007', 120000, 12),
       ('CTPT004', 'PT004', 'PN007', 950000, 9),
       ('CTPT005', 'PT005', 'PN008', 800000, 3),
       ('CTPT006', 'PT006', 'PN008', 280000, 3),
       ('CTPT007', 'PT007', 'PN009', 700000, 2),
       ('CTPT008', 'PT008', 'PN009', 600000, 1),
       ('CTPT009', 'PT009', 'PN010', 180000, 7),
       ('CTPT010', 'PT010', 'PN010', 350000, 10);
go

INSERT INTO KHACHHANG (maKhachHang, hoTenKhachHang, ngaySinh, gioiTinh, CCCD, diaChi, soDienThoai)
VALUES ('KH001', 'Đặng Gia Thuận', '2000-01-15', N'Nam', '123456789012', 'Hà Nội', '0987654321'),
       ('KH002', 'Nguyễn Thị Lan Anh', '1995-03-20', N'Nữ', '234567890123', 'Hồ Chí Minh', '0901234567'),
       ('KH003', 'Nguyễn Việt Khoa', '1988-05-10', N'Nam', '345678901234', 'Đà Nẵng', '0971234567'),
       ('KH004', 'Phạm Thị Phương Nghi', '1992-09-08', N'Nữ', '456789012345', 'Hà Nội', '0961234567'),
       ('KH005', 'Nguyễn Xuân Thể', '1985-12-25', N'Nam', '567890123456', 'Hồ Chí Minh', '0911234567'),
       ('KH006', 'Nguyễn Hồ Thiên Thanh', '1997-06-30', N'Nữ', '678901234567', 'Đà Nẵng', '0987123456'),
	   ('KH007', 'Sú Minh Luân', '1990-03-17', N'Nam', '789012345678', 'Hà Nội', '0921234567'),
       ('KH008', 'Hoàng Võ Ngọc Nguyên', '1999-08-12', N'Nam', '901234567890', 'Đà Nẵng', '0941234567');
go

INSERT INTO HOADON (maHoaDon, maKhachHang, maNhanVienThucHien, tongTien, tinhTrang)
VALUES ('HD001', 'KH001', 'NVHN004', 1250000, N'Chưa thanh toán'),
       ('HD002', 'KH002', 'NVHN004', 1350000, N'Chưa thanh toán'),
       ('HD003', 'KH003', 'NVHN004', 1150000, N'Chưa thanh toán'),
       ('HD004', 'KH004', 'NVHN004', 1400000, N'Chưa thanh toán'),
       ('HD005', 'KH005', 'NVHN004', 1200000, N'Chưa thanh toán');
go

INSERT INTO CHITIETHOADONXE (maChiTietHoaDonXe, maHoaDon, maXe, ngayNhanXe, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo)
VALUES ('CTHDX001', 'HD001', 'LOXE001_XE001', '2023-10-01', 1250000, 100, 50, 30, 40, 20),
       ('CTHDX002', 'HD002', 'LOXE001_XE002', '2023-10-02', 1350000, 110, 55, 35, 45, 25),
       ('CTHDX003', 'HD003', 'LOXE002_XE001', '2023-10-03', 1150000, 90, 45, 25, 35, 15),
       ('CTHDX004', 'HD004', 'LOXE003_XE001', '2023-10-04', 1400000, 120, 60, 40, 50, 30),
       ('CTHDX005', 'HD005', 'LOXE004_XE001', '2023-10-05', 1200000, 105, 52, 32, 42, 22);
go

INSERT INTO CHITIETHOADONPHUTUNG (maChiTietHoaDonPhuTung, soTienDaTra, maHoaDon, maPhuTung)
VALUES
    ('CTHDP001', 1250000, 'HD001', 'PT001'),
    ('CTHDP002', 1350000, 'HD002', 'PT002'),
    ('CTHDP003', 1150000, 'HD001', 'PT003'),
    ('CTHDP004', 1250000, 'HD003', 'PT004'),
    ('CTHDP005', 1400000, 'HD002', 'PT001'),
    ('CTHDP006', 1200000, 'HD004', 'PT002'),
    ('CTHDP007', 1250000, 'HD003', 'PT005'),
    ('CTHDP008', 1200000, 'HD005', 'PT006'),
    ('CTHDP009', 1000000, 'HD004', 'PT004'),
    ('CTHDP010', 1150000, 'HD004', 'PT007');

INSERT INTO HOPDONGBAOHANH (maHopDongBaoHanh, maXe, maKhachHang, ngayKyBaoHanh, thoiHanBaoHanh, tinhTrang)
VALUES ('HDBH001', 'LOXE001_XE001', 'KH001','2023-01-01', '2024-01-01', N'Còn bảo hành'),
       ('HDBH002', 'LOXE001_XE002', 'KH002','2023-02-15', '2024-02-15', N'Còn bảo hành'),
       ('HDBH003', 'LOXE002_XE001', 'KH003','2023-03-10', '2024-03-10', N'Còn bảo hành'),
       ('HDBH004', 'LOXE003_XE001', 'KH004','2023-04-20', '2024-04-20', N'Còn bảo hành'),
       ('HDBH005', 'LOXE004_XE001', 'KH005','2023-05-05', '2024-05-05', N'Còn bảo hành');
go

INSERT INTO PHIEUBAOHANH (maPhieuBaoHanh, maHopDongBaoHanh, maNhanVienThucHien, ngayNhanXe, ngayTraXe, ngayLapPhieu)
VALUES ('PBH001', 'HDBH001', 'NVHN007', '2023-07-15', '2023-07-20', '2023-07-15');
go

INSERT INTO DICHVUBAODUONG (maBaoDuong, tenBaoDuong, loaiBaoDuong, phiBaoDuong)
VALUES ('DVBD001', 'Bảo dưỡng định kỳ', 'Định kỳ 5.000km', 200000),
       ('DVBD002', 'Bảo dưỡng định kỳ', 'Định kỳ 10.000km', 300000),
       ('DVBD003', 'Thay dầu máy', 'Thay dầu máy', 150000),
       ('DVBD004', 'Thay lọc gió', 'Thay lọc gió', 100000),
       ('DVBD005', 'Kiểm tra phanh', 'Kiểm tra phanh', 120000),
       ('DVBD006', 'Điều chỉnh lốp', 'Điều chỉnh lốp', 80000),
       ('DVBD007', 'Rửa xe', 'Rửa xe', 50000),
       ('DVBD008', 'Thay bugi', 'Thay bugi', 70000),
       ('DVBD009', 'Kiểm tra hệ thống điện', 'Kiểm tra hệ thống điện', 90000),
       ('DVBD010', 'Điều chỉnh đèn', 'Điều chỉnh đèn', 60000);
go

INSERT INTO PHIEUBAODUONG (maPhieuBaoDuong, maKhachHang, maNhanVienThucHien, tongTien)
VALUES ('PBD001', 'KH001', 'NVHN007', 150000),
       ('PBD002', 'KH002', 'NVHN007', 150000);
go

INSERT INTO CHITIETPHIEUBAODUONG(maChiTietPhieuBaoDuong, maBaoDuong, maPhieuBaoDuong, thanhTien)
VALUES ('HDBD001', 'DVBD003', 'PBD001', 150000),
       ('HDBD002', 'DVBD003', 'PBD002', 150000);

select * from CHINHANH
select * from NHANVIEN
select * from TAIKHOAN
select * from NHACUNGCAP
select * from LOXE
select * from XE
select * from PHUTUNG
select * from PHIEUNHAP
select * from CHITIETPHIEUNHAPXE
select * from CHITIETPHIEUNHAPPHUTUNG
select * from KHACHHANG
select * from HOADON
select * from CHITIETHOADONXE
select * from CHITIETHOADONPHUTUNG
select * from HOPDONGBAOHANH
select * from PHIEUBAOHANH
select * from DICHVUBAODUONG
select * from PHIEUBAODUONG
select * from CHITIETPHIEUBAODUONG