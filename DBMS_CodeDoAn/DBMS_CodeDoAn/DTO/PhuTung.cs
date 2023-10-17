using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class PhuTung
    {
        private string maPhuTung;
        private string loaiPhuTung;
        private string tenPhuTung;
        private string thuongHieu;
        private string xuatXu;
        private int giaBan;
        private string chatLuong;
        private string hinhAnh;
        public string MaPhuTung { get => maPhuTung; set => maPhuTung = value; }
        public string LoaiPhuTung { get => loaiPhuTung; set => loaiPhuTung = value; }
        public string TenPhuTung { get => tenPhuTung; set => tenPhuTung = value; }
        public string ThuongHieu { get => thuongHieu; set => thuongHieu = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public string ChatLuong { get => chatLuong; set => chatLuong = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }

        public PhuTung(string maPhuTung, string loaiPhuTung, string tenPhuTung, string thuongHieu, string xuatXu, int giaBan, string chatLuong, string hinhAnh)
        {
            MaPhuTung = maPhuTung;
            LoaiPhuTung = loaiPhuTung;
            TenPhuTung = tenPhuTung;
            ThuongHieu = thuongHieu;
            XuatXu = xuatXu;
            GiaBan = giaBan;
            ChatLuong = chatLuong;
            HinhAnh = hinhAnh;
            MaPhuTung = maPhuTung;
            LoaiPhuTung = loaiPhuTung;
            TenPhuTung = tenPhuTung;
            ThuongHieu = thuongHieu;
            XuatXu = xuatXu;
            GiaBan = giaBan;
            ChatLuong = chatLuong;
            HinhAnh = hinhAnh;
        }

        public PhuTung(DataRow row)
        {
            MaPhuTung = row["maPhuTung"].ToString();
            LoaiPhuTung = row["loaiPhuTung"].ToString();
            TenPhuTung = row["tenPhuTung"].ToString();
            ThuongHieu = row["thuongHieu"].ToString();
            XuatXu = row["xuatXu"].ToString();
            GiaBan = (int)row["giaBan"];
            ChatLuong = row["chatLuong"].ToString();
            HinhAnh = row["hinhAnh"].ToString();
        }
    }
}
