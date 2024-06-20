using System.ComponentModel.DataAnnotations;

namespace MyFriends.Models
{
    public class Image
    {
        [Key]
        public int ID { get; set; }
        public FriendModel Friend { get; set; }

        [Display(Name = "תמונה")]
        public byte[] MyIamge { get; set; }

    }
}