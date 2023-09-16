using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos.Users;

public class CreateUserDto
{

    [Required(ErrorMessage = "Nome Obrigatório")]
    [MinLength(2, ErrorMessage = "Mínimo 2 letras")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Sobrenome Obrigatório")]
    [MinLength(2, ErrorMessage = "Mínimo 2 letras")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
    public string Password { get; set; }

    [Required]
    public string Roles { get; set; }
}
