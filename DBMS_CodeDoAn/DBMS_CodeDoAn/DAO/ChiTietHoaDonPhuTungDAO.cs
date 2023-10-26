using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiTietHoaDonPhuTungDAO
    {
        private static ChiTietHoaDonPhuTungDAO instance;

        public static ChiTietHoaDonPhuTungDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonPhuTungDAO(); return instance; }
            private set => instance = value;
        }

        private ChiTietHoaDonPhuTungDAO() { }

        public List<ChiTietHoaDonPhuTung> DanhSachHoaDonPhuTung()
        {
            List<ChiTietHoaDonPhuTung> listHoaDonPhuTung = new List<ChiTietHoaDonPhuTung>();

            string query = "select * from CHITIETHOADONPHUTUNG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                ChiTietHoaDonPhuTung hoaDonPhuTung = new ChiTietHoaDonPhuTung(row);
                listHoaDonPhuTung.Add(hoaDonPhuTung);
            }

            return listHoaDonPhuTung;
        }

        public bool ThemChiTietHoaDonPhuTung(string maHoaDon, string maPhuTung, float soTienDaTra)
        {
            string query = string.Format("insert into CHITIETHOADONPHUTUNG(maHoaDon, maPhuTung, soTienDaTra) values ('{0}', '{1}', {2})", maHoaDon, maPhuTung, soTienDaTra);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool CapNhatChiTietHoaDonPhuTung(string maChiTietHDPT, string maHoaDon, string maPhuTung, float soTienDaTra)
        {
            string query = string.Format("update CHITIETHOADONPHUTUNG set maHoaDon = '{0}', maPhuTung = '{1}', soTienDaTra = {2} where maChiTietHoaDonPhuTung = '{3}'", maHoaDon, maPhuTung, soTienDaTra, maChiTietHDPT);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaChiTietHoaDonPhuTung(string maChiTietHDPT)
        {
            string query = string.Format("delete CHITIETHOADONPHUTUNG where maChiTietHoaDonPhuTung = '{0}'", maChiTietHDPT);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
