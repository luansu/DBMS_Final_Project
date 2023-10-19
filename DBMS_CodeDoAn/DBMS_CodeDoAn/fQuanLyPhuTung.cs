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
    public partial class fQuanLyPhuTung : Form
    {
        public fQuanLyPhuTung()
        {
            InitializeComponent();
            LoadDanhSachPhuTung();
        }

        #region event

        #endregion

        #region method

        void LoadDanhSachPhuTung()
        {
            List<PhuTung> listPhuTung = PhuTungDAO.Instance.DanhSachPhuTung();
            dgvThongTinPhuTung.DataSource = listPhuTung;
        }

        #endregion
    }
}
