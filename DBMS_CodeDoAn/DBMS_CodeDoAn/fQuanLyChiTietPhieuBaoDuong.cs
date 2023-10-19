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
    public partial class fQuanLyChiTietPhieuBaoDuong : Form
    {
        public fQuanLyChiTietPhieuBaoDuong()
        {
            InitializeComponent();
            LoadAll();
        }

        #region events

        #endregion

        #region methods

        void LoadAll()
        {
            LoadDanhSachChiTietPhieuBaoDuong();
            LoadDanhSachMaBaoDuong();
            LoadDanhSachMaPhieuBaoDuong();
        }

        void LoadDanhSachMaBaoDuong()
        {
            List<DichVuBaoDuong> listBaoDuong = DichVuBaoDuongDAO.Instance.DanhSachDichVuBaoDuong();
            cbbMaBaoDuong.DataSource = listBaoDuong;
            cbbMaBaoDuong.DisplayMember = "maBaoDuong";
        }

        void LoadDanhSachMaPhieuBaoDuong()
        {
            List<PhieuBaoDuong> listPhieuBD = PhieuBaoDuongDAO.Instance.DanhSachPhieuBaoDuong();
            cbbMaPhieuBaoDuong.DataSource = listPhieuBD;
            cbbMaPhieuBaoDuong.DisplayMember = "maPhieuBaoDuong";
        }

        void LoadDanhSachChiTietPhieuBaoDuong()
        {
            List<ChiTietPhieuBaoDuong> listChiTietPhieuBD = ChiTietPhieuBaoDuongDAO.Instance.DanhSachChiTieuPhieuBaoDuong();
            dgvThongTinChiTietPhieuBaoDuong.DataSource = listChiTietPhieuBD;
        }

        #endregion
    }
}
