using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{

    public class Member : Person
    {
        private readonly List<Loan> _loans = new List<Loan>();

        public int MaxLoans { get; }
        public decimal DiscountPercent { get; }
        public IReadOnlyList <Loan> Loans
        {
            get
            {
                return _loans.AsReadOnly();
            }
        }
        protected Member(string personId,string fullName, string phone,int maxLoans ,decimal discountPercent)
               : base(personId, fullName, phone)
        {
            if (maxLoans <= 0)
                throw new ArgumentOutOfRangeException("Maximum loans must be greater than zero.");
            if (discountPercent < 0 || discountPercent > 100)
                throw new ArgumentOutOfRangeException("Discount must be between 0 and 100 percent.");

            MaxLoans = maxLoans;
            DiscountPercent = discountPercent;
        }

        public int ActiveLoansCount()
        {
            int count = 0;
            foreach(Loan loan in _loans)
            {
                if (loan.Status == LoanStatus.Borrowed)
                    count++;

            }
            return count;

        }
        public Loan Borrow(LibraryItem item, DateTime borrowDate)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (ActiveLoansCount() >= MaxLoans)
                throw new InvalidOperationException($"{FullName} reached the loan limit of {MaxLoans} items.");

            if (item.IsWithdrawn)
                throw new InvalidOperationException($"'{item.Title}' is withdrawn from circulation and cannot be borrowed.");

            if (item.IsOnLoan)
                throw new InvalidOperationException($"'{item.Title}' is already on loan.");

            
            Loan loan = new Loan(Id, this, item, borrowDate);
            item.MarkBorrowed();
            _loans.Add(loan);
            return loan;
        }

    }
}
