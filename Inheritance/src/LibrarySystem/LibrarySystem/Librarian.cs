using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibrarySystem
{
    public class Librarian : Staff
    {

        public Librarian(string id, string fullName, string phone, decimal salary, DateTime hireDate)
            : base(id, fullName, phone,hireDate, salary, 0m)
        {


        }

        public void ProcessReturn(Loan loan , DateTime returnDate)
        {
            if (loan ==null)
                throw new ArgumentNullException("loan");
            loan.Return(returnDate);
        }

        public void MarkAsLost(Loan loan)
        {
            if (loan == null)
                throw new ArgumentNullException("loan");
            loan.MarkLost();
        }
    }
}
