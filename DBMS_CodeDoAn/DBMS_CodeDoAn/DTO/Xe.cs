using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class Xe
    {
        private string maXe;
        private string maLoXe;
        private string tenXe;
        private string mauSac;
        private float giaBan;
        private int soChoNgoi;
        private string xuatXu;
        private string hangXe;
        private string loaiXe;
        private string phienBanXe;
        private int tocDoToiDa;
        private int trongLuong;
        private int trongTai;
        private string loaiNhienLieu;
        private int congSuatDongCo;
        private int dungTichDongCo;
        private string loaiDongCo;
        private int khoangSangGam;
        private int chieuDaiCoSo;
        private int chieuDai;
        private int chieuRong;
        private int chieuCao;
        private int banKinhQuayVong;
        private string hinhAnh;

        public string MaXe { get => maXe; set => maXe = value; }
        public string MaLoXe { get => maLoXe; set => maLoXe = value; }
        public string TenXe { get => tenXe; set => tenXe = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public float GiaBan { get => giaBan; set => giaBan = value; }
        public int SoChoNgoi { get => soChoNgoi; set => soChoNgoi = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public string HangXe { get => hangXe; set => hangXe = value; }
        public string LoaiXe { get => loaiXe; set => loaiXe = value; }
        public string PhienBanXe { get => phienBanXe; set => phienBanXe = value; }
        public int TocDoToiDa { get => tocDoToiDa; set => tocDoToiDa = value; }
        public int TrongLuong { get => trongLuong; set => trongLuong = value; }
        public int TrongTai { get => trongTai; set => trongTai = value; }
        public string LoaiNhienLieu { get => loaiNhienLieu; set => loaiNhienLieu = value; }
        public int CongSuatDongCo { get => congSuatDongCo; set => congSuatDongCo = value; }
        public int DungTichDongCo { get => dungTichDongCo; set => dungTichDongCo = value; }
        public string LoaiDongCo { get => loaiDongCo; set => loaiDongCo = value; }
        public int KhoangSangGam { get => khoangSangGam; set => khoangSangGam = value; }
        public int ChieuDaiCoSo { get => chieuDaiCoSo; set => chieuDaiCoSo = value; }
        public int ChieuDai { get => chieuDai; set => chieuDai = value; }
        public int ChieuRong { get => chieuRong; set => chieuRong = value; }
        public int ChieuCao { get => chieuCao; set => chieuCao = value; }
        public int BanKinhQuayVong { get => banKinhQuayVong; set => banKinhQuayVong = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }

        // Hàm dựng
        public Xe(string maXe, string maLoXe, string tenXe, string mauSac, int giaBan, int soChoNgoi, string xuatXu,
            string hangXe, string loaiXe, string phienBanXe, int tocDoToiDa, int trongLuong, int trongTai,
            string loaiNhienLieu, int congSuatDongCo, int dungTichDongCo, string loaiDongCo,
            int khoangSangGam, int chieuDaiCoSo, int chieuDai, int chieuRong, int chieuCao, int banKinhQuayVong, string hinhAnh)
        {
            this.maXe = maXe;
            this.maLoXe = maLoXe;
            this.tenXe = tenXe;
            this.mauSac = mauSac;
            this.giaBan = giaBan;
            this.soChoNgoi = soChoNgoi;
            this.xuatXu = xuatXu;
            this.hangXe = hangXe;
            this.loaiXe = loaiXe;
            this.phienBanXe = phienBanXe;
            this.tocDoToiDa = tocDoToiDa;
            this.trongLuong = trongLuong;
            this.trongTai = trongTai;
            this.loaiNhienLieu = loaiNhienLieu;
            this.congSuatDongCo = congSuatDongCo;
            this.dungTichDongCo = dungTichDongCo;
            this.loaiDongCo = loaiDongCo;
            this.khoangSangGam = khoangSangGam;
            this.chieuDaiCoSo = chieuDaiCoSo;
            this.chieuDai = chieuDai;
            this.chieuRong = chieuRong;
            this.chieuCao = chieuCao;
            this.banKinhQuayVong = banKinhQuayVong;
            this.hinhAnh = hinhAnh;
        }
        public Xe(DataRow row)
        {
            this.maXe = row["maXe"].ToString();
            this.maLoXe = row["maLoXe"].ToString();
            this.tenXe = row["tenXe"].ToString();
            this.mauSac = row["mauSac"].ToString();
            this.giaBan = (float)Convert.ToDouble(row["giaBan"].ToString());
            this.soChoNgoi = (int)row["soChoNgoi"];
            this.xuatXu = row["xuatXu"].ToString();
            this.hangXe = row["hangXe"].ToString();
            this.loaiXe = row["loaiXe"].ToString();
            this.phienBanXe = row["phienBanXe"].ToString();
            this.tocDoToiDa = (int)row["tocDoToiDa"];
            this.trongLuong = (int)row["trongLuong"];
            this.trongTai = (int)row["trongTai"];
            this.loaiNhienLieu = row["maLoXe"].ToString();
            this.congSuatDongCo = (int)row["congSuatDongCo"];
            this.dungTichDongCo = (int)row["dungTichDongCo"];
            this.loaiDongCo = row["loaiDongCo"].ToString();
            this.khoangSangGam = (int)row["khoangSangGam"];
            this.chieuDaiCoSo = (int)row["chieuDaiCoSo"];
            this.chieuDai = (int)row["chieuDai"];
            this.chieuRong = (int)row["chieuRong"];
            this.chieuCao = (int)row["chieuCao"];
            this.banKinhQuayVong = (int)row["banKinhQuayVong"];
            this.hinhAnh = row["hinhAnh"].ToString();
        }
    }
}
