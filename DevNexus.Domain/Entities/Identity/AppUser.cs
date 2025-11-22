using DevNexus.Domain.Common;

namespace DevNexus.Domain.Entities.Identity;

public class AppUser : Entity<Guid>
{
    public string FullName { get; set; } = string.Empty;
}