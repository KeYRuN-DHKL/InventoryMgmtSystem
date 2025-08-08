namespace InventoryMgmtSystem.Entity;

public class Purchase
{
    public Guid Id { get; set; }
    public DateOnly Tdate { get; set; }
    public Guid StakeHolderId { get; set; }
    public virtual StakeHolder StakeHolder { get; set; }
    public string InvoiceNo { get; set; }
    public decimal Amount { get; set; }
    public decimal TaxableAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public string? Remark { get; set; }
    public decimal Total => Amount + TaxAmount;
}