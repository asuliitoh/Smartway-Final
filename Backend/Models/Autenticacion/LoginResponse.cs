namespace SmartwayFinal.Models;

public class LoginResponse
{

    public required int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Token { get; set; }

}