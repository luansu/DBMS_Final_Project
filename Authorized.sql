Use DBMS_DOAN_QUANLYCUAHANGXE
go

create role r_admin;
create role r_seller;
create role r_maintenace;
---
create login u1 with password = '1'
create user u1 for login u1

create login u2 with password = '1'
create user u2 for login u2

EXEC sp_addrolemember r_admin, u1
EXEC sp_addrolemember r_seller, u2
select * from NHANVIEN

---- Cấp quyền cho admin
GRANT insert, select, delete, update, exec on DBMS_DOAN_QUANLYCUAHANGXE to r_admin;

-- Cấp quyền cho r_seller
GRANT select, exec on DBMS_DOAN_QUANLYCUAHANGXE to r_seller;
deny insert, select, update, exec on dbo.PHIEUNHAP to r_seller
deny insert, select, update, exec on dbo.CHITIETPHIEUNHAPXE to r_seller
deny insert, select, update, exec on dbo.CHITIETPHIEUNHAPPHUTUNG to r_seller

grant exec on sp_LietKeNhanVienTheoChiNhanh to r_seller

-- sp_LoXeTheoXuatXu
-- sp_ThongTinKhachHang
-- sp_ThongTinXeTheoLo
-- 

grant insert, update, exec on dbo.KHAHCHANG to r_seller
grant insert, update, exec on dbo.HOADON to r_seller
grant update, exec on dbo.CHITIETHOADONXE to r_seller
grant update, exec on dbo.CHITIETHOADONPHUTUNG to r_seller
grant insert, update, exec on dbo.PHIEUBAODUONG to r_seller
grant update, exec on dbo.CHITIETPHIEUBAODUONG to r_seller
grant update, exec on dbo.CHITIETPHIEUBAODUONG to r_seller
grant insert, update, exec on dbo.HOPDONGBAOHANH to r_seller


-- Phân quyền cho role mataienmain
GRANT select, exec on DBMS_DOAN_QUANLYCUAHANGXE to r_maintenace;

deny select on dbo.PHIEUNHAP to r_maintenace
deny select on dbo.CHITIETPHIEUNHAPXE to r_maintenace
deny select on dbo.CHITIETPHIEUNHAPPHUTUNG to r_maintenace

grant update on dbo.KHPHUTUNG to r_mataienmain
grant update on dbo.PHIEUBAOHANHF to r_maintenace