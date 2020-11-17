using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DentaFlow.Models;

namespace DentaFlow.DTOs
{
    public class DoctorCreateDTO{
      
        [Required]
        [Column]
        public int Rating { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        [Required]
        public string FirstName { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        [Required]
        public string LastName { get; set; }
          [Column(TypeName = "nvarchar(30)")]
        [Required]
        public string Location { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        
        public string Cabinet { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Mobile { get; set; } 
        
        [Column(TypeName = "nvarchar(300)")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName="nvarchar")]
        public string Availability { get; set; }
    }
}