using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{
    public class StudentMember : Member
    {

        public StudentMember(string id, string name, string phone)
           : base(id, name, phone, 3, 0m) 
        { 
        
        }
    }
}
