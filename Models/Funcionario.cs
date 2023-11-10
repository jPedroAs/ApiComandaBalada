using ApiBalada.Enum;

namespace ApiBalada.Models;

public class Funcionario
{
    public int Id { get; set; }
    public string Identificador { get; set; } = String.Empty;
    public string Nome { get; set; } = String.Empty;
    public RoleEnum Role { get; set; } = default;
    public string Senha { get; set; } = string.Empty;
}