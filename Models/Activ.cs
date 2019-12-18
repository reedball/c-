using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBelt.Models
{
    public class Activ
    {
        [Key]
        public int ActivityId { get;set; }

        [Required(ErrorMessage = "is required.")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "is required.")]
        [FutureDate(ErrorMessage="Date should be in the future.")]
        [DataType(DataType.Date)]
        public DateTime Date { get;set; }

        [Required(ErrorMessage = "is required.")]
        public string Description { get;set; }

        [Required(ErrorMessage = "is required.")]
        [DataType(DataType.Time)]
        
        public TimeSpan Time {get;set;}

        [Required(ErrorMessage = "is required.")]
        public int Duration {get;set;}

        [Required(ErrorMessage = "is required.")]
        public string Selection {get;set;}
        public string Location {get;set;}
        public string Lat {get;set;}
        public string Long {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int UserId { get;set; }
        public User Creator { get;set; }
        public List<Participate> GuestList { get;set; }
        public List<Comment> Comments { get;set; }
    }
}