using System.ComponentModel.DataAnnotations;
using ApiBalada.Enum;

namespace ApiBalada.ViewModels;

public class ContaViewModel
{
    public string Identificador { get; set; }
    public string Senha { get; set; }
}

public class CadastroViewlModel
{
    [Required]
    public string Identificador { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public RoleEnum Role { get; set; }
    [Required]
    public string Senha { get; set; }
}