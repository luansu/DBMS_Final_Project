using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class DichVuBaoDuongDAO
    {
        private static DichVuBaoDuongDAO instance;

        public static DichVuBaoDuongDAO Instance
        {
            get { if (instance == null) instance = new DichVuBaoDuongDAO(); return instance; }
            private set => instance = value;
        }

        private DichVuBaoDuongDAO() { }

        public List<DichVuBaoDuong> DanhSachDichVuBaoDuong()
        {
            List<DichVuBaoDuong> listBaoDuong = new List<DichVuBaoDuong>();

            string query = "select * from DICHVUBAODUONG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                DichVuBaoDuong baoDuong = new DichVuBaoDuong(row);
                listBaoDuong.Add(baoDuong);
            }

            return listBaoDuong;
        }

        public bool ThemDichVuBaoDuong(string tenBaoDuong, string loaiBaoDuong, float phiBaoDuong)
        {
            string query = string.Format("insert into DICHVUBAODUONG(tenBaoDuong, loaiBaoDuong, phiBaoDuong) values (N'{0}', N'{1}', {2})", tenBaoDuong, loaiBaoDuong, phiBaoDuong);

            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool XoaDichVuBaoDuong(string maBaoDuong)
        {
            string query = string.Format("delete DICHVUBAODUONG where maBaoDuong = '{0}'", maBaoDuong);

            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool CapNhatDichVuBaoDuong(string maBaoDuong, string tenBaoDuong, string loaiBaoDuong, float phiBaoDuong)
        {
            string query = string.Format("update DICHVUBAODUONG set tenBaoDuong = N'{0}', loaiBaoDuong = N'{1}', phiBaoDuong = {2} where maBaoDuong = '{3}'", tenBaoDuong, loaiBaoDuong, phiBaoDuong, maBaoDuong);

            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
    }
}
