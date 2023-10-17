using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class DichVuBaoDuongDAO
    {
        private static DichVuBaoDuongDAO instance;

        public static DichVuBaoDuongDAO Instance
        {
            get { if (instance == null) instance = new DichVuBaoDuongDAO(); return instance; }
            private set => instance = value;
        }

        private DichVuBaoDuongDAO() { }

        public List<DichVuBaoDuong> DanhSachDichVuBaoDuong()
        {
            List<DichVuBaoDuong> listBaoDuong = new List<DichVuBaoDuong>();

            string query = "select * from DICHVUBAODUONG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                DichVuBaoDuong baoDuong = new DichVuBaoDuong(row);
                listBaoDuong.Add(baoDuong);
            }

            return listBaoDuong;
        }
    }
}
