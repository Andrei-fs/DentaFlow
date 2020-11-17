using System.Collections.Generic;
using DentaFlow.Models;
using DentaFlow.ResourceParameters;

namespace DentaFlow.Data
{
    public interface  IDoctorRepo
    {
        //save changes
        bool SaveChanges();

        //get a list of doctors
        IEnumerable<Doctor> GetAllDoctors();
        
        //get one doctor by id
        Doctor GetDoctorById(int id);

        //create a doctor 
        void CreateDoctor(Doctor doctor);

        //update a doctor
        void UpdateDoctor( Doctor doctor);

        //delete a doctor  
        void DeleteDoctor(Doctor doctor);
        IEnumerable<Appointment> GetAppointments(int doctorId);

        Appointment GetAppointmentById(int appointmentId,int doctorId);

        bool DoctorExists(int doctorId);

         IEnumerable<Doctor> GetAllDoctors(EntityResourceParameters doctorResourceParameters);
         IEnumerable<DoctorPacient> GetPacients(int doctorId);
    }
}