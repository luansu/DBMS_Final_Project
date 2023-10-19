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
    public partial class fQuanLyChiTietPhieuNhapXe : Form
    {
        public fQuanLyChiTietPhieuNhapXe()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachChiTietPhieuNhapXe();
            LoadDanhSachMaPhieuNhap();
            LoadDanhSachMaXe();
        }

        void LoadDanhSachChiTietPhieuNhapXe()
        {
            List<ChiTietPhieuNhapXe> listCTPNXe = ChiTietPhieuNhapXeDAO.Instance.DanhSachChiTietPhieuNhapXe();
            dgvThongTinChiTietPhieuNhapXe.DataSource = listCTPNXe;
        }

        void LoadDanhSachMaPhieuNhap()
        {
            List<PhieuNhap> listPhieuNhap = PhieuNhapDAO.Instance.DanhSachPhieuNhap();
            cbbMaPhieuNhap.DataSource = listPhieuNhap;
            cbbMaPhieuNhap.DisplayMember = "maPhieuNhap";
        }

        void LoadDanhSachMaXe()
        {
            List<string> listMaXe = XeDAO.Instance.DanhSachMaXe();
            cbbMaXe.DataSource = listMaXe;
        }

        #endregion
    }
}
