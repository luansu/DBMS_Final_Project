using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiTietPhieuNhapPhuTungDAO
    {
        private static ChiTietPhieuNhapPhuTungDAO instance;

        public static ChiTietPhieuNhapPhuTungDAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuNhapPhuTungDAO(); return instance; }
            private set => instance = value;
        }

        private ChiTietPhieuNhapPhuTungDAO() { }

        public List<ChiTietPhieuNhapPhuTung> DanhSachChiTietPhieuNhapPhuTung()
        {
            List<ChiTietPhieuNhapPhuTung> listDanhSachCTPNPTung = new List<ChiTietPhieuNhapPhuTung> ();

            string query = "select * from CHITIETPHIEUNHAPPHUTUNG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ChiTietPhieuNhapPhuTung ctpnPTung = new ChiTietPhieuNhapPhuTung(row);
                listDanhSachCTPNPTung.Add(ctpnPTung);
            }

            return listDanhSachCTPNPTung;
        }
        public bool ThemChiTietPhieuNhapPhuTung(string maPhuTung, string maPhieuNhap, float giaNhap, int soLuong)
        {
            string query = string.Format("insert into CHITIETPHIEUNHAPPHUTUNG(maPhuTung, maPhieuNhap, giaNhap, soLuong) values ('{0}', '{1}', {2}, {3})", maPhuTung, maPhieuNhap, giaNhap, soLuong);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool CapNhatChiTietPhieuNhapPhuTung(string maChiTietPNPT, string maPhuTung, string maPhieuNhap, float giaNhap, int soLuong)
        {
            string query = string.Format("update CHITIETPHIEUNHAPPHUTUNG set maPhuTung = '{0}', maPhieuNhap = '{1}', giaNhap = {2}, soLuong = {3} where maChiTietPhieuNhapPhuTung = '{4}'", maPhuTung, maPhieuNhap, giaNhap, soLuong, maChiTietPNPT);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaChiTietPhieuNhapPhuTung(string maChiTietPNPT)
        {
            string query = string.Format("delete CHITIETPHIEUNHAPPHUTUNG where maChiTietPhieuNhapPhuTung = '{0}'",maChiTietPNPT);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
