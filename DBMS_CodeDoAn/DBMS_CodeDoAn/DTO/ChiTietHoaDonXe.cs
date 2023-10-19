using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class ChiTietHoaDonXe
    {
        private string maChiTietHoaDonXe;
        private string maHoaDon;
        private string maXe;
        private DateTime ngayNhanXe;
        private float soTienDaTra;
        private float phiDangKyBienSo;
        private float phiDangKiem;
        private float phiTruocBa;
        private float phiBaoHiemTrachNhiemDanSu;
        private float phiSuDungDuongBo;

        public string MaChiTietHoaDonXe { get => maChiTietHoaDonXe; set => maChiTietHoaDonXe = value; }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaXe { get => maXe; set => maXe = value; }
        public DateTime NgayNhanXe { get => ngayNhanXe; set => ngayNhanXe = value; }
        public float SoTienDaTra { get => soTienDaTra; set => soTienDaTra = value; }
        public float PhiDangKyBienSo { get => phiDangKyBienSo; set => phiDangKyBienSo = value; }
        public float PhiDangKiem { get => phiDangKiem; set => phiDangKiem = value; }
        public float PhiTruocBa { get => phiTruocBa; set => phiTruocBa = value; }
        public float PhiBaoHiemTrachNhiemDanSu { get => phiBaoHiemTrachNhiemDanSu; set => phiBaoHiemTrachNhiemDanSu = value; }
        public float PhiSuDungDuongBo { get => phiSuDungDuongBo; set => phiSuDungDuongBo = value; }

        // Constructor
        public ChiTietHoaDonXe(string maChiTietHoaDonXe, string maHoaDon, string maXe, 
            DateTime ngayNhanXe, float soTienDaTra, float phiDangKyBienSo, float phiDangKiem,
            float phiTruocBa, float phiBaoHiemTrachNhiemDanSu, float phiSuDungDuongBo)
        {
            this.maChiTietHoaDonXe = maChiTietHoaDonXe;
            this.maHoaDon = maHoaDon;
            this.maXe = maXe;
            this.ngayNhanXe = ngayNhanXe;
            this.soTienDaTra = soTienDaTra;
            this.phiDangKyBienSo = phiDangKyBienSo;
            this.phiDangKiem = phiDangKiem;
            this.phiTruocBa = phiTruocBa;
            this.phiBaoHiemTrachNhiemDanSu = phiBaoHiemTrachNhiemDanSu;
            this.phiSuDungDuongBo = phiSuDungDuongBo;   
        }

        public ChiTietHoaDonXe(DataRow row)
        {
            this.maChiTietHoaDonXe = row["maChiTietHoaDonXe"].ToString();
            this.maHoaDon = row["maHoaDon"].ToString();
            this.maXe = row["maXe"].ToString();
            this.ngayNhanXe = (DateTime)row["ngayNhanXe"];
            this.soTienDaTra = (float)Convert.ToDouble(row["soTienDaTra"].ToString());
            this.phiDangKyBienSo = (float)Convert.ToDouble(row["phiDangKyBienSo"].ToString());
            this.phiDangKiem = (float)Convert.ToDouble(row["phiDangKiem"].ToString());
            this.phiTruocBa = (float)Convert.ToDouble(row["phiTruocBa"].ToString());
            this.phiBaoHiemTrachNhiemDanSu = (float)Convert.ToDouble(row["phiBaoHiemTrachNhiemDanSu"].ToString());
            this.phiSuDungDuongBo = (float)Convert.ToDouble(row["phiSuDungDuongBo"].ToString());
        }
    }
}
