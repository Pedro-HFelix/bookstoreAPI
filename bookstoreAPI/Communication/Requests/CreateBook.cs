using bookstoreAPI.genderType;

namespace bookstoreAPI.Communication.Requests;

public class CreateBook
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required GenderType Gender { get; set; }
    public required double Price { get; set; }
    public int? StockQuantity { get; set; } 
}