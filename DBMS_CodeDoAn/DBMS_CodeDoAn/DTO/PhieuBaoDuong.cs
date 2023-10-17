using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class PhieuBaoDuong
    {
        private string maPhieuBaoDuong;
        private DateTime ngayLapPhieu;
        private int tongTien;
        private string maKhachHang;
        private string maNhanVienThucHien;

        public string MaPhieuBaoDuong { get => maPhieuBaoDuong; set => maPhieuBaoDuong = value; }
        public DateTime NgayLapPhieu { get => ngayLapPhieu; set => ngayLapPhieu = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string MaNhanVienThucHien { get => maNhanVienThucHien; set => maNhanVienThucHien = value; }

        // Constructor
        public PhieuBaoDuong(string maPhieuBaoDuong, DateTime ngayLapPhieu, int tongTien,
            string maKhachHang, string maNhanVienThucHien)
        {
            this.maPhieuBaoDuong = maPhieuBaoDuong;
            this.ngayLapPhieu = ngayLapPhieu;
            this.tongTien = tongTien;
            this.maKhachHang = maKhachHang;
            this.MaNhanVienThucHien = maNhanVienThucHien;
        }

        public PhieuBaoDuong(DataRow row)
        {
            this.maPhieuBaoDuong = row["maPhieuBaoDuong"].ToString();
            this.ngayLapPhieu = (DateTime)row["ngayLapPhieu"];
            this.tongTien = (int)row["tongTien"];
            this.maKhachHang = row["maKhachHang"].ToString();
            this.MaNhanVienThucHien = row["MaNhanVienThucHien"].ToString();
        }
    }
}
