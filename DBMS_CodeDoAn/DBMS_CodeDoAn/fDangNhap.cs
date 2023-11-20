﻿using DBMS_CodeDoAn.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_CodeDoAn
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }
        #region event
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtAccount.Text;
            string matKhau = txtPassword.Text;
            if (KiemTraDangNhap(tenDangNhap, matKhau))
            {
                saveLogin(tenDangNhap, matKhau);
                this.Hide();
                fHome f = new fHome();
                f.ShowDialog();
                //fTrangChu f = new fTrangChu();
                //f.ShowDialog();

                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu, vui lòng kiểm tra lại");
            }
            
        }

        #endregion

        #region method

        private bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            return TaiKhoanDAO.Instance.KiemTraDangNhap(taiKhoan, matKhau);
        }
        private void saveLogin(string taiKhoan, string matKhau)
        {
            string filePath = "log.txt";
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(taiKhoan);
                writer.WriteLine(matKhau);
            }
        }
        #endregion
    }
}
