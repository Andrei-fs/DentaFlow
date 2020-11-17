using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentaFlow.Models
{
    public class Doctor{


        [Key]
        public int DoctorId { get; set; }
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
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Mobile { get; set; } 
        
        [Column(TypeName = "nvarchar(300)")]
        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName="nvarchar(10)")]
        public string Availability { get; set; }

        public List<Appointment> Appointments { get; set; }

        public List<DoctorPacient> DoctorsPacients { get; set; } 
        
        

       
    }
}