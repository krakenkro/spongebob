using System.ComponentModel.DataAnnotations;

namespace SpongeBob.Models
{
    public class SpongeBobFriends
    {
        public Guid Id { get; set; } //Id первый первичный ключ 

        [StringLength(60)]
        [Required]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Fill the form")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Fill Job")]
        [Display(Name = "Job")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Fill JobPlace")]
        [Display(Name = "JobPlace")]
        public string JobPlace { get; set; }

        [Required(ErrorMessage = "Fill SkinCollor")]
        [Display(Name = "SkinCollor")]
        public string SkinCollor { get; set; }
        public int HomeId { get; set; }
    }
}
