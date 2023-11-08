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
        string strBtn = "";
        BindingSource bindingChiTietPhieuNhapXe = new BindingSource();
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
            DisableButtonEditData();
            EnableTextBox();
            EnableButtonSystem();
            ClearText();
            strBtn = "Add";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DisableButtonEditData();
            EnableTextBox();
            EnableButtonSystem();
            strBtn = "Edit";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DisableButtonEditData();
            EnableButtonSystem();
            strBtn = "Delete";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DisableButtonSystem();
            DisableTextBox();
            EnableButtonEditData();

            try
            {
                string maChiTietPhieuNhapXe = txtMaChiTietPhieuNhapXe.Text;
                string maLoXe = cbbMaLoXe.Text;
                string maPhieuNhap = cbbMaPhieuNhap.Text;
                float giaNhap = (float)Convert.ToDouble(txtGiaNhap.Text);
                int soLuong = (int)nmSoLuong.Value;

                if (strBtn == "Add")
                {
                    bool result = ThemChiTietPhieuNhapXe(maLoXe, maPhieuNhap, giaNhap, soLuong);
                    if (result)
                    {
                        MessageBox.Show("Thêm chi tiết phiếu nhập xe thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
                else if (strBtn == "Edit")
                {
                    bool result = CapNhatChiTietPhieuNhapXe(maChiTietPhieuNhapXe, maLoXe, maPhieuNhap, giaNhap, soLuong);
                    if (result)
                    {
                        MessageBox.Show("Cập nhật chi tiết phiếu nhập xe thành công");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }
                }
                else if (strBtn == "Delete")
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập phụ tùng này không", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        bool result = XoaChiTietPhieuNhapXe(maChiTietPhieuNhapXe);
                        if (result)
                        {
                            MessageBox.Show("Xóa chi tiết phiếu nhập xe thành công");
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("correct format"))
                {
                    MessageBox.Show("Giá nhập phải là kiểu dữ liệu số !!");
                }
            }

            ClearText();
            LoadDanhSachChiTietPhieuNhapXe();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableButtonSystem();
            EnableButtonEditData();
            ClearText();
            DisableTextBox();
        }

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachChiTietPhieuNhapXe();
            LoadDanhSachMaPhieuNhap();
            LoadDanhSachMaLoXe();
            BindingData();
        }

        void LoadDanhSachChiTietPhieuNhapXe()
        {
            List<ChiTietPhieuNhapXe> listCTPNXe = ChiTietPhieuNhapXeDAO.Instance.DanhSachChiTietPhieuNhapXe();
            bindingChiTietPhieuNhapXe.DataSource = listCTPNXe;
            dgvThongTinChiTietPhieuNhapXe.DataSource = bindingChiTietPhieuNhapXe;
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

        bool ThemChiTietPhieuNhapXe(string maLoXe, string maPhieuNhap, float giaNhap, int soLuong)
        {
            return ChiTietPhieuNhapXeDAO.Instance.ThemChiTietPhieuNhapXe(maLoXe, maPhieuNhap, giaNhap, soLuong);
        }

        bool CapNhatChiTietPhieuNhapXe(string maChiTietPNX, string maLoXe, string maPhieuNhap, float giaNhap, int soLuong)
        {
            return ChiTietPhieuNhapXeDAO.Instance.CapNhatChiTietPhieuNhapXe(maChiTietPNX, maLoXe, maPhieuNhap, giaNhap, soLuong);
        }

        bool XoaChiTietPhieuNhapXe(string maChiTietPNX)
        {
            return ChiTietPhieuNhapXeDAO.Instance.XoaChiTietPhieuNhapXe(maChiTietPNX);
        }

        void BindingData()
        {
            txtMaChiTietPhieuNhapXe.DataBindings.Add("Text", dgvThongTinChiTietPhieuNhapXe.DataSource, "maChiTietPhieuNhapXe", true, DataSourceUpdateMode.Never);
            cbbMaLoXe.DataBindings.Add("Text", dgvThongTinChiTietPhieuNhapXe.DataSource, "maLoXe", true, DataSourceUpdateMode.Never);
            cbbMaPhieuNhap.DataBindings.Add("Text", dgvThongTinChiTietPhieuNhapXe.DataSource, "maPhieuNhap", true, DataSourceUpdateMode.Never);
            txtGiaNhap.DataBindings.Add("Text", dgvThongTinChiTietPhieuNhapXe.DataSource, "giaNhap", true, DataSourceUpdateMode.Never);
            nmSoLuong.DataBindings.Add("Value", dgvThongTinChiTietPhieuNhapXe.DataSource, "soLuong", true, DataSourceUpdateMode.Never);
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
            cbbMaPhieuNhap.Enabled = true;
            cbbMaLoXe.Enabled = true;
            txtGiaNhap.Enabled = true;
            nmSoLuong.Enabled = true;
        }

        #endregion
    }
}
