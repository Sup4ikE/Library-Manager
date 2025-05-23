﻿using Library_Manager;
using Library_Manager.TablesContexts;

class Program
{
    static void Main(string[] args)
    {
        BooksContext booksContext = new BooksContext();
        UsersContexts usersContexts = new UsersContexts();
        BorrowsContext borrowsContext = new BorrowsContext();
        
        using (var context = new Context())
        {
            Console.WriteLine("Welcome to the Library Manager!");
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("Books:");
                Console.WriteLine("1. Books list");
                Console.WriteLine("2. Add book");
                Console.WriteLine("3. Update info about book");
                Console.WriteLine("4. Delete book");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Users:");
                Console.WriteLine("5. Users list");
                Console.WriteLine("6. Register new user");
                Console.WriteLine("7. Update info about user");
                Console.WriteLine("8. Delete user");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Books Operations:");
                Console.WriteLine("9.  Borrow a book to user");
                Console.WriteLine("10. Return a book to library");
                Console.WriteLine("11. View all history of borrows books");
                Console.WriteLine("----------------------------");
                Console.WriteLine("0. Exit");
                int a = int.Parse(Console.ReadLine());

                switch (a)
                {
                    case 1:
                        booksContext.ListBooks();
                        break;
                    case 2:
                        booksContext.AddBook();
                        break;
                    case 3:
                        booksContext.UpdateBook();
                        break;
                    case 4:
                        booksContext.DeleteBook();
                        break;
                    case 5:
                        usersContexts.ListUsers();
                        break;
                    case 6:
                        usersContexts.AddUser();
                        break;
                    case 7:
                        usersContexts.UpdateUser();
                        break;
                    case 8:
                        usersContexts.DeleteUser();
                        break;
                    case 9:
                        borrowsContext.borrowBook();
                        break;
                    case 10:
                        borrowsContext.returnBook();
                        break;
                    case 11:
                        borrowsContext.listBorrows();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}