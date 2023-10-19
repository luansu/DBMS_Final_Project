using DBMS_CodeDoAn.DAO;
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
    public partial class fQuanLyPhieuNhap : Form
    {
        public fQuanLyPhieuNhap()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event

        private void btnChiTietPhieuNhapXe_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyChiTietPhieuNhapXe f = new fQuanLyChiTietPhieuNhapXe();
            f.ShowDialog();
            this.Show();
        }
        private void btnChiTietPhieuNhapPhuTung_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyChiTietPhieuNhapPhuTung f = new fQuanLyChiTietPhieuNhapPhuTung();
            f.ShowDialog();
            this.Show();
        }

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachPhieuNhap();
            LoadDanhSachMaChiNhanh();
            LoadDanhSachMaNhaCungCap();
        }

        void LoadDanhSachMaChiNhanh()
        {
            List<ChiNhanh> listChiNhanh = ChiNhanhDAO.Instance.DanhSachChiNhanh();
            cbbMaChiNhanh.DataSource = listChiNhanh;
            cbbMaChiNhanh.DisplayMember = "maChiNhanh";
        }

        void LoadDanhSachMaNhaCungCap()
        {
            List<NhaCungCap> listNhaCungCap = NhaCungCapDAO.Instance.DanhSachNhaCungCap();
            cbbMaNhaCungCap.DataSource = listNhaCungCap;
            cbbMaNhaCungCap.DisplayMember = "maNhaCungCap";
        }

        void LoadDanhSachPhieuNhap()
        {
            List<PhieuNhap> listPhieuNhap = PhieuNhapDAO.Instance.DanhSachPhieuNhap();
            dgvThongTinPhieuNhap.DataSource = listPhieuNhap;
        }


        #endregion

    }
}
