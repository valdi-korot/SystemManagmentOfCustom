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
using SystemOfManagmentCustom.DialogsForms;

namespace SystemOfManagmentCustom
{
    public partial class Form1 : Form
    {
        private CustomModel db;
        public Form1()
        {
            InitializeComponent();
            db=new CustomModel();
            db.Customs.Load();
            db.Persons.Load();
            db.BlackList.Load();

            UpdateGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PersonForm personForm = new PersonForm();
            if(personForm.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                Persons person = new Persons()
                {
                    LName = personForm.textBox1.Text,
                    FName = personForm.textBox2.Text,
                    Passport = personForm.textBox3.Text,
                    VisitDate=DateTime.Now,
                    CustomId = (int)personForm.comboBox1.SelectedValue
                };
                db.Persons.Add(person);
                db.SaveChanges();
                UpdateGrid();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (persomGrid.SelectedRows.Count > 0)
            {
                int index = (int)persomGrid.SelectedRows[0].Index;
                int id = (int)persomGrid[0, index].Value;
                var person = db.Persons.Find(id);
                PersonForm personForm = new PersonForm();
                personForm.textBox1.Text = person.LName;
                personForm.textBox2.Text = person.FName;
                personForm.textBox3.Text = person.Passport;
                personForm.comboBox1.SelectedValue = person.CustomId;
                if (personForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                     person.LName=personForm.textBox1.Text;
                    person.FName=personForm.textBox2.Text;
                    person.Passport=personForm.textBox3.Text;
                    person.CustomId=(int)personForm.comboBox1.SelectedValue;
                    db.Entry(person).State = EntityState.Modified;
                    db.SaveChanges();
                    UpdateGrid();
                }
            }
        }
        private void UpdateGrid()
        {
            persomGrid.DataSource = db.Persons.ToList();
            customsGrid.DataSource = db.Customs.ToList();
            dataGridView1.DataSource = db.BlackList.Local.ToBindingList();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (persomGrid.SelectedRows.Count > 0)
            {
                int index = (int)persomGrid.SelectedRows[0].Index;
                int id = (int)persomGrid[0, index].Value;
                var person = db.Persons.Find(id);
                if (MessageBox.Show("Вы действительно хотите удалить ?", "Удаление человека", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    db.Persons.Remove(person);
                    db.SaveChanges();
                    UpdateGrid();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomForm form = new CustomForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Customs custom = new Customs();
                custom.Name = form.textBox1.Text;
                db.Customs.Add(custom);
                db.SaveChanges();
                UpdateGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (customsGrid.SelectedRows.Count > 0)
            {
                int index = (int)customsGrid.SelectedRows[0].Index;
                int id = (int)customsGrid[0, index].Value;
                var custom = db.Customs.Find(id);
                CustomForm form = new CustomForm();
                form.textBox1.Text = custom.Name;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    custom.Name = form.textBox1.Text;
                    db.Entry(custom).State=EntityState.Modified;
                    db.SaveChanges();
                    UpdateGrid();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (customsGrid.SelectedRows.Count > 0)
            {
                int index = (int)customsGrid.SelectedRows[0].Index;
                int id = (int)customsGrid[0, index].Value;
                var custom = db.Customs.Find(id);
                if (MessageBox.Show("Вы действительно хотите удалить таможенную зону ? ","Удаление",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    db.Customs.Remove(custom);
                    db.SaveChanges();
                    UpdateGrid();
                }
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (persomGrid.SelectedRows.Count > 0)
            {
                int index = (int)persomGrid.SelectedRows[0].Index;
                int id = (int)persomGrid[0, index].Value;
                var person = db.Persons.Find(id);
                AddToBlackListForm form = new AddToBlackListForm();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BlackList row = new BlackList();
                    row.StartDate = form.dateTimePicker1.Value;
                    row.EndDate = form.dateTimePicker2.Value;
                    person.BlackList.Add(row);
                    db.Entry(person).State = EntityState.Modified;
                    db.SaveChanges();
                    UpdateGrid();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1[3, i].Value.ToString().Contains(textBox1.Text))
                        dataGridView1[3, i].Selected = true;
                    else
                        dataGridView1[3, i].Selected = false;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ReporForm form = new ReporForm();
            form.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
