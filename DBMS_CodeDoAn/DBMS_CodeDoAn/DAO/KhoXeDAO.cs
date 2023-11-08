using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class KhoXeDAO
    {
        private static KhoXeDAO instance;

        public static KhoXeDAO Instance 
        {
            get { if (instance == null) instance = new KhoXeDAO(); return instance; }
            private set => instance = value; 
        }
        private KhoXeDAO() { }

        public List<KhoXe> DanhSachKhoXe()
        {
            List<KhoXe> listKhoXe = new List<KhoXe>();

            string query = "select * from KHOXE";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows) 
            {
                KhoXe khoXe = new KhoXe(row);
                listKhoXe.Add(khoXe);
            }

            return listKhoXe;
        }
    }
}
