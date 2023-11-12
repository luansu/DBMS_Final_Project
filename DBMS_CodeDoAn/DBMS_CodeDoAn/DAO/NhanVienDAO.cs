using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance 
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; } 
            private set => instance = value; 
        }

        private NhanVienDAO() { }

        public List<NhanVien> DanhSachNhanVienTheoChiNhanh(string maChiNhanh)
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();

            string query = "select * from fn_LayDanhSachNhanVienTheoChiNhanh ("+ maChiNhanh + ")";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows) 
            {
                NhanVien nhanVien = new NhanVien(row);
                listNhanVien.Add(nhanVien);
            }
            
            return listNhanVien;
        }
    
        public List<NhanVien> DanhSachNhanVien()
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();

            string query = "select * from NHANVIEN";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                NhanVien nhanVien = new NhanVien(row);
                listNhanVien.Add(nhanVien);
            }

            return listNhanVien;
        }

        public bool ThemNhanVien(string maNhanVien, string hoTenNhanVien, string CCCD, string ngaySinh, string gioiTinh, string diaChi, string soDienThoai, string chucVu, int tinhTrangLamViec, string maChiNhanh, string hinhAnh)
        {
            string query = string.Format("exec Insert_NhanVien @hoTenNhanVien , @CCCD , @ngaySinh , @gioiTinh , @diaChi , @soDienThoai , @chucVu , @tinhTrangLamViec , @maChiNhanh , @hinhAnh ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {hoTenNhanVien, CCCD, ngaySinh.Substring(0, 10), gioiTinh, diaChi, soDienThoai, chucVu, tinhTrangLamViec, maChiNhanh, hinhAnh });
            return result > 0;
        }

        public bool CapNhatNhanVien(string maNhanVien, string hoTenNhanVien, string CCCD, string ngaySinh, string gioiTinh, string diaChi, string soDienThoai, string chucVu, int tinhTrangLamViec, string maChiNhanh, string hinhAnh)
        {
            string query = string.Format("update NHANVIEN set hoTenNhanVien = N'{0}', CCCD = '{1}', ngaySinh = '{2}', gioiTinh = N'{3}', diaChi = N'{4}', soDienThoai = '{5}', chucVu = N'{6}', tinhTrangLamViec = {7}, maChiNhanh = '{8}', hinhAnh = '{9}' where maNhanVien = '{10}'", hoTenNhanVien, CCCD, ngaySinh.Substring(0, 10), gioiTinh, diaChi, soDienThoai, chucVu, tinhTrangLamViec, maChiNhanh, hinhAnh, maNhanVien);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaNhanVien(string maNhanVien)
        {
            string query = string.Format("delete NHANVIEN where maNhanVien = '{0}'", maNhanVien);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<NhanVien> TimKiemThongTinNhanVien(string hoTenNhanVien, string CCCD, string diaChi, string soDienThoai, string chucVu, string maChiNhanh)
        {
            List<NhanVien> listNhanVien = new List<NhanVien>();

            string query = string.Format("select * from NHANVIEN where hoTenNhanVien like N'%{0}%' and CCCD like N'%{1}%' and diaChi like N'%{2}%' and soDienThoai like N'%{3}%' and chucVu like N'%{4}%' and maChiNhanh like N'%{5}%'", hoTenNhanVien, CCCD, diaChi, soDienThoai, chucVu, maChiNhanh);

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                NhanVien nhanVien = new NhanVien(row);
                listNhanVien.Add(nhanVien);
            }

            return listNhanVien;
        }
    }
}
