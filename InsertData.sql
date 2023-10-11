use DBMS_DOAN_QUANLYCUAHANGXE
go

-- Thêm dữ liệu cho bảng CHI NHÁNH
INSERT INTO CHINHANH (maChiNhanh, tenChiNhanh, diaChi)
VALUES ('CN001', N'Chi nhánh A', N'123 Đường A, Quận 1, TP.HCM'),
       ('CN002', N'Chi nhánh B', N'456 Đường B, Quận 2, TP.HCM'),
       ('CN003', N'Chi nhánh C', N'789 Đường C, Quận 3, TP.HCM'),
       ('CN004', N'Chi nhánh D', N'101 Đường D, Quận 4, TP.HCM'),
       ('CN005', N'Chi nhánh E', N'202 Đường E, Quận 5, TP.HCM'),
       ('CN006', N'Chi nhánh F', N'303 Đường F, Quận 6, TP.HCM'),
       ('CN007', N'Chi nhánh G', N'404 Đường G, Quận 7, TP.HCM'),
       ('CN008', N'Chi nhánh H', N'505 Đường H, Quận 8, TP.HCM'),
       ('CN009', N'Chi nhánh I', N'606 Đường I, Quận 9, TP.HCM'),
       ('CN010', N'Chi nhánh J', N'707 Đường J, Quận 10, TP.HCM');

-- Thêm dữ liệu cho bảng NHÂN VIÊN
INSERT INTO NHANVIEN (maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, maChiNhanh)
VALUES 
('NV001', N'Nguyễn Văn A', '123456789012', '1990-05-15', N'Nam', N'123 Đường X, Quận Y, TP.HCM', '0123456789', N'Quản lý', 'CN001'),
('NV002', N'Trần Thị B', '987654321012', '1995-03-20', N'Nữ', N'456 Đường P, Quận Q, TP.HCM', '0987654321', N'Nhân viên bán hàng', 'CN002'),
('NV003', N'Lê Văn C', '456123789012', '1988-07-10', N'Nam', N'789 Đường R, Quận S, TP.HCM', '0321654987', N'Nhân viên bảo dưỡng', 'CN003'),
('NV004', N'Phạm Thị D', '789456123012', '1998-11-25', N'Nữ', N'101 Đường T, Quận U, TP.HCM', '0765432198', N'Nhân viên bán hàng', 'CN001'),
('NV005', N'Nguyễn Văn E', '321654987012', '1985-09-05', N'Nam', N'202 Đường V, Quận W, TP.HCM', '0901234567', N'Nhân viên bảo dưỡng', 'CN002'),
('NV006', N'Trần Thị F', '654987321012', '1993-12-30', N'Nữ', N'303 Đường X, Quận Y, TP.HCM', '0998765432', N'Nhân viên bán hàng', 'CN003'),
('NV007', N'Lê Văn G', '987321654012', '1987-04-17', N'Nam', N'404 Đường Z, Quận A, TP.HCM', '0888888888', N'Quản lý', 'CN001'),
('NV008', N'Phạm Thị H', '123789456012', '1997-06-12', N'Nữ', N'505 Đường B, Quận C, TP.HCM', '0777777777', N'Nhân viên bán hàng', 'CN002'),
('NV009', N'Nguyễn Văn I', '987123654012', '1989-08-22', N'Nam', N'606 Đường D, Quận E, TP.HCM', '0666666666', N'Nhân viên bán hàng', 'CN003'),
('NV010', N'Trần Thị K', '789321654012', '1994-02-08', N'Nữ', N'707 Đường F, Quận G, TP.HCM', '0555555555', N'Nhân viên bảo dưỡng', 'CN001');

-- Thêm dữ liệu cho bảng TÀI KHOẢN
INSERT INTO TAIKHOAN (tenDangNhap, matKhau, chucVu)
VALUES 
('admin', 'admin123', N'Quản trị viên'),
('nhanvien1', 'nhanvien123', N'Nhân viên'),
('nhanvien2', 'nhanvien456', N'Nhân viên'),
('nhanvien3', 'nhanvien789', N'Nhân viên'),
('quanly1', 'quanly123', N'Quản lý'),
('quanly2', 'quanly456', N'Quản lý'),
('quanly3', 'quanly789', N'Quản lý'),
('khachhang1', 'khachhang123', N'Khách hàng'),
('khachhang2', 'khachhang456', N'Khách hàng'),
('khachhang3', 'khachhang789', N'Khách hàng');

-- Thêm dữ liệu cho bảng NHÀ CUNG CẤP
INSERT INTO NHACUNGCAP (maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai)
VALUES 
('NCC001', N'Nhà cung cấp A', N'123 Đường X, Quận Y, TP.HCM', '0123456789'),
('NCC002', N'Nhà cung cấp B', N'456 Đường P, Quận Q, TP.HCM', '0987654321'),
('NCC003', N'Nhà cung cấp C', N'789 Đường R, Quận S, TP.HCM', '0321654987'),
('NCC004', N'Nhà cung cấp D', N'101 Đường T, Quận U, TP.HCM', '0765432198'),
('NCC005', N'Nhà cung cấp E', N'202 Đường V, Quận W, TP.HCM', '0901234567'),
('NCC006', N'Nhà cung cấp F', N'303 Đường X, Quận Y, TP.HCM', '0998765432'),
('NCC007', N'Nhà cung cấp G', N'404 Đường Z, Quận A, TP.HCM', '0888888888'),
('NCC008', N'Nhà cung cấp H', N'505 Đường B, Quận C, TP.HCM', '0777777777'),
('NCC009', N'Nhà cung cấp I', N'606 Đường D, Quận E, TP.HCM', '0666666666'),
('NCC010', N'Nhà cung cấp J', N'707 Đường F, Quận G, TP.HCM', '0555555555');

