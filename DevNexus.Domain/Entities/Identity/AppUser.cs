using Microsoft.AspNetCore.Identity;

namespace DevNexus.Domain.Entities.Identity;

public class AppUser : IdentityUser<Guid>
{
    public string FullName { get; set; } = string.Empty;
}