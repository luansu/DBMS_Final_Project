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
    public partial class fTrangChu : Form
    {
        public fTrangChu()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyNhanVien f = new fQuanLyNhanVien();
            f.ShowDialog();

            this.Show();
        }

        private void btnQuanLyOTo_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyOTo f = new fQuanLyOTo();
            f.ShowDialog();

            this.Show();
        }

        private void btnQuanLyPhuTung_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyPhuTung f = new fQuanLyPhuTung();
            f.ShowDialog();

            this.Show();
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyKhachHang f = new fQuanLyKhachHang();
            f.ShowDialog();

            this.Show();
        }

        private void btnQuanLyChiNhanh_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyChiNhanh f = new fQuanLyChiNhanh();
            f.ShowDialog();

            this.Show();
        }

        private void btnQuanLyNhaCungCap_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyNhaCungCap f = new fQuanLyNhaCungCap();
            f.ShowDialog();

            this.Show();
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyHoaDon f = new fQuanLyHoaDon();
            f.ShowDialog();

            this.Show();
        }

        private void btnQuanLyPhieuNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyPhieuNhap f = new fQuanLyPhieuNhap();
            f.ShowDialog();
            this.Show();
        }

        private void btnQuanLyPhieuBDBH_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyPhieuBaoDuong f = new fQuanLyPhieuBaoDuong();
            f.ShowDialog();

            this.Show();
        }

        private void btnQuanLyBaoDuong_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyBaoDuong f = new fQuanLyBaoDuong();
            f.ShowDialog();

            this.Show();
        }
    }
}
