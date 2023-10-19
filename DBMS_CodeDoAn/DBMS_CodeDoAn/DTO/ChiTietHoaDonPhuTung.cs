
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class ChiTietHoaDonPhuTung
    {
        private string maChiTietHoaDonPhuTung;
        private string maHoaDon;
        private string maPhuTung;
        private float soTienDaTra;

        public string MaChiTietHoaDonPhuTung { get => maChiTietHoaDonPhuTung; set => maChiTietHoaDonPhuTung = value; }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaPhuTung { get => maPhuTung; set => maPhuTung = value; }
        public float SoTienDaTra { get => soTienDaTra; set => soTienDaTra = value; }

        // Constructor
        public ChiTietHoaDonPhuTung(string maChiTietHoaDonPhuTung, string maHoaDon, string maPhuTung, float soTienDaTra)
        {
            this.maChiTietHoaDonPhuTung = maChiTietHoaDonPhuTung;
            this.maHoaDon = maHoaDon;
            this.maPhuTung = maPhuTung;
            this.soTienDaTra = soTienDaTra;
        }

        public ChiTietHoaDonPhuTung(DataRow row)
        {
            this.maChiTietHoaDonPhuTung = row["maChiTietHoaDonPhuTung"].ToString();
            this.maHoaDon = row["maHoaDon"].ToString();
            this.maPhuTung = row["maPhuTung"].ToString();
            this.soTienDaTra = (float)Convert.ToDouble(row["soTienDaTra"].ToString());
        }
    }
}
