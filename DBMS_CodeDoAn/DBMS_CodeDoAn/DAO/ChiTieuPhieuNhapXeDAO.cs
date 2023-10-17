using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiTieuPhieuNhapXeDAO
    {
        private static ChiTieuPhieuNhapXeDAO instance;

        public static ChiTieuPhieuNhapXeDAO Instance 
        {
            get { if (instance == null) instance = new ChiTieuPhieuNhapXeDAO(); return instance; }
            private set => instance = value; 
        }

        private ChiTieuPhieuNhapXeDAO() { }
    }
}
