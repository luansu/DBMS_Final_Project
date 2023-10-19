using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiTietPhieuNhapXeDAO
    {
        private static ChiTietPhieuNhapXeDAO instance;

        public static ChiTietPhieuNhapXeDAO Instance 
        {
            get { if (instance == null) instance = new ChiTietPhieuNhapXeDAO(); return instance; }
            private set => instance = value; 
        }

        private ChiTietPhieuNhapXeDAO() { }

        public List<ChiTietPhieuNhapXe> DanhSachChiTietPhieuNhapXe()
        {
            List<ChiTietPhieuNhapXe> listCTPNXe = new List<ChiTietPhieuNhapXe> ();

            string query = "select * from CHITIETPHIEUNHAPXE";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ChiTietPhieuNhapXe ctpnXe = new ChiTietPhieuNhapXe(row);
                listCTPNXe.Add(ctpnXe);
            }

            return listCTPNXe;
        }
    }
}
