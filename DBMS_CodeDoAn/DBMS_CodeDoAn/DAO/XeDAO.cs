using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class XeDAO
    {
        private static XeDAO instance;

        public static XeDAO Instance 
        {
            get { if (instance == null) instance = new XeDAO(); return instance; }
            private set => instance = value; 
        }

        private XeDAO() { }

        public List<string> DanhSachLoXe()
        {
            List<string> listLoXe = new List<string>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select maLoXe from LOXE");

            foreach (DataRow row in data.Rows)
            {
                string maLoXe = row["maLoXe"].ToString();
                listLoXe.Add(maLoXe);
            }

            return listLoXe;
        }

        public List<Xe> DanhSachXeTheoLo(string maLoXe)
        {
            List<Xe> listXe = new List<Xe>();

            string query = "select * from Xe where maLoXe = '" + maLoXe + "'";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Xe xe = new Xe(row);
                listXe.Add(xe);
            }

            return listXe;
        }
    }
}
