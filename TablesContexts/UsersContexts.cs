namespace Library_Manager.TablesContexts;

public class UsersContexts
{
    public void ListUsers()
    {
        using (var context = new Context())
        {
            var users = from u in context.Readers
                select u;

            foreach (var user in users)
            {
                Console.WriteLine(user.Id);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.RegistrationDate);
                Console.WriteLine("-------------------------");
            }

            if (users.Count() == 0)
            {
                Console.WriteLine("No users found!");
            }
        }
    }

    public void AddUser()
    {
        using (var context = new Context())
        {
            Console.WriteLine("Enter user name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter user email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter user registration date (yyyy-MM-dd): ");
            DateTime registrationDate = DateTime.Parse(Console.ReadLine());
            
            registrationDate = DateTime.SpecifyKind(registrationDate, DateTimeKind.Utc);

            var user = new Reader
            {
                Name = name,
                Email = email,
                RegistrationDate = registrationDate
            };

            context.Readers.Add(user);
            context.SaveChanges();
            Console.WriteLine("User added successfully!");
        }
    }

    public void UpdateUser()
    {
        Console.WriteLine("Enter user id to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("What you want to change: ");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Email");
        Console.WriteLine("3. Registration date");
        Console.WriteLine("0. Exit");
        int a = int.Parse(Console.ReadLine());
        
        switch (a)
        {
            case 1:
                Console.WriteLine("Enter new name: ");
                string name = Console.ReadLine();

                using (var context = new Context())
                {
                    var users = from u in context.Readers
                        where u.Id == id
                        select u;
                    foreach (var user in users)
                    {
                        user.Name = name;
                    }
                    context.SaveChanges();
                    Console.WriteLine("User updated successfully!");
                }
                break;
            case 2:
                Console.WriteLine("Enter new email: ");
                string email = Console.ReadLine();

                using (var context = new Context())
                {
                    var users = from u in context.Readers
                        where u.Id == id
                        select u;
                    foreach (var user in users)
                    {
                        user.Email = email;
                    }
                    context.SaveChanges();
                    Console.WriteLine("User updated successfully!");
                }
                break;
            case 3:
                Console.WriteLine("Enter new user registration date (yyyy-MM-dd): ");
                DateTime registrationDate = DateTime.Parse(Console.ReadLine());
            
                registrationDate = DateTime.SpecifyKind(registrationDate, DateTimeKind.Utc);
                using (var context = new Context())
                {
                    var users = from u in context.Readers
                        where u.Id == id
                        select u;
                    foreach (var user in users)
                    {
                        user.RegistrationDate = registrationDate;
                        
                    }
                    context.SaveChanges();
                    Console.WriteLine("User updated successfully!");
                }
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
    
    public void DeleteUser()
    {
        Console.WriteLine("Enter user id to delete: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new Context())
        {
            var users = from u in context.Readers
                where u.Id == id
                select u;
            
            foreach (var user in users)
            {
                context.Readers.Remove(user);
            }
            context.SaveChanges();
            Console.WriteLine("User deleted successfully!");
        }
    }
}