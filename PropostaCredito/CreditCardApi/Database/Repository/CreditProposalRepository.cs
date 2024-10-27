using Domain;
using Domain.Interface.Repository;
using Infra.Context;

namespace Infra.Repository;

public class CreditProposalRepository : ICreditProposalRepository
{
    private readonly ApplicationDbContext _context;

    public CreditProposalRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreditProposalEntity> AddAsync(CreditProposalEntity creditProposalEntity)
    {
        _context.CreditProposal.Add(creditProposalEntity);

        await _context.SaveChangesAsync();

        return creditProposalEntity;
    }
}