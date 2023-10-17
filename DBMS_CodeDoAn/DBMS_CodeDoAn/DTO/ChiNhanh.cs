using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class ChiNhanh
    {
        private string maChiNhanh;
        private string tenChiNhanh;
        private string diaChi;
        public string MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }
        public string TenChiNhanh { get => tenChiNhanh; set => tenChiNhanh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        public ChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi)
        {
            this.MaChiNhanh = maChiNhanh;
            this.TenChiNhanh = tenChiNhanh;
            this.DiaChi = diaChi;
        }

        public ChiNhanh(DataRow row)
        {
            this.MaChiNhanh = row["maChiNhanh"].ToString();
            this.TenChiNhanh = row["tenChiNhanh"].ToString();
            this.DiaChi = row["diaChi"].ToString();
        }
    }
}
