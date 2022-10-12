namespace ForumApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PostViewModel
    {
        [UIHint("hidden")]
        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Полето {0} трябва да е между {2} и {1} символа")]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(1500, MinimumLength = 30, ErrorMessage = "Полето {0} трябва да е между {2} и {1} символа")]
        public string Content { get; set; }
    }
}
