using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class HopDongBaoHanh
    {
        private string maHopDongBaoHanh;
        private string maXe;
        private string maKhachHang;
        private DateTime ngayKyBaoHanh;
        private DateTime thoiHanBaoHanh;
        private string tinhTrang;

        public string MaHopDongBaoHanh { get => maHopDongBaoHanh; set => maHopDongBaoHanh = value; }
        public string MaXe { get => maXe; set => maXe = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public DateTime NgayKyBaoHanh { get => ngayKyBaoHanh; set => ngayKyBaoHanh = value; }
        public DateTime ThoiHanBaoHanh { get => thoiHanBaoHanh; set => thoiHanBaoHanh = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        // Constructor
        public HopDongBaoHanh(string maHopDongBaoHanh, string maXe, string maKhachHang,
            DateTime ngayKyBaoHanh, DateTime thoiHanBaoHanh, string tinhTrang)
        {
            this.maHopDongBaoHanh = maHopDongBaoHanh;
            this.maXe = maXe;
            this.maKhachHang = maKhachHang;
            this.ngayKyBaoHanh = ngayKyBaoHanh;
            this.thoiHanBaoHanh = thoiHanBaoHanh;
            this.tinhTrang = tinhTrang;
        }

        public HopDongBaoHanh(DataRow row)
        {
            this.maHopDongBaoHanh = row["maHopDongBaoHanh"].ToString();
            this.maXe = row["maXe"].ToString();
            this.maKhachHang = row["maKhachHang"].ToString();
            this.ngayKyBaoHanh = (DateTime)row["ngayKyBaoHanh"];
            this.thoiHanBaoHanh = (DateTime)row["thoiHanBaoHanh"];
            this.tinhTrang = row["tinhTrang"].ToString();
        }
    }
}
