using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set => instance = value;
        }

        private KhachHangDAO() { }

        public List<KhachHang> DanhSachKhachHang()
        {
            List<KhachHang> listKhachHang = new List<KhachHang>();

            string query = "select * from KHACHHANG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                KhachHang khachHang = new KhachHang(row);
                listKhachHang.Add(khachHang);
            }

            return listKhachHang;
        }

        public bool ThemKhachHang(string hoTenKH, DateTime ngaySinh, string gioiTinh, string CCCD, string diaChi, string soDienThoai)
        {
            string query = string.Format("insert into KHACHHANG(hoTenKhachHang, ngaySinh, diaChi, gioiTinh, CCCD, soDienThoai) values (N'{0}', '{1}', N'{2}', '{3}', N'{4}', '{5}')", 
                hoTenKH, ngaySinh, gioiTinh, CCCD, diaChi, soDienThoai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
