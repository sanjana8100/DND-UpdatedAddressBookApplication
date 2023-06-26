namespace DND_UpdatedAddressBookApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Welcome to AddressBook : ");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("******************MENU:******************");
                Console.WriteLine("=> To Add Contact: PRESS 1");
                Console.WriteLine("=> To Edit an Existing Contact: PRESS 2");
                Console.WriteLine("=> To Delete a Contact: PRESS 3");
                Console.WriteLine("=> To Display a specific Contact: PRESS 4");
                Console.WriteLine("=> To Display all Contacts in the Address Book: PRESS 5");
                Console.WriteLine("=> To EXIT: PRESS 6");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            try
                            {
                                addressBook.AddContact();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                addressBook.EditContact();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                addressBook.DeleteContact();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                addressBook.DisplayContact();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 5:
                        {
                            try
                            {
                                addressBook.Display();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 6:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
    }
}