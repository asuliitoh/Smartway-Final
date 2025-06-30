namespace SmartwayFinal.Models;
using System.ComponentModel.DataAnnotations;

public class AgenteLoginDTO
{
    [Required]
    public long Id { get; set; }
    
    [Required]
    public string? Password { get; set; }
}