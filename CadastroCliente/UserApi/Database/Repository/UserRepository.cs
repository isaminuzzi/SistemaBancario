using Domain;
using Domain.Interface.Repository;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<UserEntity> AddAsync(UserEntity user)
    {
        _context.User.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public Task<bool> ExistsByCpfAsync(string cpf)
    {
        return _context.User.AnyAsync(x => x.Cpf.Equals(cpf));
    }
}