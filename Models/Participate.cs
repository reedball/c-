using System;
using System.ComponentModel.DataAnnotations;

namespace CBelt.Models
{
    public class Participate
    {
        [Key]
        public int ParticipateId { get;set; }
        public int UserId { get;set; }
        public int ActivityId { get;set; }
        public User Participator { get;set; }
        public Activ SpecificActiv { get;set; }

        public DateTime CreatedAt { get;set; } = DateTime.Now;
        public DateTime UpdatedAt { get;set; } = DateTime.Now;
    }
}