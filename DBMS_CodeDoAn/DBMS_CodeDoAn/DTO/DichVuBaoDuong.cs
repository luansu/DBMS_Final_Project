using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class DichVuBaoDuong
    {
        private string maBaoDuong;
        private string tenBaoDuong;
        private string loaiBaoDuong;
        private int phiBaoDuong;

        public string MaBaoDuong { get => maBaoDuong; set => maBaoDuong = value; }
        public string TenBaoDuong { get => tenBaoDuong; set => tenBaoDuong = value; }
        public string LoaiBaoDuong { get => loaiBaoDuong; set => loaiBaoDuong = value; }
        public int PhiBaoDuong { get => phiBaoDuong; set => phiBaoDuong = value; }
        
        // Constructor
        public DichVuBaoDuong(string maBaoDuong, string tenBaoDuong, string loaiBaoDuong, int phiBaoDuong)
        {
            this.maBaoDuong = maBaoDuong;
            this.tenBaoDuong = tenBaoDuong;
            this.loaiBaoDuong = loaiBaoDuong;
            this.phiBaoDuong = phiBaoDuong;

        }

        public DichVuBaoDuong(DataRow row)
        {
            this.maBaoDuong = row["maBaoDuong"].ToString();
            this.tenBaoDuong = row["tenBaoDuong"].ToString();
            this.loaiBaoDuong = row["loaiBaoDuong"].ToString();
            this.phiBaoDuong = (int)row["phiBaoDuong"];
        }
    }
}
