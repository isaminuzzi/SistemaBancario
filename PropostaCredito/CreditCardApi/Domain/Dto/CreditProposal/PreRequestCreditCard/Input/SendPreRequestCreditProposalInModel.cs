using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.CreditCard.PreRequestCreditCard.Input;

public class SendPreRequestCreditProposalInModel
{
    [Required(ErrorMessage = "Agency is required.")]
    public long Agency { get; set; }

    [Required(ErrorMessage = "Account is required.")]
    public long Account { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    public string UserCpf { get; set; }
}