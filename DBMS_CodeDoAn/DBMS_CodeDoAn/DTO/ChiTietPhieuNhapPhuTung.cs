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
        private string maPhuTung;
        private string maPhieuNhap;
        private float giaNhap;
        private int soLuong;
        public string MaChiTietPhieuNhapPhuTung { get => maChiTietPhieuNhapPhuTung; set => maChiTietPhieuNhapPhuTung = value; }
        public string MaPhuTung { get => maPhuTung; set => maPhuTung = value; }
        public string MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public float GiaNhap { get => giaNhap; set => giaNhap = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public ChiTietPhieuNhapPhuTung(string maChiTietPhieuNhapPhuTung, string maPhuTung, string maPhieuNhap, float giaNhap, int soLuong)
        {
            this.maChiTietPhieuNhapPhuTung = maChiTietPhieuNhapPhuTung;
            this.maPhuTung = maPhuTung;
            this.maPhieuNhap = maPhieuNhap;
            this.giaNhap = giaNhap;
            this.soLuong = soLuong;
        }

        public ChiTietPhieuNhapPhuTung(DataRow row)
        {
            this.maChiTietPhieuNhapPhuTung = row["maChiTietPhieuNhapPhuTung"].ToString();
            this.maPhuTung = row["maPhuTung"].ToString();
            this.maPhieuNhap = row["maPhieuNhap"].ToString();
            this.giaNhap = (float)Convert.ToDouble(row["giaNhap"].ToString());
            this.soLuong = (int)row["soLuong"];
        }
    }
}
