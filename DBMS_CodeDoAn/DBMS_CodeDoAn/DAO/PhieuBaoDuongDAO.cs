using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class PhieuBaoDuongDAO
    {
        private static PhieuBaoDuongDAO instance;

        public static PhieuBaoDuongDAO Instance
        {
            get { if (instance == null) instance = new PhieuBaoDuongDAO(); return instance; }
            private set => instance = value;
        }

        private PhieuBaoDuongDAO() { }

        public List<PhieuBaoDuong> DanhSachPhieuBaoDuong()
        {
            List<PhieuBaoDuong> listPhieuBaoDuong = new List<PhieuBaoDuong>();

            string query = "select * from PHIEUBAODUONG";
            
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                PhieuBaoDuong phieuBaoDuong = new PhieuBaoDuong(row);
                listPhieuBaoDuong.Add(phieuBaoDuong);
            }

            return listPhieuBaoDuong;
        }

        public bool ThemPhieuBaoDuong(string ngayLapPhieu, float tongTien, string maKhachHang, string maNhanVienThucHien)
        {
            string query = string.Format("insert into PHIEUBAODUONG(ngayLapPhieu, tongTien, maKhachHang, maNhanVienThucHien) values('{0}', {1}, '{2}', '{3}')", ngayLapPhieu.Substring(0, 10), tongTien, maKhachHang, maNhanVienThucHien);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool CapNhatPhieuBaoDuong(string maPhieuBaoDuong, string ngayLapPhieu, float tongTien, string maKhachHang, string maNhanVienThucHien)
        {
            string query = string.Format("update PHIEUBAODUONG set ngayLapPhieu = '{0}', tongTien = {1}, maKhachHang = '{2}', maNhanVienThucHien = '{3}' where maPhieuBaoDuong = '{4}'", ngayLapPhieu, tongTien, maKhachHang, maNhanVienThucHien, maPhieuBaoDuong);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaPhieuBaoDuong(string maPhieuBaoDuong)
        {
            string query = string.Format("delete PHIEUBAODUONG where maPhieuBaoDuong = '{0}'", maPhieuBaoDuong);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
