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
    public partial class frmPhanCong : Form
    {
        ServiceClient client = new ServiceClient();
        

        public frmPhanCong()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhanCong_Load(object sender, EventArgs e)
        {
            loadtrangthaibtn();
            gridPhanCong.DataSource = client.GetAllDataFromPhanCong();
            Loadcb();
            
            
        }

        private void gridPhanCong_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (gridPhanCong.SelectedRows.Count > 0 && gridPhanCong.SelectedRows.Count <= gridPhanCong.Rows.Count)
            {
                txtsoluong.Text = e.Row.Cells["SLNGAYCONG"].Value.ToString();
                cbMaCongTrinh.Text = e.Row.Cells["MACT"].Value.ToString();
                cbMaNhanVien.Text = e.Row.Cells["MANV"].Value.ToString();
                txtmapb.Text = e.Row.Cells["MAPB"].Value.ToString();
                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận thêm !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                txtsoluong.Clear();
            }
            else
            {
                try
                {
                    if (checkInfo())
                    {
                        ePhanCong pc = new ePhanCong();
                        pc.MACT = cbMaCongTrinh.SelectedValue.ToString();
                        pc.MANV = cbMaNhanVien.SelectedValue.ToString();
                        pc.MAPB = txtmapb.Text;
                        pc.SLNGAYCONG = txtsoluong.Text;

                        int kq = client.insertPc(pc);
                        if (kq == 0)
                            MessageBox.Show("Trùng mã!", "Thông Báo!");
                        else
                            MessageBox.Show("Thêm thành Công!", "Thông báo!");
                        gridPhanCong.DataSource = client.GetAllDataFromPhanCong();
                        loadtrangthaibtn();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void Loadcb()
        {
            this.cbMaCongTrinh.DataSource = client.GetAllDataFromCongTrinh();
            this.cbMaCongTrinh.DisplayMember = "MACT";
            this.cbMaCongTrinh.ValueMember = "MACT";
         
            

            this.cbMaNhanVien.DataSource = client.GetAllDataFromNhanVien();
            this.cbMaNhanVien.DisplayMember = "MANV";
            this.cbMaNhanVien.ValueMember = "MANV";
        
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
             DialogResult r = MessageBox.Show("Xác nhận xóa !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
             if (r == DialogResult.No)
             {
                 txtsoluong.Clear();
             }
             else
             {
                 ePhanCong pc = new ePhanCong();
                 pc.MACT = cbMaCongTrinh.SelectedValue.ToString();
                 pc.MANV = cbMaNhanVien.SelectedValue.ToString();
                 pc.MAPB = txtmapb.Text;
                 pc.SLNGAYCONG = txtsoluong.Text;

                 int kq = client.remove1datafromPhanCong(pc);
                 if (kq == 0)
                     MessageBox.Show("Lỗi!", "Thông Báo!");
                 else
                     MessageBox.Show("Xóa thành Công!", "Thông báo!");
                 gridPhanCong.DataSource = client.GetAllDataFromPhanCong();
                 loadtrangthaibtn();
             }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
             DialogResult r = MessageBox.Show("Xác nhận sửa !", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
             if (r == DialogResult.No)
             {
                 txtsoluong.Clear();
             }
             else
             {

                 ePhanCong pc = new ePhanCong();
                 pc.MACT = cbMaCongTrinh.SelectedValue.ToString();
                 pc.MANV = cbMaNhanVien.SelectedValue.ToString();
                 pc.MAPB = txtmapb.Text;
                 pc.SLNGAYCONG = txtsoluong.Text;

                 int kq = client.change1PhanCong(pc);
                 if (kq == 0)
                     MessageBox.Show("Lỗi!", "Thông Báo!");
                 else
                     MessageBox.Show("Sửa thành Công!", "Thông báo!");
                 gridPhanCong.DataSource = client.GetAllDataFromPhanCong();
                 loadtrangthaibtn();
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
            if (!Regular(txtsoluong.Text, @"\d", "Sai số lượng ngày công"))
            {
                txtsoluong.Select();
                value = false;
            }
            
            else { value = true; }
            return value;
        }

        private void cbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

            this.txtmapb.Text = client.GetMaPBfromMaNV(cbMaNhanVien.SelectedValue.ToString());

           

            //this.cbMaNhanVien.DataSource = client.GetAllDataFromNhanVien();
            //this.cbMaNhanVien.DisplayMember = "MANV";
            //this.cbMaNhanVien.ValueMember = "MANV";
        }

        private void cbMaPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }
        public void loadtrangthaibtn()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnThoat.Enabled = true;
        }

        private void frmPhanCong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
