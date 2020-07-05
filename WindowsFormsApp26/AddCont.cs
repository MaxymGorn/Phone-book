using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp26.NewFolder1;

namespace WindowsFormsApp26
{
    public partial class AddCont : Form
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Telegram { get; set; }
        public string Viber { get; set; }

        public string Email { get; set; }
        public string Category { get; set; }
        public AddCont(CategoriesManager categoriesManager)
        {
            InitializeComponent();
            categoriesManager.LoadData();
            comboBox1.Items.Clear();
            foreach (var el in categoriesManager.Categories)
            {
                comboBox1.Items.Add(el.Name);
            }
            if (comboBox1.Items.Count != 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text=="" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    throw new Exception("Eror text!!!");
                }
                if (comboBox1.SelectedIndex == null)
                {
                    throw new Exception("Eror selected category!!!");
                }
                Name = textBox1.Text;
                Adress = textBox2.Text;
                Email = textBox3.Text;
                Phone = textBox4.Text;
                Telegram = textBox5.Text;
                Viber = textBox6.Text;
                Category = comboBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }
        }

        private void AddCont_Load(object sender, EventArgs e)
        {

        }
    }
}
