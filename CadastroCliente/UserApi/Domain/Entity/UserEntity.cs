using Domain.Common;

namespace Domain;

public class UserEntity : AuditableEntity
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public long Balance { get; set; }
}