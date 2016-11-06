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
    public partial class frmPhongBan : Form
    {
        ServiceClient client = new ServiceClient();
        public frmPhongBan()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            gridPhongBan.DataSource = client.GetAllDataFromPhongBan();
            loadtrangthaibtn();
        }

        private void gridPhongBan_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (gridPhongBan.SelectedRows.Count > 0 && gridPhongBan.SelectedRows.Count <= gridPhongBan.Rows.Count)
            {
                txtMaPhongBan.Text = e.Row.Cells["MAPB"].Value.ToString();
                txtTenPhongBan.Text = e.Row.Cells["TENPB"].Value.ToString();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận thêm mới !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if(r==DialogResult.No)
            {
                txtMaPhongBan.Clear();
                txtTenPhongBan.Clear();
                loadtrangthaibtn();
            }
            else
            try{
                if(checkInfo()){
                    PhongBan p = new PhongBan();
                    p.MAPB = txtMaPhongBan.Text;
                    p.TENPB = txtTenPhongBan.Text;
                    int kq = client.insertPhongBan(p);
                    if (kq == 0)
                        MessageBox.Show("Trùng mã!", "Thông Báo!");
                    else
                        MessageBox.Show("Thêm thành Công!", "Thông báo!");
                    gridPhongBan.DataSource = client.GetAllDataFromPhongBan();
                    loadtrangthaibtn(); 
                }
            }
                catch(Exception ex){MessageBox.Show(ex.Message);}
                    
            
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận xóa !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                txtMaPhongBan.Clear();
                txtTenPhongBan.Clear();                
                loadtrangthaibtn();
            }
            else
            {
                PhongBan p = new PhongBan();
                p.MAPB = txtMaPhongBan.Text;
                p.TENPB = txtTenPhongBan.Text;
                int kq = client.remove1datafromPhongBan(p);
                if (kq == 0)
                    MessageBox.Show("Không có mã công trình!", "Thông Báo!");
                else
                    MessageBox.Show("Xóa thành Công!", "Thông báo!");
                gridPhongBan.DataSource = client.GetAllDataFromPhongBan();
                loadtrangthaibtn();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận sửa !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                txtMaPhongBan.Clear();
                txtTenPhongBan.Clear();
                loadtrangthaibtn();
            }
            else
            {
                PhongBan p = new PhongBan();
                p.MAPB = txtMaPhongBan.Text;
                p.TENPB = txtTenPhongBan.Text;
                int kq = client.change1PhongBan(p);
                if (kq == 0)
                    MessageBox.Show("Không có mã công trình!", "Thông Báo!");
                else
                {
                    MessageBox.Show("Sửa thành Công!", "Thông báo!");
                    gridPhongBan.DataSource = client.GetAllDataFromPhongBan();
                    loadtrangthaibtn();
                }
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
            if (!Regular(txtMaPhongBan.Text, @"PB\d", "Sai mã phòng ban"))
            {
                txtMaPhongBan.Select();
                value = false;
            }
            else if (!Regular(txtTenPhongBan.Text, @"(\D)+", "Sai tên phòng ban"))
            {
                txtTenPhongBan.Select();
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

        private void frmPhongBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
