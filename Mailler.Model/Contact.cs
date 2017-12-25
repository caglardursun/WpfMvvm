using System.ComponentModel.DataAnnotations;

namespace Mailler.Model
{
    public class Contact
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Adı")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Display(Name = "Soyadı")]
        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        [Display(Name = "EPosta")]
        public string EMail { get; set; }        
    }
}
