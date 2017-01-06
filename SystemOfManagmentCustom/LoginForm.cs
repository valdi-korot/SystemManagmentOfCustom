using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemOfManagmentCustom.Model;

namespace SystemOfManagmentCustom
{
    public partial class LoginForm : Form
    {
        CustomModel db ;
        public LoginForm()
        {
            InitializeComponent();
            db = new CustomModel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (db.Users.Where(p => p.Login == textBox1.Text && p.Password == textBox2.Text).Any())
            {
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }
    }
}
