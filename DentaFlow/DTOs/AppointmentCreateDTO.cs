using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentaFlow.DTOs
{
    public class AppointmentCreateDTO {
        
        [Required]
        public string AppointmentHour { get; set; }

        [Required]
        public int DoctorId {get; set;}
        [Required]
        public int PacientId {get;set;}


        //aceleasi propietati ca in model.

        // [Required]
        // [Column(TypeName="nvarchar(100)")]
        // public string DoctorFirstName {get;set;}
        // [Required]
        // [Column(TypeName="nvarchar(100)")]
        // public string DoctorLastName {get;set;}
        // [Required]
        // [Column(TypeName="nvarchar(100)")]
        // public string PacientFirstName { get; set; } 
        // [Required]
        // [Column(TypeName="nvarchar(100)")]
        // public string PacientLastName { get; set; } 
        
        // public string DoctorPhoneNumber { get; set; }     
                
    }
}