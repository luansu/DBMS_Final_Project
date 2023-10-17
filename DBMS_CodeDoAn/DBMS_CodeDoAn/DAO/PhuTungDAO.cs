using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class PhuTungDAO
    {
        private static PhuTungDAO instance;

        public static PhuTungDAO Instance 
        {
            get { if (instance == null) instance = new PhuTungDAO(); return instance; }
            private set => instance = value; 
        }

        private PhuTungDAO() { }

        public List<PhuTung> DanhSachPhuTung()
        {
            List<PhuTung> listPhuTung = new List<PhuTung>();

            string query = "select * from PHUTUNG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                PhuTung phuTung = new PhuTung(row);
                listPhuTung.Add(phuTung);
            }

            return listPhuTung;
        }
    }
}
