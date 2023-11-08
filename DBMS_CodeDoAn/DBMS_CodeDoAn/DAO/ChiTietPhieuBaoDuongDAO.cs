using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiTietPhieuBaoDuongDAO
    {
        private static ChiTietPhieuBaoDuongDAO instance;

        public static ChiTietPhieuBaoDuongDAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuBaoDuongDAO(); return instance; }
            private set => instance = value;
        }

        private ChiTietPhieuBaoDuongDAO() { }

        public List<ChiTietPhieuBaoDuong> DanhSachChiTieuPhieuBaoDuong()
        {
            List<ChiTietPhieuBaoDuong> listChiTietBaoDuong = new List<ChiTietPhieuBaoDuong>();

            string query = "exec list_CHITIETPHIEUBAODUONG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ChiTietPhieuBaoDuong chiTietPhieuBaoDuong = new ChiTietPhieuBaoDuong(row);
                listChiTietBaoDuong.Add(chiTietPhieuBaoDuong);
            }

            return listChiTietBaoDuong;
        }

        public bool ThemChiTietPhieuBaoDuong(string maBaoDuong, string maPhieuBaoDuong, float thanhTien)
        {
            string query = "exec Insert_CHITIETPHIEUBAODUONG @maBaoDuong , @maPhieuBaoDuong , @thanhTien ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maBaoDuong, maPhieuBaoDuong, thanhTien});
            return result > 0;
        }

        public bool CapNhatChiTietPhieuBaoDuong(string maChiTietPhieuBD, string maBaoDuong, string maPhieuBaoDuong, float thanhTien)
        {
            string query = "exec Update_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong , @maBaoDuong , @maPhieuBaoDuong , @thanhTien  ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maChiTietPhieuBD, maBaoDuong, maPhieuBaoDuong, thanhTien });
            return result > 0;
        }

        public bool XoaChiTietPhieuBaoDuong(string maChiTietPhieuBD)
        {
            string query = "exec Delete_CHITIETPHIEUBAODUONG @maChiTietPhieuBaoDuong ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maChiTietPhieuBD });
            return result > 0;
        }
    }
}
