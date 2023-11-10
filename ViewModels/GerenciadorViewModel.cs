using System.ComponentModel.DataAnnotations;

namespace ApiBalada.ViewModels;

public class ComandaViewModel
{
    [Required]
    public string Comanda { get; set; }

}

public class ComandaPedidoViewModel
{
    [Required]
    public string id { get; set; }   

    public List<ComandaPedido> Comanda { get; set; }
}

public class ComandaHistoricoViewModel
{
     public int Id { get; set; }
    public DateTime Data { get; set; }
    
}

public class ComandaPedido
{
    public string Comanda { get; set; }
    public string Codigo { get; set; }
    public int QtPedido { get; set; }
}
