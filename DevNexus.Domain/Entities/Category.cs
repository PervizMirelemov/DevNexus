using DevNexus.Domain.Common;

namespace DevNexus.Domain.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Post>? Posts { get; set; }
}