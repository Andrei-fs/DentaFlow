

namespace DentaFlow.Models

{
    public class DoctorPacient
    {
        
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PacientId { get; set; }

        public Pacient Pacient { get; set; }
    }    
}