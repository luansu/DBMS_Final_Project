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
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
        }

        private void quảnLýXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyOTo f = new fQuanLyOTo();
            f.ShowDialog();

            this.Show();
        }

        private void quảnLýPhụTùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyPhuTung f = new fQuanLyPhuTung();
            f.ShowDialog();

            this.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyNhanVien f = new fQuanLyNhanVien();
            f.ShowDialog();

            this.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyKhachHang f = new fQuanLyKhachHang();
            f.ShowDialog();

            this.Show();
        }

        private void quảnLýChiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyChiNhanh f = new fQuanLyChiNhanh();
            f.ShowDialog();

            this.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyNhaCungCap f = new fQuanLyNhaCungCap();
            f.ShowDialog();

            this.Show();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyHoaDon f = new fQuanLyHoaDon();
            f.ShowDialog();

            this.Show();
        }

        private void quảnLýPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyPhieuNhap f = new fQuanLyPhieuNhap();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýDịchVụBảoDưỡngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyBaoDuong f = new fQuanLyBaoDuong();
            f.ShowDialog();

            this.Show();
        }

        private void quảnLýPhiếuBảoDưỡngBảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyPhieuBaoDuong f = new fQuanLyPhieuBaoDuong();
            f.ShowDialog();

            this.Show();
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyKho f = new fQuanLyKho();
            f.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
