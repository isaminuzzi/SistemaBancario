using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enum;

namespace Domain;

public class CreditProposalEntity : AuditableEntity
{
    [ForeignKey("UserId")] 
    public Guid UserId { get; set; }

    [Required]
    public long Limit { get; set; }
    
    [Required]
    public double InterestRate { get; set; }
    
    [Required]
    public CreditProposalStatusEnum Status { get; set; }
    
    [Required]
    public long Agency { get; set; }

    [Required(ErrorMessage = "Account is required.")]
    public long Account { get; set; }
}