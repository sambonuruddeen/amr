using Microsoft.AspNetCore.Identity;

namespace jed_amr.Models;

public class Meter
{
    public int Id { get; set; }
    public string LogicalDeviceName { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public bool Status { get; set; }
    public DateTime LastReading { get; set; }

}
