using System.ComponentModel.DataAnnotations;

namespace SpendSmart;

public class Expense
{
    int Id {get; set;}
    decimal Value {get; set;}
    
    [Required]
    string? Description {get; set;}
}
