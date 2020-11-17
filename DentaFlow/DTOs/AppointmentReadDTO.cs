using System.ComponentModel.DataAnnotations;

namespace DentaFlow.DTOs
{
    public class AppointmentReadDTO
    {
         //need to map this
        public int AppointmentId { get; set; }
        public string AppointmentHour { get; set; }

       
        public string DoctorName {get;set;}

        public string DoctorPhoneNumber { get; set; }
        public string PacientName { get; set; } 
    }
}