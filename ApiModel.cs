using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class ApiModel
{
    public ApiModel(){

    }
    public string Id {get;set;}
    [Required]
    [MaxLength(20)]
    [Description("Tên là gì?")]
    [DefaultValue("OK")]
    public string Name {get;set;}
    public string Status {get;set;}
}
public enum ApiEnum
{
    Start,
    Done,
    Failed
}