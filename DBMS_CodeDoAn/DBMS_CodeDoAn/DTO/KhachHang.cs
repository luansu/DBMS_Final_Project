using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class KhachHang
    {
        private string maKhachHang;
        private string hoTenKhachHang;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string cCCD;
        private string diaChi;
        private string soDienThoai;

        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string HoTenKhachHang { get => hoTenKhachHang; set => hoTenKhachHang = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string CCCD { get => cCCD; set => cCCD = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }

        // Hàm dựng
        public KhachHang(string maKhachHang, string hoTenKhachHang, DateTime ngaySinh, string gioiTinh, string cccd, string diaChi, string soDienThoai)
        {
            this.maKhachHang = maKhachHang;
            this.hoTenKhachHang = hoTenKhachHang;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.cCCD = cccd;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
        }
        
        public KhachHang(DataRow row)
        {
            this.maKhachHang = row["maKhachHang"].ToString();
            this.hoTenKhachHang = row["hoTenKhachHang"].ToString();
            this.ngaySinh = (DateTime)row["ngaySinh"];
            this.gioiTinh = row["gioiTinh"].ToString();
            this.cCCD = row["CCCD"].ToString();
            this.diaChi = row["diaChi"].ToString();
            this.soDienThoai = row["soDienThoai"].ToString();
        }
    }
}
