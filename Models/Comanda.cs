namespace ApiBalada.Models;

public class Comanda
{
//     public Comanda(string comanda, bool status, DateTime? data)
//     {
//         Cmd = comanda;
//         Status = status;
//         Data = data;
//     }

    public int Id { get; set; } = default;
    public string Cmd { get; set; } = string.Empty;
    public bool Status { get; set; } = default;
    public DateTime? Data { get; set; } = default;
}