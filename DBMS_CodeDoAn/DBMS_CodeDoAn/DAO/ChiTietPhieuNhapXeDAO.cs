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

            string query = "exec list_CHITIETPHIEUNHAPXE";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ChiTietPhieuNhapXe ctpnXe = new ChiTietPhieuNhapXe(row);
                listCTPNXe.Add(ctpnXe);
            }

            return listCTPNXe;
        }

        public bool ThemChiTietPhieuNhapXe(string maLoXe, string maPhieuNhap, float giaNhap, int soLuong)
        {
            string query = string.Format("exec Insert_CHITIETPHIEUNHAPXE @maLoXe , @maPhieuNhap , @giaNhap , @soLuong  ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maLoXe, maPhieuNhap, giaNhap, soLuong });
            return result > 0;
        }

        public bool CapNhatChiTietPhieuNhapXe(string maChiTietPhieuNhapXe, string maLoXe, string maPhieuNhap, float giaNhap, int soLuong)
        {
            string query = string.Format("exec Update_CHITIETPHIEUNHAPXE @maChiTietPhieuNhapXe , @maLoXe , @maPhieuNhap , @giaNhap , @soLuong ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maChiTietPhieuNhapXe, maLoXe, maPhieuNhap, giaNhap, soLuong});
            return result > 0;
        }

        public bool XoaChiTietPhieuNhapXe(string maChiTietPhieuNhapXe)
        {
            string query = string.Format("exec Delete_CHITIETPHIEUNHAPXE @maChiTietPhieuNhapXe ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maChiTietPhieuNhapXe });
            return result > 0;
        }
    }
}
