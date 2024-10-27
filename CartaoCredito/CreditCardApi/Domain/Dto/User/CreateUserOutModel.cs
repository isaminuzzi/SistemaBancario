namespace Domain.Dto.User;

public class CreateUserOutModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public long Balance { get; set; }

}