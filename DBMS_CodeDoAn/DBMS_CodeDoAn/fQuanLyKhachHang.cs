using DBMS_CodeDoAn.DAO;
using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_CodeDoAn
{
    public partial class fQuanLyKhachHang : Form
    {
        string strBtn = "";
        int index = 0;
        BindingSource bindingKhachHang = new BindingSource();

        public fQuanLyKhachHang()
        {
            InitializeComponent();
            LoadDanhSachKhachHang();
            LoadCbbGioiTinh();
            BindingData();
        }

        #region event
        private void fQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            DisableButtonSystem();
            DisableTextBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearText();
            DisableButtonEditData();
            EnableButtonSystem();
            EnableTextBox();
            strBtn = "Add";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableTextBox();
            DisableButtonEditData();
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
            EnableButtonEditData();
            DisableButtonSystem();
            DisableTextBox();

            string maKhachHang = txtMaKhachHang.Text;
            string hoTenKhachHang = txtHoTenKhachHang.Text;
            string ngaySinhFormatted = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string gioiTinh = cbbGioiTinh.Text;
            string CCCD = txtCCCD.Text;
            string diaChi = txtDiaChi.Text;
            string soDienThoai = txtSoDienThoai.Text;
            if (strBtn == "Add")
            {
                bool result = ThemKhachHang(hoTenKhachHang, ngaySinhFormatted, gioiTinh, CCCD, diaChi, soDienThoai);
                if (result)
                {
                    MessageBox.Show("Thêm khách hàng thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else if (strBtn == "Edit")
            {
                bool result = CapNhatKhachHang(maKhachHang, hoTenKhachHang, ngaySinhFormatted, gioiTinh, CCCD, diaChi, soDienThoai);
                if ( result)
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else if (strBtn == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool result = XoaKhachHang(maKhachHang);
                    if (result)
                    {
                        MessageBox.Show("Xóa khách hàng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
            ClearText();
            LoadDanhSachKhachHang();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
            DisableButtonSystem();
            EnableButtonEditData();
            DisableTextBox();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            index = 0;
            GetDataInDataGridView(index);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                GetDataInDataGridView(index);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index < dgvThongTinKhachHang.Rows.Count - 1)
            {
                index++;
                GetDataInDataGridView(index);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            index = dgvThongTinKhachHang.Rows.Count - 1;
            GetDataInDataGridView(index);
        }

        #endregion

        #region method

        void LoadDanhSachKhachHang()
        {
            List<KhachHang> listKhachHang = KhachHangDAO.Instance.DanhSachKhachHang();
            bindingKhachHang.DataSource = listKhachHang;
            dgvThongTinKhachHang.DataSource = bindingKhachHang;
        }

        void LoadCbbGioiTinh()
        {
            List<string> listGioiTinh = new List<string>(){ "Nam", "Nữ" };
            cbbGioiTinh.DataSource = listGioiTinh;
        }

        bool ThemKhachHang(string hoTenKhachHang, string ngaySinh, string gioiTinh, string CCCD, string diaChi, string soDienThoai)
        {
            return KhachHangDAO.Instance.ThemKhachHang(hoTenKhachHang, ngaySinh, gioiTinh, CCCD, diaChi, soDienThoai);
        }
        bool CapNhatKhachHang(string maKhachHang, string hoTenKhachHang, string ngaySinh, string gioiTinh, string CCCD, string diaChi, string soDienThoai)
        {
            return KhachHangDAO.Instance.CapNhatKhachHang(maKhachHang, hoTenKhachHang, ngaySinh, gioiTinh, CCCD, diaChi, soDienThoai);
        }     
        bool XoaKhachHang(string maKhachHang)
        {
            return KhachHangDAO.Instance.XoaKhachHang(maKhachHang);
        }
        void BindingData()
        {
            txtMaKhachHang.DataBindings.Add(new Binding("Text", dgvThongTinKhachHang.DataSource, "maKhachHang", true, DataSourceUpdateMode.Never));
            txtHoTenKhachHang.DataBindings.Add(new Binding("Text", dgvThongTinKhachHang.DataSource, "hoTenKhachHang", true, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Value", dgvThongTinKhachHang.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvThongTinKhachHang.DataSource, "diaChi", true, DataSourceUpdateMode.Never));
            cbbGioiTinh.DataBindings.Add(new Binding("Text", dgvThongTinKhachHang.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never));
            txtCCCD.DataBindings.Add(new Binding("Text", dgvThongTinKhachHang.DataSource, "CCCD", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dgvThongTinKhachHang.DataSource, "soDienThoai", true, DataSourceUpdateMode.Never));
        }

        void GetDataInDataGridView(int idx)
        {
            DataGridViewRow row = dgvThongTinKhachHang.Rows[idx];
            txtMaKhachHang.Text = row.Cells["maKhachHang"].Value.ToString();
            txtHoTenKhachHang.Text = row.Cells["hoTenKhachHang"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["ngaySinh"].Value.ToString());
            txtDiaChi.Text = row.Cells["diaChi"].Value.ToString();
            cbbGioiTinh.Text = row.Cells["gioiTinh"].Value.ToString();
            txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
            txtSoDienThoai.Text = row.Cells["soDienThoai"].Value.ToString();
        }

        /// <summary>
        /// Function for form
        /// </summary>
        void ClearText()
        {
            foreach (Control item in grbThongTinKhachHang.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
            dtpNgaySinh.Value = DateTime.Now;
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
            foreach (Control item in grbThongTinKhachHang.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
            }
            dtpNgaySinh.Enabled = false;
            cbbGioiTinh.Enabled = false;
        }
        void EnableTextBox()
        {
            foreach (Control item in grbThongTinKhachHang.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true;
                }
            }
            txtMaKhachHang.Enabled = false;
            dtpNgaySinh.Enabled = true;
            cbbGioiTinh.Enabled = true;
        }

        #endregion
    }
}
