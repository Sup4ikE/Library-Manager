using System.Security.Cryptography.X509Certificates;

namespace Library_Manager.TablesContexts;

public class BooksContext
{
    public void ListBooks()
    {
        using (var context = new Context())
        {
            var books = from b in context.Books
                select b;

            foreach (var book in books)
            {
                Console.WriteLine(book.Id);
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.Genre);
                Console.WriteLine(book.YearPublished);
                Console.WriteLine(book.CopiesAvailable);
                Console.WriteLine("-------------------------");
            }
            
            if (books.Count() == 0)
            {
                Console.WriteLine("No books found!");
            }
        }
    }

    public void AddBook()
    {
        using (var context = new Context())
        {
            Console.WriteLine("Enter book title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter book author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Enter book genre: ");
            string genre = Console.ReadLine();

            Console.WriteLine("Enter book year published: ");
            int yearPublished = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter book copies available: ");
            int copiesAvailable = int.Parse(Console.ReadLine());

            var book = new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                YearPublished = yearPublished,
                CopiesAvailable = copiesAvailable
            };

            context.Books.Add(book);
            context.SaveChanges();
            Console.WriteLine("Book added successfully!");
        }
    }

    public void UpdateBook()
    {
        Console.WriteLine("Enter book id to update: ");
        int id = int.Parse(Console.ReadLine());
        
        Console.WriteLine("What you want to change: ");
        Console.WriteLine("1. Title");
        Console.WriteLine("2. Author");
        Console.WriteLine("3. Genre");
        Console.WriteLine("4. Year published");
        Console.WriteLine("5. Copies available");
        Console.WriteLine("0. Exit");
        int a = int.Parse(Console.ReadLine());

        switch (a)
        {
            case 1:
                Console.WriteLine("Enter new title: ");
                string title = Console.ReadLine();
                using (var context = new Context())
                {
                    var books = from b in context.Books
                        where b.Id == id
                            select b;
                    
                    foreach (var book in books)
                    {
                        book.Title = title;
                    }
                    
                    context.SaveChanges();
                    Console.WriteLine("Book updated successfully!");
                }
                break;
            case 2:
                Console.WriteLine("Enter new author: ");
                string author = Console.ReadLine();
                using (var context = new Context())
                {
                    var books = from b in context.Books
                        where b.Id == id
                        select b;
                    
                    foreach (var book in books)
                    {
                        book.Author = author;;
                    }
                    
                    context.SaveChanges();
                    Console.WriteLine("Book updated successfully!");
                }
                break;
            case 3:
                Console.WriteLine("Enter new genre: ");
                string genre = Console.ReadLine();
                using (var context = new Context())
                {
                    var books = from b in context.Books
                        where b.Id == id
                        select b;
                    
                    foreach (var book in books)
                    {
                        book.Genre = genre;
                    }
                    
                    context.SaveChanges();
                    Console.WriteLine("Book updated successfully!");
                }
                break;
            case 4:
                Console.WriteLine("Enter new year published: ");
                int yearPublished = int.Parse(Console.ReadLine());
                using (var context = new Context())
                {
                    var books = from b in context.Books
                        where b.Id == id
                        select b;
                    
                    foreach (var book in books)
                    {
                        book.YearPublished = yearPublished;
                    }
                    
                    context.SaveChanges();
                    Console.WriteLine("Book updated successfully!");
                }
                break;
            case 5:
                Console.WriteLine("Enter new copies available: ");
                int copiesAvailable = int.Parse(Console.ReadLine());
                using (var context = new Context())
                {
                    var books = from b in context.Books
                        where b.Id == id
                        select b;
                    
                    foreach (var book in books)
                    {
                        book.CopiesAvailable = copiesAvailable;
                    }
                    
                    context.SaveChanges();
                    Console.WriteLine("Book updated successfully!");
                }
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
    
    public void DeleteBook()
    {
        Console.WriteLine("Enter book id to delete: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new Context())
        {
            var books = from b in context.Books
                where b.Id == id
                    select b;
            
            foreach (var book in books)
            {
                context.Books.Remove(book);
            }
            
            context.SaveChanges();
            Console.WriteLine("Book deleted successfully!");
        }
    }
    
}