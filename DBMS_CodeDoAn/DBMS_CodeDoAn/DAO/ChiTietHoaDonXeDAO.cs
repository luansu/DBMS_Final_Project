using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiTietHoaDonXeDAO
    {
        private static ChiTietHoaDonXeDAO instance;

        public static ChiTietHoaDonXeDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonXeDAO(); return instance; }
            private set => instance = value;
        }

        private ChiTietHoaDonXeDAO() { }

        public List<ChiTietHoaDonXe> DanhSachCTHDXe()
        {
            List<ChiTietHoaDonXe> listHoaDonXe = new List<ChiTietHoaDonXe>();

            string query = "exec list_CHITIETHOADONXE";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                ChiTietHoaDonXe hoaDonXe = new ChiTietHoaDonXe(row);
                listHoaDonXe.Add(hoaDonXe);
            }

            return listHoaDonXe;
        }

        public bool ThemChiTietHoaDonXe(string maHoaDon, string maXe, string ngayNhanXe, float soTienDaTra, float phiDangKyBienSo, float phiDangKiem, float phiTruocBa, float phiBaoHiemTrachNhiemDanSu, float phiSuDungDuongBo)
        {
            string query = string.Format("exec Insert_CHITIETHOADONXE @maHoaDon , @maXe , @ngayNhanXe , @soTienDaTra , @phiDangKyBienSo , @phiDangKiem , @phiTruocBa , @phiBaoHiemTrachNhiemDanSu , @phiSuDungDuongBo ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maHoaDon, maXe, ngayNhanXe.Substring(0, 10), soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo });
            return result > 0;
        }

        public bool CapNhatChiTietHoaDonXe(string maChiTietHoaDonXe, string maHoaDon, string maXe, string ngayNhanXe, float soTienDaTra, float phiDangKyBienSo, float phiDangKiem, float phiTruocBa, float phiBaoHiemTrachNhiemDanSu, float phiSuDungDuongBo)
        {
            string query = string.Format("exec Update_CHITIETHOADONXE @maChiTietHoaDonXe , @maHoaDon , @maXe , @ngayNhanXe , @soTienDaTra , @phiDangKyBienSo , @phiDangKiem , @phiTruocBa , @phiBaoHiemTrachNhiemDanSu , @phiSuDungDuongBo ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maHoaDon, maXe, ngayNhanXe.Substring(0, 10), soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo, maChiTietHoaDonXe });
            return result > 0;
        }

        public bool XoaChiTietHoaDonXe(string maChiTietHoaDonXe)
        {
            string query = string.Format("exec Delete_CHITIETHOADONXE @maChiTietHoaDonXe ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maChiTietHoaDonXe });
            return result > 0;
        }
    }
}
