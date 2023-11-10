using System.ComponentModel.DataAnnotations;
using ApiBalada.Enum;

namespace ApiBalada.ViewModels;


public class BebidaViewlModel
{

    [Required]
    public string CodigoProduto { get; set; }
     [Required]
    public decimal Valor { get; set; }
}