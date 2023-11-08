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

            string query = "exec List_CHITIETHOADONPHUTUNG";

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
            string query = string.Format("exec Insert_CHITIETHOADONPHUTUNG @maHoaDon , @maPhuTung , @soTienDaTra ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maHoaDon, maPhuTung, soTienDaTra });
            return result > 0;
        }

        public bool CapNhatChiTietHoaDonPhuTung(string maChiTietHDPT, string maHoaDon, string maPhuTung, float soTienDaTra)
        {
            string query = string.Format("exec Update_CHITIETHOADONPHUTUNG @maChiTietHoaDonPhuTung , @maHoaDon , @maPhuTung , @soTienDaTra ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maChiTietHDPT, maHoaDon, maPhuTung, soTienDaTra});
            return result > 0;
        }

        public bool XoaChiTietHoaDonPhuTung(string maChiTietHDPT)
        {
            string query = string.Format("exec Delete_CHITIETHOADONPHUTUNG @maChiTietHoaDonPhuTung ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maChiTietHDPT });
            return result > 0;
        }
    }
}
