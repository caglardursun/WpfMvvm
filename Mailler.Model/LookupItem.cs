using System.ComponentModel.DataAnnotations;

namespace Mailler.Model
{
    public class LookUpItem
    {
        [Key]
        public int Id { get; set; }

        public string DisplayMember { get; set; }
    }
}
