using System;
using System.ComponentModel.DataAnnotations;

namespace CBelt.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get;set; }
        [Required(ErrorMessage = "is required.")]
        public string CommentBody { get; set; }
        public int UserId { get;set; }
        public int ActivityId { get;set; }
        public User Commenter { get;set; }
        public Activ ActivCommented { get;set; }
        public DateTime CreatedAt { get;set; } = DateTime.Now;
        public DateTime UpdatedAt { get;set; } = DateTime.Now;
    }
}