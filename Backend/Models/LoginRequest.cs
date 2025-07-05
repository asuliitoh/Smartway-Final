namespace SmartwayFinal.Models;
using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
   
    public required string Id { get; set; }
    
    public string? Password { get; set; }
}