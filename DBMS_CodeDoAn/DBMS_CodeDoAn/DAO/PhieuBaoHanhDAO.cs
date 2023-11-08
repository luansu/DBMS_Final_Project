using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class PhieuBaoHanhDAO
    {
        private static PhieuBaoHanhDAO instance;

        public static PhieuBaoHanhDAO Instance
        {
            get { if (instance == null) instance = new PhieuBaoHanhDAO(); return instance; }
            private set => instance = value;
        }

        private PhieuBaoHanhDAO() { }

        public List<PhieuBaoHanh> DanhSachPhieuBaoHanh()
        {
            List<PhieuBaoHanh> listPhieuBaoHanh = new List<PhieuBaoHanh>();

            string query = "select * from PHIEUBAOHANH";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                PhieuBaoHanh phieuBaoHanh = new PhieuBaoHanh(row);
                listPhieuBaoHanh.Add(phieuBaoHanh);
            }

            return listPhieuBaoHanh;
        }

        public bool ThemPhieuBaoHanh(string maHopDongBaoHanh, string maNhanVienThucHien, DateTime ngayNhanXe, DateTime ngayTraXe, DateTime ngayLapPhieu)
        {
            string query = string.Format("INSERT INTO PHIEUBAOHANH (maPhieuBaoHanh, maHopDongBaoHanh, maNhanVienThucHien, ngayNhanXe, ngayTraXe, ngayLapPhieu) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                                           maHopDongBaoHanh, maNhanVienThucHien, ngayNhanXe.ToString("yyyy-MM-dd"), ngayTraXe.ToString("yyyy-MM-dd"), ngayLapPhieu.ToString("yyyy-MM-dd"));

            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool CapNhapPhieuBaoHanh(string maPhieuBaoHanh, string maHopDongBaoHanh, string maNhanVienThucHien, DateTime ngayNhanXe, DateTime ngayTraXe, DateTime ngayLapPhieu)
        {
            string query = string.Format("UPDATE PHIEUBAOHANH SET maHopDongBaoHanh = '{0}', maNhanVienThucHien = '{1}', ngayNhanXe = '{2}', ngayTraXe = '{3}', ngayLapPhieu = '{4}' WHERE maPhieuBaoHanh = '{5}'",
                   maHopDongBaoHanh, maNhanVienThucHien, ngayNhanXe.ToString("yyyy-MM-dd"), ngayTraXe.ToString("yyyy-MM-dd"), ngayLapPhieu.ToString("yyyy-MM-dd"), maPhieuBaoHanh);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaPhieuBaoHanh(string maPhieuBaoHanh)
        {
            string query = string.Format("delete PHIEUBAOHANH where maPhieuBaoHanh = '{0}'", maPhieuBaoHanh);
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }
    }
}
