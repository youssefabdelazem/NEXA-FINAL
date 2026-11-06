using System;
using System.Drawing;
using System.Windows.Forms;

namespace NEXA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void lblSlogan_Click(object sender, EventArgs e) { }
        private void lblSubtitle_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBoxEye_Click(object sender, EventArgs e) { }
        private void btnShowPass_Click(object sender, EventArgs e) { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) &&
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Please fill in both Username and Password.",
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show(
                    "Please enter your Username.",
                    "Missing Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Please enter your Password.",
                    "Missing Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            this.Hide();
            using (MainForm dashboard = new MainForm())
            {
                dashboard.ShowDialog();
            }
            this.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e) { }
    }
}
