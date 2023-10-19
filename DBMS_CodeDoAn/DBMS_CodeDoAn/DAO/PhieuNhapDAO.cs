using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class PhieuNhapDAO
    {
        private static PhieuNhapDAO instance;

        public static PhieuNhapDAO Instance 
        {
            get { if (instance == null) instance = new PhieuNhapDAO(); return instance; }
            private set => instance = value; 
        }
        private PhieuNhapDAO() { }

        public List<PhieuNhap> DanhSachPhieuNhap()
        {
            List<PhieuNhap> listPhieuNhap = new List<PhieuNhap>();

            string query = "select * from PHIEUNHAP";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows) 
            {
                PhieuNhap phieuNhap = new PhieuNhap(row);
                listPhieuNhap.Add(phieuNhap);
            }

            return listPhieuNhap;
        }

    }
}
