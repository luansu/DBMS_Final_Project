using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class HoaDon
    {
        private string maHoaDon;
        private DateTime ngayLapHoaDon;
        private int tongTien;
        private string tinhTrang;
        private string maKhachHang;
        private string maNhanVienThucHien;

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime NgayLapHoaDon { get => ngayLapHoaDon; set => ngayLapHoaDon = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string MaNhanVienThucHien { get => maNhanVienThucHien; set => maNhanVienThucHien = value; }
    
        // Hàm dựng
        public HoaDon(string maHoaDon, DateTime ngayLapHoaDon, int tongTien, string tinhTrang, string maKhachHang, string maNhanVienThucHien)
        {
            this.maHoaDon = maHoaDon;
            this.ngayLapHoaDon = ngayLapHoaDon;
            this.tongTien = tongTien;
            this.tinhTrang = tinhTrang;
            this.maKhachHang = maKhachHang;
            this.maNhanVienThucHien = maNhanVienThucHien;
        }

        public HoaDon(DataRow row)
        {
            this.maHoaDon = row["maHoaDon"].ToString();
            this.ngayLapHoaDon = (DateTime)row["ngayLapHoaDon"];
            this.tongTien = (int)row["tongTien"];
            this.tinhTrang = row["tinhTrang"].ToString();
            this.maKhachHang = row["maKhachHang"].ToString();
            this.maNhanVienThucHien = row["maNhanVienThucHien"].ToString();
        }
    }
}
