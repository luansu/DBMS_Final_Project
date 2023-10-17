using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class PhieuNhapDAO
    {
        private static PhieuNhapDAO instance;

        public static PhieuNhapDAO Instance 
        {
            get { if (instance == null) instance = new PhieuNhapDAO(); return instance; }
            private set => instance = value; 
        }
        private PhieuNhapDAO() { }

    }
}
