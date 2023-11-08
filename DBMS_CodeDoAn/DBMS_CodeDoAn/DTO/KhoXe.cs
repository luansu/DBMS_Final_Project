using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class KhoXe
    {
        private string maChiNhanh;
        private string maLoXe;
        int soLuongXeCon;
        int soLuongXeDaBan;

        public string MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }
        public string MaLoXe { get => maLoXe; set => maLoXe = value; }
        public int SoLuongXeCon { get => soLuongXeCon; set => soLuongXeCon = value; }
        public int SoLuongXeDaBan { get => soLuongXeDaBan; set => soLuongXeDaBan = value; }

        public KhoXe(string maChiNhanh, string maLoXe, int soLuongCon, int soLuongBan) 
        {
            this.maChiNhanh = maChiNhanh;
            this.maLoXe = maLoXe;
            this.soLuongXeCon = soLuongCon;
            this.soLuongXeDaBan= soLuongBan;
        }

        public KhoXe(DataRow row)
        {
            this.maChiNhanh = row["maChiNhanh"].ToString();
            this.maLoXe = row["maLoXe"].ToString();
            this.soLuongXeCon = (int)row["soLuongXeCon"];
            this.soLuongXeDaBan = (int)row["soLuongXeDaBan"];
        }
    }
}
