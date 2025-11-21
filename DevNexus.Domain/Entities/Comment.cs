using DevNexus.Domain.Common;
using DevNexus.Domain.Entities.Identity;

namespace DevNexus.Domain.Entities;

public class Comment : Entity<int>
{
    public string Text { get; set; } = string.Empty;
    public DateTime PostedAt { get; set; } = DateTime.UtcNow;

    public int PostId { get; set; }
    public Post? Post { get; set; }

    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
}