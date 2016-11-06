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
    public partial class frmNhanVien : Form
    {
        string phai = "Nam";
        ServiceClient client = new ServiceClient();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            Loadcb();
            loadtrangthaibtn();
            gridNhanVien.DataSource = client.GetAllDataFromNhanVien();
            var ls = client.GetAllDataFromNhanVien();
            for (int i = 0; i < 1; i++)
                txtmapb.Text= ls[i].MAPB;

            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận thêm !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                txtDiaChi.Clear();
                txtHoTen.Clear();
                txtMaNhanVien.Clear();
                txtmapb.Clear();
                txtNgaySinh.Clear();

            }
            else
            {
                try
                {
                    if (checkInfo() == true)
                    {
                        NhanVien nv = new NhanVien();
                        nv.MANV = txtMaNhanVien.Text;
                        nv.HOTEN = txtHoTen.Text;
                        nv.NGAYSINH = Convert.ToDateTime(txtNgaySinh.Text);
                        nv.DIACHI = txtDiaChi.Text;
                        nv.PHAI = phai;
                        nv.MAPB = txtmapb.Text;
                        int kq = client.insertNv(nv);
                        if (kq == 0)
                            MessageBox.Show("Trùng mã!", "Thông Báo!");
                        else
                            MessageBox.Show("Thêm thành Công!", "Thông báo!");
                        gridNhanVien.DataSource = client.GetAllDataFromNhanVien();
                        loadtrangthaibtn();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void radNam_CheckedChanged(object sender, EventArgs e)
        {
            phai = "Nam";
        }

        private void radNu_CheckedChanged(object sender, EventArgs e)
        {
            phai = "Nữ";
        }

        private void CbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }
        private void Loadcb()
        {
            this.CbPhongBan.DataSource = client.GetAllDataFromPhongBan();
            this.CbPhongBan.DisplayMember = "TENPB";
            this.CbPhongBan.ValueMember = "MAPB";
        }

        private void txtTimNhanVien_TextChanged(object sender, EventArgs e)
        {
            var nv = client.seach1Nhanvienbymanv(txtTimNhanVien.Text);
            if (nv == null)
                MessageBox.Show("Không có mã công trình!", "Thông báo!");
            else
                gridNhanVien.DataSource = nv;
        }

        private void CbPhongBan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtmapb.Text = ((ComboBox)sender).SelectedValue.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận xóa !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                txtDiaChi.Clear();
                txtHoTen.Clear();
                txtMaNhanVien.Clear();
                txtmapb.Clear();
                txtNgaySinh.Clear();

            }
            else
            {
                NhanVien nv = new NhanVien();
                nv.MANV = txtMaNhanVien.Text;
                nv.HOTEN = txtHoTen.Text;
                nv.NGAYSINH = Convert.ToDateTime(txtNgaySinh.Text);
                nv.DIACHI = txtDiaChi.Text;
                nv.PHAI = phai;
                nv.MAPB = txtmapb.Text;
                int kq = client.remove1datafromNhanVien(nv);
                if (kq == 0)
                    MessageBox.Show("Không tìm thấy nhân viên có mã trên!", "Thông Báo!");
                else
                    MessageBox.Show("Xóa thành Công!", "Thông báo!");
                gridNhanVien.DataSource = client.GetAllDataFromNhanVien();
                loadtrangthaibtn();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận sửa !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                txtDiaChi.Clear();
                txtHoTen.Clear();
                txtMaNhanVien.Clear();
                txtmapb.Clear();
                txtNgaySinh.Clear();

            }
            else
            {
            NhanVien nv = new NhanVien();
            nv.MANV = txtMaNhanVien.Text;
            nv.HOTEN = txtHoTen.Text;
            nv.NGAYSINH = Convert.ToDateTime(txtNgaySinh.Text);
            nv.DIACHI = txtDiaChi.Text;
            nv.PHAI = phai;
            nv.MAPB = txtmapb.Text;
            int kq = client.change1Nhanvien(nv);
            if (kq == 0)
                MessageBox.Show("Không tìm thấy nhân viên có mã trên!", "Thông Báo!");
            else
            {
                MessageBox.Show("Sửa thành Công!", "Thông báo!");
                gridNhanVien.DataSource = client.GetAllDataFromNhanVien();
                loadtrangthaibtn();
            }
            }
        }

        private void gridNhanVien_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (gridNhanVien.SelectedRows.Count > 0 && gridNhanVien.SelectedRows.Count <= gridNhanVien.Rows.Count)
            {
                txtDiaChi.Text = e.Row.Cells["DIACHI"].Value.ToString();
                txtHoTen.Text = e.Row.Cells["HOTEN"].Value.ToString();
                txtMaNhanVien.Text = e.Row.Cells["MANV"].Value.ToString();
                txtmapb.Text = e.Row.Cells["MAPB"].Value.ToString();
                CbPhongBan.Text = e.Row.Cells["MAPB"].Value.ToString();
                if (e.Row.Cells["PHAI"].Value.ToString().Equals("Nam"))
                    radNam.Checked = true;
                else
                    radNu.Checked = true;
                txtNgaySinh.Text = e.Row.Cells["NGAYSINH"].Value.ToString();
            }
        }

        public bool Regular(string input, string expression, string message)
        {
            bool value = Regex.Match(input, expression).Success;
            if (!value)
            {
                MessageBox.Show(message,"Invalid input", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return value;
        }

        public bool checkInfo(){
            bool value;
            if (!Regular(txtHoTen.Text, @"(\D)+", "Sai tên nhân viên"))
            {
                txtHoTen.Select();
                value = false;
            }
            else if (!Regular(txtMaNhanVien.Text, @"NV0\d", "Sai mã nhân viên"))
            {
                txtMaNhanVien.Select();
                value = false;
            }
            else if (!Regular(txtNgaySinh.Text, @"\d{1,2}/\d{1,2}/\d{4}", "Sai ngày sinh"))
            {
                txtNgaySinh.Select();
                value = false;
            }
            else if (!Regular(txtDiaChi.Text, @"(\D)+|Q\d", "Sai địa chỉ"))
            {
                txtDiaChi.Select();
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

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
