using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        public static NhaCungCapDAO Instance 
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return instance; }
            private set => instance = value; 
        }
        
        private NhaCungCapDAO() { }

        public List<NhaCungCap> DanhSachNhaCungCap()
        {
            List<NhaCungCap> listNhaCungCap = new List<NhaCungCap>();

            string query = "select * from NHACUNGCAP";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                NhaCungCap nhaCungCap = new NhaCungCap(row);
                listNhaCungCap.Add(nhaCungCap);
            }

            return listNhaCungCap;
        }
    }
}
