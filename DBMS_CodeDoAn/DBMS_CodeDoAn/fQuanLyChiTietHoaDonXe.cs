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
    public partial class fQuanLyChiTietHoaDonXe : Form
    {
        public fQuanLyChiTietHoaDonXe()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachChiTietHoaDonXe();
            LoadDanhSachMaHoaDon();
            LoadDanhSachMaXe();
        }

        void LoadDanhSachChiTietHoaDonXe()
        {
            List<ChiTietHoaDonXe> listCTHDXe = ChiTietHoaDonXeDAO.Instance.DanhSachCTHDXe();
            dgvThongTinChiTietHoaDonXe.DataSource = listCTHDXe;
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

        #endregion
    }
}
