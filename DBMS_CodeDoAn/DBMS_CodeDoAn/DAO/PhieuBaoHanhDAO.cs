using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class PhieuBaoHanhDAO
    {
        private static PhieuBaoHanhDAO instance;

        public static PhieuBaoHanhDAO Instance
        {
            get { if (instance == null) instance = new PhieuBaoHanhDAO(); return instance; }
            private set => instance = value;
        }

        private PhieuBaoHanhDAO() { }

        public List<PhieuBaoHanh> DanhSachPhieuBaoHanh()
        {
            List<PhieuBaoHanh> listPhieuBaoHanh = new List<PhieuBaoHanh>();

            string query = "select * from PHIEUBAOHANH";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                PhieuBaoHanh phieuBaoHanh = new PhieuBaoHanh(row);
                listPhieuBaoHanh.Add(phieuBaoHanh);
            }

            return listPhieuBaoHanh;
        }
    }
}
