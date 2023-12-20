namespace jed_amr.Models;

public class MeterReading
{
    public string Id { get; set; }
    public datetime Date { get; set; }
    public string ConnectionSessionId { get; set; }
    // public string DeviceId { get; set; }
    public string InterfaceClass { get; set; }
    public string LogicalDeviceName { get; set; }
    public string Data { get; set; }
    public string Unit { get; set; }
    
}
