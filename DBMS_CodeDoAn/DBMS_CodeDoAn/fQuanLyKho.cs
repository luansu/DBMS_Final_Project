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
    public partial class fQuanLyKho : Form
    {
        public fQuanLyKho()
        {
            InitializeComponent();
            LoadDanhSachKhoXe();
        }

        #region -> Events

        #endregion

        #region -> Methods

        void LoadDanhSachKhoXe()
        {
            List<KhoXe> listKhoXe = KhoXeDAO.Instance.DanhSachKhoXe();
            dgvKhoXe.DataSource = listKhoXe;
        }

        #endregion
    }
}
