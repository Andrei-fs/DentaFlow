using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentaFlow.Models
{
    public class Appointment
    {   
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string AppointmentHour { get; set; }
    
        //doctor
        
       
        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId {get; set;}

        public Doctor Doctor { get; set; }

        //pacient
        
        [Required]
        [ForeignKey("Pacient")]
        public int PacientId {get;set;}

         public Pacient Pacient { get; set; }

      

    }
}