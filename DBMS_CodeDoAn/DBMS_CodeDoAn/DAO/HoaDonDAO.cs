using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set => instance = value;
        }

        private HoaDonDAO() { }

        public List<HoaDon> DanhSachHoaDon()
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();

            string query = "select * from HOADON";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                HoaDon hoaDon = new HoaDon(row);
                listHoaDon.Add(hoaDon);
            }

            return listHoaDon;
        }
    }
}
