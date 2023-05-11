using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

public class ApiModel2
{
    public ApiModel2(){

    }
    public string Id {get;set;}
    [Required]
    [MaxLength(20)]
    [Description("Tên là 2?")]
    [DefaultValue("OK")]
    public string Name {get;set;}
    public string Status {get;set;} 
}
