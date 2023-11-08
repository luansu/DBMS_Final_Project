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
    public partial class fQuanLyHoaDon : Form
    {
        int index = 0;
        string strBtn = "";
        BindingSource bindingHoaDon = new BindingSource();
        public fQuanLyHoaDon()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event
        
        // Click to open form CarBillDetail
        private void btnChiTietHoaDoaXe_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyChiTietHoaDonXe f = new fQuanLyChiTietHoaDonXe();
            f.ShowDialog();
            this.Show();
        }

        // Click to open form AccessoryBillDetail
        private void btnChiTietHoaDonPhuTung_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyChiTietHoaDonPhuTung f = new fQuanLyChiTietHoaDonPhuTung();
            f.ShowDialog();
            this.Show();
        }

        private void fQuanLyHoaDon_Load(object sender, EventArgs e)
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

            try
            {
                string maHoaDon = txtMaHoaDon.Text;
                string ngayLapHoaDon = dtpNgayLapHoaDon.Value.ToString("yyyy-MM-dd");
                float tongTien = (float)Convert.ToDouble(txtTongTien.Text.ToString());
                string tinhTrang = txtTinhTrang.Text;
                string maKhachHang = cbbMaKhachHang.Text;
                string maNVTH = cbbMaNhanVien.Text;

                if (strBtn == "Add")
                {
                    bool result = ThemHoaDon(ngayLapHoaDon, tongTien, tinhTrang, maKhachHang, maNVTH);
                    if (result)
                    {
                        MessageBox.Show("Thêm hóa đơn thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
                else if (strBtn == "Edit")
                {
                    bool result = CapNhatHoaDon(maHoaDon, ngayLapHoaDon, tongTien, tinhTrang, maKhachHang, maNVTH);
                    if (result)
                    {
                        MessageBox.Show("Cập nhật hóa đơn thành công");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }
                }
                else if (strBtn == "Delete")
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này không?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        bool result = XoaHoaDon(maHoaDon);
                        if (result)
                        {
                            MessageBox.Show("Xóa hóa đơn thành công");
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }

                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Message.Contains("column 'tinhTrang'."))
                {
                    MessageBox.Show("Tình trạng hóa đơn mặc định là 'Chưa thanh toán' !!");
                }
            }

            ClearText();
            LoadDanhSachHoaDon();
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
            LoadDanhSachHoaDon();
            LoadDanhSachMaNhanVien();
            LoadDanhSachMaKhachHang();
            BindingData();
        }

        void LoadDanhSachHoaDon()
        {
            List<HoaDon> listHoaDon = HoaDonDAO.Instance.DanhSachHoaDon();
            bindingHoaDon.DataSource = listHoaDon;
            dgvThongTinHoaDon.DataSource = bindingHoaDon;
        }

        void LoadDanhSachMaNhanVien()
        {
            List<NhanVien> listNhanVien = NhanVienDAO.Instance.DanhSachNhanVien();
            cbbMaNhanVien.DataSource = listNhanVien;
            cbbMaNhanVien.DisplayMember = "maNhanVien";
        }

        void LoadDanhSachMaKhachHang()
        {
            List<KhachHang> listKhachHang = KhachHangDAO.Instance.DanhSachKhachHang();
            cbbMaKhachHang.DataSource = listKhachHang;
            cbbMaKhachHang.DisplayMember = "maKhachHang";
        }

        bool ThemHoaDon(string ngayLapHoaDon, float tongTien, string tinhTrang, string maKhachHang, string maNVTH)
        {
            return HoaDonDAO.Instance.ThemHoaDon(ngayLapHoaDon, tongTien, tinhTrang, maKhachHang, maNVTH);
        }

        bool CapNhatHoaDon(string maHoaDon, string ngayLapHoaDon, float tongTien, string tinhTrang, string maKhachHang, string maNVTH)
        {
            return HoaDonDAO.Instance.CapNhatHoaDon(maHoaDon, ngayLapHoaDon, tongTien, tinhTrang, maKhachHang, maNVTH);
        }

        bool XoaHoaDon(string maHoaDon)
        {
            return HoaDonDAO.Instance.XoaHoaDon(maHoaDon);
        }

        void BindingData()
        {
            txtMaHoaDon.DataBindings.Add("Text", dgvThongTinHoaDon.DataSource, "maHoaDon", true, DataSourceUpdateMode.Never);
            dtpNgayLapHoaDon.DataBindings.Add("Value", dgvThongTinHoaDon.DataSource, "ngayLapHoaDon", true, DataSourceUpdateMode.Never);
            txtTongTien.DataBindings.Add("Text", dgvThongTinHoaDon.DataSource, "tongTien", true, DataSourceUpdateMode.Never);
            txtTinhTrang.DataBindings.Add("Text", dgvThongTinHoaDon.DataSource, "tinhTrang", true, DataSourceUpdateMode.Never);
            cbbMaKhachHang.DataBindings.Add("Text", dgvThongTinHoaDon.DataSource, "maKhachHang", true, DataSourceUpdateMode.Never);
            cbbMaNhanVien.DataBindings.Add("Text", dgvThongTinHoaDon.DataSource, "maNhanVienThucHien", true, DataSourceUpdateMode.Never);
         }

        void ClearText()
        {
            foreach (Control item in grbChiTietHoaDon.Controls)
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
            foreach (Control item in grbChiTietHoaDon.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
            }
            cbbMaNhanVien.Enabled = false;
            cbbMaKhachHang.Enabled = false;
            dtpNgayLapHoaDon.Enabled = false;
        }
        void EnableTextBox()
        {
            foreach (Control item in grbChiTietHoaDon.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true;
                }
            }
            txtMaHoaDon.Enabled = false;
            cbbMaNhanVien.Enabled = true;
            cbbMaKhachHang.Enabled = true;
            dtpNgayLapHoaDon.Enabled = true;
        }

        #endregion
    }
}
