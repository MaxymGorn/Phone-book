using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace WindowsFormsApp26.NewFolder1
{
    public abstract class DbProvider 
    {
        string connectionString;
        SqlConnection SqlConnection;
        public static DataSet DataSet { get; set; }
        public SqlDataAdapter SqlDataAdapter { get; set; }
        public static SqlCommandBuilder sqlCommandBuilder;

        public DbProvider()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection = new SqlConnection(connectionString);
            string query1 = "select * from Categories";
            string query2 = "select * from Contacts";
            string query3 =$"{query1} {query2}";
            SqlDataAdapter = new SqlDataAdapter(query3,SqlConnection);
            DataSet = new DataSet();
            SqlDataAdapter.Fill(DataSet);
             sqlCommandBuilder = new SqlCommandBuilder(SqlDataAdapter);
        }
        public abstract void LoadData();
        public abstract void Del(string category);
     
         ~DbProvider()
        {

        }
    }
}
