using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnEmployees.Click += (sender, e) => OpenChild(new EmployeesForm());
            picemployees.Click += (sender, e) => OpenChild(new EmployeesForm());
            btndepartments.Click += (sender, e) => OpenChild(new DepartmentsForm());
            picdepartments.Click += (sender, e) => OpenChild(new DepartmentsForm());

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e) { OpenChild(new ReportsForm()); }

        private void OpenChild(Form child)
        {
            this.Hide();
            using (child)
            {
                child.ShowDialog(this);
                bool logout = child is EmployeesForm && ((EmployeesForm)child).LogoutRequested
                    || child is ReportsForm && ((ReportsForm)child).LogoutRequested
                    || child is DepartmentsForm && ((DepartmentsForm)child).LogoutRequested
                    || child is formSearchFilter && ((formSearchFilter)child).LogoutRequested;
                if (logout) { this.Close(); return; }
            }
            if (!this.IsDisposed) this.Show();
        }

        private void picreports_Click(object sender, EventArgs e) { OpenChild(new ReportsForm()); }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            OpenChild(new formSearchFilter());
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlheader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalEmployee_Click(object sender, EventArgs e)
        {

        }

        private void picnotification_Click(object sender, EventArgs e)
        {

        }

        private void picAverageSalary_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void picTotalDepartment_Click(object sender, EventArgs e)
        {

        }
    }
}
