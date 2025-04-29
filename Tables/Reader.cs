namespace Library_Manager;

public class Reader
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate {get; set;}
    
    public ICollection<Borrow> Borrows { get; set; }
}