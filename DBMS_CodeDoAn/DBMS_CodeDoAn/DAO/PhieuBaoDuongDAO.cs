using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class PhieuBaoDuongDAO
    {
        private static PhieuBaoDuongDAO instance;

        public static PhieuBaoDuongDAO Instance
        {
            get { if (instance == null) instance = new PhieuBaoDuongDAO(); return instance; }
            private set => instance = value;
        }

        private PhieuBaoDuongDAO() { }

        public List<PhieuBaoDuong> DanhSachPhieuBaoDuong()
        {
            List<PhieuBaoDuong> listPhieuBaoDuong = new List<PhieuBaoDuong>();

            string query = "select * from PHIEUBAODUONG";
            
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                PhieuBaoDuong phieuBaoDuong = new PhieuBaoDuong(row);
                listPhieuBaoDuong.Add(phieuBaoDuong);
            }

            return listPhieuBaoDuong;
        }
    }
}
