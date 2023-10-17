using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiTietHoaDonXeDAO
    {
        private static ChiTietHoaDonXeDAO instance;

        public static ChiTietHoaDonXeDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonXeDAO(); return instance; }
            private set => instance = value;
        }

        private ChiTietHoaDonXeDAO() { }

        public List<ChiTietHoaDonXe> DanhSachHoaDonXe()
        {
            List<ChiTietHoaDonXe> listHoaDonXe = new List<ChiTietHoaDonXe>();

            string query = "select * from CHITIETHOADONXE";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                ChiTietHoaDonXe hoaDonXe = new ChiTietHoaDonXe(row);
                listHoaDonXe.Add(hoaDonXe);
            }

            return listHoaDonXe;
        }
    }
}
