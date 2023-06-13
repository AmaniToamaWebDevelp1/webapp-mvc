using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace  webapp_mvc.Models{
 public class SuperAdmin
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DisplayName("Username")]
    public string username { get; set; }

    [DisplayName("Password")]
    public string pwd { get; set; }
}

}
