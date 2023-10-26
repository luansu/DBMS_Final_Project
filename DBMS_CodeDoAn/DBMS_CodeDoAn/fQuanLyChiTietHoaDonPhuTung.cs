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
    public partial class fQuanLyChiTietHoaDonPhuTung : Form
    {
        int index = 0;
        string strBtn = "";
        BindingSource bindingChiTietHDPT = new BindingSource();
        public fQuanLyChiTietHoaDonPhuTung()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event

        private void fQuanLyChiTietHoaDonPhuTung_Load(object sender, EventArgs e)
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

            string maChiTietHoaDonPhuTung = txtMaChiTietHoaDonPhuTung.Text;
            string maHoaDon = cbbMaHoaDon.Text;
            string maPhuTung = cbbMaPhuTung.Text;
            float soTienDaTra = (float)Convert.ToDouble(txtSoTienDaTra.Text.ToString());

            if (strBtn == "Add")
            {
                bool result = ThemChiTietHoaDonPhuTung(maHoaDon, maPhuTung, soTienDaTra);
                if (result)
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn phụ tùng thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else if (strBtn == "Edit")
            {
                bool result = CapNhatChiTietHoaDonPhuTung(maChiTietHoaDonPhuTung, maHoaDon, maPhuTung, soTienDaTra);
                if (result)
                {
                    MessageBox.Show("Cập nhật chi tiết hóa đơn phụ tùng thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else if (strBtn == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa chi tiết hóa đơn phụ tùng này không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    bool result = XoaChiTietHoaDonPhuTung(maChiTietHoaDonPhuTung);
                    if (result)
                    {
                        MessageBox.Show("Xóa chi tiết hóa đơn phụ tùng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
            LoadDanhSachChiTietHoaDonPhuTung();
            ClearText();
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
            if (index < dgvThongTinChTietHoaDonPhuTung.Rows.Count - 1)
            {
                index++;
                GetDataInDataGridView(index);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            index = dgvThongTinChTietHoaDonPhuTung.Rows.Count - 1;
            GetDataInDataGridView(index);
        }

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachChiTietHoaDonPhuTung();
            LoadDanhSachMaHoaDon();
            LoadDanhSachMaPhuTung();
            BindingData();
        }

        void LoadDanhSachChiTietHoaDonPhuTung()
        {
            List<ChiTietHoaDonPhuTung> listCTHDPhuTung = ChiTietHoaDonPhuTungDAO.Instance.DanhSachHoaDonPhuTung();
            bindingChiTietHDPT.DataSource = listCTHDPhuTung;
            dgvThongTinChTietHoaDonPhuTung.DataSource = bindingChiTietHDPT;
        }

        void LoadDanhSachMaHoaDon()
        {
            List<HoaDon> listHoaDon = HoaDonDAO.Instance.DanhSachHoaDon();
            cbbMaHoaDon.DataSource = listHoaDon;
            cbbMaHoaDon.DisplayMember = "maHoaDon";
        }

        void LoadDanhSachMaPhuTung()
        {
            List<PhuTung> listPhuTung = PhuTungDAO.Instance.DanhSachPhuTung();
            cbbMaPhuTung.DataSource = listPhuTung;
            cbbMaPhuTung.DisplayMember = "maPhuTung";
        }

        bool ThemChiTietHoaDonPhuTung(string maHoaDon, string maPhuTung, float soTienDaTra)
        {
            return ChiTietHoaDonPhuTungDAO.Instance.ThemChiTietHoaDonPhuTung(maHoaDon, maPhuTung, soTienDaTra);
        }

        bool CapNhatChiTietHoaDonPhuTung(string maChiTietHDPT, string maHoaDon, string maPhuTung, float soTienDaTra)
        {
            return ChiTietHoaDonPhuTungDAO.Instance.CapNhatChiTietHoaDonPhuTung(maChiTietHDPT, maHoaDon, maPhuTung, soTienDaTra);
        }

        bool XoaChiTietHoaDonPhuTung(string maChiTietHDPT)
        {
            return ChiTietHoaDonPhuTungDAO.Instance.XoaChiTietHoaDonPhuTung(maChiTietHDPT);
        }

        void BindingData()
        {
            txtMaChiTietHoaDonPhuTung.DataBindings.Add("Text", dgvThongTinChTietHoaDonPhuTung.DataSource, "maChiTietHoaDonPhuTung", true, DataSourceUpdateMode.Never);
            cbbMaHoaDon.DataBindings.Add("Text", dgvThongTinChTietHoaDonPhuTung.DataSource, "maHoaDon", true, DataSourceUpdateMode.Never);
            cbbMaPhuTung.DataBindings.Add("Text", dgvThongTinChTietHoaDonPhuTung.DataSource, "maPhuTung", true, DataSourceUpdateMode.Never);
            txtSoTienDaTra.DataBindings.Add("Text", dgvThongTinChTietHoaDonPhuTung.DataSource, "soTienDaTra", true, DataSourceUpdateMode.Never);
        }

        void GetDataInDataGridView(int idx)
        {
            DataGridViewRow row = dgvThongTinChTietHoaDonPhuTung.Rows[idx];
            txtMaChiTietHoaDonPhuTung.Text = row.Cells["maChiTietHoaDonPhuTung"].Value.ToString();
            cbbMaHoaDon.Text = row.Cells["maHoaDon"].Value.ToString();
            cbbMaPhuTung.Text = row.Cells["maPhuTung"].Value.ToString();
            txtSoTienDaTra.Text = row.Cells["soTienDaTra"].Value.ToString();
        }

        /// <summary>
        /// Function for form
        /// </summary>
        void ClearText()
        {
            foreach (Control item in grbChiTietHoaDonPhuTung.Controls)
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
            foreach (Control item in grbChiTietHoaDonPhuTung.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
            }
            cbbMaHoaDon.Enabled = false;
            cbbMaPhuTung.Enabled = false;
        }
        void EnableTextBox()
        {
            foreach (Control item in grbChiTietHoaDonPhuTung.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true;
                }
            }
            txtMaChiTietHoaDonPhuTung.Enabled = false;
            cbbMaHoaDon.Enabled = true;
            cbbMaPhuTung.Enabled = true;
        }

        #endregion
    }
}
