using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set => instance = value;
        }

        private HoaDonDAO() { }

        public List<HoaDon> DanhSachHoaDon()
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();

            string query = "select * from HOADON";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                HoaDon hoaDon = new HoaDon(row);
                listHoaDon.Add(hoaDon);
            }

            return listHoaDon;
        }

        public bool ThemHoaDon(string ngayLapHoaDon, float tongTien, string tinhTrang, string maKhachHang, string maNVTH)
        {
            string query = string.Format("insert into HOADON(ngayLapHoaDon, tongTien, tinhTrang, maKhachHang, maNhanVienThucHien) values('{0}', {1}, N'{2}', '{3}', '{4}')", ngayLapHoaDon.Substring(0, 10), tongTien, tinhTrang, maKhachHang, maNVTH);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool CapNhatHoaDon(string maHoaDon, string ngayLapHoaDon, float tongTien, string tinhTrang, string maKhachHang, string maNVTH)
        {
            string query = string.Format("update HOADON set ngayLapHoaDon = '{0}', tongTien = {1}, tinhTrang = N'{2}', maKhachHang = '{3}', maNhanVienThucHien = '{4}' where maHoaDon = '{5}'", ngayLapHoaDon.Substring(0, 10), tongTien, tinhTrang, maKhachHang, maNVTH, maHoaDon);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaHoaDon(string maHoaDon)
        {
            string query = string.Format("delete HOADON where maHoaDon = '{0}'", maHoaDon);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
