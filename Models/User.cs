using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]  // Primary Key annotation
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string PhoneNumber { get; set; }
}
