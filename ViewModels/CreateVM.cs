using System.ComponentModel.DataAnnotations;

namespace Internalization.Models;
public class CreateVM {
    [Display(Name = "Name")]
    public string Name{get;set;}
}