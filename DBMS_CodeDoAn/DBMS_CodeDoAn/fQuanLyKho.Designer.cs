namespace DBMS_CodeDoAn
{
    partial class fQuanLyKho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvKhoXe = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoXe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvKhoXe);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 286);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(745, 286);
            this.panel2.TabIndex = 0;
            // 
            // dgvKhoXe
            // 
            this.dgvKhoXe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoXe.Location = new System.Drawing.Point(3, 3);
            this.dgvKhoXe.Name = "dgvKhoXe";
            this.dgvKhoXe.RowHeadersWidth = 62;
            this.dgvKhoXe.RowTemplate.Height = 28;
            this.dgvKhoXe.Size = new System.Drawing.Size(739, 280);
            this.dgvKhoXe.TabIndex = 0;
            // 
            // fQuanLyKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fQuanLyKho";
            this.Text = "fQuanLyKho";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvKhoXe;
        private System.Windows.Forms.Panel panel2;
    }
}