namespace Domain.Interface.Repository;

public interface ICreditCardRepository
{
    Task<CreditCardEntity> AddAsync(CreditCardEntity creditCard);
}