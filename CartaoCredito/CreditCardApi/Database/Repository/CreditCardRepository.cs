using Domain;
using Domain.Interface.Repository;
using Infra.Context;

namespace Infra.Repository;

public class CreditCardRepository : ICreditCardRepository
{
    private readonly ApplicationDbContext _context;

    public CreditCardRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreditCardEntity> AddAsync(CreditCardEntity creditCard)
    {
        _context.CreditCard.Add(creditCard);

        await _context.SaveChangesAsync();

        return creditCard;
    }
}