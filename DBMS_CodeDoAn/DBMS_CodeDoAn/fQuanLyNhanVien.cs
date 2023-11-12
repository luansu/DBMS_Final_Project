using DBMS_CodeDoAn.DAO;
using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_CodeDoAn
{
    public partial class fQuanLyNhanVien : Form
    {
        string strBtn = "";
        BindingSource bindingNhanVien = new BindingSource();
        public fQuanLyNhanVien()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event

        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            DisableButtonSystem();
            DisableTextBox();
        }

        private void cbbMaChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBindingData();
            string maChiNhanh = cbbMaChiNhanh.Text;
            LoadDanhSachNhanVienTheoChiNhanh(maChiNhanh);
            BindingData();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenPicture(picNhanVien);
        }

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
            EnableButtonEditData();
            DisableTextBox();

            string maChiNhanh = cbbMaChiNhanh.Text;
            string maNhanVien = txtMaNhanVien.Text;
            string hoTenNhanVien = txtHoTen.Text;
            string CCCD = txtCCCD.Text;
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string gioiTinh = cbbGioiTinh.Text;
            string diaChi = txtDiaChi.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string chucVu = txtChucVu.Text;
            int tinhTrangLamViec = txtTinhTrangLamViec.Text == "True" ? 1 : 0;
            string hinhAnh = picNhanVien.ImageLocation;

            try
            {
                if (strBtn == "Add")
                {
                    bool result = ThemNhanVien(maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, tinhTrangLamViec, maChiNhanh, hinhAnh);
                    if (result)
                    {
                        MessageBox.Show("Thêm nhân viên thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
                else if (strBtn == "Edit")
                {
                    bool result = CapNhatNhanVien(maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, tinhTrangLamViec, maChiNhanh, hinhAnh);
                    if (result)
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }
                }
                else if (strBtn == "Delete")
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này không?", "Chú ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        bool result = XoaNhanVien(maNhanVien);
                        if (result)
                        {
                            MessageBox.Show("Xoá thông tin nhân viên thành công");
                        }
                        else
                        {
                            MessageBox.Show("Xoá thất bại");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("contr_NHANVIEN_checkLenSDT"))
                {
                    MessageBox.Show("Loi SDT");
                }
            }


            ClearText();
            LoadDanhSachNhanVienTheoChiNhanh(maChiNhanh);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableButtonSystem();
            EnableButtonEditData();
            DisableTextBox();
            ClearText();
        }

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachMaChiNhanh();
            LoadGioiTinh();
            BindingData();
        }

        void LoadDanhSachMaChiNhanh()
        {
            List<ChiNhanh> listChiNhanh = ChiNhanhDAO.Instance.DanhSachChiNhanh();
            cbbMaChiNhanh.DataSource = listChiNhanh;
            cbbMaChiNhanh.DisplayMember = "maChiNhanh";
        }

        void LoadDanhSachNhanVienTheoChiNhanh(string maChiNhanh)
        {
            List<NhanVien> listNhanVien = NhanVienDAO.Instance.DanhSachNhanVienTheoChiNhanh(maChiNhanh);
            bindingNhanVien = new BindingSource();
            bindingNhanVien.DataSource = listNhanVien;
            dgvThongTinNhanVien.DataSource = bindingNhanVien;
        }

        void LoadGioiTinh()
        {
            List<string> listGioiTinh = new List<string>() { "Nam", "Nữ" };
            cbbGioiTinh.DataSource = listGioiTinh;
        }

        bool ThemNhanVien(string maNhanVien, string hoTenNhanVien, string CCCD, string ngaySinh, string gioiTinh, string diaChi, string soDienThoai, string chucVu, int tinhTrangLamViec, string maChiNhanh, string hinhAnh)
        {
            return NhanVienDAO.Instance.ThemNhanVien(maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, tinhTrangLamViec, maChiNhanh, hinhAnh);
        }

        bool CapNhatNhanVien(string maNhanVien, string hoTenNhanVien, string CCCD, string ngaySinh, string gioiTinh, string diaChi, string soDienThoai, string chucVu, int tinhTrangLamViec, string maChiNhanh, string hinhAnh)
        {
            return NhanVienDAO.Instance.CapNhatNhanVien(maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, tinhTrangLamViec, maChiNhanh, hinhAnh);
        }

        bool XoaNhanVien(string maNhanVien)
        {
            return NhanVienDAO.Instance.XoaNhanVien(maNhanVien);
        }

        void BindingData()
        {
            ClearBindingData();
            txtMaNhanVien.DataBindings.Add("Text", dgvThongTinNhanVien.DataSource, "maNhanVien", true, DataSourceUpdateMode.Never);
            txtHoTen.DataBindings.Add("Text", dgvThongTinNhanVien.DataSource, "hoTenNhanVien", true, DataSourceUpdateMode.Never);
            txtCCCD.DataBindings.Add("Text", dgvThongTinNhanVien.DataSource, "CCCD", true, DataSourceUpdateMode.Never);
            dtpNgaySinh.DataBindings.Add("Value", dgvThongTinNhanVien.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
            cbbGioiTinh.DataBindings.Add("Text", dgvThongTinNhanVien.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", dgvThongTinNhanVien.DataSource, "diaChi", true, DataSourceUpdateMode.Never);
            txtSoDienThoai.DataBindings.Add("Text", dgvThongTinNhanVien.DataSource, "soDienThoai", true, DataSourceUpdateMode.Never);
            txtChucVu.DataBindings.Add("Text", dgvThongTinNhanVien.DataSource, "chucVu", true, DataSourceUpdateMode.Never);
            txtTinhTrangLamViec.DataBindings.Add("Text", dgvThongTinNhanVien.DataSource, "tinhTrangLamViec", true, DataSourceUpdateMode.Never);
            cbbMaChiNhanh.DataBindings.Add("Text", dgvThongTinNhanVien.DataSource, "maChiNhanh", true, DataSourceUpdateMode.Never);
            picNhanVien.DataBindings.Add("ImageLocation", dgvThongTinNhanVien.DataSource, "hinhAnh", true, DataSourceUpdateMode.Never);


            // Lỗi
            if (txtTinhTrangLamViec.Text == "True")
            {
                ckbTinhTrangLamViec.Text = "Đang làm việc";
                ckbTinhTrangLamViec.Checked = true;
            }
            else
            {
                ckbTinhTrangLamViec.Text = "Đã nghỉ";
                ckbTinhTrangLamViec.Checked = false;
            }
        }

        void ClearBindingData()
        {
            txtMaNhanVien.DataBindings.Clear();
            txtHoTen.DataBindings.Clear();
            txtCCCD.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();
            cbbGioiTinh.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Clear();
            txtChucVu.DataBindings.Clear();
            txtTinhTrangLamViec.DataBindings.Clear();
            cbbMaChiNhanh.DataBindings.Clear();
            picNhanVien.DataBindings.Clear();
        }

        void ClearText()
        {
            foreach (Control item in grbNhanVien.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).ResetText();
                }
            }
            dtpNgaySinh.Value = DateTime.Now;
            picNhanVien.ImageLocation = null;
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
            foreach (Control item in grbNhanVien.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
            }
            dtpNgaySinh.Enabled = false;
        }
        void EnableTextBox()
        {
            foreach (Control item in grbNhanVien.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true;
                }
            }
            dtpNgaySinh.Enabled = true;
        }

        void OpenPicture(PictureBox pic)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image File(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)| *.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pic.ImageLocation = openFileDialog.FileName;
            }
        }

        #endregion
    }
}
