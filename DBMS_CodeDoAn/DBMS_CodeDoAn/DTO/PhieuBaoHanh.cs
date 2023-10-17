using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class PhieuBaoHanh
    {
        private string maPhieuBaoHanh;
        private string maHopDongBaoHanh;
        private string maNhanVienThucHien;
        private DateTime ngayNhanXe;
        private DateTime ngayTraXe;
        private DateTime ngayLapPhieu;

        public string MaPhieuBaoHanh { get => maPhieuBaoHanh; set => maPhieuBaoHanh = value; }
        public string MaHopDongBaoHanh { get => maHopDongBaoHanh; set => maHopDongBaoHanh = value; }
        public string MaNhanVienThucHien { get => maNhanVienThucHien; set => maNhanVienThucHien = value; }
        public DateTime NgayNhanXe { get => ngayNhanXe; set => ngayNhanXe = value; }
        public DateTime NgayTraXe { get => ngayTraXe; set => ngayTraXe = value; }
        public DateTime NgayLapPhieu { get => ngayLapPhieu; set => ngayLapPhieu = value; }

        // Constructor
        public PhieuBaoHanh(string maPhieuBaoHanh, string maHopDongBaoHanh, string maNhanVienThucHien, 
            DateTime ngayNhanXe, DateTime ngayTraXe, DateTime ngayLapPhieu)
        {
            this.maPhieuBaoHanh = maPhieuBaoHanh;
            this.maHopDongBaoHanh = maHopDongBaoHanh;
            this.maNhanVienThucHien = maNhanVienThucHien;
            this.ngayNhanXe = ngayNhanXe;
            this.ngayTraXe = ngayTraXe;
            this.ngayLapPhieu = ngayLapPhieu;
        }

        public PhieuBaoHanh(DataRow row)
        {
            this.maPhieuBaoHanh = row["maPhieuBaoHanh"].ToString();
            this.maHopDongBaoHanh = row["maHopDongBaoHanh"].ToString();
            this.maNhanVienThucHien = row["maNhanVienThucHien"].ToString();
            this.ngayNhanXe = (DateTime)row["ngayNhanXe"];
            this.ngayTraXe = (DateTime)row["ngayTraXe"];
            this.ngayLapPhieu = (DateTime)row["ngayLapPhieu"];
        }
    }
}
