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
