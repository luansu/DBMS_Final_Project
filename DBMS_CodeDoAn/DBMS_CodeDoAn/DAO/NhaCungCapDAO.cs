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

        public bool ThemNhaCungCap(string maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai)
        {
            string query = string.Format("insert into NHACUNGCAP(maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai) values('{0}', N'{1}', N'{2}', N'{3}')", maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool CapNhatNhaCungCap(string maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai)
        {
            string query = string.Format("Update NHACUNGCAP set tenNhaCungCap = N'{0}', diaChi = N'{1}', soDienThoai = N'{2}' where maNhaCungCap = '{3}'", tenNhaCungCap, diaChi, soDienThoai, maNhaCungCap);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaNhaCungCap(string maNhaCungCap)
        {
            string query = string.Format("delete NHACUNGCAP where maNhaCungCap = '{0}'", maNhaCungCap);
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }
    }
}
