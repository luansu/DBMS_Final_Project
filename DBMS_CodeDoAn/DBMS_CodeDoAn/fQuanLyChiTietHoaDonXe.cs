using DBMS_CodeDoAn.DAO;
using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_CodeDoAn
{
    public partial class fQuanLyChiTietHoaDonXe : Form
    {
        int index = 0;
        string strBtn = "";
        BindingSource bindingChiTietHoaDonXe = new BindingSource();
        public fQuanLyChiTietHoaDonXe()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event

        private void fQuanLyChiTietHoaDonXe_Load(object sender, EventArgs e)
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

            string maCTHDXe = txtMaChiTietHoaDonXe.Text;
            string maHoaDon = cbbMaHoaDon.Text;
            string maXe = cbbMaXe.Text;
            string ngayNhan = dtpNgayNhanXe.Value.ToString("yyyy-MM-dd");
            float soTienDaTra = (float)Convert.ToDouble(txtSoTienDaTra.Text.ToString());
            float phiDangKyBienSo = (float)Convert.ToDouble(txtPhiDangKyBienSo.Text.ToString());
            float phiDangKiem = (float)Convert.ToDouble(txtPhiDangKiem.Text.ToString());
            float phiTruocBa = (float)Convert.ToDouble(txtPhiTruocBa.Text.ToString());
            float phiBaoHiemTrachNhiemHinhSu = (float)Convert.ToDouble(txtPhiBaoHiemTrachNhiemDanSu.Text.ToString());
            float phiSuDungDuongBo = (float)Convert.ToDouble(txtPhiSuDungDuongBo.Text.ToString());

            if (strBtn == "Add")
            {
                bool result = ThemChiTietHoaDonXe(maHoaDon, maXe, ngayNhan, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemHinhSu, phiSuDungDuongBo);
                if (result)
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn mới thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else if (strBtn == "Edit")
            {
                bool result = CapNhatChiTietHoaDonXe(maCTHDXe, maHoaDon, maXe, ngayNhan, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemHinhSu, phiSuDungDuongBo);
                if (result)
                {
                    MessageBox.Show("Cập nhật chi tiết hóa đơn thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else if (strBtn == "Delete")
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa chi tiết hóa đơn này không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool result = XoaChiTietHoaDonXe(maCTHDXe);
                    if (result)
                    {
                        MessageBox.Show("Xóa chi tiết hóa đơn thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }

            ClearText();
            LoadDanhSachChiTietHoaDonXe();
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
            if (index < dgvThongTinChiTietHoaDonXe.Rows.Count - 1)
            {
                index++;
                GetDataInDataGridView(index);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            index = dgvThongTinChiTietHoaDonXe.Rows.Count - 1;
            GetDataInDataGridView(index);
        }

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachChiTietHoaDonXe();
            LoadDanhSachMaHoaDon();
            LoadDanhSachMaXe();
            BindingData();
        }

        void LoadDanhSachChiTietHoaDonXe()
        {
            List<ChiTietHoaDonXe> listCTHDXe = ChiTietHoaDonXeDAO.Instance.DanhSachCTHDXe();
            bindingChiTietHoaDonXe.DataSource = listCTHDXe;
            dgvThongTinChiTietHoaDonXe.DataSource = bindingChiTietHoaDonXe;
        }

        void LoadDanhSachMaHoaDon()
        {
            List<HoaDon> listMaHoaDon = HoaDonDAO.Instance.DanhSachHoaDon();
            cbbMaHoaDon.DataSource = listMaHoaDon;
            cbbMaHoaDon.DisplayMember = "maHoaDon";
        }

        void LoadDanhSachMaXe()
        {
            List<string> listMaXe = XeDAO.Instance.DanhSachMaXe();
            cbbMaXe.DataSource = listMaXe;
        }

        bool ThemChiTietHoaDonXe(string maHoaDon, string maXe, string ngayNhanXe, float soTienDaTra, float phiDangKyBienSo, float phiDangKiem, float phiTruocBa, float phiBaoHiemTrachNhiemDanSu, float phiSuDungDuongBo)
        {
            return ChiTietHoaDonXeDAO.Instance.ThemChiTietHoaDonXe(maHoaDon, maXe, ngayNhanXe, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo);
        }

        bool CapNhatChiTietHoaDonXe(string maChiTietHoaDonXe, string maHoaDon, string maXe, string ngayNhanXe, float soTienDaTra, float phiDangKyBienSo, float phiDangKiem, float phiTruocBa, float phiBaoHiemTrachNhiemDanSu, float phiSuDungDuongBo)
        {
            return ChiTietHoaDonXeDAO.Instance.CapNhatChiTietHoaDonXe(maChiTietHoaDonXe, maHoaDon, maXe, ngayNhanXe, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, phiBaoHiemTrachNhiemDanSu, phiSuDungDuongBo);
        }
        
        bool XoaChiTietHoaDonXe(string maChiTietHoaDonXe)
        {
            return ChiTietHoaDonXeDAO.Instance.XoaChiTietHoaDonXe(maChiTietHoaDonXe);
        }

        void GetDataInDataGridView(int idx)
        {
            DataGridViewRow row = dgvThongTinChiTietHoaDonXe.Rows[idx];
            txtMaChiTietHoaDonXe.Text = row.Cells[0].Value.ToString();
            cbbMaHoaDon.Text = row.Cells[1].Value.ToString();
            cbbMaXe.Text = row.Cells[2].Value.ToString();
            dtpNgayNhanXe.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
            txtSoTienDaTra.Text = row.Cells[4].Value.ToString();
            txtPhiDangKyBienSo.Text = row.Cells[5].Value.ToString();
            txtPhiDangKiem.Text = row.Cells[6].Value.ToString();
            txtPhiTruocBa.Text = row.Cells[7].Value.ToString();
            txtPhiBaoHiemTrachNhiemDanSu.Text = row.Cells[8].Value.ToString();
            txtPhiSuDungDuongBo.Text = row.Cells[9].Value.ToString();
        }

        void BindingData()
        {
            txtMaChiTietHoaDonXe.DataBindings.Add("Text", dgvThongTinChiTietHoaDonXe.DataSource, "maChiTietHoaDonXe", true, DataSourceUpdateMode.Never);
            cbbMaHoaDon.DataBindings.Add("Text", dgvThongTinChiTietHoaDonXe.DataSource, "maHoaDon", true, DataSourceUpdateMode.Never);
            cbbMaXe.DataBindings.Add("Text", dgvThongTinChiTietHoaDonXe.DataSource, "maXe", true, DataSourceUpdateMode.Never);
            dtpNgayNhanXe.DataBindings.Add("Value", dgvThongTinChiTietHoaDonXe.DataSource, "ngayNhanXe", true, DataSourceUpdateMode.Never);
            txtSoTienDaTra.DataBindings.Add("Text", dgvThongTinChiTietHoaDonXe.DataSource, "soTienDaTra", true, DataSourceUpdateMode.Never);
            txtPhiDangKyBienSo.DataBindings.Add("Text", dgvThongTinChiTietHoaDonXe.DataSource, "phiDangKyBienSo", true, DataSourceUpdateMode.Never);
            txtPhiDangKiem.DataBindings.Add("Text", dgvThongTinChiTietHoaDonXe.DataSource, "phiDangKiem", true, DataSourceUpdateMode.Never);
            txtPhiTruocBa.DataBindings.Add("Text", dgvThongTinChiTietHoaDonXe.DataSource, "phiTruocBa", true, DataSourceUpdateMode.Never);
            txtPhiBaoHiemTrachNhiemDanSu.DataBindings.Add("Text", dgvThongTinChiTietHoaDonXe.DataSource, "phiBaoHiemTrachNhiemDanSu", true, DataSourceUpdateMode.Never);
            txtPhiSuDungDuongBo.DataBindings.Add("Text", dgvThongTinChiTietHoaDonXe.DataSource, "phiSuDungDuongBo", true, DataSourceUpdateMode.Never);
        }

        void ClearText()
        {
            foreach (Control item in grbChiTietHoaDonXe.Controls)
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
            foreach (Control item in grbChiTietHoaDonXe.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
            }
            cbbMaHoaDon.Enabled = false;
            cbbMaXe.Enabled = false;
            dtpNgayNhanXe.Enabled = false;
        }
        void EnableTextBox()
        {
            foreach (Control item in grbChiTietHoaDonXe.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true;
                }
            }
            txtMaChiTietHoaDonXe.Enabled = false;
            cbbMaHoaDon.Enabled = true;
            cbbMaXe.Enabled = true;
            dtpNgayNhanXe.Enabled = true;
        }

        #endregion
    }
}
