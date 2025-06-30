namespace SmartwayFinal.Models;
using System.ComponentModel.DataAnnotations;

public class AgenteRegistroDTO
{
    [Required]
    public string? Nombre { get; set; }
    
    [Required]
    public string? Apellidos { get; set; }
    
    [Required]
    public string? Password { get; set; }
}