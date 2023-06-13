using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace webapp_mvc.Models 
{
    public class Admin {
    [Key]
    public int userId{get; set;}
    [Required]
    [DisplayName("Username")]
    public string username {get; set;}
    [MinLength(8)]
    [DisplayName("Password")]
    public string pwd{get; set;}

}}