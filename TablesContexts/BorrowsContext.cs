namespace Library_Manager.TablesContexts;

public class BorrowsContext
{
    public void borrowBook()
    {
        Console.WriteLine("Enter book id to borrow: ");
        int id = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter reader id to borrow: ");
        int idr = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter rerurn date (yyyy-MM-dd): ");
        DateTime retrDateTime = DateTime.Parse(Console.ReadLine());
        retrDateTime = DateTime.SpecifyKind(retrDateTime, DateTimeKind.Utc);

        using (var context = new Context())
        {
            var book = context.Books.FirstOrDefault(b => b.Id == id);
            
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (book.CopiesAvailable <= 0)
            {
                Console.WriteLine("No copies available to borrow.");
                return;
            }

            var borrow = new Borrow
            {
                BookId = id,
                ReaderId = idr,
                BorrowDate = DateTime.UtcNow,
                ReturnDate = retrDateTime,
                IsReturned = false
            };

            book.CopiesAvailable--; 

            context.Borrows.Add(borrow);
            context.SaveChanges(); 

            Console.WriteLine("Book borrowed successfully!");
        }
    }
    
    public void returnBook()
    {
        Console.WriteLine("Enter borrws id: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new Context())
        {
            var borrow = context.Borrows.FirstOrDefault(b => b.Id == id);
            borrow.IsReturned = true;
            
            var book = context.Books.FirstOrDefault(b => b.Id == borrow.BookId);
            book.CopiesAvailable++;
            
            context.SaveChanges();
            Console.WriteLine("Book returned successfully!");
            
        }
    }

    public void listBorrows()
    {
        using (var context = new Context())
        {
            var borrows = from b in context.Borrows
                select b;

            foreach (var borrow in borrows)
            {
                Console.WriteLine(borrow.Id);
                Console.WriteLine("Book ID: " + borrow.BookId);
                Console.WriteLine("Reader ID: " + borrow.ReaderId);
                Console.WriteLine("Borrow Date: " + borrow.BorrowDate);
                Console.WriteLine("Return Date: " + borrow.ReturnDate);
                Console.WriteLine("IsReturned: " + borrow.IsReturned);
                Console.WriteLine("-------------------------");
            }
            
            if (borrows.Count() == 0)
            {
                Console.WriteLine("No borrows found!");
            }
        }
    }
}