using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.ServiceReference1;
using System.Text.RegularExpressions;

namespace GUI
{
    
    public partial class frmCongTrinh : Form
    {
        ServiceClient client = new ServiceClient();
        public frmCongTrinh()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCongTrinh_Load(object sender, EventArgs e)
        {
            gridCongTrinh.DataSource = client.GetAllDataFromCongTrinh();
            loadtrangthaibtn();
        }

        private void txtTimCongTrinh_TextChanged(object sender, EventArgs e)
        {
            var ct = client.seach1CongtrinhbymaCT(txtTimCongTrinh.Text);
            if (ct == null)
                MessageBox.Show("Không có mã công trình!", "Thông báo!");
            else
                gridCongTrinh.DataSource = ct;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
             DialogResult r = MessageBox.Show("Xác nhận thêm !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
             if (r == DialogResult.No)
             {
                 txtDiaDiem.Clear();
                 txtMaCongTrinh.Clear();
                 txtNgayCapGiayPhep.Clear();
                 txtNgayHoanThanh.Clear();
                 txtNgayKhoiCong.Clear();
                 txtTenCongTrinh.Clear();
             }
             else
             {
                 try
                 {
                     if (checkInfo())
                     {
                         CongTrinh ct = new CongTrinh();
                         ct.MACT = txtMaCongTrinh.Text;
                         ct.NGAYCAPGP = Convert.ToDateTime(txtNgayCapGiayPhep.Text);
                         ct.NGAYHT = Convert.ToDateTime(txtNgayHoanThanh.Text);
                         ct.NGAYKC = Convert.ToDateTime(txtNgayKhoiCong.Text);
                         ct.TENCT = txtTenCongTrinh.Text;
                         ct.DIADIEM = txtDiaDiem.Text;
                         int kq = client.insertCt(ct);
                         if (kq == 0)
                             MessageBox.Show("Trùng mã!", "Thông Báo!");
                         else
                             MessageBox.Show("Thêm thành Công!", "Thông báo!");
                         gridCongTrinh.DataSource = client.GetAllDataFromCongTrinh();
                         loadtrangthaibtn();
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
             }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận xóa !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                txtDiaDiem.Clear();
                txtMaCongTrinh.Clear();
                txtNgayCapGiayPhep.Clear();
                txtNgayHoanThanh.Clear();
                txtNgayKhoiCong.Clear();
                txtTenCongTrinh.Clear();
            }
            else
            {
                CongTrinh ct = new CongTrinh();
                ct.MACT = txtMaCongTrinh.Text;
                ct.NGAYCAPGP = Convert.ToDateTime(txtNgayCapGiayPhep.Text);
                ct.NGAYHT = Convert.ToDateTime(txtNgayHoanThanh.Text);
                ct.NGAYKC = Convert.ToDateTime(txtNgayKhoiCong.Text);
                ct.TENCT = txtTenCongTrinh.Text;
                ct.DIADIEM = txtDiaDiem.Text;
                int kq = client.remove1datafromCongTrinh(ct);
                if (kq == 0)
                    MessageBox.Show("Không tìm thấy công trình có mã trên!", "Thông Báo!");
                else
                {
                    MessageBox.Show("Xóa thành Công!", "Thông báo!");
                    gridCongTrinh.DataSource = client.GetAllDataFromCongTrinh();
                    loadtrangthaibtn();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận sửa !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                txtDiaDiem.Clear();
                txtMaCongTrinh.Clear();
                txtNgayCapGiayPhep.Clear();
                txtNgayHoanThanh.Clear();
                txtNgayKhoiCong.Clear();
                txtTenCongTrinh.Clear();
            }
            else
            {
                CongTrinh ct = new CongTrinh();
                ct.MACT = txtMaCongTrinh.Text;
                ct.NGAYCAPGP = Convert.ToDateTime(txtNgayCapGiayPhep.Text);
                ct.NGAYHT = Convert.ToDateTime(txtNgayHoanThanh.Text);
                ct.NGAYKC = Convert.ToDateTime(txtNgayKhoiCong.Text);
                ct.TENCT = txtTenCongTrinh.Text;
                ct.DIADIEM = txtDiaDiem.Text;
                int kq = client.change1CongTrinh(ct);
                if (kq == 0)
                    MessageBox.Show("Không tìm thấy Công trình có mã trên!", "Thông Báo!");
                else
                {
                    MessageBox.Show("Sửa thành Công!", "Thông báo!");
                    gridCongTrinh.DataSource = client.GetAllDataFromCongTrinh();
                    loadtrangthaibtn();
                }
            }
        }

        private void gridCongTrinh_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (gridCongTrinh.SelectedRows.Count > 0 && gridCongTrinh.SelectedRows.Count <= gridCongTrinh.Rows.Count)
            {
               txtDiaDiem.Text = e.Row.Cells["DIADIEM"].Value.ToString();
                txtMaCongTrinh.Text = e.Row.Cells["MACT"].Value.ToString();
                txtNgayCapGiayPhep.Text = e.Row.Cells["NGAYCAPGP"].Value.ToString();
                txtNgayHoanThanh.Text = e.Row.Cells["NGAYHT"].Value.ToString();
                txtNgayKhoiCong.Text = e.Row.Cells["NGAYKC"].Value.ToString();
                txtTenCongTrinh.Text = e.Row.Cells["TENCT"].Value.ToString();
            }
        }

        public bool Regular(string input, string expression, string message)
        {
            bool value = Regex.Match(input, expression).Success;
            if (!value)
            {
                MessageBox.Show(message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return value;
        }

        public bool checkInfo()
        {
            bool value;
            if (!Regular(txtMaCongTrinh.Text, @"CT\d", "Sai mã công trình"))
            {
                txtMaCongTrinh.Select();
                value = false;
            }
            else if (!Regular(txtTenCongTrinh.Text, @"(\D)+", "Sai tên công trình"))
            {
                txtTenCongTrinh.Select();
                value = false;
            }
            else if (!Regular(txtDiaDiem.Text, @"(\D)+", "Sai địa điểm"))
            {
                txtDiaDiem.Select();
                value = false;
            }
            else if (!Regular(txtNgayCapGiayPhep.Text, @"\d{1,2}/\d{1,2}/\d{4}", "Sai ngày cấp"))
            {
                txtNgayCapGiayPhep.Select();
                value = false;
            }
            else if (!Regular(txtNgayKhoiCong.Text, @"\d{1,2}/\d{1,2}/\d{4}", "Sai ngày khởi công"))
            {
                txtNgayKhoiCong.Select();
                value = false;
            }
            else if (!Regular(txtNgayHoanThanh.Text, @"\d{1,2}/\d{1,2}/\d{4}", "Sai ngày hoàn thành"))
            {
                txtNgayHoanThanh.Select();
                value = false;
            }
            else { value = true; }
            return value;
        }
        public void loadtrangthaibtn()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnThoat.Enabled = true;
        }

        private void frmCongTrinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
