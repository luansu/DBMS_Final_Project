using DBMS_CodeDoAn.DAO;
using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_CodeDoAn
{
    public partial class fQuanLyPhuTung : Form
    {
        int index = 0;
        string strBtn = "Add";
        BindingSource bindingPhuTung = new BindingSource();
        public fQuanLyPhuTung()
        {
            InitializeComponent();
            LoadDanhSachPhuTung();
            BindingData();
        }

        #region event

        private void fQuanLyPhuTung_Load(object sender, EventArgs e)
        {
            DisableButtonSystem();
            DisableTextBox();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenPicture(picPhuTung);
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

            string maPhuTung = txtMaPhuTung.Text;
            string loaiPhuTung = txtLoaiPhuTung.Text;
            string tenPhuTung = txtTenPhuTung.Text;
            string thuongHieu = txtThuongHieu.Text;
            string xuatXu = txtXuatXu.Text;
            float giaBan = (float)Convert.ToDouble(txtGiaBan.Text);
            string chatLuong = txtChatLuong.Text;
            string hinhAnh = picPhuTung.ImageLocation;

            if (strBtn == "Add")
            {
                bool result = ThemPhuTung(loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh);
                if (result)
                {
                    MessageBox.Show("Thêm phụ tùng thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else if (strBtn == "Edit")
            {
                bool result = CapNhatPhuTung(maPhuTung, loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh);
                if (result)
                {
                    MessageBox.Show("Cập nhật phụ tùng thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else if (strBtn == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa phụ tùng này", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool result = XoaPhuTung(maPhuTung);
                    if (result)
                    {
                        MessageBox.Show("Xóa phụ tùng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }

            LoadDanhSachPhuTung();
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
            if (index < dgvThongTinPhuTung.Rows.Count - 1)
            {
                index++;
                GetDataInDataGridView(index);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            index = dgvThongTinPhuTung.Rows.Count - 1;
            GetDataInDataGridView(index);
        }

        #endregion

        #region method

        void LoadDanhSachPhuTung()
        {
            List<PhuTung> listPhuTung = PhuTungDAO.Instance.DanhSachPhuTung();
            bindingPhuTung.DataSource = listPhuTung;
            dgvThongTinPhuTung.DataSource = bindingPhuTung;
        }

        bool ThemPhuTung(string loaiPhuTung, string tenPhuTung, string thuongHieu, string xuatXu, float giaBan, string chatLuong, string hinhAnh)
        {
            return PhuTungDAO.Instance.ThemPhuTung(loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh);
        }

        bool CapNhatPhuTung(string maPhuTung, string loaiPhuTung, string tenPhuTung, string thuongHieu, string xuatXu, float giaBan, string chatLuong,string hinhAnh)
        {
            return PhuTungDAO.Instance.CapNhatPhuTung(maPhuTung, loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh);
        }

        bool XoaPhuTung(string maPhuTung)
        {
            return PhuTungDAO.Instance.XoaPhuTung(maPhuTung);
        }

        void GetDataInDataGridView(int idx)
        {
            DataGridViewRow row = dgvThongTinPhuTung.Rows[idx];
            txtMaPhuTung.Text = row.Cells[0].Value.ToString();
            txtLoaiPhuTung.Text = row.Cells[1].Value.ToString();
            txtTenPhuTung.Text = row.Cells[2].Value.ToString();
            txtThuongHieu.Text = row.Cells[3].Value.ToString();
            txtXuatXu.Text = row.Cells[4].Value.ToString();
            txtGiaBan.Text = row.Cells[5].Value.ToString();
            txtChatLuong.Text = row.Cells[6].Value.ToString();
            picPhuTung.ImageLocation = row.Cells[7].Value.ToString();
        }

        void BindingData()
        {
            txtMaPhuTung.DataBindings.Add("Text", dgvThongTinPhuTung.DataSource, "maPhuTung", true, DataSourceUpdateMode.Never);
            txtLoaiPhuTung.DataBindings.Add("Text", dgvThongTinPhuTung.DataSource, "loaiPhuTung", true, DataSourceUpdateMode.Never);
            txtTenPhuTung.DataBindings.Add("Text", dgvThongTinPhuTung.DataSource, "tenPhuTung", true, DataSourceUpdateMode.Never);
            txtThuongHieu.DataBindings.Add("Text", dgvThongTinPhuTung.DataSource, "thuongHieu", true, DataSourceUpdateMode.Never);
            txtXuatXu.DataBindings.Add("Text", dgvThongTinPhuTung.DataSource, "xuatXu", true, DataSourceUpdateMode.Never);
            txtGiaBan.DataBindings.Add("Text", dgvThongTinPhuTung.DataSource, "giaBan", true, DataSourceUpdateMode.Never);
            txtChatLuong.DataBindings.Add("Text", dgvThongTinPhuTung.DataSource, "chatLuong", true, DataSourceUpdateMode.Never);
            picPhuTung.DataBindings.Add("ImageLocation", dgvThongTinPhuTung.DataSource, "hinhAnh", true, DataSourceUpdateMode.Never);
        }

        void ClearText()
        {
            foreach (Control item in grbPhuTung.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).ResetText();    
                }
            }
            picPhuTung.ImageLocation = null;
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
            foreach (Control item in grbPhuTung.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
            }
        }
        void EnableTextBox()
        {
            foreach (Control item in grbPhuTung.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true;
                }
            }
            txtMaPhuTung.Enabled = false;
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
