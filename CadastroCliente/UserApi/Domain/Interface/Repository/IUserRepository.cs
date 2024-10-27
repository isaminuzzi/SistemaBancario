namespace Domain.Interface.Repository;

public interface IUserRepository
{
    Task<UserEntity> AddAsync(UserEntity user);
    Task<bool> ExistsByCpfAsync(string cpf);
}