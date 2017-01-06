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
using System.Data.Entity;

namespace SystemOfManagmentCustom.DialogsForms
{
    public partial class PersonForm : Form
    {
        CustomModel _db;
        public PersonForm()
        {
            InitializeComponent();
            _db = new CustomModel();
            _db.Customs.Load();
            comboBox1.DataSource = _db.Customs.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
