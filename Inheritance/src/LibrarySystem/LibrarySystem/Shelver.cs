using System;
using System.Collections.Generic;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace LibrarySystem
{
    public class Shelver : Staff
    {
        public string Section { get; private set; }
        public Shelver(string id, string fullName, string phone, decimal salary, DateTime hireDate,string section)
            : base(id, fullName, phone, hireDate, salary, 0m)
        {
            if (string.IsNullOrEmpty(section))
                throw new ArgumentException("Section must not be Empty!");

            Section = section;
        }
        private static string ValidateSection(string section)
        {
            if (string.IsNullOrEmpty(section))
                throw new ArgumentException("Section can not be empty!");

            return section;
        }

        public void Reassign(string newSection)
        {

            Section= ValidateSection(newSection);

        }

    }
    
}
