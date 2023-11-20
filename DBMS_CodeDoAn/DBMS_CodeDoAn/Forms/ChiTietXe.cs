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

namespace DBMS_CodeDoAn.Forms
{
    public partial class ChiTietXe : Form
    {
        private Xe xe;
        public ChiTietXe(Xe xe)
        {
            InitializeComponent();
            this.xe = xe;
        }

        private void ChiTietXe_Load(object sender, EventArgs e)
        {
            txtTenXe.Text = xe.TenXe.ToString();
        }
    }
}
