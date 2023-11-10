namespace ApiBalada.Models;

public class Pedido
{
    public int Id { get; set; }
    public string? CodigoProduto { get; set; } = string.Empty;
    public int? QuantidadeDoPedido { get; set; } = default;
    public DateTime? Data { get; set; } = default;
    public int ComandaId { get; set; } = default;
}