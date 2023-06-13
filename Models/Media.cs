using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_mvc.Models 
{
    public class Meida
    {
    [Key]
    public int Id { get; set; }

    [DisplayName("File Name")]
    public string Filename { get; set; }
    [DisplayName("File Type")]
    public string FileType { get; set; }
    [DisplayName("Upload your file")]
     public byte[] FileData { get; set; }
    [NotMapped]
    public IFormFile File { get; set; }   
     [Required]
    [DisplayName("Product Name")]
    [MaxLength(50)]
    public string ProductName {get; set;}
    [DisplayName("Product Description")]
    [MaxLength(200)]
    public string ProductDesc{get; set;}
    [Range(1.0,100.65)]
    public double Price{get; set;}
    public DateTime CreatedDate = DateTime.Now;
    public string Gender { get; set; }
     



    } 
    // public enum Gender {
    //     Non,
    //     Girl,
    //     Boy
    // }
}   