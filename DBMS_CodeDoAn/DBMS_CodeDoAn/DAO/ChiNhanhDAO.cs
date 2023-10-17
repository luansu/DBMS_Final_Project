using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiNhanhDAO
    {
        private static ChiNhanhDAO instance;
        public static ChiNhanhDAO Instance 
        {
            get { if (instance == null) instance = new ChiNhanhDAO(); return instance; }
            private set => instance = value; 
        }

        private ChiNhanhDAO() { }

        public List<ChiNhanh> DanhSachChiNhanh()
        {
            List<ChiNhanh> listChiNhanh = new List<ChiNhanh>();

            string query = "select * from CHINHANH";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                ChiNhanh chiNhanh = new ChiNhanh(row);
                listChiNhanh.Add(chiNhanh);
            }

            return listChiNhanh;
        }
    }
}
