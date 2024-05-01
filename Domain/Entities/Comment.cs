namespace Domain.Entities;
public class Comment : BaseEntity
{
    public string CommenterName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;


    public Post Post { get; set; } = null!;
    public int Post_id { get; set; }
    public int User_id { get; set; }
}
