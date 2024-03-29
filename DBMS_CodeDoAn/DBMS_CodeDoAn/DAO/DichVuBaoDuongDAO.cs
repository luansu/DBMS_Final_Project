﻿using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DAO
{
    public class DichVuBaoDuongDAO
    {
        private static DichVuBaoDuongDAO instance;

        public static DichVuBaoDuongDAO Instance
        {
            get { if (instance == null) instance = new DichVuBaoDuongDAO(); return instance; }
            private set => instance = value;
        }

        private DichVuBaoDuongDAO() { }

        public List<DichVuBaoDuong> DanhSachDichVuBaoDuong()
        {
            List<DichVuBaoDuong> listBaoDuong = new List<DichVuBaoDuong>();

            string query = "exec list_DICHVUBAODUONG";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                DichVuBaoDuong baoDuong = new DichVuBaoDuong(row);
                listBaoDuong.Add(baoDuong);
            }

            return listBaoDuong;
        }

        public bool ThemDichVuBaoDuong(string tenBaoDuong, string loaiBaoDuong, float phiBaoDuong)
        {
            string query = string.Format("exec Insert_DICHVUBAODUONG @tenBaoDuong , @loaiBaoDuong , @phiBaoDuong ");

            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {tenBaoDuong, loaiBaoDuong, phiBaoDuong });

            return result > 0;
        }

        public bool XoaDichVuBaoDuong(string maBaoDuong)
        {
            string query = string.Format("exec Delete_DICHVUBAODUONG @maBaoDuong ");

            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maBaoDuong });

            return result > 0;
        }

        public bool CapNhatDichVuBaoDuong(string maBaoDuong, string tenBaoDuong, string loaiBaoDuong, float phiBaoDuong)
        {
            string query = string.Format("exec Update_DICHVUBAODUONG @maBaoDuong , @tenBaoDuong , @loaiBaoDuong , @phiBaoDuong ");

            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maBaoDuong, tenBaoDuong, loaiBaoDuong, phiBaoDuong });

            return result > 0;
        }
    }
}
