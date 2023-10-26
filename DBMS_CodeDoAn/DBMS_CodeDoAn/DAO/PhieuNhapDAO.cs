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

        public bool ThemPhieuNhap(string ngayNhap, string maChiNhanh, string maNhaCungCap)
        {
            string query = string.Format("insert into PHIEUNHAP(ngayNhap, maChiNhanh, maNhaCungCap) values('{0}', '{1}', '{2}')", ngayNhap.Substring(0, 10), maChiNhanh, maNhaCungCap);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool CapNhatPhieuNhap(string maPhieuNhap, string ngayNhap, string maChiNhanh, string maNhaCungCap)
        {
            string query = string.Format("update PHIEUNHAP set ngayNhap = '{0}', maChiNhanh = '{1}', maNhaCungCap = '{2}' where maPhieuNhap = '{3}'", ngayNhap.Substring(0, 10), maChiNhanh, maNhaCungCap, maPhieuNhap);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaPhieuNhap(string maPhieuNhap)
        {
            string query = string.Format("delete PHIEUNHAP where maPhieuNhap = '{0}'", maPhieuNhap);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
