using System.ComponentModel;

namespace Domain.Enum;

public enum CreditProposalStatusEnum
{
    [DefaultValue("Aprovado")]
    Approved = 1,
    [DefaultValue("Rejeitado")]
    Rejected = 2,
    [DefaultValue("Pendente")]
    Pending = 3
}