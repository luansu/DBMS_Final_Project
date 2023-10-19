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
    public partial class fQuanLyChiNhanh : Form
    {
        string strBtn = "";
        int index = 0;
        BindingSource sourceChiNhanh = new BindingSource();

        public fQuanLyChiNhanh()
        {
            InitializeComponent();
            LoadDanhSachChiNhanh();
            
        }

        #region event

        private void fQuanLyChiNhanh_Load(object sender, EventArgs e)
        {
            CloseTextBox();
            CloseButtonSystem();
            BindingData();
        }

        /// <summary>
        /// Button Data
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearText();
            CloseButtonEditData();
            OpenTextBox();
            OpenButtonSystem();
            strBtn = "Add";
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            CloseButtonEditData();
            OpenTextBox();
            OpenButtonSystem();
            strBtn = "Edit";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            CloseButtonEditData();
            OpenButtonSystem();
            strBtn = "Delete";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CloseTextBox();
            CloseButtonSystem();
            OpenButtonEditData();

            string maChiNhanh = txtMaChiNhanh.Text;
            string tenChiNhanh = txtTenChiNhanh.Text;
            string diaChi = txtDiaChi.Text;

            if (strBtn == "Add")
            {
                bool result = ThemChiNhanh(maChiNhanh, tenChiNhanh, diaChi);
                if (result)
                {
                    MessageBox.Show("Thêm chi nhánh thành công");
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu thất bại, vui lòng kiểm tra lại");
                }
            }
            else if (strBtn == "Edit")
            {
                bool result = CapNhatChiNhanh(maChiNhanh, tenChiNhanh, diaChi);
                if (result)
                {
                    MessageBox.Show("Cập nhật thông tin chi nhánh thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else if (strBtn == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa chi nhánh này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool result = XoaChiNhanh(maChiNhanh);
                    if (result)
                    {
                        MessageBox.Show("Xóa chi nhánh thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại");
                    }
                }
            }
            LoadDanhSachChiNhanh();
            ClearText();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseTextBox();
            CloseButtonSystem();
            OpenButtonEditData();
        }

        /// <summary>
        /// Button view
        /// </summary>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            index = 0;
            GetDataInDataGriview(index);
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                GetDataInDataGriview(index);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index < dgvThongTinChiNhanh.Rows.Count - 1)
            {
                index++;
                GetDataInDataGriview(index);
            }
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            index = dgvThongTinChiNhanh.Rows.Count - 1;
            GetDataInDataGriview(index);
        }

        #endregion

        #region method

        void LoadDanhSachChiNhanh()
        {
            List<ChiNhanh> listChiNhanh = ChiNhanhDAO.Instance.DanhSachChiNhanh();
            sourceChiNhanh.DataSource = listChiNhanh;
            dgvThongTinChiNhanh.DataSource = sourceChiNhanh;
        }
        bool ThemChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi)
        {
            return ChiNhanhDAO.Instance.ThemChiNhanh(maChiNhanh, tenChiNhanh, diaChi);
        }
        bool CapNhatChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi)
        {
            return ChiNhanhDAO.Instance.CapNhatChiNhanh(maChiNhanh, tenChiNhanh, diaChi);
        }
        bool XoaChiNhanh(string maChiNhanh)
        {
            return ChiNhanhDAO.Instance.XoaChiNhanh(maChiNhanh);
        }
        void BindingData()
        {
            txtMaChiNhanh.DataBindings.Add(new Binding
                ("Text", dgvThongTinChiNhanh.DataSource, "maChiNhanh", true, DataSourceUpdateMode.Never));
            txtTenChiNhanh.DataBindings.Add(new Binding
                ("Text", dgvThongTinChiNhanh.DataSource, "tenChiNhanh", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding
                ("Text", dgvThongTinChiNhanh.DataSource, "diaChi", true, DataSourceUpdateMode.Never));
        }

        void GetDataInDataGriview(int idx)
        {
            DataGridViewRow row = dgvThongTinChiNhanh.Rows[idx];
            txtMaChiNhanh.Text = row.Cells[0].Value.ToString();
            txtTenChiNhanh.Text = row.Cells[1].Value.ToString();
            txtDiaChi.Text = row.Cells[2].Value.ToString();
        }

        void ClearText()
        {
            foreach (Control item in grbThongTinChiNhanh.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }
        void OpenButtonEditData()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }
        void CloseButtonEditData()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        void OpenButtonSystem()
        {
            btnSave.Enabled = true;
            btnReset.Enabled = true;
            btnCancel.Enabled = true;
        }
        void CloseButtonSystem()
        {
            btnSave.Enabled = false;
            btnReset.Enabled = false;
            btnCancel.Enabled = false;
        }
        void CloseTextBox()
        {
            foreach (Control item in grbThongTinChiNhanh.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
            }
        }
        void OpenTextBox()
        {
            foreach (Control item in grbThongTinChiNhanh.Controls)
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
