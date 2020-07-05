using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp26
{
    public partial class Add_Category : Form
    {
        public string Name { get; set; }
        public Add_Category()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text=="")
                {
                    throw new Exception("Eror text!!!");
                }
                Name = textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message,"Ошыбка!");
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Category_Load(object sender, EventArgs e)
        {

        }
    }
}
