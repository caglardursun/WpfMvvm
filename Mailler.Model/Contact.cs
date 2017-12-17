using System.ComponentModel.DataAnnotations;

namespace Mailler.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string EMail { get; set; }
    }
}
