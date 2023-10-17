using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class NhaCungCap
    {
        private string maNhaCungCap;
        private string tenNhaCungCap;
        private string diaChi;
        private string soDienThoai;
        public string MaNhaCungCap { get => maNhaCungCap; set => maNhaCungCap = value; }
        public string TenNhaCungCap { get => tenNhaCungCap; set => tenNhaCungCap = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }

        // Hàm dựng
        public NhaCungCap(string maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai)
        {
            this.MaNhaCungCap = maNhaCungCap;
            this.TenNhaCungCap = tenNhaCungCap;
            this.DiaChi = diaChi;
            this.SoDienThoai = soDienThoai;
        }

        public NhaCungCap(DataRow row)
        {
            this.MaNhaCungCap = row["maNhaCungCap"].ToString();
            this.TenNhaCungCap = row["tenNhaCungCap"].ToString();
            this.DiaChi = row["diaChi"].ToString();
            this.SoDienThoai = row["soDienThoai"].ToString();
        }
    }
}
