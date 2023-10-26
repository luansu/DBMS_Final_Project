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
    public partial class fQuanLyPhieuNhap : Form
    {
        int index = 0;
        string strBtn = "";
        BindingSource bindingPhieuNhap = new BindingSource();
        public fQuanLyPhieuNhap()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event
        private void fQuanLyPhieuNhap_Load(object sender, EventArgs e)
        {
            DisableButtonSystem();
            DisableTextBox();
        }

        private void btnChiTietPhieuNhapXe_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyChiTietPhieuNhapXe f = new fQuanLyChiTietPhieuNhapXe();
            f.ShowDialog();
            this.Show();
        }
        private void btnChiTietPhieuNhapPhuTung_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyChiTietPhieuNhapPhuTung f = new fQuanLyChiTietPhieuNhapPhuTung();
            f.ShowDialog();
            this.Show();
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

            string maPhieuNhap = txtMaPhieuNhap.Text;
            string ngayNhap = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
            string maChiNhanh = cbbMaChiNhanh.Text;
            string maNhaCungCap = cbbMaNhaCungCap.Text;

            if (strBtn == "Add")
            {
                bool result = ThemPhieuNhap(ngayNhap, maChiNhanh, maNhaCungCap);
                if (result)
                {
                    MessageBox.Show("Thêm phiếu nhập thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thấy bại");
                }
            }
            else if (strBtn == "Edit")
            {
                bool result = CapNhatPhieuNhap(maPhieuNhap, ngayNhap, maChiNhanh, maNhaCungCap);
                if (result)
                {
                    MessageBox.Show("Cập nhật phiếu nhập thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else if (strBtn == "Delete")
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa phiếu nhập này không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool result = XoaPhieuNhap(maPhieuNhap);
                    if (result)
                    {
                        MessageBox.Show("Xóa phiếu nhập thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
            ClearText();
            LoadDanhSachPhieuNhap();
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
            GetDataInDataGridVew(index);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                GetDataInDataGridVew(index);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index < dgvThongTinPhieuNhap.Rows.Count - 1)
            {
                index++;
                GetDataInDataGridVew(index);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            index = dgvThongTinPhieuNhap.Rows.Count - 1;
            GetDataInDataGridVew(index);
        }

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachPhieuNhap();
            LoadDanhSachMaChiNhanh();
            LoadDanhSachMaNhaCungCap();
            BindingData();
        }

        void LoadDanhSachMaChiNhanh()
        {
            List<ChiNhanh> listChiNhanh = ChiNhanhDAO.Instance.DanhSachChiNhanh();
            cbbMaChiNhanh.DataSource = listChiNhanh;
            cbbMaChiNhanh.DisplayMember = "maChiNhanh";
        }

        void LoadDanhSachMaNhaCungCap()
        {
            List<NhaCungCap> listNhaCungCap = NhaCungCapDAO.Instance.DanhSachNhaCungCap();
            cbbMaNhaCungCap.DataSource = listNhaCungCap;
            cbbMaNhaCungCap.DisplayMember = "maNhaCungCap";
        }

        void LoadDanhSachPhieuNhap()
        {
            List<PhieuNhap> listPhieuNhap = PhieuNhapDAO.Instance.DanhSachPhieuNhap();
            bindingPhieuNhap.DataSource = listPhieuNhap;
            dgvThongTinPhieuNhap.DataSource = bindingPhieuNhap;
        }

        bool ThemPhieuNhap(string ngayNhap, string maChiNhanh, string maNhaCungCap)
        {
            return PhieuNhapDAO.Instance.ThemPhieuNhap(ngayNhap, maChiNhanh, maNhaCungCap);
        }

        bool CapNhatPhieuNhap(string maPhieuNhap, string ngayNhap, string maChiNhanh, string maNhaCungCap)
        {
            return PhieuNhapDAO.Instance.CapNhatPhieuNhap(maPhieuNhap, ngayNhap, maChiNhanh, maNhaCungCap);
        }
        
        bool XoaPhieuNhap(string maPhieuNhap)
        {
            return PhieuNhapDAO.Instance.XoaPhieuNhap(maPhieuNhap);
        }
        
        void GetDataInDataGridVew(int idx)
        {
            DataGridViewRow row = dgvThongTinPhieuNhap.Rows[idx];
            txtMaPhieuNhap.Text = row.Cells[0].Value.ToString();
            dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["ngayNhap"].Value.ToString());
            cbbMaChiNhanh.Text = row.Cells[2].Value.ToString();
            cbbMaNhaCungCap.Text = row.Cells[3].Value.ToString();
        }

        void BindingData()
        {
            txtMaPhieuNhap.DataBindings.Add(new Binding("Text", dgvThongTinPhieuNhap.DataSource, "maPhieuNhap", true, DataSourceUpdateMode.Never));
            cbbMaChiNhanh.DataBindings.Add(new Binding("Text", dgvThongTinPhieuNhap.DataSource, "maChiNhanh", true, DataSourceUpdateMode.Never));
            cbbMaNhaCungCap.DataBindings.Add(new Binding("Text", dgvThongTinPhieuNhap.DataSource, "maNhaCungCap", true, DataSourceUpdateMode.Never));
            dtpNgayNhap.DataBindings.Add(new Binding("Value", dgvThongTinPhieuNhap.DataSource, "ngayNhap", true, DataSourceUpdateMode.Never));

        }

        void ClearText()
        {
            foreach (Control item in grbThongTinPhieuNhap.Controls)
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
            txtMaPhieuNhap.Enabled = false;
            cbbMaChiNhanh.Enabled = false;
            cbbMaNhaCungCap.Enabled = false;
            dtpNgayNhap.Enabled = false;
        }
        void EnableTextBox()
        {
            cbbMaChiNhanh.Enabled = true;
            cbbMaNhaCungCap.Enabled = true;
            dtpNgayNhap.Enabled = true;
        }

        #endregion
    }
}
