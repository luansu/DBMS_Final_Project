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
        private int soTienDaTra;
        private int phiDangKyBienSo;
        private int phiDangKiem;
        private int phiTruocBa;
        private int phiBaoHiemTrachNhiemDanSu;
        private int phiSuDungDuongBo;

        public string MaChiTietHoaDonXe { get => maChiTietHoaDonXe; set => maChiTietHoaDonXe = value; }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaXe { get => maXe; set => maXe = value; }
        public DateTime NgayNhanXe { get => ngayNhanXe; set => ngayNhanXe = value; }
        public int SoTienDaTra { get => soTienDaTra; set => soTienDaTra = value; }
        public int PhiDangKyBienSo { get => phiDangKyBienSo; set => phiDangKyBienSo = value; }
        public int PhiDangKiem { get => phiDangKiem; set => phiDangKiem = value; }
        public int PhiTruocBa { get => phiTruocBa; set => phiTruocBa = value; }
        public int PhiBaoHiemTrachNhiemDanSu { get => phiBaoHiemTrachNhiemDanSu; set => phiBaoHiemTrachNhiemDanSu = value; }
        public int PhiSuDungDuongBo { get => phiSuDungDuongBo; set => phiSuDungDuongBo = value; }

        // Constructor
        public ChiTietHoaDonXe(string maChiTietHoaDonXe, string maHoaDon, string maXe, 
            DateTime ngayNhanXe, int soTienDaTra, int phiDangKyBienSo, int phiDangKiem,
            int phiTruocBa, int phiBaoHiemTrachNhiemDanSu, int phiSuDungDuongBo)
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
            this.soTienDaTra = (int)row["soTienDaTra"];
            this.phiDangKyBienSo = (int)row["phiDangKyBienSo"];
            this.phiDangKiem = (int)row["phiDangKiem"];
            this.phiTruocBa = (int)row["phiTruocBa"];
            this.phiBaoHiemTrachNhiemDanSu = (int)row["phiBaoHiemTrachNhiemDanSu"];
            this.phiSuDungDuongBo = (int)row["phiSuDungDuongBo"];
        }
    }
}
