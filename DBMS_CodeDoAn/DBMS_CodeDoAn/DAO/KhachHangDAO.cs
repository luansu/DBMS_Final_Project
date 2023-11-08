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

        public bool ThemKhachHang(string hoTenKH, string ngaySinh, string gioiTinh, string CCCD, string diaChi, string soDienThoai)
        {
            string query = string.Format("insert into KHACHHANG(hoTenKhachHang, ngaySinh, gioiTinh, CCCD, diaChi, soDienThoai) values (N'{0}', '{1}', N'{2}', '{3}', N'{4}', '{5}')", 
                hoTenKH, ngaySinh.ToString().Substring(0, 10), gioiTinh, CCCD, diaChi, soDienThoai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool CapNhatKhachHang(string maKhachHang, string hoTenKH, string ngaySinh, string gioiTinh, string CCCD, string diaChi, string soDienThoai)
        {
            string query = string.Format("Update KHACHHANG set hoTenKhachHang = N'{0}', ngaySinh = '{1}', gioiTinh = N'{2}', CCCD = '{3}', diaChi = N'{4}', soDienThoai = '{5}' where maKhachHang = '{6}'",
                hoTenKH, ngaySinh.ToString().Substring(0, 10), gioiTinh, CCCD, diaChi, soDienThoai, maKhachHang);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaKhachHang(string maKhachHang)
        {
            string query = string.Format("delete KHACHHANG where maKhachHang = '{0}'", maKhachHang);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<KhachHang> TimKiemThongTinKhachHang(string hoTenKH, string CCCD, string diaChi, string soDienThoai)
        {
            List<KhachHang> listKhachHang = new List<KhachHang>();

            string query = string.Format("select * from KHACHHANG where hoTenKhachHang like N'%{0}%' and CCCD like N'%{1}%' and diaChi like N'%{2}%' and soDienThoai like N'%{3}%'", hoTenKH, CCCD, diaChi, soDienThoai);

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                KhachHang khachHang = new KhachHang(row);
                listKhachHang.Add(khachHang);
            }

            return listKhachHang;
        }
    }
}
