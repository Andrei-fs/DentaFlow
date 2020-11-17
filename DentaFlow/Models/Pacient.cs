using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentaFlow.Models
{
    public class Pacient
    {
        [Key]
        public int PacientId { get; set; }
        [Required]
        [Column(TypeName="nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName="nvarchar(100)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName="nvarchar(30)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName="nvarchar(10)")]
        public string Mobile { get; set; }
    
        public List<Appointment> Appointments { get; set; }

        public List<DoctorPacient> DoctorsPacients { get; set; } 
       


    }
}