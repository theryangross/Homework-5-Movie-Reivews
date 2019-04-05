using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RazorPagesMovie.Models
{
    public class Review
    {
        public int ReviewID { get; set;} [Required]
        public int Score { get; set;} 
        [Range(1,5)]
        public int ID {get; set;} //FK
        public Movie Movie {get; set;} //Nav prop
    }
}