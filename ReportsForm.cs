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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            btnDashboard.Click += (sender, e) => NavigateTo(new MainForm());
            picdashboard.Click += (sender, e) => NavigateTo(new MainForm());
            btnEmployees.Click += (sender, e) => NavigateTo(new EmployeesForm());
            picemployees.Click += (sender, e) => NavigateTo(new EmployeesForm());
            btndepartments.Click += (sender, e) => NavigateTo(new DepartmentsForm());
            picdepartments.Click += (sender, e) => NavigateTo(new DepartmentsForm());

            btnsearch.Click += (sender, e) => NavigateTo(new formSearchFilter());
            picsearch.Click += (sender, e) => NavigateTo(new formSearchFilter());
            btnlogout.Click += (sender, e) => { LogoutRequested = true; this.Close(); };
            piclogout.Click += (sender, e) => { LogoutRequested = true; this.Close(); };
        }

        public bool LogoutRequested { get; private set; }

        private void NavigateTo(Form next)
        {
            this.Hide();
            using (next)
            {
                next.ShowDialog(this);
                bool logout = next is EmployeesForm && ((EmployeesForm)next).LogoutRequested
                    || next is ReportsForm && ((ReportsForm)next).LogoutRequested
                    || next is DepartmentsForm && ((DepartmentsForm)next).LogoutRequested
                    || next is formSearchFilter && ((formSearchFilter)next).LogoutRequested;
                if (logout) { LogoutRequested = true; this.Close(); return; }
            }
            if (!this.IsDisposed) this.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e) { NavigateTo(new ReportsForm()); }

        private void picreports_Click(object sender, EventArgs e) { NavigateTo(new ReportsForm()); }

        private void btnlogout_Click(object sender, EventArgs e) { LogoutRequested = true; this.Close(); }

        private void pnlheader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {

        }

        private void lblSalaryChartTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblEmployeesChartTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
