using Microsoft.AspNetCore.Identity;

namespace jed_amr.Models;

public class AmrUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => FirstName + " " + LastName;
    public string? Recovery { get; set; }
}
