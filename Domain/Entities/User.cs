using Domain.Enums;

namespace Domain.Entities;
public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone_Number { get; set; } = string.Empty;
    public Roles Role { get; set; }
    public bool IsVerified { get; set; } = false;
}
