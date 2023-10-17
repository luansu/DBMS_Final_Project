using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class NhanVien
    {
        private string maNhanVien;
        private string hoTenNhanVien;
        private string cccd;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string diaChi;
        private string soDienThoai;
        private string chucVu;
        private bool tinhTrangLamViec; // 1: Còn làm || 0: Đã nghỉ
        private string maChiNhanh;
        private string hinhAnh;
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTenNhanVien { get => hoTenNhanVien; set => hoTenNhanVien = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public bool TinhTrangLamViec { get => tinhTrangLamViec; set => tinhTrangLamViec = value; }
        public string MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }

        // Hàm dựng
        public NhanVien(string maNhanVien, string hoTenNhanVien, string cccd, DateTime ngaySinh, 
            string gioiTinh, string diaChi, string soDienThoai, string chucVu, bool tinhTrangLamViec, string maChiNhanh, string hinhAnh)
        {
            this.MaNhanVien = maNhanVien;
            this.HoTenNhanVien = hoTenNhanVien;
            this.Cccd = cccd;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.SoDienThoai = soDienThoai;
            this.ChucVu = chucVu;
            this.TinhTrangLamViec = tinhTrangLamViec;
            this.MaChiNhanh = maChiNhanh;
            this.HinhAnh = hinhAnh;
        }

        public NhanVien(DataRow row)
        {
            this.MaNhanVien = row["maNhanVien"].ToString();
            this.HoTenNhanVien = row["hoTenNhanVien"].ToString();
            this.Cccd = row["cccd"].ToString();
            this.NgaySinh = (DateTime)row["ngaySinh"];
            this.GioiTinh = row["gioiTinh"].ToString();
            this.DiaChi = row["diaChi"].ToString();
            this.SoDienThoai = row["soDienThoai"].ToString();
            this.ChucVu = row["chucVu"].ToString();
            this.TinhTrangLamViec = (bool)row["tinhTrangLamViec"];
            this.MaChiNhanh = row["maChiNhanh"].ToString();
            this.HinhAnh = row["hinhAnh"].ToString();
        }
    }
}
