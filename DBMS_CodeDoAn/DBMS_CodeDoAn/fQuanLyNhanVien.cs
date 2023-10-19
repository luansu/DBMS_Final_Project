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
    public partial class fQuanLyNhanVien : Form
    {
        public fQuanLyNhanVien()
        {
            InitializeComponent();
            LoadDanhSachMaChiNhanh();
        }

        #region event

        private void cbbMaChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maChiNhanh = cbbMaChiNhanh.Text;
            LoadDanhSachNhanVienTheoChiNhanh(maChiNhanh);
        }

        #endregion

        #region method

        void LoadDanhSachMaChiNhanh()
        {
            List<ChiNhanh> listChiNhanh = ChiNhanhDAO.Instance.DanhSachChiNhanh();
            cbbMaChiNhanh.DataSource = listChiNhanh;
            cbbMaChiNhanh.DisplayMember = "maChiNhanh";
        }

        void LoadDanhSachNhanVienTheoChiNhanh(string maChiNhanh)
        {
            List<NhanVien> listNhanVien = NhanVienDAO.Instance.DanhSachNhanVienTheoChiNhanh(maChiNhanh);
            dgvThongTinNhanVien.DataSource = listNhanVien;
        }

        #endregion
        
    }
}
