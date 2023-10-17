using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class TaiKhoan
    {
        private string tenDangNhap;
        private string matKhau;
        private string chucVu;
        private string maNhanVien;
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }

        public TaiKhoan(string tenDangNhap, string matKhau, string chucVu, string maNhanVien)
        {
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.ChucVu = chucVu;
            this.MaNhanVien = maNhanVien;
        }

        public TaiKhoan(DataRow row)
        {
            this.TenDangNhap = row["tenDangNhap"].ToString();
            this.MatKhau = row["matKhau"].ToString();
            this.ChucVu = row["chucVu"].ToString();
            this.MaNhanVien = row["maNhanVien"].ToString();
        }
    }
}
