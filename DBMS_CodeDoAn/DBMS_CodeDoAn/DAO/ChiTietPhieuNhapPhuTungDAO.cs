using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiTietPhieuNhapPhuTungDAO
    {
        private static ChiTietPhieuNhapPhuTungDAO instance;

        public static ChiTietPhieuNhapPhuTungDAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuNhapPhuTungDAO(); return instance; }
            private set => instance = value;
        }

        private ChiTietPhieuNhapPhuTungDAO() { }
    }
}
