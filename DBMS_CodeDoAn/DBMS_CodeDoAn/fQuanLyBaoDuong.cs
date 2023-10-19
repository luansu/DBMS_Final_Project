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
    public partial class fQuanLyBaoDuong : Form
    {
        BindingSource sourceDichVuBaoDuong = new BindingSource();
        string strBtn = "";
        int index = 0;
        public fQuanLyBaoDuong()
        {
            InitializeComponent();
            LoadDanhSachDichVuBaoDuong();
            BindingDichVuBaoDuong();
        }

        #region events

        private void fQuanLyBaoDuong_Load(object sender, EventArgs e)
        {
            CloseButtonSystem();
            CloseTextBox();
        }

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
            strBtn = "Update";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            CloseButtonEditData();
            OpenButtonSystem();
            strBtn = "Delete";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CloseButtonSystem();
            CloseTextBox();
            OpenButtonEditData();

            string maBaoDuong = txtMaBaoDuong.Text;
            string tenBaoDuong = txtTenBaoDuong.Text;
            string loaiBaoDuong = txtLoaiBaoDuong.Text;
            float phiBaoDuong = (float)Convert.ToDouble(txtPhiBaoDuong.Text.ToString());
            if (strBtn == "Add")
            {
                bool result = ThemDichVuBaoDuong(tenBaoDuong, loaiBaoDuong, phiBaoDuong);

                if (result)
                {
                    MessageBox.Show("Thêm dịch vụ bảo dưỡng mới thành công");
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm dịch vụ bảo dưỡng, vui lòng kiểm tra lại");
                }

            }
            else if (strBtn == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool result = XoaDichVuBaoDuong(maBaoDuong);
                    if (result)
                    {
                        MessageBox.Show("Xóa dịch vụ bảo dưỡng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa dịch vụ bảo dưỡng thất bại");
                    }
                }

            }
            else if (strBtn == "Update")
            {
                bool result = CapNhatDichVuBaoDuong(maBaoDuong, tenBaoDuong, loaiBaoDuong, phiBaoDuong);
                if (result)
                {
                    MessageBox.Show("Cập nhật dịch vụ bảo dưỡng thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            LoadDanhSachDichVuBaoDuong();
            ClearText();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
            CloseButtonSystem();
            CloseTextBox();
            OpenButtonEditData();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            int index = 0;
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
            if (index < dgvThongTinDichVuBaoDuong.Rows.Count - 1)
            {
                index++;
                GetDataInDataGridView(index);
            }
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            int index = dgvThongTinDichVuBaoDuong.Rows.Count - 1;
            GetDataInDataGridView(index);
        }

        #endregion



        #region methods

        void LoadDanhSachDichVuBaoDuong()
        {
            List<DichVuBaoDuong> listBaoDuong = DichVuBaoDuongDAO.Instance.DanhSachDichVuBaoDuong();
            sourceDichVuBaoDuong.DataSource = listBaoDuong;
            dgvThongTinDichVuBaoDuong.DataSource = sourceDichVuBaoDuong;
        }
        bool ThemDichVuBaoDuong(string tenBaoDuong, string loaiBaoDuong, float phiBaoDuong)
        {
            return DichVuBaoDuongDAO.Instance.ThemDichVuBaoDuong(tenBaoDuong, loaiBaoDuong, phiBaoDuong);
        }
        bool XoaDichVuBaoDuong(string maBaoDuong)
        {
            return DichVuBaoDuongDAO.Instance.XoaDichVuBaoDuong(maBaoDuong);
        }
        bool CapNhatDichVuBaoDuong(string maBaoDuong, string tenBaoDuong, string loaiBaoDuong, float phiBaoDuong)
        {
            return DichVuBaoDuongDAO.Instance.CapNhatDichVuBaoDuong(maBaoDuong, tenBaoDuong, loaiBaoDuong, phiBaoDuong );
        }
        void BindingDichVuBaoDuong()
        {
            // Binding dữ liệu: 1: Thuộc tính, 2 Source, 3 : Tên cột, 4 : Chuyển kiểu DL, 5 : Chiều binding
            txtMaBaoDuong.DataBindings.Add(new Binding("Text", dgvThongTinDichVuBaoDuong.DataSource, "maBaoDuong", true, DataSourceUpdateMode.Never));
            txtTenBaoDuong.DataBindings.Add(new Binding("Text", dgvThongTinDichVuBaoDuong.DataSource, "tenBaoDuong", true, DataSourceUpdateMode.Never));
            txtLoaiBaoDuong.DataBindings.Add(new Binding("Text", dgvThongTinDichVuBaoDuong.DataSource, "loaiBaoDuong", true, DataSourceUpdateMode.Never));
            txtPhiBaoDuong.DataBindings.Add(new Binding("Text", dgvThongTinDichVuBaoDuong.DataSource, "phiBaoDuong", true, DataSourceUpdateMode.Never));
        }
        void GetDataInDataGridView(int index)
        {
            DataGridViewRow row = dgvThongTinDichVuBaoDuong.Rows[index];
            txtMaBaoDuong.Text = row.Cells[0].Value.ToString();
            txtTenBaoDuong.Text = row.Cells[1].Value.ToString();
            txtLoaiBaoDuong.Text = row.Cells[2].Value.ToString();
            txtPhiBaoDuong.Text = row.Cells[3].Value.ToString();
        }

        /// <summary>
        /// Function for form
        /// </summary>
        void ClearText()
        {
            foreach (Control item in grbThongTinBaoDuong.Controls)
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
            foreach (Control item in grbThongTinBaoDuong.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
            }
        }
        void OpenTextBox()
        {
            foreach (Control item in grbThongTinBaoDuong.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true;
                }
            }

            txtMaBaoDuong.Enabled = false;
        }

        #endregion

    }
}
