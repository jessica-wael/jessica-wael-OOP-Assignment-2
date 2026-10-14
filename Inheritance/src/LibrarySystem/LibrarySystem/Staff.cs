using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{
    public class Staff : Person
    {

        public decimal Salary { get; private set; }
        public DateTime HireDate { get; }
        protected decimal MonthlyAllowance { get; }

        public decimal GetMonthlypay => Salary + MonthlyAllowance;

        protected Staff(string staffId, string fullName, string phone, DateTime hireDate, decimal salary, decimal monthlyAllowance)
            : base(staffId, fullName,phone)
        {
            if (salary <= 0) 
                throw new ArgumentException("Salary must be positive."); 

            if (monthlyAllowance < 0) 
                throw new ArgumentException("Allowance cannot be negative."); 

            Salary = salary;
            HireDate = hireDate;
            MonthlyAllowance = monthlyAllowance;
            
        }
        public void GiveRaise(decimal percent)
        {
            if (percent <= 0)
                throw new ArgumentException("Raise percentage must be greater then zero!");

            Salary += Salary *percent / 100m;

        }

       

    }

    
}
