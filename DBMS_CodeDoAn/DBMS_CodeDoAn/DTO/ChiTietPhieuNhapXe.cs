using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class ChiTietPhieuNhapXe
    {
        private string maChiTietPhieuNhapXe;
        private string maLoXe;
        private string maPhieuNhap;
        private float giaNhap;
        private int soLuong;
        public string MaChiTietPhieuNhapXe { get => maChiTietPhieuNhapXe; set => maChiTietPhieuNhapXe = value; }
        public string MaLoXe { get => maLoXe; set => maLoXe = value; }
        public string MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public float GiaNhap { get => giaNhap; set => giaNhap = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public ChiTietPhieuNhapXe(string maChiTietPhieuNhapXe, string maLoXe, string maPhieuNhap, float giaNhap, int soLuong)
        {
            this.maChiTietPhieuNhapXe = maChiTietPhieuNhapXe;
            this.maLoXe = maLoXe;
            this.maPhieuNhap = maPhieuNhap;
            this.giaNhap = giaNhap;
            this.soLuong = soLuong;
        }

        public ChiTietPhieuNhapXe(DataRow row)
        {
            this.maChiTietPhieuNhapXe = row["maChiTietPhieuNhapXe"].ToString();
            this.maLoXe = row["maLoXe"].ToString();
            this.maPhieuNhap = row["maPhieuNhap"].ToString();
            this.giaNhap = (float)Convert.ToDouble(row["giaNhap"].ToString());
            this.soLuong = (int)row["soLuong"];
        }
    }
}
