using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webapp_mvc.Models
{
    public class Permission
    {
        [Key]
        public int Id{get; set;}
        [DisplayName("Add item")]
        public bool addMedia{get;set;}
        [DisplayName("Edit item")]
        public bool editMedi{get; set;}
        [DisplayName("Delete item")]
        public bool deleteMedia{get; set;}
        [DisplayName("Access to clients info")]
        public bool accessToClientsInfo{get; set;}


    }
}