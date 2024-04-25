namespace Domain.Entities;
public class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int Created { get; set; }

    public Author Author { get; set; } = new();
    public int Author_id { get; set; }
    public int Likes_id { get; set; }
    public Likes Likes { get; set; } = new();
    public int Comment_id { get; set; }
    public List<Comment> Comments { get; set; } = new();
}
