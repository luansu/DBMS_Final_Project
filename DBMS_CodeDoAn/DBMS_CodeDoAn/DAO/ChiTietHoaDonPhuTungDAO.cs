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
    }
}
