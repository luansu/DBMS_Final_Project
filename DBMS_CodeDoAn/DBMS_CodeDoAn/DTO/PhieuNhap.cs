using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class PhieuNhap
    {
        private string maPhieuNhap;
        private DateTime ngayNhap;
        private string maNhaCungCap;
        private string maChiNhanh;
        public string MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string MaNhaCungCap { get => maNhaCungCap; set => maNhaCungCap = value; }
        public string MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }

        public PhieuNhap(string maPhieuNhap, DateTime ngayNhap, string maNhaCungCap, string maChiNhanh)
        {
            this.maPhieuNhap = maPhieuNhap;
            this.ngayNhap = ngayNhap;
            this.maNhaCungCap = maNhaCungCap;
            this.maChiNhanh = maChiNhanh;
        }
        public PhieuNhap(DataRow row)
        {
            this.maPhieuNhap = row["maPhieuNhap"].ToString();
            this.ngayNhap = (DateTime)row["ngayNhap"];
            this.maNhaCungCap = row["maNhaCungCap"].ToString();
            this.maChiNhanh = row["maChiNhanh"].ToString();
        }
    }
}
