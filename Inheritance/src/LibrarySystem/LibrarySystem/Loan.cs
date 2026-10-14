using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{
    public class Loan
    {

        public string LoanId { get; }
        public DateTime BorrowDate { get; }
        public Member Member { get; }
        public LibraryItem Item { get; }
        public LoanStatus Status { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public DateTime DueDate
        {
            get { return BorrowDate.AddDays(Item.LoanPeriodDays); }
        }

        public decimal LateFee { get; private set; }

        internal Loan(string loanId, Member member, LibraryItem item, DateTime borrowDate)
        {
            if (string.IsNullOrWhiteSpace(loanId))
                throw new ArgumentException("Loan ID must not be empty.");
            if (member == null)
                throw new ArgumentNullException(nameof(member));
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            LoanId = loanId;
            Member = member;
            Item = item;
            BorrowDate = borrowDate;
            Status = LoanStatus.Borrowed;
        }
     
        internal void Return(DateTime returnDate)
        {

            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException("Only a borrowed loan can be returned.");
            if (returnDate < BorrowDate)
                throw new ArgumentException("Return date cannot be earlier than the borrow date.");

            ReturnDate = returnDate;
            Status = LoanStatus.Returned;
            Item.MarkReturned();
        }
        public void MarkLost()
        {
            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException("Only a borrowed loan can be marked as lost.");

            Status = LoanStatus.Lost;
        }

    }
}
