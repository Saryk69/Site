using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainWeb.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Value")]
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Range must be between 1-100!!!")]
        public int DisplayOrder { get; set; }

        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
