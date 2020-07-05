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
    public partial class Form1 : Form
    {
        CategoriesManager CategoriesManager;
        ContactManager ContactManager;
        public Form1()
        {
            InitializeComponent();
            CategoriesManager = new CategoriesManager();
            ContactManager = new ContactManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadContacts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddCont add_Category = new AddCont(CategoriesManager);
            if (add_Category.ShowDialog() == DialogResult.OK)
            {
                ContactManager.
                    Add(add_Category.Name,
                    add_Category.Adress,
                    add_Category.Email,
                    add_Category.Phone,
                    add_Category.Telegram,
                    add_Category.Viber,
                    add_Category.Category);
                LoadContacts();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ContactManager.Del(ContactList.Items[ContactList.SelectedIndex].ToString());
            LoadContacts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoriesManager.Del(comboBox1.Text);
            LoadCategory();
        }
        private void LoadCategory()
        {
            CategoriesManager = new CategoriesManager();
            CategoriesManager.LoadData();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("All");
            foreach (var el in CategoriesManager.Categories)
            {
                comboBox1.Items.Add(el.Name);
            }
            comboBox1.SelectedIndex = 0;
            if(ContactList.Items.Count!=0)
            {
                ContactList.SelectedIndex = 0;
                
            }
            
        }
        private void LoadContacts()
        {
            ContactManager=new ContactManager();
            ContactManager.LoadData();
            ContactList.Items.Clear();
            foreach (var el in ContactManager.Contacts)
            {
                ContactList.Items.Add(el.Name);
            }
            if (ContactList.Items.Count != 0)
            {
                ContactList.SelectedIndex = 0;
            }
        }
        private void FilterContacts()
        {
            if(comboBox1.SelectedIndex==0)
            {
                LoadContacts(); 
            }
            else
            {
               
                    ContactList.Items.Clear();
                    foreach (var el in ContactManager.Contacts.Where(i => i.CategoryId == ContactManager.GetId2(comboBox1.Text)))
                    {
                        ContactList.Items.Add(el.Name);
                    }
                    if (ContactList.Items.Count != 0)
                    {
                        ContactList.SelectedIndex = 0;
                    }
   
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Add_Category add_Category = new Add_Category();
            if(add_Category.ShowDialog()==DialogResult.OK)
            {
                string categoryName = add_Category.Name;
                CategoriesManager.Add(categoryName);
                LoadCategory();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterContacts();
        }

        private void ContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = (string)ContactManager.GetId(ContactList.Text)["Name"];
                textBox2.Text = (string)ContactManager.GetId(ContactList.Text)["Adress"];
                textBox3.Text = (string)ContactManager.GetId(ContactList.Text)["E-mail"];
                textBox4.Text = (string)ContactManager.GetId(ContactList.Text)["Phone"];
                textBox5.Text = (string)ContactManager.GetId(ContactList.Text)["Telegram"];
                textBox6.Text = (string)ContactManager.GetId(ContactList.Text)["Viber"];

            }
            catch(Exception)
            {

            }
          



        }
    }
}
