using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class XeDAO
    {
        private static XeDAO instance;

        public static XeDAO Instance 
        {
            get { if (instance == null) instance = new XeDAO(); return instance; }
            private set => instance = value; 
        }

        private XeDAO() { }

        public List<string> DanhSachLoXe()
        {
            List<string> listLoXe = new List<string>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select maLoXe from LOXE");

            foreach (DataRow row in data.Rows)
            {
                string maLoXe = row["maLoXe"].ToString();
                listLoXe.Add(maLoXe);
            }

            return listLoXe;
        }

        public List<string> DanhSachMaXe()
        {
            List<string> listMaXe = new List<string>();

            string query = "select maXe from XE";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                string maXe = row["maXe"].ToString();
                listMaXe.Add(maXe);
            }

            return listMaXe;
        }

        public List<string> DanhSachMaLoXe()
        {
            List<string> listMaLoXe = new List<string>();

            string query = "select maLoXe from LOXE";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                string maLoXe = row["maLoXe"].ToString();
                listMaLoXe.Add(maLoXe);
            }

            return listMaLoXe;
        }

        public List<Xe> DanhSachXeTheoLo(string maLoXe)
        {
            List<Xe> listXe = new List<Xe>();

            string query = "exec sp_ThongTinXeTheoLo @maLoXe = '" + maLoXe + "'";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Xe xe = new Xe(row);
                listXe.Add(xe);
            }

            return listXe;
        }

        public bool ThemLoXe(string maLoXe, string tenXe, string mauSac, decimal giaBan, int soChoNgoi, string xuatXu, string hangXe, string loaiXe, string phienBanXe, int tocDoToiDa, decimal trongLuong, decimal trongTai, string loaiNhienLieu, decimal congSuatDongCo, decimal dungTichDongCo, string loaiDongCo, decimal khoangSangGam, decimal chieuDaiCoSo, decimal chieuDai, decimal chieuRong, decimal chieuCao, decimal banKinhQuayVong, string hinhAnh, string moTa)
        {
            string query = string.Format("INSERT INTO LOXE (maLoXe, tenXe, mauSac, giaBan, soChoNgoi, xuatXu, hangXe, loaiXe, phienBanXe, tocDoToiDa, trongLuong, trongTai, loaiNhienLieu, congSuatDongCo, dungTichDongCo, loaiDongCo, khoangSangGam, chieuDaiCoSo, chieuDai, chieuRong, chieuCao, banKinhQuayVong, hinhAnh, moTa) " +
                "VALUES ('{0}', '{1}', '{2}', {3}, {4}, '{5}', '{6}', '{7}', '{8}', {9}, {10}, {11}, '{12}', {13}, {14}, '{15}', {16}, {17}, {18}, {19}, {20}, '{21}', '{22}')",
                maLoXe, tenXe, mauSac, giaBan, soChoNgoi, xuatXu, hangXe, loaiXe, phienBanXe, tocDoToiDa, trongLuong, trongTai, loaiNhienLieu, congSuatDongCo, dungTichDongCo, loaiDongCo, khoangSangGam, chieuDaiCoSo, chieuDai, chieuRong, chieuCao, banKinhQuayVong, hinhAnh, moTa);

            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool CapNhapLoXe(string maLoXe, string tenXe, string mauSac, decimal giaBan, int soChoNgoi, string xuatXu, string hangXe, string loaiXe, string phienBanXe, int tocDoToiDa, decimal trongLuong, decimal trongTai, string loaiNhienLieu, decimal congSuatDongCo, decimal dungTichDongCo, string loaiDongCo, decimal khoangSangGam, decimal chieuDaiCoSo, decimal chieuDai, decimal chieuRong, decimal chieuCao, decimal banKinhQuayVong, string hinhAnh)
        {
            string query = string.Format("UPDATE LOXE SET tenXe = '{0}', mauSac = '{1}', giaBan = {2}, soChoNgoi = {3}, xuatXu = '{4}', hangXe = '{5}', loaiXe = '{6}', phienBanXe = '{7}', tocDoToiDa = {8}, trongLuong = {9}, trongTai = {10}, loaiNhienLieu = '{11}', congSuatDongCo = {12}, dungTichDongCo = {13}, loaiDongCo = '{14}', khoangSangGam = {15}, chieuDaiCoSo = {16}, chieuDai = {17}, chieuRong = {18}, chieuCao = {19}, banKinhQuayVong = {20}, hinhAnh = '{21}' WHERE maLoXe = '{22}'",
                tenXe, mauSac, giaBan, soChoNgoi, xuatXu, hangXe, loaiXe, phienBanXe, tocDoToiDa, trongLuong, trongTai, loaiNhienLieu, congSuatDongCo, dungTichDongCo, loaiDongCo, khoangSangGam, chieuDaiCoSo, chieuDai, chieuRong, chieuCao, banKinhQuayVong, hinhAnh, maLoXe);

            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaLoXe(string maLoXe)
        {
            string query = string.Format("DELETE FROM LOXE WHERE maLoXe = '{0}'", maLoXe);

            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
