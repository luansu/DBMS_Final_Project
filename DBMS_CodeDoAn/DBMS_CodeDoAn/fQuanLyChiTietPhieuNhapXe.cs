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
    public partial class fQuanLyChiTietPhieuNhapXe : Form
    {
        public fQuanLyChiTietPhieuNhapXe()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event
        private void fQuanLyChiTietPhieuNhapXe_Load(object sender, EventArgs e)
        {
            DisableButtonSystem();
            DisableTextBox();
            EnableButtonEditData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachChiTietPhieuNhapXe();
            LoadDanhSachMaPhieuNhap();
            LoadDanhSachMaLoXe();
        }

        void LoadDanhSachChiTietPhieuNhapXe()
        {
            List<ChiTietPhieuNhapXe> listCTPNXe = ChiTietPhieuNhapXeDAO.Instance.DanhSachChiTietPhieuNhapXe();
            dgvThongTinChiTietPhieuNhapXe.DataSource = listCTPNXe;
        }

        void LoadDanhSachMaPhieuNhap()
        {
            List<PhieuNhap> listPhieuNhap = PhieuNhapDAO.Instance.DanhSachPhieuNhap();
            cbbMaPhieuNhap.DataSource = listPhieuNhap;
            cbbMaPhieuNhap.DisplayMember = "maPhieuNhap";
        }

        void LoadDanhSachMaLoXe()
        {
            List<string> listMaLoXe = XeDAO.Instance.DanhSachMaLoXe();
            cbbMaLoXe.DataSource = listMaLoXe;
        }

        void ClearText()
        {
            foreach (Control item in grbChiTietPhieuNhapXe.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).ResetText();
                }
            }
        }
        void EnableButtonEditData()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }
        void DisableButtonEditData()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        void EnableButtonSystem()
        {
            btnSave.Enabled = true;
            btnReset.Enabled = true;
            btnCancel.Enabled = true;
        }
        void DisableButtonSystem()
        {
            btnSave.Enabled = false;
            btnReset.Enabled = false;
            btnCancel.Enabled = false;
        }
        void DisableTextBox()
        {
            txtMaChiTietPhieuNhapXe.Enabled = false;
            cbbMaPhieuNhap.Enabled = false;
            cbbMaLoXe.Enabled = false;
            txtGiaNhap.Enabled = false;
            nmSoLuong.Enabled = false;
        }
        void EnableTextBox()
        {
            txtMaChiTietPhieuNhapXe.Enabled = true;
            cbbMaPhieuNhap.Enabled = true;
            cbbMaLoXe.Enabled = true;
            txtGiaNhap.Enabled = true;
            nmSoLuong.Enabled = true;
        }

        #endregion
    }
}
