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
    public partial class fQuanLyPhieuBaoDuong : Form
    {
        public fQuanLyPhieuBaoDuong()
        {
            InitializeComponent();
            LoadAll();
        }

        #region events

        private void btnChiTietPhieuBaoDuong_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyChiTietPhieuBaoDuong f = new fQuanLyChiTietPhieuBaoDuong();
            f.ShowDialog();

            this.Show();
        }

        #endregion

        #region methods

        void LoadAll()
        {
            LoadDanhSachPhieuBaoDuong();
            LoadDanhSachMaKhachHang();
            LoadDanhSachMaNhanVien();
        }

        void LoadDanhSachMaNhanVien()
        {
            List<NhanVien> listNhanVien = NhanVienDAO.Instance.DanhSachNhanVien();
            cbbMaNhanVien.DataSource = listNhanVien;
            cbbMaNhanVien.DisplayMember = "maNhanVien";
        }

        void LoadDanhSachMaKhachHang()
        {
            List<KhachHang> listKhachHang = KhachHangDAO.Instance.DanhSachKhachHang();
            cbbMaKhachHang.DataSource = listKhachHang;
            cbbMaKhachHang.DisplayMember = "maKhachHang";
        }

        void LoadDanhSachPhieuBaoDuong()
        {
            List<PhieuBaoDuong> listPhieuBaoDuong = PhieuBaoDuongDAO.Instance.DanhSachPhieuBaoDuong();
            dgvThongTinPhieuBaoDuong.DataSource = listPhieuBaoDuong;
        }

        #endregion

    }
}
