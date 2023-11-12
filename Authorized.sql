﻿Use DBMS_DOAN_QUANLYCUAHANGXE
go

create role r_admin;
create role r_seller;
create role r_maintenace;

GRANT insert, select, delete, update on DBMS_DOAN_QUANLYCUAHANGXE to r_admin;
EXEC sp_addrolemember r_seller
begin tran;
grant select on DBMS_DOAN_QUANLYCUAHANGXE to r_seller

deny select on dbo.PHIEUNHAP to r_seller
deny select on dbo.CHITIETPHIEUNHAPXE to r_seller
deny select on dbo.CHITIETPHIEUNHAPPHUTUNG to r_seller

grant insert, update on dbo.KHAHCHANG to r_seller
grant insert, update on dbo.HOADON to r_seller
grant update on dbo.CHITIETHOADONXE to r_seller
grant update on dbo.CHITIETHOADONPHUTUNG to r_seller
grant insert, update on dbo.PHIEUBAODUONG to r_seller
grant update on dbo.CHITIETPHIEUBAODUONG to r_seller
grant update on dbo.CHITIETPHIEUBAODUONG to r_seller
grant insert, update on dbo.HOPDONGBAOHANH to r_seller


-- Phân quyền cho role mataienmain
grant select on DBMS_DOAN_QUANLYCUAHANGXE to r_maintenace

deny select on dbo.PHIEUNHAP to r_maintenace
deny select on dbo.CHITIETPHIEUNHAPXE to r_maintenace
deny select on dbo.CHITIETPHIEUNHAPPHUTUNG to r_maintenace

grant update on dbo.KHPHUTUNG to r_mataienmain
grant update on dbo.PHIEUBAOHANHF to r_maintenace