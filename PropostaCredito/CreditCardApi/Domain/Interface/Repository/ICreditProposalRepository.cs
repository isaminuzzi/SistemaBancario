namespace Domain.Interface.Repository;

public interface ICreditProposalRepository
{
    Task<CreditProposalEntity> AddAsync(CreditProposalEntity creditProposalEntity);
}