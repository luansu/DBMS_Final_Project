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
    public partial class fQuanLyChiTietPhieuNhapPhuTung : Form
    {
        public fQuanLyChiTietPhieuNhapPhuTung()
        {
            InitializeComponent();
            LoadAll();
        }

        #region event

        #endregion

        #region method

        void LoadAll()
        {
            LoadDanhSachChiTietPhieuNhapPhuTung();
            LoadDanhSachMaPhieuNhap();
            LoadDanhSachMaPhuTung();
        }

        void LoadDanhSachChiTietPhieuNhapPhuTung()
        {
            List<ChiTietPhieuNhapPhuTung> listCTPNPhuTung = ChiTietPhieuNhapPhuTungDAO.Instance.DanhSachChiTietPhieuNhapPhuTung();
            dgvThongTinChiTietPhieuNhapPhuTung.DataSource = listCTPNPhuTung;
        }

        void LoadDanhSachMaPhieuNhap()
        {
            List<PhieuNhap> listPhieuNhap = PhieuNhapDAO.Instance.DanhSachPhieuNhap();
            cbbMaPhieuNhap.DataSource = listPhieuNhap;
            cbbMaPhieuNhap.DisplayMember = "maPhieuNhap";
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
