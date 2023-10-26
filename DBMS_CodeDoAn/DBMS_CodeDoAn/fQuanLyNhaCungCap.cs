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
    public partial class fQuanLyNhaCungCap : Form
    {
        int index = 0;
        string strBtn = "";
        BindingSource bindingNhaCungCap = new BindingSource();
        public fQuanLyNhaCungCap()
        {
            InitializeComponent();
            LoadDanhSachNhaCungCap();
            BindingData();
        }

        #region event

        private void fQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            DisableButtonSystem();
            DisableTextBox();
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

            string maNhaCungCap = txtMaNhaCungCap.Text;
            string tenNhaCungCap = txtTenNhaCungCap.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string diaChi = txtDiaChi.Text;

            if (strBtn == "Add")
            {
                bool result = ThemNhaCungCap(maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai);
                if (result)
                {
                    MessageBox.Show("Thêm chi nhánh thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else if (strBtn == "Edit")
            {
                bool result = CapNhatNhaCungCap(maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai);
                if (result)
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else if (strBtn == "Delete")
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa nhà cung cấp này?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool result = XoaNhaCungCap(maNhaCungCap);
                    if (result)
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
            ClearText();
            LoadDanhSachNhaCungCap();
            
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
            if (index < dgvThongTinNhaCungCap.Rows.Count - 1)
            {
                index++;
                GetDataInDataGridView(index);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            index = dgvThongTinNhaCungCap.Rows.Count - 1;
            GetDataInDataGridView(index);
        }

        #endregion

        #region method

        void LoadDanhSachNhaCungCap()
        {
            List<NhaCungCap> listNhaCungCap = NhaCungCapDAO.Instance.DanhSachNhaCungCap();
            bindingNhaCungCap.DataSource = listNhaCungCap;
            dgvThongTinNhaCungCap.DataSource = bindingNhaCungCap;
        }

        bool ThemNhaCungCap(string maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai)
        {
            return NhaCungCapDAO.Instance.ThemNhaCungCap(maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai);
        }

        bool CapNhatNhaCungCap(string maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai)
        {
            return NhaCungCapDAO.Instance.CapNhatNhaCungCap(maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai);
        }

        bool XoaNhaCungCap(string maNhaCungCap)
        {
            return NhaCungCapDAO.Instance.XoaNhaCungCap(maNhaCungCap);
        }

        void BindingData()
        {
            txtMaNhaCungCap.DataBindings.Add(new Binding("Text", dgvThongTinNhaCungCap.DataSource, "maNhaCungCap", true, DataSourceUpdateMode.Never));
            txtTenNhaCungCap.DataBindings.Add(new Binding("Text", dgvThongTinNhaCungCap.DataSource, "tenNhaCungCap", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvThongTinNhaCungCap.DataSource, "diaChi", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dgvThongTinNhaCungCap.DataSource, "soDienThoai", true, DataSourceUpdateMode.Never));

        }

        void GetDataInDataGridView(int idx)
        {
            DataGridViewRow row = dgvThongTinNhaCungCap.Rows[idx];
            txtMaNhaCungCap.Text = row.Cells["maNhaCungCap"].Value.ToString();
            txtTenNhaCungCap.Text = row.Cells["tenNhaCungCap"].Value.ToString();
            txtDiaChi.Text = row.Cells["diaChi"].Value.ToString();
            txtSoDienThoai.Text = row.Cells["soDienThoai"].Value.ToString();
        }

        void ClearText()
        {
            foreach (Control item in grbThongTinNhaCungCap.Controls)
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
            foreach (Control item in grbThongTinNhaCungCap.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
            }
        }
        void EnableTextBox()
        {
            foreach (Control item in grbThongTinNhaCungCap.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true;
                }
            }
        }
        #endregion
    }
}
