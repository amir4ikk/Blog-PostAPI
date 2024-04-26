namespace Domain.Entities;
public class Author : BaseEntity
{
    public string Name { get; set; } = "";
    public string Year { get; set; } = "";

    public Post Post { get; set; } = new();
    public int Post_id { get; set; }
}
