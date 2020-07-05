using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp26.NewFolder1
{
    class ContactManager : DbProvider
    {
        public List<Contact> Contacts { get; set; }
        public ContactManager() : base()
        {
            Contacts = new List<Contact>();
        }
        public override void LoadData()
        {
            Contacts.Clear();
            SqlDataAdapter.Fill(DataSet);
            foreach (DataRow row in DataSet.Tables[1].Rows)
            {
                Contact Contactss = new Contact()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Adress=(string)row["Adress"],
                    CategoryId=(int)row["CategoryId"],
                    Email=(string)row["E-mail"],
                    Phone=(string)row["Phone"],
                    Telegram=(string)row["Telegram"],
                    Viber=(string)row["Viber"]

                };
                Contacts.Add(Contactss);
            }
        }
        public static int GetId2(string name)
        {

            foreach (DataRow dr in DataSet.Tables[0].Rows)
            {
                string el = (string)dr["Name"];
                if (el.Contains(name))
                {
                    return (int)dr["Id"];
                }
            }
            return 0;

        }
        public static DataRow GetId(string name)
        {
         
                foreach (DataRow dr in DataSet.Tables[1].Rows)
                {
                    string el = (string)dr["Name"];
                    if (el.Contains(name))
                    {
                        return dr;
                    }
                }
            return null;

        }
  
        public void Add(string Name, string Adress, string mail, string Phone, string Telegram, string Viber, string Category)
        {
            try
            {
                DataRow dataRow = DataSet.Tables[1].NewRow();
                dataRow["Id"] = 0;
                dataRow["Name"] = Name;
                dataRow["Adress"] = Adress;
                dataRow["CategoryId"] = ContactManager.GetId2(Category);
                dataRow["E-mail"] = mail;
                dataRow["Phone"] = Phone;
                dataRow["Telegram"] = Telegram;
                dataRow["Viber"] = Viber;
                DataSet.Tables[1].Rows.Add(dataRow);
                DataRow[] dataRows = DataSet.Tables[1].Rows.Cast<DataRow>().AsEnumerable().ToArray();
                SqlDataAdapter.Update(DataSet, "Table1");
                sqlCommandBuilder.GetUpdateCommand();
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }

         
          
        }

        public override void Del(string c)
        {
            int k = 0;

            foreach (DataRow row in DataSet.Tables[1].Rows)
            {
                if ((string)row["Name"] == c)
                {
                    k++;
                    row.Delete();
                    SqlDataAdapter.Update(DataSet);
                }
            }
            try
            {
                if (k == 0)
                {
                    throw new Exception("Данного контакта не существует!");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Notifications");
            }
        }


    }
}
