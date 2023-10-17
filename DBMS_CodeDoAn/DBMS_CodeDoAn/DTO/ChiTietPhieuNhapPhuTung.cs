using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class ChiTietPhieuNhapPhuTung
    {
        private string maChiTietPhieuNhapPhuTung;
        private string maXe;
        private string maPhieuNhap;
        private int giaNhap;
        private int soLuong;
        public string MaChiTietPhieuNhapPhuTung { get => maChiTietPhieuNhapPhuTung; set => maChiTietPhieuNhapPhuTung = value; }
        public string MaXe { get => maXe; set => maXe = value; }
        public string MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public int GiaNhap { get => giaNhap; set => giaNhap = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public ChiTietPhieuNhapPhuTung(string maChiTietPhieuNhapPhuTung, string maXe, string maPhieuNhap, int giaNhap, int soLuong)
        {
            this.maChiTietPhieuNhapPhuTung = maChiTietPhieuNhapPhuTung;
            this.maXe = maXe;
            this.maPhieuNhap = maPhieuNhap;
            this.giaNhap = giaNhap;
            this.soLuong = soLuong;
        }

        public ChiTietPhieuNhapPhuTung(DataRow row)
        {
            this.maChiTietPhieuNhapPhuTung = row["maChiTietPhieuNhapXe"].ToString();
            this.maXe = row["maXe"].ToString();
            this.maPhieuNhap = row["maPhieuNhap"].ToString();
            this.giaNhap = (int)row["giaNhap"];
            this.soLuong = (int)row["soLuong"];
        }
    }
}
