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

            string query = "exec List_PhieuNhap";

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
            string query = string.Format("exec Insert_PhieuNhap @ngayNhap , @maChiNhanh , @maNhaCungCap ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {ngayNhap.Substring(0, 10), maChiNhanh, maNhaCungCap });
            return result > 0;
        }

        public bool CapNhatPhieuNhap(string maPhieuNhap, string ngayNhap, string maChiNhanh, string maNhaCungCap)
        {
            string query = string.Format("exec Update_PhieuNhap @maPhieuNhap , @ngayNhap , @maChiNhanh , @maNhaCungCap ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maPhieuNhap, ngayNhap.Substring(0, 10), maChiNhanh, maNhaCungCap });
            return result > 0;
        }

        public bool XoaPhieuNhap(string maPhieuNhap)
        {
            string query = string.Format("exec Delete_PhieuNhap @maPhieuNhap ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maPhieuNhap });
            return result > 0;
        }
    }
}
