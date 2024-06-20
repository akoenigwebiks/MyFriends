using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyFriends.Models
{
    public class FriendModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; } = "";

        [Display(Name = "שם משפחה")]
        public string LastName { get; set; } = "";

        [Display(Name = "שם מלא"), NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
        //public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "כתובת מייל"), EmailAddress(ErrorMessage = "כתובת מייל אינה נכונה")]
        public string EmailAddress { get; set; } = string.Empty;

        [Display(Name = "מספר טלפון"), Phone]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "הוספת תמונה"), NotMapped]
        public IFormFile SetImage
        {
            get { return null; }
            set
            {
                if (value == null) return;
                AddImage(value);
            }
        }


        public List<Image> Images { get; set; }

        public FriendModel()
        {
            Images = new();
        }

        public void AddImage(IFormFile image)
        {
            MemoryStream stream = new();
            image.CopyTo(stream);
            AddImage(stream.ToArray());
        }
        public void AddImage(Image image) { Images.Add(image); }
        public void AddImage(byte[] image)
        {
            Images.Add(new Image { MyIamge = image, Friend = this });
        }
    }
}
