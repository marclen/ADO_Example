using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadDB();
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        public static void ReadDB()
        {
            //ADO.NET
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MarkyDB;Integrated Security=True");
            SqlCommand command = new SqlCommand("Persons_Get");
            DataTable dt = new DataTable();

            using (connection)
            {
                using (command)
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = command.CommandText.ToString();
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dt);
                }
            }

            List<Person> people = new List<Person>();

            foreach (DataRow dr in dt.Rows)
            {
                Person a = new Person();
                a.person_ID = int.Parse(dr["person_ID"].ToString());
                a.FirstName = dr["FirstName"].ToString();
                a.LastName = dr["LastName"].ToString();
                a.Phone = dr["Phone"].ToString();
                a.Email = dr["Email"].ToString();
                people.Add(a);
            }

        }
    }
}
