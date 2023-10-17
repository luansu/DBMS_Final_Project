using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class ChiTieuPhieuNhapXe
    {
        private string maChiTietPhieuNhapXe;
        private string maXe;
        private string maPhieuNhap;
        private int giaNhap;
        private int soLuong;
        public string MaChiTietPhieuNhapXe { get => maChiTietPhieuNhapXe; set => maChiTietPhieuNhapXe = value; }
        public string MaXe { get => maXe; set => maXe = value; }
        public string MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public int GiaNhap { get => giaNhap; set => giaNhap = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public ChiTieuPhieuNhapXe(string maChiTietPhieuNhapXe, string maXe, string maPhieuNhap, int giaNhap, int soLuong)
        {
            this.maChiTietPhieuNhapXe = maChiTietPhieuNhapXe;
            this.maXe = maXe;
            this.maPhieuNhap = maPhieuNhap;
            this.giaNhap = giaNhap;
            this.soLuong = soLuong;
        }

        public ChiTieuPhieuNhapXe(DataRow row)
        {
            this.maChiTietPhieuNhapXe = row["maChiTietPhieuNhapXe"].ToString();
            this.maXe = row["maXe"].ToString();
            this.maPhieuNhap = row["maPhieuNhap"].ToString();
            this.giaNhap = (int)row["giaNhap"];
            this.soLuong = (int)row["soLuong"];
        }
    }
}
