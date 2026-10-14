using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{
    public class Person
    {

        public string Id { get; }
        public string FullName { get; }
        public string Phone { get; }

        protected Person(string id, string fullName, string phone)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id must not be Empty!");

            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentException("Full name must not be Empty!");


            if (string.IsNullOrEmpty(phone))
                throw new ArgumentException("phone number must not be Empty!");


            Id = id;
            FullName = fullName;
            Phone = phone;
        }


            
    }
}
