using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DND_UpdatedAddressBookApplication
{
    internal class AddressBook
    {
        List<Contact> ContactList = new List<Contact>();
        ValidationMethods validationMethods = new ValidationMethods();
        public void AddContact()
        {
            Console.WriteLine("Enter the details to add a contact: ");

            Console.Write("\nEnter name: ");
            string name = Console.ReadLine();
            if (!validationMethods.ValidateName(name))
            {
                Console.WriteLine("INVALID NAME!!! Enter the valid data...\n");
                AddContact();
                return;
            }

            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            if (!validationMethods.ValidateEmail(email))
            {
                Console.WriteLine("INVALID EMAIL!!! Enter the valid data...\n");
                AddContact();
                return;
            }

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();
            if (!validationMethods.ValidatePhoneNumber(phone))
            {
                Console.WriteLine("INVALID PHONE NUMBER!!! Enter the valid data...\n");
                AddContact();
                return;
            }

            Console.Write("Enter state: ");
            string state = Console.ReadLine();

            Console.Write("Enter city: ");
            string city = Console.ReadLine();

            Console.Write("Enter zip: ");
            string zip = Console.ReadLine();
            if (!validationMethods.ValidateZIP(zip))
            {
                Console.WriteLine("INVALID ZIP CODE!!! Enter the valid data...\n");
                AddContact();
                return;
            }

            Contact contact = new Contact(name, email, phone, state, city, zip);

            bool duplicateContactFound = false;
            foreach (Contact c in ContactList)
            {
                if (c.phone == phone || c.name == name)
                {
                    duplicateContactFound = true;
                    throw new DuplicateContactException("DUPLICATE CONTACT FOUND!!! Please add contact with different attributes.");
                }
            }

            if (!duplicateContactFound)
            {
                ContactList.Add(contact);
                Console.WriteLine("Contact Added...");
            }
        }

        public void EditContact()
        {
            Console.WriteLine("Enter the First Name of the Contact you want to Edit: ");
            String editName = Console.ReadLine();
            bool contactFound = false;

            for (int index = 0; index < ContactList.Count; index++)
            {
                Contact contact = ContactList[index];
                if (editName.Equals(contact.name))
                {
                    contactFound = true;
                    Console.WriteLine("Current Contact Details:");
                    Console.WriteLine(contact.ToString());

                    Console.WriteLine("Select the name of the Field you want to Edit in Contact's Details:");
                    Console.WriteLine("1.First Name\t2.E-mail Address\t3.Phone Number\t4.State\t5.City\t6.ZIP Code");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Current Name: " + contact.name);
                            Console.Write("Enter the NEW Name: ");
                            contact.name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Current E-mail Address: " + contact.email);
                            Console.Write("Enter the NEW E-mail Address: ");
                            contact.email = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Current Phone Number: " + contact.phone);
                            Console.Write("Enter the NEW Phone Number: ");
                            contact.phone = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Current State: " + contact.state);
                            Console.Write("Enter the NEW State: ");
                            contact.state = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Current City: " + contact.city);
                            Console.Write("Enter the NEW City: ");
                            contact.city = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Current ZIP Code: " + contact.zipcode);
                            Console.Write("Enter the NEW ZIP Code: ");
                            contact.zipcode = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Enter a valid field!!!");
                            break;
                    }
                    Console.WriteLine("Contact Edited!!!");
                    Console.WriteLine("Contact Details AFTER Edit:");
                    Console.WriteLine(contact.ToString());
                }
            }
            if (!contactFound)
            {
                throw new Exception("CONTACT NOT FOUND!!! Please enter the name of an existing contact.");
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter the Name of the Contact you want to Delete: ");
            string deleteName = Console.ReadLine();

            bool contactFound = false;
            for (int index = 0; index < ContactList.Count; index++)
            {
                Contact contact = ContactList[index];
                if (deleteName == contact.name)
                {
                    contactFound = true;
                    Console.WriteLine("Details of the Contact you want to DELETE:");
                    Console.WriteLine(contact.ToString());
                    Console.WriteLine("Are you sure you want to DELETE the Contact?");
                    Console.WriteLine("1. YES \t 2. NO");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            ContactList.Remove(contact);
                            Console.WriteLine("Contact Deleted!!!");
                            break;
                        case 2:
                            Console.WriteLine("Contact is NOT deleted!!!");
                            break;
                        default:
                            Console.WriteLine("Select a valid option!!!");
                            break;
                    }
                }
            }
            if (!contactFound)
            {
                throw new Exception("CONTACT NOT FOUND!!! Please enter the name of an existing contact.");
            }
        }

        public void DisplayContact()
        {
            Console.WriteLine("Enter the Name of the Contact you want to Display: ");
            string displayName = Console.ReadLine();

            bool contactFound = false;
            for (int index = 0; index < ContactList.Count; index++)
            {
                Contact contact = ContactList[index];
                if (displayName == contact.name)
                {
                    contactFound = true;
                    Console.WriteLine("Details of the Contact: ");
                    Console.WriteLine(contact.ToString());
                }
            }
            if (!contactFound)
            {
                throw new Exception("CONTACT NOT FOUND!!! Please enter the name of an existing contact.");
            }
        }

        public void Display()
        {
            Console.WriteLine("The Contacts in the Address Book are: ");
            foreach (Contact contact in ContactList)
            {
                Console.WriteLine(contact.ToString());
                Console.WriteLine();
            }
        }
    }
}
