using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{
    public class HeadLibrarian : Staff
    {
        public HeadLibrarian(string id, string fullName, string phone, decimal salary, DateTime hireDate) 
            : base(id, fullName, phone, hireDate, salary, 400m)
        {

        }

        public void ChangeLateFee(LibraryItem item , decimal newFee )
        {
            if(item == null)
                throw new ArgumentNullException("item");

            item.ChangeBaseLateFee(newFee);
        }
        public void Withdraw(LibraryItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            item.Withdraw();
        }
        public void Restore(LibraryItem item)
        {

            if (item == null)
                throw new ArgumentNullException("item");
            item.Restore();

        }
    }
}
