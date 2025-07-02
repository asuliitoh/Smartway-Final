namespace SmartwayFinal.Models;
using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
    [Required]
    public long Id { get; set; }
    
    [Required]
    public string? Password { get; set; }
}