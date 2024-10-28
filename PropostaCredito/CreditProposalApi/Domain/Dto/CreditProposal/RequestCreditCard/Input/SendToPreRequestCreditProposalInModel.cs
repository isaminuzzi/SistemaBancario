using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.CreditCard;

public class SendToPreRequestCreditProposalInModel
{
    [Required(ErrorMessage = "RequestCreditCardProposalId is required.")]
    public Guid RequestCreditCardProposalId { get; set; }
    
    [Required(ErrorMessage = "Agency is required.")]
    public long Agency { get; set; }

    [Required(ErrorMessage = "Account is required.")]
    public long Account { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    public string UserCpf { get; set; }
}