using System.ComponentModel.DataAnnotations;
using Domain.Dto.User;
using MediatR;

namespace Application.UseCase.User.Create;

public class CreateUserRequest : IRequest<CreateUserResponse>
{
    [Required(ErrorMessage = "Data is required")]
    public CreateUserInModel Data { get; set; }
}