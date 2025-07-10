namespace SmartwayFinal.Models;
using System.ComponentModel.DataAnnotations;

public class RegistroRequest
{
    
    public required string Nombre { get; set; }
    
    public required string Apellidos { get; set; }
    
    public required string Password { get; set; }
}