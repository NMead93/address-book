using System;
using System.Collections.Generic;

namespace Address.Objects
{
    public class Contact
    {
        private string _name;
        private string _number;
        private string _address;
        private static Dictionary<string, Contact> _contactList = new Dictionary<string, Contact> () {};

        public Contact (string name, string number, string address)
        {
            _name = name;
            _number = number;
            _address = address;
        }

        public string GetName ()
        {
            return _name;
        }

        public string GetNumber ()
        {
            return _number;
        }

        public string GetAddress ()
        {
            return _address;
        }

        public void SetName (string name)
        {
            _name = name;
        }

        public void SetNumber (string number)
        {
            _number = number;
        }

        public void SetAddress (string address)
        {
            _address = address;
        }

        public static Dictionary<string, Contact> GetContacts ()
        {
            return _contactList;
        }

        public static Contact GetOneContact(string name)
        {
            return _contactList[name];
        }

        public static void ClearContacts ()
        {
            _contactList.Clear();
        }

        public static void SaveContact (string name, Contact newContact)
        {
            _contactList.Add(name, newContact);
        }
    }
}
