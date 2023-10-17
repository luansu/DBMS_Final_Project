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
    public partial class fTrangChu : Form
    {
        public fTrangChu()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            
        }

        private void btnQuanLyOTo_Click(object sender, EventArgs e)
        {
            this.Hide();

            fQuanLyOTo f = new fQuanLyOTo();
            f.ShowDialog();

            this.Show();
        }
    }
}
