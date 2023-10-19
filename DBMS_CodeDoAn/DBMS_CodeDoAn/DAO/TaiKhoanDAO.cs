
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance 
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set => instance = value; 
        }

        private TaiKhoanDAO() { }

        public bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            string query = "select * from TAIKHOAN where tenDangNhap = '" + taiKhoan + "' and matKhau = '" + matKhau + "' ";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            return data.Rows.Count > 0;
        }
    }
}
