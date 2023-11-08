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

            string query = "exec List_NhaCungCap";

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
            string query = string.Format("exec Insert_NhaCungCap @maNhaCungCap , @tenNhaCungCap , @diaChi , @soDienThoai ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai });
            return result > 0;
        }

        public bool CapNhatNhaCungCap(string maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai)
        {
            string query = string.Format("exec Update_NhaCungCap @maNhaCungCap , @tenNhaCungCap , @diaChi , @soDienThoai ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai });
            return result > 0;
        }

        public bool XoaNhaCungCap(string maNhaCungCap)
        {
            string query = string.Format("exec Delete_NhaCungCap @maNhaCungCap ");
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { maNhaCungCap }) > 0;
        }
    }
}
