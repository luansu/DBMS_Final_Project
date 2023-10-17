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

            string query = "select * from CHITIETPHIEUBAODUONG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ChiTietPhieuBaoDuong chiTietPhieuBaoDuong = new ChiTietPhieuBaoDuong(row);
                listChiTietBaoDuong.Add(chiTietPhieuBaoDuong);
            }

            return listChiTietBaoDuong;
        }
    }
}
