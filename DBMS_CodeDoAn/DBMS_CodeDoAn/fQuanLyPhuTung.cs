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
            byte[] hinhAnh = ImageToByteArray(picPhuTung);

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

        #endregion

        #region method

        void LoadDanhSachPhuTung()
        {
            List<PhuTung> listPhuTung = PhuTungDAO.Instance.DanhSachPhuTung();
            bindingPhuTung.DataSource = listPhuTung;
            dgvThongTinPhuTung.DataSource = bindingPhuTung;
        }

        bool ThemPhuTung(string loaiPhuTung, string tenPhuTung, string thuongHieu, string xuatXu, float giaBan, string chatLuong, byte[] hinhAnh)
        {
            return PhuTungDAO.Instance.ThemPhuTung(loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh);
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
            picPhuTung.DataBindings.Add("Image", dgvThongTinPhuTung.DataSource, "hinhAnh", true, DataSourceUpdateMode.Never);
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
                MessageBox.Show(pic.ImageLocation);
            }
        }

        private byte[] ImageToByteArray(PictureBox pic)
        {
            MemoryStream ms = new MemoryStream();
            pic.Image.Save(ms, pic.Image.RawFormat);
            return ms.ToArray();
        }

        #endregion
    }
}
