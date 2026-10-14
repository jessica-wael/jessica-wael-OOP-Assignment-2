using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{
    public class LibraryItem 
    {

        public string CatalogId { get; }
        public string Title { get; }
        public decimal BaseLateFee { get; private set; }
        public int LoanPeriodDays { get; }
        public decimal LateFeeMultiplier { get; }
        public bool IsWithdrawn { get; private set; }
        public bool IsOnLoan { get; private set; }
        public decimal DailyLateFee => BaseLateFee * LateFeeMultiplier; 

        public LibraryItem(string catalogId, string title, decimal baseLateFee, int loanPeriodDays, decimal lateFeeMultiplier)
        {
            if (string.IsNullOrEmpty(catalogId))
                throw new ArgumentException("Catalog number cannot be empty.");
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title cannot be empty.");
            if (baseLateFee <= 0)
                throw new ArgumentException("Base late fee must be positive.");


            CatalogId = catalogId;
            Title = title;
            LoanPeriodDays = loanPeriodDays;
            LateFeeMultiplier = lateFeeMultiplier;
            BaseLateFee = baseLateFee;
        }

        internal void ChangeBaseLateFee(decimal newFee)
        {
            if (newFee <= 0)
                throw new ArgumentException("Late fee must be greater than zero.");
            BaseLateFee = newFee;
        }

        internal void Withdraw()
        {
            IsWithdrawn = true;
        }

        internal void Restore()
        {
            IsWithdrawn = false;
        }

        internal void MarkBorrowed()
        {
            if (IsWithdrawn)
                throw new InvalidOperationException("Withdrawn item cannot be borrowed.");
            if (IsOnLoan)
                throw new InvalidOperationException("Item is already on loan.");

            IsOnLoan = true;
        }

        internal void MarkReturned()
        {
            IsOnLoan = false;
        }

    }
}
