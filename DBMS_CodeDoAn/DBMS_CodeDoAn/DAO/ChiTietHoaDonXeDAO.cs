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

            string query = "select * from CHITIETHOADONXE";

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
            string query = string.Format("insert into CHITIETHOADONXE(maHoaDon, maXe, ngayNhanXe, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo) values ('{0}', '{1}', '{2}', {3}, {4}, {5}, {6}, {7}, {8})", maHoaDon, maXe, ngayNhanXe.Substring(0, 10), soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool CapNhatChiTietHoaDonXe(string maChiTietHoaDonXe, string maHoaDon, string maXe, string ngayNhanXe, float soTienDaTra, float phiDangKyBienSo, float phiDangKiem, float phiTruocBa, float phiBaoHiemTrachNhiemDanSu, float phiSuDungDuongBo)
        {
            string query = string.Format("update CHITIETHOADONXE set maHoaDon = '{0}', maXe = '{1}', ngayNhanXe = '{2}', soTienDaTra = {3}, phiDangKyBienSo = {4}, phiDangKiem = {5}, phiTruocBa = {6}, phiBaoHiemTrachNhiemDanSu = {7}, phiSuDungDuongBo = {8} where maChiTietHoaDonXe = '{9}'", maHoaDon, maXe, ngayNhanXe.Substring(0, 10), soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo, maChiTietHoaDonXe);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaChiTietHoaDonXe(string maChiTietHoaDonXe)
        {
            string query = string.Format("delete CHITIETHOADONXE where maChiTietHoaDonXe = '{0}'", maChiTietHoaDonXe);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
