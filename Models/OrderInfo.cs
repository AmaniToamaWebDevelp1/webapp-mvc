using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webapp_mvc.Models
{
    public class OrderInfo
    {
         [DisplayName("Parents Phone")]
        public string? ParentsPhone{get; set;}
        [DisplayName("Credit Card Number")]
        public string? CreditCardNum{get; set;}

        [Key]
        public int Id{get; set;}

        [Required]
        public int productId{get; set;}
        public string Name{get; set;}
        public string Email{get; set;}
        [MinLength(7)]
        public string Phone{get; set;}
        
        [Range(14,90)]
        public int Age{get;set;}
        public string Governorate{get; set;}
        public string City{get; set;}
        [DisplayName("Address Line")]
        public string AddressLine{get; set;}
        [Range(1,100)]
       
        public int Quantity{get; set;}
        [DisplayName("Way of payment")]
        public string WayOfPayment{get; set;}
       
      

    }
}