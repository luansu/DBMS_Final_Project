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

            string query = "exec list_HOADON";

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
            string query = string.Format("exec Insert_HOADON @ngayLapHoaDon , @tongTien , @tinhTrang , @maKhachHang , @maNhanVienThucHien ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {ngayLapHoaDon.Substring(0, 10), tongTien, tinhTrang, maKhachHang, maNVTH });
            return result > 0;
        }

        public bool CapNhatHoaDon(string maHoaDon, string ngayLapHoaDon, float tongTien, string tinhTrang, string maKhachHang, string maNVTH)
        {
            string query = string.Format("exec Update_HOADON @maHoaDon , @ngayLapHoaDon , @tongTien , @tinhTrang , @maKhachHang , @maNhanVienThucHien ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maHoaDon, ngayLapHoaDon.Substring(0, 10), tongTien, tinhTrang, maKhachHang, maNVTH });
            return result > 0;
        }

        public bool XoaHoaDon(string maHoaDon)
        {
            string query = string.Format("exec Delete_HOADON @maHoaDon ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maHoaDon});
            return result > 0;
        }
    }
}
