namespace Domain.Entities;
public class Likes : BaseEntity
{
    public int Counter { get; set; }
    public int Post_id { get; set; }
    public int User_id { get; set; }
}
