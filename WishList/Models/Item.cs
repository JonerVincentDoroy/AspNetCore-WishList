using System.ComponentModel.DataAnnotations; //to add attributes to a property

namespace WishList.Models
{
    public class Item
    {
        public int Id { get; set; }

        //added attributes to Description property
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

    }
}
