using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class ChiTietPhieuBaoDuong
    {
        private string maChiTietPhieuBaoDuong;
        private string maBaoDuong;
        private string maPhieuBaoDuong;
        private int thanhTien;

        public string MaChiTietPhieuBaoDuong { get => maChiTietPhieuBaoDuong; set => maChiTietPhieuBaoDuong = value; }
        public string MaBaoDuong { get => maBaoDuong; set => maBaoDuong = value; }
        public string MaPhieuBaoDuong { get => maPhieuBaoDuong; set => maPhieuBaoDuong = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }

        // Constructor
        public ChiTietPhieuBaoDuong(string maChiTietPhieuBaoDuong, string maBaoDuong, string maPhieuBaoDuong, int thanhTien)
        {
            this.maChiTietPhieuBaoDuong = maChiTietPhieuBaoDuong;
            this.maBaoDuong = maBaoDuong;
            this.maPhieuBaoDuong = maPhieuBaoDuong;
            this.thanhTien = thanhTien;
        }

        public ChiTietPhieuBaoDuong(DataRow row)
        {
            this.maChiTietPhieuBaoDuong = row["maChiTietPhieuBaoDuong"].ToString();
            this.maBaoDuong = row["maBaoDuong"].ToString();
            this.maPhieuBaoDuong = row["maPhieuBaoDuong"].ToString();
            this.thanhTien = (int)row["thanhTien"];
        }
    }
}
