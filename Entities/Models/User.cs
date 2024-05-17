namespace CareApi.Entities.Models;

public class User {
    public Guid Id { get; set; }
    public required string username { get; set; }
    public required string password { get; set; }
}
