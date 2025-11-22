using DevNexus.Domain.Common;
using DevNexus.Domain.Enums;

namespace DevNexus.Domain.Entities;

public class Post : Entity<int>
{
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int Views { get; set; }
    public int CategoryId { get; set; }

    public string TitleAz { get; set; }
    public string TitleEn { get; set; }
    public string TitleRu { get; set; }

    // Navigation
    public Category? Category { get; set; }
    public ICollection<PostTranslation>? Translations { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}

public class PostTranslation : Entity<int>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty; // HTML
    public string ShortDescription { get; set; } = string.Empty;
    public Lang Lang { get; set; }

    public int PostId { get; set; }
    public Post? Post { get; set; }
}