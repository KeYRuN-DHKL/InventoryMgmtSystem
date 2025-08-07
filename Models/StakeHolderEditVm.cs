namespace InventoryMgmtSystem.Models;

public class StakeHolderEditVm
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public string Vat { get; set; }
    public string Type { get; set; }
    public bool IsActive { get; set; } = true;
}