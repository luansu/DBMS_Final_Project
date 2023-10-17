﻿using DBMS_CodeDoAn.DAO;
using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_CodeDoAn
{
    public partial class fQuanLyOTo : Form
    {
        public fQuanLyOTo()
        {
            InitializeComponent();
            LoadDanhSachLoXe();
        }

        #region event

        private void cbbMaLoXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idLoXe = cbbMaLoXe.Text;
            //string query = "exec sp_ThongTinXeTheoLo @maLoXe = '" + idLoXe + "'";

            //MessageBox.Show(query);
            LoadDanhSachXeTheoLo(idLoXe);
        }

        #endregion


        #region method

        void LoadDanhSachLoXe()
        {
            List<string> listLoXe = XeDAO.Instance.DanhSachLoXe();
            cbbMaLoXe.DataSource = listLoXe;
        }

        void LoadDanhSachXeTheoLo(string idLoXe)
        {
            List<Xe> listXe = XeDAO.Instance.DanhSachXeTheoLo(idLoXe);

            dgvThongTinXe.DataSource = listXe;
        }

        #endregion

    }
}