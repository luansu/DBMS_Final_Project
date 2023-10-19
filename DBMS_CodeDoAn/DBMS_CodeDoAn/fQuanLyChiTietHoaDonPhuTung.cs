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
        public fQuanLyChiTietHoaDonPhuTung()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachChiTietHoaDonPhuTung();
            LoadDanhSachMaHoaDon();
            LoadDanhSachMaPhuTung();
        }

        void LoadDanhSachChiTietHoaDonPhuTung()
        {
            List<ChiTietHoaDonPhuTung> listCTHDPhuTung = ChiTietHoaDonPhuTungDAO.Instance.DanhSachHoaDonPhuTung();
            dgvThongTinChTietHoaDonPhuTung.DataSource = listCTHDPhuTung;
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

        #endregion
    }
}
