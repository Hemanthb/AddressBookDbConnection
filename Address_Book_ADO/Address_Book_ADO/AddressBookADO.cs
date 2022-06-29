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
                    Console.WriteLine("No records found in Database.");
                }
                reader.Close();
                connect.Close();

            }
        }

        //UC2 Update record in database
        public void UpdateRecord()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            try
            {
                using (connect)
                {
                    Console.WriteLine("Enter the name of Person whose contact has to be updated:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter new phone Number:");
                    string phone = Console.ReadLine();
                    connect.Open();
                    string query = "update Address_Book set Phone_Number =" + phone + "where FirstName='" + name + "'";
                    SqlCommand command = new SqlCommand(query, connect);
                    if (command.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("Records updated successfully!");
                        return;
                    }
                    Console.WriteLine("Not Updated!!!");
                    connect.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //To Delete Data
        public void DeleteData(string name)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(connectionString))
                {
                    string sql = "DELETE FROM Address_Book WHERE FirstName = '" + name + "'";
                    SqlCommand Command = new SqlCommand(sql, Connection);
                    Connection.Open();
                    var result = Command.ExecuteNonQuery();
                    Connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Data is Deleted Successfully");
                        return;
                    }
                    Console.WriteLine("Data is not Deleted!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddData(AddressBookModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            lock (this)
            {
                using (connection)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("spAddress_Book", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FIRST_NAME", model.FirstName);
                        command.Parameters.AddWithValue("@LAST_NAME", model.LastName);
                        command.Parameters.AddWithValue("@ADDRESS", model.Address);
                        command.Parameters.AddWithValue("@CITY", model.City);
                        command.Parameters.AddWithValue("@STATE", model.State);
                        command.Parameters.AddWithValue("@ZIP_CODE", model.Zip);
                        command.Parameters.AddWithValue("@PHONE_NUMBER", model.Phone);
                        command.Parameters.AddWithValue("@EMAIL", model.Email);
                        connection.Open();
                        var result = command.ExecuteNonQuery();
                        connection.Close();
                        Console.WriteLine("Data Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void AddMultipleContacts(List<AddressBookModel> bookList)
        {
            bookList.ForEach(details =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Thread Start Time: " + DateTime.Now);
                    this.AddData(details);
                    Console.WriteLine("Contact Added: " + details.FirstName);
                    Console.WriteLine("Thread End Time: " + DateTime.Now);
                });
                thread.Start();
            });
        }
    }
}