using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using SystemOfManagmentCustom.Model;

namespace SystemOfManagmentCustom.DialogsForms
{
    public partial class ReporForm : Form
    {
        CustomModel db;
        public ReporForm()
        {
            InitializeComponent();
            db = new CustomModel();
            db.Customs.Load();
            comboBox1.DataSource = db.Customs.Local.ToBindingList();
        }

        private void ReporForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           int coutnOfPerson =  db.Customs.Find((int)comboBox1.SelectedValue).Persons.Where(p => p.VisitDate >= dateTimePicker1.Value.Date
                && p.VisitDate <= dateTimePicker2.Value.Date.AddDays(1).AddMinutes(-1)).Count();
           label3.Text = "Количество человек за период : " + coutnOfPerson;
        }
    }
}
