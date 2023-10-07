using System;
using System.ComponentModel.DataAnnotations;

namespace LindnerAirlines.Models
{
    public class Assist
    {
        public int Id { get; set; }

        [Display(Name = "Assist Description")]
        public string? RequestDescription { get; set; }


        [Display(Name = "Assist Type")]
        public string? AssistType { get; set; }

        // Navigation property for related entities, e.g., User
        public User? User { get; set; }
        public int? UserId { get; set; }
    }

}

