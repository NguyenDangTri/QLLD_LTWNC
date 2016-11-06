namespace GUI
{
    partial class frmCongTrinh
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtNgayHoanThanh = new System.Windows.Forms.TextBox();
            this.txtNgayKhoiCong = new System.Windows.Forms.TextBox();
            this.txtNgayCapGiayPhep = new System.Windows.Forms.TextBox();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.txtTenCongTrinh = new System.Windows.Forms.TextBox();
            this.txtMaCongTrinh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridCongTrinh = new System.Windows.Forms.DataGridView();
            this.txtTimCongTrinh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCongTrinh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtNgayHoanThanh);
            this.groupBox1.Controls.Add(this.txtNgayKhoiCong);
            this.groupBox1.Controls.Add(this.txtNgayCapGiayPhep);
            this.groupBox1.Controls.Add(this.txtDiaDiem);
            this.groupBox1.Controls.Add(this.txtTenCongTrinh);
            this.groupBox1.Controls.Add(this.txtMaCongTrinh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(424, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin công trình";
            // 
            // btnThoat
            // 
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Image = global::GUI.Properties.Resources._3;
            this.btnThoat.Location = new System.Drawing.Point(263, 267);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 30;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Image = global::GUI.Properties.Resources._2;
            this.btnXoa.Location = new System.Drawing.Point(182, 267);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 29;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Image = global::GUI.Properties.Resources._1;
            this.btnSua.Location = new System.Drawing.Point(101, 267);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 28;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Image = global::GUI.Properties.Resources._4;
            this.btnThem.Location = new System.Drawing.Point(20, 267);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 27;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtNgayHoanThanh
            // 
            this.txtNgayHoanThanh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNgayHoanThanh.Location = new System.Drawing.Point(138, 225);
            this.txtNgayHoanThanh.Name = "txtNgayHoanThanh";
            this.txtNgayHoanThanh.Size = new System.Drawing.Size(200, 20);
            this.txtNgayHoanThanh.TabIndex = 11;
            // 
            // txtNgayKhoiCong
            // 
            this.txtNgayKhoiCong.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNgayKhoiCong.Location = new System.Drawing.Point(138, 188);
            this.txtNgayKhoiCong.Name = "txtNgayKhoiCong";
            this.txtNgayKhoiCong.Size = new System.Drawing.Size(200, 20);
            this.txtNgayKhoiCong.TabIndex = 10;
            // 
            // txtNgayCapGiayPhep
            // 
            this.txtNgayCapGiayPhep.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNgayCapGiayPhep.Location = new System.Drawing.Point(138, 150);
            this.txtNgayCapGiayPhep.Name = "txtNgayCapGiayPhep";
            this.txtNgayCapGiayPhep.Size = new System.Drawing.Size(200, 20);
            this.txtNgayCapGiayPhep.TabIndex = 9;
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDiaDiem.Location = new System.Drawing.Point(138, 114);
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(200, 20);
            this.txtDiaDiem.TabIndex = 8;
            // 
            // txtTenCongTrinh
            // 
            this.txtTenCongTrinh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTenCongTrinh.Location = new System.Drawing.Point(138, 75);
            this.txtTenCongTrinh.Name = "txtTenCongTrinh";
            this.txtTenCongTrinh.Size = new System.Drawing.Size(200, 20);
            this.txtTenCongTrinh.TabIndex = 7;
            // 
            // txtMaCongTrinh
            // 
            this.txtMaCongTrinh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMaCongTrinh.Location = new System.Drawing.Point(138, 37);
            this.txtMaCongTrinh.Name = "txtMaCongTrinh";
            this.txtMaCongTrinh.Size = new System.Drawing.Size(200, 20);
            this.txtMaCongTrinh.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày hoàn thành";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày khởi công";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày cấp giấy phép";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa điểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên công trình";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã công trình";
            // 
            // gridCongTrinh
            // 
            this.gridCongTrinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCongTrinh.Location = new System.Drawing.Point(10, 60);
            this.gridCongTrinh.Name = "gridCongTrinh";
            this.gridCongTrinh.Size = new System.Drawing.Size(399, 271);
            this.gridCongTrinh.TabIndex = 1;
            this.gridCongTrinh.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCongTrinh_RowStateChanged);
            // 
            // txtTimCongTrinh
            // 
            this.txtTimCongTrinh.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTimCongTrinh.Location = new System.Drawing.Point(193, 23);
            this.txtTimCongTrinh.Name = "txtTimCongTrinh";
            this.txtTimCongTrinh.Size = new System.Drawing.Size(216, 20);
            this.txtTimCongTrinh.TabIndex = 20;
            this.txtTimCongTrinh.TextChanged += new System.EventHandler(this.txtTimCongTrinh_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Location = new System.Drawing.Point(12, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Nhập mã công trình cần tìm kiếm ";
            // 
            // frmCongTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(796, 336);
            this.Controls.Add(this.txtTimCongTrinh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gridCongTrinh);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCongTrinh";
            this.Text = "Công Trình";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCongTrinh_FormClosing);
            this.Load += new System.EventHandler(this.frmCongTrinh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCongTrinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNgayHoanThanh;
        private System.Windows.Forms.TextBox txtNgayKhoiCong;
        private System.Windows.Forms.TextBox txtNgayCapGiayPhep;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.TextBox txtTenCongTrinh;
        private System.Windows.Forms.TextBox txtMaCongTrinh;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView gridCongTrinh;
        private System.Windows.Forms.TextBox txtTimCongTrinh;
        private System.Windows.Forms.Label label7;
    }
}