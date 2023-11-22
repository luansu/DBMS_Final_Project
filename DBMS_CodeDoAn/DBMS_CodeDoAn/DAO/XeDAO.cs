using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

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

        public List<string> DanhSachMaXe()
        {
            List<string> listMaXe = new List<string>();

            string query = "select maXe from XE";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                string maXe = row["maXe"].ToString();
                listMaXe.Add(maXe);
            }

            return listMaXe;
        }

        public List<string> DanhSachMaLoXe()
        {
            List<string> listMaLoXe = new List<string>();

            string query = "select maLoXe from LOXE";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                string maLoXe = row["maLoXe"].ToString();
                listMaLoXe.Add(maLoXe);
            }

            return listMaLoXe;
        }

        public List<Xe> DanhSachXe()
        {
            List<Xe> listXe = new List<Xe>();   
            string query = "select * from XE inner join LOXE on XE.maLoXe = LOXE.maLoXe";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Xe xe = new Xe(row);
                listXe.Add(xe);
            }

            return listXe;
        }

        public List<Xe> DanhSachXeTheoLo(string maLoXe)
        {
            List<Xe> listXe = new List<Xe>();

            string query = "exec sp_ThongTinXeTheoLo @maLoXe = '" + maLoXe + "'";

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
