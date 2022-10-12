namespace ForumApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PostViewModel : AddPostViewModel
    {
        public int Id { get; set; }
    }
}
