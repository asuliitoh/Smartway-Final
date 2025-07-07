namespace SmartwayFinal.Models;

public class PasswordRequest
{

    public string? Id { get; set; }
    
    public string? Password { get; set; }
    public string? NewPassword { get; set; }
    public string? ConfirmPassword { get; set; }

    public string? EquipoId { get; set; }
}