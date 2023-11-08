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

            string query = "exec List_PhuTung";

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
            string query = string.Format("exec Insert_PhuTung @loaiPhuTung , @tenPhuTung , @thuongHieu , @xuatXu , @giaBan , @chatLuong , @hinhAnh ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh });
            return result > 0;
        }

        public bool CapNhatPhuTung(string maPhuTung, string loaiPhuTung, string tenPhuTung, string thuongHieu, string xuatXu, float giaBan, string chatLuong, string hinhAnh)
        {
            string query = string.Format("exec Update_PhuTung @maPhuTung , @loaiPhuTung , @tenPhuTung , @thuongHieu , @xuatXu , @giaBan , @chatLuong , @hinhAnh ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maPhuTung, loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh });
            return result > 0;
        }

        public bool XoaPhuTung(string maPhuTung)
        {
            string query = string.Format("exec Delete_PhuTung @maPhuTung ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maPhuTung });
            return result > 0;
        }

        public List<PhuTung> TimKiemThongTinPhuThung(string loaiPhuTung, string tenPhuTung, string thuongHieu, string xuatXu, float giaBan = 0)
        {
            List<PhuTung> listPhuTung = new List<PhuTung>();

            string query = string.Format("select * from PHUTUNG where loaiPhuTung like N'{0}' and tenPhuTung like N'{1}' and thuongHieu like N'{2}' and xuatXu like N'{3}' and giaBan = {4}", loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan);
            
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                PhuTung phuTung = new PhuTung(row);
                listPhuTung.Add(phuTung);
            }


            return listPhuTung;
        }
    }
}
