using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance 
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; } 
            private set => instance = value; 
        }

        private NhanVienDAO() { }

        public List<NhanVien> DanhSachNhanVienTheoChiNhanh(string maChiNhanh)
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();

            string query = "select * from NhanVien where maChiNhanh = '" + maChiNhanh + "'";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows) 
            {
                NhanVien nhanVien = new NhanVien(row);
                listNhanVien.Add(nhanVien);
            }
            
            return listNhanVien;
        }
    
        public List<NhanVien> DanhSachNhanVien()
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();

            string query = "select * from NHANVIEN";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                NhanVien nhanVien = new NhanVien(row);
                listNhanVien.Add(nhanVien);
            }

            return listNhanVien;
        }
    }
}
