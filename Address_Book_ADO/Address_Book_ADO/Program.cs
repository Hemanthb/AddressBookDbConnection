Address_Book_ADO.AddressBookADO bookADO = new Address_Book_ADO.AddressBookADO();
Console.WriteLine("Enter Your Choice\n\t1 - To Select Data\n\t2 - To Update Data\n\t3 - To Delete Data\n");
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
}

