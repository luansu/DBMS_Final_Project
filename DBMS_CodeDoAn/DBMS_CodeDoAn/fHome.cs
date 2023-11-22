using DBMS_CodeDoAn.DAO;
using DBMS_CodeDoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_CodeDoAn
{
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
        }

        #region Events

        private void fHome_Load(object sender, EventArgs e)
        {
            LoadListXe();
        }

        private void quảnLýXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyOTo f = new fQuanLyOTo();
                f.ShowDialog();
                this.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                this.Show();
            }
        }

        private void quảnLýPhụTùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyPhuTung f = new fQuanLyPhuTung();
                f.ShowDialog();
                this.Show();
            }
            catch
            {
                MessageBox.Show("Bạn không có quyền truy cập");
            }
            finally
            {
                this.Show();
            }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyNhanVien f = new fQuanLyNhanVien();
                f.ShowDialog();
                this.Show();
            }
            catch (SqlException ex)
            {
                if (ex.Message.ToString().Contains("permission was denied"))
                    MessageBox.Show("Bạn không có quyền truy cập");
                else
                    MessageBox.Show("Bạn không có quyền truy cập");
            }
            finally
            {
                this.Show();
            }
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyKhachHang f = new fQuanLyKhachHang();
                f.ShowDialog();
                this.Show();
            }
            catch
            {
                MessageBox.Show("Bạn không có quyền truy cập");
                this.Hide();
                fHome f = new fHome();
                f.ShowDialog();
                this.Show();
            }
            
        }

        private void quảnLýChiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyChiNhanh f = new fQuanLyChiNhanh();
                f.ShowDialog();
                this.Show();
            }
            catch
            {
                MessageBox.Show("Bạn không có quyền truy cập");
                this.Hide();
                fHome f = new fHome();
                f.ShowDialog();
                this.Show();
            }
            
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            fQuanLyNhaCungCap f = new fQuanLyNhaCungCap();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyHoaDon f = new fQuanLyHoaDon();
                f.ShowDialog();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                
            } finally 
            {
                this.Show();
            }
            
        }

        private void quảnLýPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyPhieuNhap f = new fQuanLyPhieuNhap();
                f.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "Bạn không có quyền truy cập");
                this.Hide();
                fHome f = new fHome();
                f.ShowDialog();
                this.Show();
            }
            
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyKho f = new fQuanLyKho();
                f.ShowDialog();
                this.Show();
            }
            catch 
            {
                MessageBox.Show("Bạn không có quyền truy cập");
            }
            finally
            {
                this.Hide();
                fHome f = new fHome();
                f.ShowDialog();
            }
        }

        private void quảnLýDịchVụBảoDưỡngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyBaoDuong f = new fQuanLyBaoDuong();
                f.ShowDialog();
                this.Show();
            }
            catch
            {
                MessageBox.Show("Bạn không có quyền truy cập");
            }
            finally
            {
                this.Show();
            }
        }

        private void quảnLýPhiếuBảoDưỡngBảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                fQuanLyPhieuBaoDuong f = new fQuanLyPhieuBaoDuong();
                f.ShowDialog();
                this.Show();
            }
            catch
            {
                MessageBox.Show("Bạn không có quyền truy cập");
            }
            finally
            {
                this.Show();
            }
            
        }

        private void quảnLýHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLýTàiChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methos

        void LoadListXe()
        {
            List<Xe> listXe = XeDAO.Instance.DanhSachXe();

            foreach (Xe xe in listXe)
            {

                string path = xe.HinhAnh.Replace(@"\", @"\\");
                Button btn = new Button()
                {
                    Width = 200,
                    Height = 200,
                };
                if (xe.HinhAnh != "")
                {
                    btn.BackgroundImage = Image.FromFile(path);
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.Text = xe.TenXe + Environment.NewLine + xe.GiaBan;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                }
                else
                {
                    btn.Text = xe.TenXe + Environment.NewLine + xe.GiaBan;
                }
                flpXe.Controls.Add(btn);

            }
        }



        #endregion

        
    }
}
