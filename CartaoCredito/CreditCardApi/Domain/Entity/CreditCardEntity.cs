using Domain.Common;

namespace Domain;

public class CreditCardEntity : AuditableEntity
{
    public long Agency { get; set; }
    public long Account { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int CVV { get; set; }
    public int Quantity { get; set; }
    public bool IsVirtual { get; set; }
    public bool IsBlocked { get; set; }
}