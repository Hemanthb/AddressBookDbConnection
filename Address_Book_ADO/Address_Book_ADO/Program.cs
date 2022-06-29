Address_Book_ADO.AddressBookADO bookADO = new Address_Book_ADO.AddressBookADO();
Console.WriteLine("Enter Your Choice\n\t1 - To Select Data\n\t2 - To Update Data\n\t3 - To Delete Data\n\t4 - Add Multiple Contacts using thread");
int choice = Convert.ToInt32(Console.ReadLine());
switch (choice)
{
    case 1:
        bookADO.GetData();
        break;
    case 2:
        bookADO.UpdateRecord();
        break;
    case 3:
        Console.WriteLine("Enter the first name whose details have to be deleted");
        string name = Console.ReadLine();
        bookADO.DeleteData(name);
        break;
    case 4:
        List<Address_Book_ADO.AddressBookModel> bookList = new List<Address_Book_ADO.AddressBookModel>();
        Console.WriteLine("Enter number of contacts to Add");
        int number = Convert.ToInt32(Console.ReadLine());
        while (number!=0)
        {
            Address_Book_ADO.AddressBookModel model = new Address_Book_ADO.AddressBookModel();
            Console.WriteLine("Enter First Name");
            model.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            model.LastName = Console.ReadLine();
            Console.WriteLine("Enter Address ");
            model.Address = Console.ReadLine();
            Console.WriteLine("Enter City ");
            model.City = Console.ReadLine();
            Console.WriteLine("Enter State ");
            model.State = Console.ReadLine();
            Console.WriteLine("Enter Zip Code ");
            model.Zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone ");
            model.Phone = Console.ReadLine();
            Console.WriteLine("Enter Email ");
            model.Email = Console.ReadLine();
            bookList.Add(model);
            number--;
        }
        bookADO.AddMultipleContacts(bookList);
        break;
}

