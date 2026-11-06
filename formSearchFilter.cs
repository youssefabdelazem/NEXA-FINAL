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
    public partial class formSearchFilter : Form
    {
        // True only when the user chooses Logout from this page.
        public bool LogoutRequested { get; private set; }

        public formSearchFilter()
        {
            InitializeComponent();

            // The Search & Filter page has its own sidebar.
            // Dashboard returns to the already-open Dashboard form.
            btnDashboard.Click += btnDashboard_Click;
            picdashboard.Click += btnDashboard_Click;
            piclogout.Click += btnlogout_Click;
            btnEmployees.Click += (sender, e) => NavigateTo(new EmployeesForm());
            picemployees.Click += (sender, e) => NavigateTo(new EmployeesForm());
            btndepartments.Click += (sender, e) => NavigateTo(new DepartmentsForm());
            picdepartments.Click += (sender, e) => NavigateTo(new DepartmentsForm());

        }

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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Close Search & Filter; MainForm will show itself again.
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            // Tell MainForm to close as well, returning the user to Login.
            LogoutRequested = true;
            this.Close();
        }
    }
}
