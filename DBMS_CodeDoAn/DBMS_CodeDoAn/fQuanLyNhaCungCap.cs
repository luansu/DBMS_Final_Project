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
    public partial class fQuanLyNhaCungCap : Form
    {
        public fQuanLyNhaCungCap()
        {
            InitializeComponent();
            LoadDanhSachNhaCungCap();
        }

        #region event

        #endregion

        #region method

        void LoadDanhSachNhaCungCap()
        {
            List<NhaCungCap> listNhaCungCap = NhaCungCapDAO.Instance.DanhSachNhaCungCap();
            dgvThongTinNhaCungCap.DataSource = listNhaCungCap;
        }

        #endregion
    }
}
