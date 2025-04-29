namespace Library_Manager;

public class Borrow
{
    public int Id { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; }

    public int ReaderId { get; set; }
    public Reader Reader { get; set; }

    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
}