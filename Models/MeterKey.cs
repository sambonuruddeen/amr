using Microsoft.AspNetCore.Identity;

namespace jed_amr.Models;

public class MeterKey
{
    public int Id { get; set; }
    public string LogicalDeviceName { get; set; }
    public string AuthenticationKey { get; set; }
    public string EncryptionKey { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }

}
