using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiTietPhieuNhapPhuTungDAO
    {
        private static ChiTietPhieuNhapPhuTungDAO instance;

        public static ChiTietPhieuNhapPhuTungDAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuNhapPhuTungDAO(); return instance; }
            private set => instance = value;
        }

        private ChiTietPhieuNhapPhuTungDAO() { }

        public List<ChiTietPhieuNhapPhuTung> DanhSachChiTietPhieuNhapPhuTung()
        {
            List<ChiTietPhieuNhapPhuTung> listDanhSachCTPNPTung = new List<ChiTietPhieuNhapPhuTung> ();

            string query = "exec list_CHITIETPHIEUNHAPPHUTUNG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ChiTietPhieuNhapPhuTung ctpnPTung = new ChiTietPhieuNhapPhuTung(row);
                listDanhSachCTPNPTung.Add(ctpnPTung);
            }

            return listDanhSachCTPNPTung;
        }
        public bool ThemChiTietPhieuNhapPhuTung(string maPhuTung, string maPhieuNhap, float giaNhap, int soLuong)
        {
            string query = string.Format("exec Insert_CHITIETPHIEUNHAPPHUTUNG @maPhuTung , @maPhieuNhap , @giaNhap , @soLuong ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maPhuTung, maPhieuNhap, giaNhap, soLuong });
            return result > 0;
        }

        public bool CapNhatChiTietPhieuNhapPhuTung(string maChiTietPNPT, string maPhuTung, string maPhieuNhap, float giaNhap, int soLuong)
        {
            string query = string.Format("exec Update_CHITIETPHIEUNHAPPHUTUNG @maChiTietPhieuNhapPhuTung , @maPhuTung , @maPhieuNhap , @giaNhap , @soLuong ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maChiTietPNPT, maPhuTung, maPhieuNhap, giaNhap, soLuong });
            return result > 0;
        }

        public bool XoaChiTietPhieuNhapPhuTung(string maChiTietPNPT)
        {
            string query = string.Format("exec Delete_CHITIETPHIEUNHAPPHUTUNG  @maChiTietPhieuNhapPhuTung ", maChiTietPNPT);
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maChiTietPNPT });
            return result > 0;
        }
    }
}
