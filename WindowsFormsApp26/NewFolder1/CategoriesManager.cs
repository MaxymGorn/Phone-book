using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp26.NewFolder1
{
    public class CategoriesManager : DbProvider
    { 
    public List<Category> Categories { get; set; }
    
        public CategoriesManager():base()
        {
            Categories = new List<Category>();
        }
        public override void LoadData()
        {
            Categories.Clear();
            SqlDataAdapter.Fill(DataSet);
            foreach(DataRow row in DataSet.Tables[0].Rows)
            {
                Category category = new Category() 
                { 
                    Id=(int)row["Id"],
                    Name=(string)row["Name"]
 
                };
                Categories.Add(category);
            }
        }

        public  void Add(string category)
        {
            DataRow dataRow = DataSet.Tables[0].NewRow();
            dataRow["Id"] = 0;
            dataRow["Name"] = category;
            DataSet.Tables[0].Rows.Add(dataRow);
            SqlDataAdapter.Update(DataSet);
        }

        public override void Del(string category)
        {
            int k = 0;
            foreach(DataRow row in DataSet.Tables[0].Rows)
            {
                if((string)row["Name"]==category)
                {   
                    k++;
                    row.Delete();
                    break;
                }
            }
            SqlDataAdapter.Update(DataSet);
            try
            {
                if(k==0)
                {
                    throw new Exception("Данной категории не существует!");
                }
              
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "Notifications");
            }
        }
    }
}
