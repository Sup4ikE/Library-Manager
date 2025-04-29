namespace Library_Manager;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int YearPublished { get; set; }
    public string CopiesAvailable {get; set;} 
    
    public ICollection<Borrow> Borrows { get; set; }
}