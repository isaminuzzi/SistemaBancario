using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.CreditCard;

public class SendToRequestCreditCardInModel
{
    [Required(ErrorMessage = "RequestCreditCardId is required.")]
    public Guid RequestCreditCardId { get; set; }
    
    [Required(ErrorMessage = "Agency is required.")]
    public long Agency { get; set; }

    [Required(ErrorMessage = "Account is required.")]
    public long Account { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "IsVirtual is required.")]
    public bool IsVirtual { get; set; }
    
    [Required(ErrorMessage = "Card number is required.")]
    public string CardNumber { get; set; }

    [Required(ErrorMessage = "Card holder name is required.")]
    public string CardHolderName { get; set; }

    [Required(ErrorMessage = "Expiration date is required.")]
    public DateTime ExpirationDate { get; set; }

    [Required(ErrorMessage = "CVV is required.")]
    public int CVV { get; set; }
}