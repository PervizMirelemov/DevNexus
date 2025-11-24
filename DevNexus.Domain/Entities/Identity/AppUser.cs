using DevNexus.Domain.Common;

namespace DevNexus.Domain.Entities.Identity;

public class AppUser : Entity<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; }
    public string NormalizedUserName { get; set; }
    public string PasswordHash { get; set; }
}