using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance 
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; } 
            private set => instance = value; 
        }

        private NhanVienDAO() { }
    }
}
