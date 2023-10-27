using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool ThemPhuTung(string loaiPhuTung, string tenPhuTung, string thuongHieu, string xuatXu, float giaBan, string chatLuong, string hinhAnh)
        {
            string query = string.Format("insert into PHUTUNG(loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh) values ('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}')", loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool CapNhatPhuTung(string maPhuTung, string loaiPhuTung, string tenPhuTung, string thuongHieu, string xuatXu, float giaBan, string chatLuong, string hinhAnh)
        {
            string query = string.Format("Update PHUTUNG set loaiPhuTung = '{0}', tenPhuTung = '{1}', thuongHieu = '{2}', xuatXu = '{3}', giaBan = '{4}', chatLuong = '{5}', hinhAnh = '{6}' where maPhuTung = '{7}'", loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh, maPhuTung);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool XoaPhuTung(string maPhuTung)
        {
            string query = string.Format("delete PHUTUNG where maPhuTung = '{0}'", maPhuTung);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
