using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class ChiNhanhDAO
    {
        private static ChiNhanhDAO instance;
        public static ChiNhanhDAO Instance 
        {
            get { if (instance == null) instance = new ChiNhanhDAO(); return instance; }
            private set => instance = value; 
        }

        private ChiNhanhDAO() { }

        public List<ChiNhanh> DanhSachChiNhanh()
        {
            List<ChiNhanh> listChiNhanh = new List<ChiNhanh>();

            string query = "exec list_ChiNhanh";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                ChiNhanh chiNhanh = new ChiNhanh(row);
                listChiNhanh.Add(chiNhanh);
            }

            return listChiNhanh;
        }

        public bool ThemChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi)
        {
            string query = string.Format("exec Insert_CHINHANH @maChiNhanh , @tenChiNhanh ,  @diaChi ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maChiNhanh, tenChiNhanh, diaChi });
            return result > 0;
        }
        public bool CapNhatChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi)
        {
            string query = string.Format("exec Update_CHINHANH @tenChiNhanh , @diaChi , @maChiNhanh ");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { tenChiNhanh, diaChi, maChiNhanh });
            return result > 0;
        }
        public bool XoaChiNhanh(string maChiNhanh)
        {
            string query = string.Format("exec Delete_CHINHANH @maChiNhanh");
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maChiNhanh});
            return result > 0;
        }
    }
}
