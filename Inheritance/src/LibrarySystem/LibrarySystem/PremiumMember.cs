using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{
    public class PremiumMember : Member
    {
        private const int PointsReturnedLoans = 5;
        public PremiumMember(string id, string name, string phone, decimal discountPercent)
        : base(id, name, phone, 10, discountPercent) { }

        public int ReadingPoints
        {
            get
            {
                int points = 0;
                foreach (Loan loan in Loans)
                {
                    if (loan.Status == LoanStatus.Returned)
                        points ++;
                }
                return points*PointsReturnedLoans;
            }
        }
    }
}
