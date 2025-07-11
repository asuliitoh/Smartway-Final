namespace SmartwayFinal.Models;
using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
   
    public required int Id { get; set; }
    
    public string? Password { get; set; }
}