INSERT INTO XE 
(maXe, tenXe, mauSac, giaBan, soChoNgoi, xuatXu, hangXe, 
loaiXe, phienBanXe, tocDoToiDa, trongLuong, canhBaoPhuongTien, 
canhBaoDiemMu, tuiKhi, mocGheAnToan, camBienLui, cameraLui, 
phanhSau, phanhTruoc, boTruyenLuc, boDieuKhien, mucTieuThuNhienLieu, 
loaiNhienLieu, congSuatDongCo, dungTichDongCo, loaiDongCo, momenXoan,
khoanSangGam, chieuDaiCoSo, chieuDai, chieuRong, chieuCao, banKinhQuayVong)
'X001', 'Toyota Camry', 'Đỏ', 300000000, 5, 'Nhật Bản', 'Toyota', 
'Sedan', 'Phiên bản 1', 200, 1200, 'Cảnh báo va chạm', 
'Cảnh báo điểm mù', 'Có', 'Có', 'Có', 'Có',
'Có', 'Có', 'Có', 'Có', 'Xăng', 150, 2000, 'Động cơ X', 180, 50, 4500, 4800, 1800, 1500, 250
VALUES
('X001', 'Toyota Camry', 'Đỏ', 300000000, 5, 'Nhật Bản', 'Toyota', 'Sedan', 'Phiên bản 1', 200, 1200, 'Cảnh báo va chạm', 'Cảnh báo điểm mù', 'Có', 'Có', 'Có', 'Có', 'Có', 'Có', 'Có', 'Có', 'Xăng', 150, 2000, 'Động cơ X', 180, 50, 4500, 4800, 1800, 1500, 250),
('X002', 'Hyundai Tucson', 'Xanh', 250000000, 4, 'Hàn Quốc', 'Hyundai', 'SUV', 'Phiên bản 2', 180, 1400, 'Cảnh báo va chạm', 'Cảnh báo điểm mù', 'Không', 'Có', 'Không', 'Có', 'Có', 'Có', 'Không', 'Có', 'Dầu', 120, 1800, 'Động cơ Y', 160, 45, 4200, 4500, 1700, 1400, 230),
('X003', 'Ford Escape', 'Trắng', 350000000, 7, 'Mỹ', 'Ford', 'Crossover', 'Phiên bản 3', 220, 1600, 'Cảnh báo va chạm', 'Cảnh báo điểm mù', 'Có', 'Không', 'Có', 'Không', 'Không', 'Không', 'Có', 'Không', 'Xăng', 180, 2500, 'Động cơ Z', 200, 55, 4800, 5000, 1850, 1600, 260),
('X004', 'BMW 5 Series', 'Đen', 400000000, 5, 'Đức', 'BMW', 'Sedan', 'Phiên bản 1', 250, 1800, 'Cảnh báo va chạm', 'Cảnh báo điểm mù', 'Có', 'Có', 'Có', 'Không', 'Không', 'Có', 'Không', 'Có', 'Dầu', 190, 2800, 'Động cơ X', 230, 60, 5200, 5500, 1900, 1700, 280),
('X006', 'Kia Sportage', 'Đỏ', 320000000, 5, 'Hàn Quốc', 'Kia', 'SUV', 'Phiên bản 3', 210, 1500, 'Cảnh báo va chạm', 'Cảnh báo điểm mù', 'Có', 'Có', 'Có', 'Có', 'Không', 'Không', 'Không', 'Có', 'Dầu', 170, 2200, 'Động cơ Z', 190, 50, 4600, 4800, 1750, 1600, 240),
('X007', 'Chevrolet Equinox', 'Xám', 330000000, 7, 'Mỹ', 'Chevrolet', 'Crossover', 'Phiên bản 2', 230, 1700, 'Cảnh báo va chạm', 'Cảnh báo điểm mù', 'Có', 'Có', 'Không', 'Có', 'Không', 'Không', 'Không', 'Không', 'Xăng', 180, 2400, 'Động cơ X', 210, 55, 4900, 5200, 1800, 1650, 250),
('X008', 'Audi A6', 'Trắng', 380000000, 5, 'Đức', 'Audi', 'Sedan', 'Phiên bản 1', 260, 1900, 'Cảnh báo va chạm', 'Cảnh báo điểm mù', 'Có', 'Không', 'Có', 'Không', 'Có', 'Có', 'Có', 'Không', 'Dầu', 200, 2600, 'Động cơ Y', 240, 65, 5300, 5600, 1950, 1750, 290),
('X009', 'Mazda 3', 'Vàng', 270000000, 4, 'Nhật Bản', 'Mazda', 'Hatchback', 'Phiên bản 2', 180, 1400, 'Không', 'Cảnh báo điểm mù', 'Không', 'Có', 'Không', 'Không', 'Có', 'Không', 'Không', 'Xăng', 150, 1900, 'Động cơ Z', 160, 42, 4100, 4400, 1700, 1550, 230),
('X010', 'Hyundai Santa Fe', 'Đen', 310000000, 4, 'Hàn Quốc', 'Hyundai', 'SUV', 'Phiên bản 3', 200, 1600, 'Cảnh báo va chạm', 'Cảnh báo điểm mù', 'Không', 'Có', 'Không', 'Không', 'Có', 'Có', 'Không', 'Không', 'Dầu', 180, 2200, 'Động cơ X', 180, 48, 4900;
