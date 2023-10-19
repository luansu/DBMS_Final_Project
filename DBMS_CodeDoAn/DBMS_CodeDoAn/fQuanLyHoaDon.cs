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
    public partial class fQuanLyHoaDon : Form
    {
        public fQuanLyHoaDon()
        {
            InitializeComponent();
            LoadDanhSachHoaDon();
            LoadDanhSachMaNhanVien();
        }

        #region event
        
        // Click to open form CarBillDetail
        private void btnChiTietHoaDoaXe_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyChiTietHoaDonXe f = new fQuanLyChiTietHoaDonXe();
            f.ShowDialog();
            this.Show();
        }

        // Click to open form AccessoryBillDetail
        private void btnChiTietHoaDonPhuTung_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyChiTietHoaDonPhuTung f = new fQuanLyChiTietHoaDonPhuTung();
            f.ShowDialog();
            this.Show();
        }

        #endregion

        #region method

        void LoadDanhSachHoaDon()
        {
            List<HoaDon> listHoaDon = HoaDonDAO.Instance.DanhSachHoaDon();
            dgvThongTinHoaDon.DataSource = listHoaDon;
        }

        void LoadDanhSachMaNhanVien()
        {
            List<NhanVien> listNhanVien = NhanVienDAO.Instance.DanhSachNhanVien();
            cbbMaNhanVien.DataSource = listNhanVien;
            cbbMaNhanVien.DisplayMember = "maNhanVien";
        }


        #endregion

    }
}
