using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.User;

public class CreateUserInModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Cpf is required")]
    public string Cpf { get; set; }
    
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "Account is required")]
    public string Account { get; set; }
    
    [Required(ErrorMessage = "Agency is required")]
    public string Agency { get; set; }
}