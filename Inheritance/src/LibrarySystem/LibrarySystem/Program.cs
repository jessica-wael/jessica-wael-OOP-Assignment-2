namespace LibrarySystem;

class program
{
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\n=======  Library System  ======");
        Console.ResetColor();

        DateTime today = new DateTime(2026, 10, 1);
  

        StudentMember student = new StudentMember("S1", "Ali", "0100000001");
        StudentMember student2 = new StudentMember("S2", "Sara", "0100000002");
        PremiumMember premium = new PremiumMember("p1", "Asmaa", "01122334455",0m);
        PremiumMember premium2 = new PremiumMember("p2", "Karem", "01188999999", 5m);
        Librarian librarian = new Librarian("L1", "Laila", "0100000003", 3000m, new DateTime(2018, 3, 1));
        HeadLibrarian head = new HeadLibrarian("H1", "Hoda", "0100000004", 5000m, new DateTime(2015, 1, 1));
        Shelver shelver = new Shelver("SH1", "Sami", "0100000005", 2000m, new DateTime(2020, 9, 1), "Fiction");


        Console.WriteLine("\n==== Staff monthly pay ====");
        List<Staff> staffmembers = new List<Staff> { librarian, head, shelver };
        foreach(Staff staffmember in staffmembers)
        {
            Console.WriteLine($"{staffmember.FullName}: {staffmember.GetMonthlypay}$");
        }

        Console.WriteLine("\n=== Item loan periods and daily late fees ===");
        List<LibraryItem> items = new List<LibraryItem>
        {
            new Book("B01", "C# Basics", 10m),
            new Book("B02","OOP Fundmintals" , 15m),
            new DVD("D01", "Learning C# Video", 10m),
            new DVD("D02", "Clean Code Video", 5m),
            new Magazine("M01", "Tech Monthly", 10m),
            new Magazine("M02", "Akhbar Al-Yom", 20m),
        };
        foreach(LibraryItem item in items)
        {
            Console.WriteLine($"{item.Title}: {item.LoanPeriodDays} days; daily fee = {item.DailyLateFee}$");
        }


        Console.WriteLine("\n=== Reject borrowing a withdrawn item ===");
        Book withdrawnBook = new Book("B03", "Git & GitHub", 15m);
        head.Withdraw(withdrawnBook);
        try
        {
            student.Borrow(withdrawnBook, new DateTime(2026, 10, 1));

        }
        catch(Exception ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }


        Console.WriteLine("\n=== Reject borrowing an item already on loan ===");
        Book sharedBook = new Book("B03", "Shared Book", 5m);
        student.Borrow(sharedBook, new DateTime(2026, 10, 1));
        try
        {
            premium.Borrow(sharedBook, new DateTime(2026, 10, 2));
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Rejected: {exception.Message}");
        }

        Console.WriteLine("\n=== Reject a Student's fourth active loan ===");
        Book studentBook1 = new Book("B04", "Student Book 1", 5m);
        Book studentBook2 = new Book("B05", "Student Book 2", 5m);
        Book studentBook3 = new Book("B06", "Student Book 3", 5m);
        student.Borrow(studentBook1, new DateTime(2026, 10, 1));
        student.Borrow(studentBook2, new DateTime(2026, 10, 1));
        try
        {
            student.Borrow(studentBook3, new DateTime(2026, 10, 1));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }

        Console.WriteLine("\n=== Premium member returns a DVD five days late ===");

        DVD lateDvd = new DVD("D02", "C# Advanced DVD", 10m);
        Loan premiumLoan = premium.Borrow(lateDvd, new DateTime(2026, 9, 1));
        DateTime returnDate = premiumLoan.DueDate.AddDays(5);
        librarian.ProcessReturn(premiumLoan, returnDate);
        Console.WriteLine($"Due date: {premiumLoan.DueDate:yyyy-MM-dd}");
        Console.WriteLine($"Return date: {premiumLoan.ReturnDate:yyyy-MM-dd}");
        Console.WriteLine($"Daily late fee: {premiumLoan.Item.DailyLateFee}$");
        Console.WriteLine($"Late fee after {premium.DiscountPercent}% discount: {premiumLoan.LateFee}$");
        Console.WriteLine($"Premium reading points: {premium.ReadingPoints}");


        Console.WriteLine("\n=== Reject returning the same loan twice ===");
        try
        {
            librarian.ProcessReturn(premiumLoan, returnDate.AddDays(1));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }

        Console.WriteLine("\n=== Reject marking a returned loan as lost ===");
        try
        {
            librarian.MarkAsLost(premiumLoan);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }


        Console.WriteLine("\n=== Invalid return date ===");
        
        Book dateBook = new Book("B007", "Date Validation Book", 5m);
        Loan dateLoan = premium.Borrow(dateBook, new DateTime(2026, 10, 10));
        try
        {
            librarian.ProcessReturn(dateLoan, new DateTime(2026, 10, 9));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }

        
    }
}
    

    
