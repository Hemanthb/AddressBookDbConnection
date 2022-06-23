using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Address_Book_ADO
{
    public class AddressBookADO
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookService;";
        //UC1 Retrieve data from table
        public void GetData()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            Address_Book_ADO.AddressBookModel book = new Address_Book_ADO.AddressBookModel();
            using (connect)
            {
                connect.Open();
                string query = "Select * from Address_Book";
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        book.ContactId = reader.GetInt32(0);
                        book.FirstName = reader.GetString(1);
                        book.LastName = reader.GetString(2);
                        book.Address = reader.GetString(3);
                        book.City = reader.GetString(4);
                        book.State = reader.GetString(5);
                        book.Zip = reader.GetInt32(6);
                        book.Phone = reader.GetString(7);
                        book.Email = reader.GetString(8);
                        
                        Console.WriteLine(book.ContactId + " | " + book.FirstName + " | " + book.LastName + " | " + book.Address +
                            " | " + book.City + " | " + book.State + " | " + book.Zip + " | ");
                    }
                }
                else
                {
                    Console.WriteLine("Records not found in Database.");
                }
                reader.Close();
                connect.Close();

            }
        }
    }
}