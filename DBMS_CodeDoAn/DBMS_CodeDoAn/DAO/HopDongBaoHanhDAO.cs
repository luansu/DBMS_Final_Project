using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class HopDongBaoHanhDAO
    {
        private static HopDongBaoHanhDAO instance;

        public static HopDongBaoHanhDAO Instance
        {
            get { if (instance == null) instance = new HopDongBaoHanhDAO(); return instance; }
            private set => instance = value;
        }

        private HopDongBaoHanhDAO() { }

        public List<HopDongBaoHanh> DanhSachHopDongBaoHanh()
        {
            List<HopDongBaoHanh> listHopDong = new List<HopDongBaoHanh>();

            string query = "select * from HOPDONGBAOHANH";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                HopDongBaoHanh hopDong = new HopDongBaoHanh(row);
                listHopDong.Add(hopDong);
            }

            return listHopDong;
        }
    }
}
