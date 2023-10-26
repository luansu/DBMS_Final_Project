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
    public partial class fQuanLyChiTietPhieuNhapPhuTung : Form
    {
        string strBtn = "";
        BindingSource sourceChiTietPhieuNhapPT = new BindingSource();
        public fQuanLyChiTietPhieuNhapPhuTung()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DisableButtonEditData();
            EnableButtonSystem();
            EnableTextBox();
            ClearText();
            strBtn = "Add";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DisableButtonEditData();
            EnableButtonSystem();
            EnableTextBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DisableButtonEditData();
            EnableButtonSystem();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DisableButtonSystem();
            EnableButtonEditData();
            DisableTextBox();

            string maChiTietPhieuNhapPhuTung = txtMaChiTietPhieuNhapPhuTung.Text;
            string maPhuTung = cbbMaPhuTung.Text;
            string maPhieuNhap = cbbMaPhieuNhap.Text;
            float giaNhap = (float)Convert.ToDouble(txtGiaNhap.Text.ToString());
            int soLuong = (int)nmSoLuong.Value;

            if (strBtn == "Add")
            {
                bool result = ThemChiTietPhieuNhapPhuTung(maPhuTung, maPhieuNhap, giaNhap, soLuong);
                if (result)
                {
                    MessageBox.Show("Thêm chi tiết phiếu nhập phụ tùng thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }


            ClearText();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableButtonSystem();
            DisableTextBox();
            EnableButtonEditData();
            ClearText();
        }

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachChiTietPhieuNhapPhuTung();
            LoadDanhSachMaPhieuNhap();
            LoadDanhSachMaPhuTung();
            BindingData();
        }

        void LoadDanhSachChiTietPhieuNhapPhuTung()
        {
            List<ChiTietPhieuNhapPhuTung> listCTPNPhuTung = ChiTietPhieuNhapPhuTungDAO.Instance.DanhSachChiTietPhieuNhapPhuTung();
            sourceChiTietPhieuNhapPT.DataSource = listCTPNPhuTung;
            dgvThongTinChiTietPhieuNhapPhuTung.DataSource = sourceChiTietPhieuNhapPT;
        }

        void LoadDanhSachMaPhieuNhap()
        {
            List<PhieuNhap> listPhieuNhap = PhieuNhapDAO.Instance.DanhSachPhieuNhap();
            cbbMaPhieuNhap.DataSource = listPhieuNhap;
            cbbMaPhieuNhap.DisplayMember = "maPhieuNhap";
        }

        void LoadDanhSachMaPhuTung()
        {
            List<PhuTung> listPhuTung = PhuTungDAO.Instance.DanhSachPhuTung();
            cbbMaPhuTung.DataSource = listPhuTung;
            cbbMaPhuTung.DisplayMember = "maPhuTung";
        }

        bool ThemChiTietPhieuNhapPhuTung(string maPhuTung, string maPhieuNhap, float giaNhap, int soLuong)
        {
            return ChiTietPhieuNhapPhuTungDAO.Instance.ThemChiTietPhieuNhapPhuTung(maPhuTung, maPhieuNhap, giaNhap, soLuong);
        }

        void BindingData()
        {
            txtMaChiTietPhieuNhapPhuTung.DataBindings.Add(new Binding("Text", dgvThongTinChiTietPhieuNhapPhuTung.DataSource, "maChiTietPhieuNhapPhuTung", true, DataSourceUpdateMode.Never));
            cbbMaPhuTung.DataBindings.Add(new Binding("Text", dgvThongTinChiTietPhieuNhapPhuTung.DataSource, "maPhuTung", true, DataSourceUpdateMode.Never));
            cbbMaPhieuNhap.DataBindings.Add(new Binding("Text", dgvThongTinChiTietPhieuNhapPhuTung.DataSource, "maPhieuNhap", true, DataSourceUpdateMode.Never));
            txtGiaNhap.DataBindings.Add(new Binding("Text", dgvThongTinChiTietPhieuNhapPhuTung.DataSource, "giaNhap", true, DataSourceUpdateMode.Never));
            nmSoLuong.DataBindings.Add(new Binding("Value", dgvThongTinChiTietPhieuNhapPhuTung.DataSource, "soLuong", true, DataSourceUpdateMode.Never));
        }

        void ClearText()
        {
            foreach (Control item in grbChiTietPhieuNhapPhuTung.Controls)
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
            txtMaChiTietPhieuNhapPhuTung.Enabled = false;
            cbbMaPhieuNhap.Enabled = false;
            cbbMaPhuTung.Enabled = false;
            txtGiaNhap.Enabled = false;
            nmSoLuong.Enabled = false;
        }
        void EnableTextBox()
        {
            txtMaChiTietPhieuNhapPhuTung.Enabled = true;
            cbbMaPhieuNhap.Enabled = true;
            cbbMaPhuTung.Enabled = true;
            txtGiaNhap.Enabled = true;
            nmSoLuong.Enabled = true;
        }

        #endregion
    }
}
